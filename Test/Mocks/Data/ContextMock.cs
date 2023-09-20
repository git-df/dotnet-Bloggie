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
            List<MockUser> mockUsers = new List<MockUser>()
            {
                new MockUser("ee9cd4d7-fb53-4d24-a145-b7962561f1c6", "Czesław", "Majchrzak"),
                new MockUser("6184b1d8-f807-4ebe-8b29-ff4abca1a6e4", "Edyta", "Stefańska"),
                new MockUser("39aed296-43cd-4370-9524-29f1b45e6ca2", "Dorian", "Marek"),
                new MockUser("a839a211-8682-4195-82cc-9da6171a587d", "Bruno", "Lipiński"),
                new MockUser("364868f6-457b-407a-875d-f36afba3fb20", "Grzegorz", "Dąbrowski")
            };

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
                    Author = mockUsers[0].FirstName + " " + mockUsers[0].LastName,
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
                    Author = mockUsers[1].FirstName + " " + mockUsers[1].LastName,
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
                    Author = mockUsers[2].FirstName + " " + mockUsers[2].LastName,
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
                    Author = mockUsers[3].FirstName + " " + mockUsers[3].LastName,
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
                    Author = mockUsers[4].FirstName + " " + mockUsers[4].LastName,
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
                    BlogPostId = BlogPosts[0].Id,
                    BlogPost = BlogPosts[0],
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("0915b89b-1225-4f48-84e9-4aae26198e57"),
                    Name = "Tag1 test1",
                    BlogPostId = BlogPosts[0].Id,
                    BlogPost = BlogPosts[0],
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("63b001ca-22dc-44d3-b3dd-74159d43c332"),
                    Name = "Tag1 test1",
                    BlogPostId = BlogPosts[1].Id,
                    BlogPost = BlogPosts[1],
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("bdb46144-fbf1-4779-86b2-458dd0e14b47"),
                    Name = "Tag1 test1",
                    BlogPostId = BlogPosts[3].Id,
                    BlogPost = BlogPosts[3],
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new Tag()
                {
                    Id = new Guid("c391492b-f623-4016-8bbc-d2a2b6ecade0"),
                    Name = "Tag1 test1",
                    BlogPostId = BlogPosts[4].Id,
                    BlogPost = BlogPosts[4],
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

            BlogPostLikes = new List<BlogPostLike>()
            {
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[0].Id,
                    UserId = mockUsers[0].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[0].Id,
                    UserId = mockUsers[1].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[0].Id,
                    UserId = mockUsers[2].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[1].Id,
                    UserId = mockUsers[3].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[1].Id,
                    UserId = mockUsers[4].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[4].Id,
                    UserId = mockUsers[0].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[4].Id,
                    UserId = mockUsers[1].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[4].Id,
                    UserId = mockUsers[2].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[4].Id,
                    UserId = mockUsers[3].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                },
                new BlogPostLike()
                {
                    Id = new Guid(),
                    BlogPostId = BlogPosts[4].Id,
                    UserId = mockUsers[4].Id,
                    Created = DateTime.UtcNow,
                    CreatedBy = "UnitTests",
                    Updated = DateTime.UtcNow,
                    UpdatedBy = "UnitTests"
                }
            };

            foreach (var like in BlogPostLikes)
            {
                BlogPosts.Find(x => x.Id == like.BlogPostId)?.Likes.Add(like);
            }
        }
    }

    public struct MockUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public MockUser(string id, string firstName, string lastName)
        {
            Id = new Guid(id);
            FirstName = firstName;
            LastName = lastName;
        }
    }
}