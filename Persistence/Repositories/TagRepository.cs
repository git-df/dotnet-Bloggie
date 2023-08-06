using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(BloggieDbContext bloggieDbContext) : base(bloggieDbContext)
        {
        }

        public async Task<List<Tag>> GetAllDistinctByName()
        {
            var tags = await _dbContext.Tags.Include(x => x.BlogPost).Where(x => x.BlogPost.Visible && x.BlogPost.PublishedDate <= DateTime.UtcNow).ToListAsync();

            tags = tags.DistinctBy(x => x.Name.ToLower()).ToList();

            return tags;
        }
    }
}
