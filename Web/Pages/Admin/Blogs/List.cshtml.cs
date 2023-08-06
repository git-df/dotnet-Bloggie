using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        [BindProperty]
        public List<ListBlogPostModel> ListBlogPostModels { get; set; }

        public ListModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var response = await _blogPostService.GetAllBlogPosts();

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            if (response.Success)
            {
                ListBlogPostModels = response.Data;
            }

            return Page();
        }
    }
}
