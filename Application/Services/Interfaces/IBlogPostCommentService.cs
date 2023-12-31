﻿using Application.Models;
using Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IBlogPostCommentService
    {
        Task<BaseResponse> AddComment(AddBlogPostCommentModel model);
        Task<BaseResponse<List<BlogPostCommentOnList>>> GetCommentsByPost(Guid blogPostId);
    }
}
