using Application.Contracts.Persistence;
using Application.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTest.Mocks.Repository
{
    public class BlogPostRepositoryMocks
    {
        public static Mock<IBlogPostRepository> GetBlogPostRepository()
        {
            var mockBlogPostRepository = new Mock<IBlogPostRepository>();

            //mockBlogPostRepository.Setup(repo => repo.Get)

            return mockBlogPostRepository;
        }
    }
}
