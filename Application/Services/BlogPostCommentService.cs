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
    public class BlogPostCommentService : IBlogPostCommentService
    {
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;
        private readonly IMapper _mapper;

        public BlogPostCommentService(IBlogPostCommentRepository blogPostCommentRepository, IMapper mapper)
        {
            _blogPostCommentRepository = blogPostCommentRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> AddComment(AddBlogPostCommentModel model)
        {
            var blogPostComment = _mapper.Map<BlogPostComment>(model);
            blogPostComment.DateAdded = DateTime.UtcNow;

            var newComment = await _blogPostCommentRepository.Add(blogPostComment);

            if (newComment == null)
            {
                return new BaseResponse(false, "Something went wrong", MessageAlertType.Error);
            }

            return new BaseResponse("Comment added", MessageAlertType.Success);
        }
    }
}
