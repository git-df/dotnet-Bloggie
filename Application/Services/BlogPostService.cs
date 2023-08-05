using Application.Contracts.Persistence;
using Application.Models;
using Application.Models.Responses;
using Application.Services.Interfaces;
using Application.Models.Validators;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Enums;

namespace Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<BaseResponse> AddBlogPost(AddBlogPostModel model)
        {
            var validator = new AddBlogPostValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return new BaseResponse(false);
            }

            if (model.PublishedDate < DateTime.UtcNow.Date)
            {
                return new BaseResponse(false, "The date cannot be past", MessageAlertType.Warning);
            }

            var newBlogPost = await _blogPostRepository.Add(_mapper.Map<BlogPost>(model));

            if (newBlogPost == null)
            {
                return new BaseResponse(false, "Something went wrong", MessageAlertType.Error);
            }

            return new BaseResponse("Added blog post", MessageAlertType.Success);
        }

        public async Task<BaseResponse> DeleteBlogPost(Guid id)
        {
            await _blogPostRepository.DeleteById(id);

            return new BaseResponse("Deleted blog post", MessageAlertType.Success);
        }

        public async Task<BaseResponse> EditBlogPost(EditBlogPostModel model)
        {
            var validator = new EditBlogPostValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return new BaseResponse(false);
            }

            if (model.PublishedDate < DateTime.UtcNow.Date)
            {
                return new BaseResponse(false, "The date cannot be past", MessageAlertType.Warning);
            }

            var editedBlogPost = await _blogPostRepository.Update(_mapper.Map<BlogPost>(model));

            if (editedBlogPost == null)
            {
                return new BaseResponse(false, "Something went wrong", MessageAlertType.Error);
            }

            return new BaseResponse("Edited blog post", MessageAlertType.Success);
        }

        public async Task<BaseResponse<List<ListBlogPostModel>>> GetAllBlogPosts()
        {
            var blogPostList = await _blogPostRepository.GetAll();

            if (blogPostList == null || blogPostList.Count == 0)
            {
                return new BaseResponse<List<ListBlogPostModel>>(false, "No blog posts", MessageAlertType.Warning);
            }

            return new BaseResponse<List<ListBlogPostModel>>(_mapper.Map<List<ListBlogPostModel>>(blogPostList));
        }

        public async Task<BaseResponse<DetailsBlogPostModel>> GetBlogPostDetails(string urlHandle)
        {
            var blogPost = await _blogPostRepository.GetByUrlHandle(urlHandle);

            if (blogPost == null)
            {
                return new BaseResponse<DetailsBlogPostModel>(false, "Blog Post not exist", MessageAlertType.Error);
            }

            return new BaseResponse<DetailsBlogPostModel>(_mapper.Map<DetailsBlogPostModel>(blogPost));
        }

        public async Task<BaseResponse<EditBlogPostModel>> GetBlogPostToEdit(Guid model)
        {
            var existBlogPost = await _blogPostRepository.GetById(model);

            if (existBlogPost == null)
            {
                return new BaseResponse<EditBlogPostModel>(false, "Blog Post not exist", MessageAlertType.Error);
            }

            return new BaseResponse<EditBlogPostModel>(_mapper.Map<EditBlogPostModel>(existBlogPost));
        }

        public async Task<BaseResponse<List<HomeBlogPostModel>>> GetHomeBlogPosts()
        {
            var blogs = await _blogPostRepository.GetAll();

            if (blogs == null)
            {
                return new BaseResponse<List<HomeBlogPostModel>>(false, "Something went wrong", MessageAlertType.Error);
            }

            if (!blogs.Any())
            {
                return new BaseResponse<List<HomeBlogPostModel>>(false, "No blog posts", MessageAlertType.Warning);
            }

            return new BaseResponse<List<HomeBlogPostModel>>(_mapper.Map<List<HomeBlogPostModel>>(blogs));
        }
    }
}
