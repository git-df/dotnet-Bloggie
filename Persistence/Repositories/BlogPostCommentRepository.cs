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
    public class BlogPostCommentRepository : BaseRepository<BlogPostComment>, IBlogPostCommentRepository
    {
        public BlogPostCommentRepository(BloggieDbContext bloggieDbContext) : base(bloggieDbContext)
        {
        }

        public async Task<List<BlogPostComment>> GetComentsByBlogPostId(Guid blogPostId)
        {
            return await _dbContext.blogPostComments.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}