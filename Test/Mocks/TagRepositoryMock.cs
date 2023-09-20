using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Mocks.Data;

namespace Test.Mocks
{
    public class TagRepositoryMock
    {
        public static Mock<ITagRepository> GetRepository()
        {
            var _context = new ContextMock();
            var _mockRepository = new Mock<ITagRepository>();

            _mockRepository.Setup(repo => repo.GetAllDistinctByName()).ReturnsAsync(
                () =>
                {
                    var tags = _context.Tags.Where(x => x.BlogPost.Visible && x.BlogPost.PublishedDate <= DateTime.UtcNow).ToList();

                    tags = tags.DistinctBy(x => x.Name.ToLower()).ToList();

                    return _context.Tags.ToList();
                });

            return _mockRepository;
        }
    }
}
