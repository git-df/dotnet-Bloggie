using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            CreateMap<BlogPost, EditBlogPostModel>().ReverseMap();
        }
    }
}
