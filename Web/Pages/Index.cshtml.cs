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
        public IBlogPostService _blogPostService { get; }

        [BindProperty]
        public List<HomeBlogPostModel> Blogs { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var response = await _blogPostService.GetHomeBlogPosts();

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            if (response.Success)
            {
                Blogs = response.Data;
            }

            return Page();
        }
    }
}