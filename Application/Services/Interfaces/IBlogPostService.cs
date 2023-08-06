using Application.Models;
using Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IBlogPostService
    {
        Task<BaseResponse> AddBlogPost(AddBlogPostModel model);
        Task<BaseResponse> EditBlogPost(EditBlogPostModel model);
        Task<BaseResponse> DeleteBlogPost(Guid id);
        Task<BaseResponse<EditBlogPostModel>> GetBlogPostToEdit(Guid model);
        Task<BaseResponse<List<ListBlogPostModel>>> GetAllBlogPosts();
        Task<BaseResponse<List<HomeBlogPostModel>>> GetHomeBlogPosts(string? tag);
        Task<BaseResponse<DetailsBlogPostModel>> GetBlogPostDetails(string urlHandle);
    }
}
