using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(BloggieDbContext bloggieDbContext) : base(bloggieDbContext)
        {
        }

        public async Task<BlogPost?> GetByUrlHandle(string urlHandle)
        {
            return await _dbContext.BlogPosts.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }
    }
}
