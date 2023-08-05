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
            var tags = await _dbContext.Tags.ToListAsync();


            return tags.DistinctBy(x => x.Name.ToLower()).ToList();
        }
    }
}
