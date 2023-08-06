using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
