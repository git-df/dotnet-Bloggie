using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

        [BindProperty]
        public AddBlogPostModel AddBlogPostModel { get; set; } = new AddBlogPostModel() { PublishedDate = DateTime.UtcNow.Date };

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public AddModel(IBlogPostService blogPostService, IMapper mapper)
        {
            _blogPostService = blogPostService;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var a = User.Identity.Name;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(Tags))
            {
                var tags = JsonSerializer.Deserialize<List<TagInputModel>>(Tags);
                AddBlogPostModel.Tags = _mapper.Map<List<Tag>>(tags);
            }

            var response = await _blogPostService.AddBlogPost(AddBlogPostModel);

            ModelState.Clear();

            if (response.ValidationErrors.Any())
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError("AddBlogPostModel." + error.Property, error.Message);
                }
            }

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
