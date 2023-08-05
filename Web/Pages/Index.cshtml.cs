using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITagService _tagService;
        public readonly IBlogPostService _blogPostService;

        [BindProperty]
        public List<HomeBlogPostModel> Blogs { get; set; }

        [BindProperty]
        public List<string> Tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostService blogPostService, ITagService tagService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
            _tagService = tagService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var responseTags = await _tagService.GetTagsNames();

            if (responseTags.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(responseTags.Message, responseTags.AlertType);
            }

            if (responseTags.Success)
            {
                Tags = responseTags.Data;
            }

            var responsePosts = await _blogPostService.GetHomeBlogPosts();

            if (responsePosts.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(responsePosts.Message, responsePosts.AlertType);
            }

            if (responsePosts.Success)
            {
                Blogs = responsePosts.Data;
            }

            return Page();
        }
    }
}