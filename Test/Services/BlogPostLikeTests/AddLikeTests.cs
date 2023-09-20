using Application.Models;
using Application.Services;
using Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.BlogPostLikeTests
{
    public class AddLikeTests : BaseTest
    {
        [Fact]
        public async Task BlogPostLike_Add()
        {
            var _blogPostLikeService = new BlogPostLikeService(_blogPostLikeRepository.Object, _mapper);

            var newLike = new AddBlogPostLikeModel()
            {
                BlogPostId = new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"),
                UserId = Guid.NewGuid(),
            };

            var response = await _blogPostLikeService.AddLike(newLike);

            response.Success.ShouldBeTrue();
            response.Data.ShouldBeOfType<BlogPostLike>();
            response.Data.BlogPostId.ShouldBe(newLike.BlogPostId);
            response.Data.UserId.ShouldBe(newLike.UserId);
        }

        [Fact]
        public async Task BlogPostLike_Add_BadBlogPostId()
        {
            var _blogPostLikeService = new BlogPostLikeService(_blogPostLikeRepository.Object, _mapper);

            var newLike = new AddBlogPostLikeModel()
            {
                BlogPostId = new Guid("00000000-0000-0000-0000-000000000000"),
                UserId = Guid.NewGuid(),
            };

            var response = await _blogPostLikeService.AddLike(newLike);

            response.Success.ShouldBeFalse();
            response.Data.ShouldBeNull();
        }
    }
}
