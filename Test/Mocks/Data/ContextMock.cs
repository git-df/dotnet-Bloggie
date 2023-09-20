using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Test.Mocks.Data
{
    public class ContextMock
    {
        public List<BlogPost> BlogPosts { get; set; }
        public List<BlogPostComment> BlogPostComments { get; set; }
        public List<BlogPostLike> BlogPostLikes { get; set; }
        public List<Tag> Tags { get; set; }

        public ContextMock()
        {
            BlogPosts = new List<BlogPost>()
            {
                new BlogPost()
                {
                    Id = new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"),
                    Heading = "Heading test1",
                    PageTitle = "PageTitle test1",
                    Content = "Content test1",
                    ShortDescription = "ShortDescription test1",
                    FeaturedImageUrl = "FeaturedImageUrl test1",
                    UrlHandle = "UrlHandle test1",
                    PublishedDate = DateTime.UtcNow.AddDays(-1),
                    Author = "Author test1",
                    Visible = true,
                    Tags = new List<Tag>(),
                    Likes = new List<BlogPostLike>(),
                    Comments = new List<BlogPostComment>(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPost()
                {
                    Id = new Guid("d4f18f99-8f3f-4aab-b0bc-5686420cfeb2"),
                    Heading = "Heading test2",
                    PageTitle = "PageTitle test2",
                    Content = "Content test2",
                    ShortDescription = "ShortDescription test2",
                    FeaturedImageUrl = "FeaturedImageUrl test2",
                    UrlHandle = "UrlHandle test2",
                    PublishedDate = DateTime.UtcNow.AddDays(-3),
                    Author = "Author test2",
                    Visible = false,
                    Tags = new List<Tag>(),
                    Likes = new List<BlogPostLike>(),
                    Comments = new List<BlogPostComment>(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPost()
                {
                    Id = new Guid("58d1876d-ce34-414d-8093-68182c4fd2a6"),
                    Heading = "Heading test3",
                    PageTitle = "PageTitle test3",
                    Content = "Content test3",
                    ShortDescription = "ShortDescription test3",
                    FeaturedImageUrl = "FeaturedImageUrl test3",
                    UrlHandle = "UrlHandle test3",
                    PublishedDate = DateTime.UtcNow.AddDays(-10),
                    Author = "Author test3",
                    Visible = true,
                    Tags = new List<Tag>(),
                    Likes = new List<BlogPostLike>(),
                    Comments = new List<BlogPostComment>(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPost()
                {
                    Id = new Guid("9addd338-b2e1-46ad-8796-c09b73ccc928"),
                    Heading = "Heading test4",
                    PageTitle = "PageTitle test4",
                    Content = "Content test4",
                    ShortDescription = "ShortDescription test4",
                    FeaturedImageUrl = "FeaturedImageUrl test4",
                    UrlHandle = "UrlHandle test4",
                    PublishedDate = DateTime.UtcNow.AddDays(5),
                    Author = "Author test4",
                    Visible = true,
                    Tags = new List<Tag>(),
                    Likes = new List<BlogPostLike>(),
                    Comments = new List<BlogPostComment>(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPost()
                {
                    Id = new Guid("e6a4733d-70be-4957-bc50-ab3f24d44efb"),
                    Heading = "Heading test5",
                    PageTitle = "PageTitle test5",
                    Content = "Content test5",
                    ShortDescription = "ShortDescription test5",
                    FeaturedImageUrl = "FeaturedImageUrl test5",
                    UrlHandle = "UrlHandle test5",
                    PublishedDate = DateTime.UtcNow.AddDays(-15),
                    Author = "Author test5",
                    Visible = true,
                    Tags = new List<Tag>(),
                    Likes = new List<BlogPostLike>(),
                    Comments = new List<BlogPostComment>(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                }
            };

            Tags = new List<Tag>()
            {
                new Tag()
                {
                    Id = new Guid("8aea34e4-ce18-4fcc-9b31-ad45745b242f"),
                    Name = "Tag1 test1",
                    BlogPostId = new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"),
                    BlogPost = BlogPosts.FirstOrDefault(x => x.Id == new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5")) ?? new BlogPost(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("0915b89b-1225-4f48-84e9-4aae26198e57"),
                    Name = "Tag1 test1",
                    BlogPostId = new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5"),
                    BlogPost = BlogPosts.FirstOrDefault(x => x.Id == new Guid("f8298318-cd0a-4071-ba98-d4a6aa9059c5")) ?? new BlogPost(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("63b001ca-22dc-44d3-b3dd-74159d43c332"),
                    Name = "Tag1 test1",
                    BlogPostId = new Guid("d4f18f99-8f3f-4aab-b0bc-5686420cfeb2"),
                    BlogPost = BlogPosts.FirstOrDefault(x => x.Id == new Guid("d4f18f99-8f3f-4aab-b0bc-5686420cfeb2")) ?? new BlogPost(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("bdb46144-fbf1-4779-86b2-458dd0e14b47"),
                    Name = "Tag1 test1",
                    BlogPostId = new Guid("9addd338-b2e1-46ad-8796-c09b73ccc928"),
                    BlogPost = BlogPosts.FirstOrDefault(x => x.Id == new Guid("9addd338-b2e1-46ad-8796-c09b73ccc928")) ?? new BlogPost(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("c391492b-f623-4016-8bbc-d2a2b6ecade0"),
                    Name = "Tag1 test1",
                    BlogPostId = new Guid("e6a4733d-70be-4957-bc50-ab3f24d44efb"),
                    BlogPost = BlogPosts.FirstOrDefault(x => x.Id == new Guid("e6a4733d-70be-4957-bc50-ab3f24d44efb")) ?? new BlogPost(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                }
            };

            foreach (var tag in Tags)
            {
                BlogPosts.Find(x => x.Id == tag.BlogPostId)?.Tags.Add(tag);
            }
        }
    }
}