using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BloggieDbContext _dbContext;

        public BaseRepository(BloggieDbContext bloggieDbContext)
        {
            _dbContext = bloggieDbContext;
        }

        public async Task<T?> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteById(Guid id)
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRange(List<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbContext.Set<T>()
                .FindAsync(id);
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbContext.Set<T>()
                .FindAsync(id);
        }

        public async Task<T?> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
