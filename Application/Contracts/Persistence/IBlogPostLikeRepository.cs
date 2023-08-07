using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IBlogPostLikeRepository : IBaseRepository<BlogPostLike>
    {
        Task<int> GetBlogPostLikesCount(Guid blogPostId);
        Task<int> GetUserBlogPostLikesCount(Guid blogPostId, Guid userId);
    }
}
