using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        [BindProperty]
        public DetailsBlogPostModel BlogPost { get; set; }

        public DetailsModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> OnGetAsync(string urlHandle)
        {
            var response = await _blogPostService.GetBlogPostDetails(urlHandle);

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            if (response.Success)
            {
                BlogPost = response.Data;

                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
