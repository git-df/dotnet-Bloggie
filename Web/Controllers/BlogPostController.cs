using Application.Models;
using Application.Services.Interfaces;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostLikeService _blogPostLikeService;

        public BlogPostController(IBlogPostLikeService blogPostLikeService)
        {
            _blogPostLikeService = blogPostLikeService;
        }

        [Route("AddLike")]
        [HttpPut]
        public async Task<IActionResult> AddLike([FromBody] AddBlogPostLikeModel request)
        {
            var response = await _blogPostLikeService.AddLike(request);

            if (response != null && response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Route("GetLikesCount/{blogPostId:Guid}")]
        [HttpGet]
        public async Task<IActionResult> GetLikesCount([FromRoute] Guid blogPostId)
        {
            var response = await _blogPostLikeService.GetLikesCountByBlogPostId(blogPostId);

            if (response != null && response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
