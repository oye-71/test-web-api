using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.DataManagement.Interfacage.DbEntities;

namespace TestWebApi.DataManagement.Interfacage.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        public Task<TEntity> GetById(Guid id);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task Add(TEntity entity);
        public Task AddRange(IEnumerable<TEntity> entities);
        public Task Update(TEntity entity);
        public Task AddOrUpdate(TEntity entity);
        public Task Delete(TEntity entity);
        public Task DeleteRange(IEnumerable<TEntity> entities);
    }
}
