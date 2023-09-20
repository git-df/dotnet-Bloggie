using Application.Contracts.Persistence;
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

            // TODO

            return _mockRepository;
        }
    }
}

//GetBlogPostLikesCount
//    GetUserBlogPostLikesCount
//    Add