using Application.Contracts.Persistence;
using Application.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Mocks;

namespace Test
{
    public class BaseTest
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<ITagRepository> _tagRepository;
        protected readonly Mock<IBlogPostLikeRepository> _blogPostLikeRepository;

        public BaseTest()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

            _tagRepository = TagRepositoryMock.GetRepository();
            _blogPostLikeRepository = BlogPostLikeRepositoryMock.GetRepository();
        }
    }
}
