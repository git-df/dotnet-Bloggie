using Application.Contracts.Persistence;
using Application.Mapper;
using Application.UnitTest.Mocks.Repository;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTest.Tests.BlogPostServiceTests
{
    public class AddBlogPostTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBlogPostRepository> _mockBlogPostRepository;

        public AddBlogPostTests()
        {
            _mockBlogPostRepository = BlogPostRepositoryMocks.GetBlogPostRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                }
            );

            _mapper = configurationProvider.CreateMapper();
        }


    }
}
