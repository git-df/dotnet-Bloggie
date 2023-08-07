using Application.Services.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;

namespace Persistence.Data
{
    public class BloggieDbContext : IdentityDbContext
    {
        private readonly IUserContextProvider _userContextProvider;

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLikes { get; set; }
        public DbSet<BlogPostComment> blogPostComments { get; set; }

        public BloggieDbContext(DbContextOptions options, IUserContextProvider userContextProvider) : base(options)
        {
            _userContextProvider = userContextProvider;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _userContextProvider.GetCurrentUserName();
                        break;
                    case EntityState.Modified:
                        entry.Entity.Updated = DateTime.Now;
                        entry.Entity.UpdatedBy = _userContextProvider.GetCurrentUserName();
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = "e3acd725-762a-4834-99d6-c3183665b071",
                    ConcurrencyStamp = "e3acd725-762a-4834-99d6-c3183665b071"
                },
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = "f0eb3a97-7718-48a2-9352-b7583fb3d2c5",
                    ConcurrencyStamp = "f0eb3a97-7718-48a2-9352-b7583fb3d2c5"
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = "8e4cae41-eb7c-4bfc-b6c6-95424bb1ad46",
                    ConcurrencyStamp = "8e4cae41-eb7c-4bfc-b6c6-95424bb1ad46"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var sa = new IdentityUser()
            {
                Id = "ef95714c-0958-4770-99e6-91bf2f2aad68",
                UserName = "sa",
                Email = "sa@bloggie.pl",
                NormalizedUserName = "sa".ToUpper(),
                NormalizedEmail = "sa@bloggie.pl".ToUpper()
            };

            sa.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(sa, "Haslo123!");

            builder.Entity<IdentityUser>().HasData(sa);

            var saRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = "e3acd725-762a-4834-99d6-c3183665b071",
                    UserId = "ef95714c-0958-4770-99e6-91bf2f2aad68"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "f0eb3a97-7718-48a2-9352-b7583fb3d2c5",
                    UserId = "ef95714c-0958-4770-99e6-91bf2f2aad68"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "8e4cae41-eb7c-4bfc-b6c6-95424bb1ad46",
                    UserId = "ef95714c-0958-4770-99e6-91bf2f2aad68"
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(saRoles);
        }
    }
}
