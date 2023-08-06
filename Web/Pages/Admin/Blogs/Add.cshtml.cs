using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        [BindProperty]
        public AddBlogPostModel AddBlogPostModel { get; set; } = new AddBlogPostModel() { PublishedDate = DateTime.UtcNow.Date };

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public AddModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public void OnGet()
        {
            var a = User.Identity.Name;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (Tags != null && Tags.Any())
            {
                AddBlogPostModel.Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag { Name = x.Trim() }));

            }

            var response = await _blogPostService.AddBlogPost(AddBlogPostModel);

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            if (response.Success)
            {
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();
        }
    }
}
