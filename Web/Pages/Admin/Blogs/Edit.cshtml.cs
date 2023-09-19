using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Models.Enums;
using System;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using AutoMapper;

namespace Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IMapper _mapper;

        [BindProperty]
        public EditBlogPostModel EditBlogPostModel { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public EditModel(IBlogPostService blogPostService, IMapper mapper)
        {
            _blogPostService = blogPostService;
            _mapper = mapper;
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
            if (!string.IsNullOrWhiteSpace(Tags))
            {
                var tags = JsonSerializer.Deserialize<List<TagInputModel>>(Tags);
                EditBlogPostModel.Tags = _mapper.Map<List<Tag>>(tags);
            }

            var response = await _blogPostService.EditBlogPost(EditBlogPostModel);

            ModelState.Clear();

            if (response.ValidationErrors.Any())
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError("EditBlogPostModel." + error.Property, error.Message);
                }
            }

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