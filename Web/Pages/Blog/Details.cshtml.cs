using Application.Models;
using Application.Models.Enums;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IBlogPostLikeService _blogPostLikeService;
        private readonly IBlogPostCommentService _blogPostCommentService;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public AddBlogPostCommentModel Comment { get; set; }
        [BindProperty]
        public Guid BlogPostId { get; set; }

        public DetailsBlogPostModel BlogPost { get; set; }

        public int LikesCount { get; set; }
        public bool Liked { get; set; }

        public DetailsModel(IBlogPostService blogPostService, IBlogPostLikeService blogPostLikeService, IBlogPostCommentService blogPostCommentService, UserManager<IdentityUser> userManager)
        {
            _blogPostService = blogPostService;
            _blogPostLikeService = blogPostLikeService;
            _blogPostCommentService = blogPostCommentService;
            _userManager = userManager;
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
                BlogPostId = BlogPost.Id;

                var likesResponse = await _blogPostLikeService.GetLikesCountByBlogPostId(response.Data.Id);

                LikesCount = likesResponse.Data;

                var userId = _userManager.GetUserId(User);

                if (!string.IsNullOrWhiteSpace(userId))
                {
                    var likedResponse = await _blogPostLikeService.CheckUserLiked(response.Data.Id, Guid.Parse(userId));
                    Liked = likedResponse.Data;
                }

                return Page();
            }

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync(string urlHandle)
        {
            var userId = _userManager.GetUserId(User);

            Comment.BlogPostId = BlogPostId;
            Comment.UserId = Guid.Parse(userId);

            var response = await _blogPostCommentService.AddComment(Comment);

            if (response.AlertType != MessageAlertType.None)
            {
                TempData["Alert"] = AlertModel.GetJsonString(response.Message, response.AlertType);
            }

            return RedirectToPage("/blog/Details", new { urlHandle = urlHandle });
        }
    }
}
