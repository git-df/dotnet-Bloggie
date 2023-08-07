using Application.Models;
using Application.Models.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IBlogPostLikeService
    {
        Task<BaseResponse<int>> GetLikesCountByBlogPostId(Guid blogPostId);
        Task<BaseResponse<bool>> CheckUserLiked(Guid blogPostId, Guid userId);
        Task<BaseResponse<BlogPostLike>> AddLike(AddBlogPostLikeModel model);
    }
}
