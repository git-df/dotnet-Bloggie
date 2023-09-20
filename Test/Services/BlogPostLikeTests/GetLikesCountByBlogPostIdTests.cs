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
    public class GetLikesCountByBlogPostIdTests : BaseTest
    {
        [Fact]
        public async Task BlogPostLike_GetLikesCountByBlogPostId()
        {
            var _blogPostLikeService = new BlogPostLikeService(_blogPostLikeRepository.Object, _mapper);

            var response = await _blogPostLikeService.GetLikesCountByBlogPostId(new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"));

            response.Success.ShouldBeTrue();
            response.Data.ShouldBe(3);

            await _blogPostLikeService.AddLike(new AddBlogPostLikeModel()
            {
                BlogPostId = new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"),
                UserId = new Guid()
            });

            response = await _blogPostLikeService.GetLikesCountByBlogPostId(new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"));

            response.Success.ShouldBeTrue();
            response.Data.ShouldBe(4);
        }

        [Fact]
        public async Task BlogPostLike_GetLikesCountByBlogPostId_BadBlogPostId()
        {
            var _blogPostLikeService = new BlogPostLikeService(_blogPostLikeRepository.Object, _mapper);

            var response = await _blogPostLikeService.GetLikesCountByBlogPostId(new Guid("00000000-0000-0000-0000-000000000000"));

            response.Success.ShouldBeTrue();
            response.Data.ShouldBe(0);

            await _blogPostLikeService.AddLike(new AddBlogPostLikeModel()
            {
                BlogPostId = new Guid("00000000-0000-0000-0000-000000000000"),
                UserId = new Guid()
            });

            response = await _blogPostLikeService.GetLikesCountByBlogPostId(new Guid("00000000-0000-0000-0000-000000000000"));

            response.Success.ShouldBeTrue();
            response.Data.ShouldBe(0);
        }
    }
}
