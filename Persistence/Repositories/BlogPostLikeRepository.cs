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
    public class BlogPostLikeRepository : BaseRepository<BlogPostLike>, IBlogPostLikeRepository
    {
        public BlogPostLikeRepository(BloggieDbContext bloggieDbContext) : base(bloggieDbContext)
        {
        }

        public async Task<int> GetBlogPostLikesCount(Guid blogPostId)
        {
            return await _dbContext.BlogPostLikes.CountAsync(x => x.BlogPostId == blogPostId);
        }

        public async Task<int> GetUserBlogPostLikesCount(Guid blogPostId, Guid userId)
        {
            return await _dbContext.BlogPostLikes.CountAsync(x => x.BlogPostId == blogPostId && x.UserId == userId);

        }
    }
}
