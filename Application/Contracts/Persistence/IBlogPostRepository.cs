using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IBlogPostRepository : IBaseRepository<BlogPost>
    {
        Task<BlogPost?> GetByUrlHandle(string urlHandle);
        Task<BlogPost?> GetByIdWithTags(Guid id);
        Task<List<BlogPost>> GetAllByTag(string? tag);
    }
}
