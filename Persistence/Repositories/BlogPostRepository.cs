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

        public async Task<List<BlogPost>> GetAllByTag(string? tag)
        {
            var blogPosts = _dbContext.BlogPosts.Where(x => x.Visible && x.PublishedDate <= DateTime.UtcNow);

            if (!string.IsNullOrWhiteSpace(tag))
            {
                blogPosts = blogPosts.Where(x => x.Tags.Where(x => x.Name == tag).Any());
            }

            return await blogPosts.ToListAsync();
        }

        public async Task<BlogPost?> GetByIdWithTags(Guid id)
        {
            return await _dbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandle(string urlHandle)
        {
            return await _dbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }
    }
}
