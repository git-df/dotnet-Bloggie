using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Mocks.Data;

namespace Test.Mocks
{
    public class BlogPostLikeRepositoryMock
    {
        public static Mock<IBlogPostLikeRepository> GetRepository()
        {
            var _context = new ContextMock();
            var _mockRepository = new Mock<IBlogPostLikeRepository>();

            _mockRepository.Setup(repo => repo.Add(It.IsAny<BlogPostLike>())).ReturnsAsync(
                (BlogPostLike like) =>
                {
                    var blogPost = _context.BlogPosts.Find(x => x.Id == like.BlogPostId);

                    if (blogPost != null)
                    {
                        _context.BlogPostLikes.Add(like);

                        blogPost.Likes.Add(like);

                        return like;
                    }

                    return null;
                });

            return _mockRepository;
        }
    }
}

//GetBlogPostLikesCount
//    GetUserBlogPostLikesCount
//    Add