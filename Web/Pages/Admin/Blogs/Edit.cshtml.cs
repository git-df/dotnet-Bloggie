using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Models.Enums;
using System;
using Domain.Entities;

namespace Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        [BindProperty]
        public EditBlogPostModel EditBlogPostModel { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public EditModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _blogPostService.GetBlogPostToEdit(id);

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            if (response.Success)
            {
                EditBlogPostModel = response.Data;

                if (EditBlogPostModel.Tags != null && EditBlogPostModel.Tags.Any())
                {
                    Tags = string.Join(',', EditBlogPostModel.Tags.Select(x => x.Name));
                }

                return Page();
            }

            return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (Tags != null && Tags.Any())
            {
                EditBlogPostModel.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag { Name = x.Trim() }));
            }

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