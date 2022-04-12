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
        /// <summary>
        /// Récupère une entité en fonction de son id.
        /// </summary>
        /// <returns></returns>
        public Task<TEntity> GetById(Guid id);

        /// <summary>
        /// Récupère toutes les entités d'une table.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Ajoute une nouvelle entité en base.
        /// </summary>
        /// <returns></returns>
        public Task Add(TEntity entity);

        /// <summary>
        /// Ajoute plusieurs nouvelles entités en base.
        /// </summary>
        /// <returns></returns>
        public Task AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Met a jour une entité déjà existante en base.
        /// </summary>
        /// <returns></returns>
        public Task Update(TEntity entity);

        /// <summary>
        /// Vérifie si l'entité à ajouter existe, si c'est le cas la met à jour, sinon l'ajoute.
        /// </summary>
        /// <returns></returns>
        public Task AddOrUpdate(TEntity entity);

        /// <summary>
        /// Supprime une entité en base.
        /// </summary>
        /// <returns></returns>
        public Task Delete(TEntity entity);

        /// <summary>
        /// Supprime plusieurs entités en base.
        /// </summary>
        /// <returns></returns>
        public Task DeleteRange(IEnumerable<TEntity> entities);
    }
}
