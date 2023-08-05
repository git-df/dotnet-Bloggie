using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Models.Enums;
using System;

namespace Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        [BindProperty]
        public EditBlogPostModel EditBlogPostModel { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        public EditModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _blogPostService.GetBlogPostToEdit(id);

            if (response.Success)
            {
                EditBlogPostModel = response.Data;

                return Page();
            }

            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostEdit()
        {
            var response = await _blogPostService.EditBlogPost(EditBlogPostModel);

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var response = await _blogPostService.DeleteBlogPost(EditBlogPostModel.Id);

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}