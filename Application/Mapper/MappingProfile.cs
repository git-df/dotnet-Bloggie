using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddBlogPostModel, BlogPost>();
            CreateMap<BlogPost, ListBlogPostModel>();
            CreateMap<BlogPost, HomeBlogPostModel>();
            CreateMap<BlogPost, DetailsBlogPostModel>();
            CreateMap<BlogPost, EditBlogPostModel>().ReverseMap();
            CreateMap<TagInputModel, Tag>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.value.ToUpper()))
                .ReverseMap();
            CreateMap<AddBlogPostLikeModel, BlogPostLike>();
            CreateMap<AddBlogPostCommentModel, BlogPostComment>();
            CreateMap<BlogPostComment, BlogPostCommentOnList>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.CreatedBy));
        }
    }
}
