using Application.Contracts.Persistence;
using Application.Models;
using Application.Models.Enums;
using Application.Models.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BlogPostLikeService : IBlogPostLikeService
    {
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        private readonly IMapper _mapper;

        public BlogPostLikeService(IBlogPostLikeRepository blogPostLikeRepository, IMapper mapper)
        {
            _blogPostLikeRepository = blogPostLikeRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BlogPostLike>> AddLike(AddBlogPostLikeModel model)
        {
            var newLike = await _blogPostLikeRepository.Add(_mapper.Map<BlogPostLike>(model));

            if (newLike == null)
            {
                return new BaseResponse<BlogPostLike>(false, "Something went wrong", MessageAlertType.Error);
            }

            return new BaseResponse<BlogPostLike>("Liked blog post", MessageAlertType.Success);
        }

        public async Task<BaseResponse<bool>> CheckUserLiked(Guid blogPostId, Guid userId)
        {
            var userLikes = await _blogPostLikeRepository.GetUserBlogPostLikesCount(blogPostId, userId);

            return new BaseResponse<bool>(data: (userLikes > 0));
        }

        public async Task<BaseResponse<int>> GetLikesCountByBlogPostId(Guid blogPostId)
        {
            var likesCount = await _blogPostLikeRepository.GetBlogPostLikesCount(blogPostId);

            return new BaseResponse<int>(likesCount);
        }
    }
}
