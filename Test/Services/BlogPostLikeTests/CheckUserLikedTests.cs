using Application.Models;
using Application.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.BlogPostLikeTests
{
    public class CheckUserLikedTests : BaseTest
    {
        [Fact]
        public async Task BlogPostLike_CheckUserLikedTests()
        {
            var _blogPostLikeService = new BlogPostLikeService(_blogPostLikeRepository.Object, _mapper);

            var userId = Guid.NewGuid();

            var response = await _blogPostLikeService.CheckUserLiked(new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"), userId);

            response.Success.ShouldBeTrue();
            response.Data.ShouldBeFalse();

            await _blogPostLikeService.AddLike(new AddBlogPostLikeModel()
            {
                BlogPostId = new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"),
                UserId = userId
            });

            response = await _blogPostLikeService.CheckUserLiked(new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"), userId);

            response.Success.ShouldBeTrue();
            response.Data.ShouldBeTrue();
        }


        [Fact]
        public async Task BlogPostLike_CheckUserLikedTests_BadBlogPostId()
        {
            var _blogPostLikeService = new BlogPostLikeService(_blogPostLikeRepository.Object, _mapper);

            var userId = Guid.NewGuid();

            var response = await _blogPostLikeService.CheckUserLiked(new Guid("00000000-cd0a-4071-ba98-d4a6aa9059c5"), userId);

            response.Success.ShouldBeTrue();
            response.Data.ShouldBeFalse();
        }
    }
}
