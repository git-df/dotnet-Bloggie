﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;
using Domain.Entities;

namespace Persistence
{
    public static class PersistenceInstallation
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloggieDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BloggieDbConnectionString")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IBlogPostLikeRepository, BlogPostLikeRepository>();
            services.AddScoped<IBlogPostCommentRepository, BlogPostCommentRepository>();

            return services;
        }
    }
}