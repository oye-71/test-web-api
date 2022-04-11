using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.DataManagement.Interfacage.DbEntities;
using TestWebApi.DataManagement.Interfacage.Repositories;

namespace TestWebApi.DataManagement.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ComputersDbContext _context;

        public BaseRepository(ComputersDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrUpdate(TEntity entity)
        {
            if (await GetById(entity.Id) != null)
            {
                await Update(entity);
            }
            else
            {
                await Add(entity);
            }
        }

        public async Task AddRange(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().AddRange(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
