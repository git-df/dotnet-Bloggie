using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;

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

            return services;
        }
    }
}