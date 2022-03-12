using System;
using System.Threading.Tasks;
using Todo.DAL.Repository;
using Microsoft.Extensions.Logging;

namespace Todo.BL
{
    /// <summary>
    /// Base class for services which implements CRUD operations
    /// </summary>
    public abstract class BaseEntityCrudService<TEntity, TKey, TRepository> : BaseEntityService<TRepository>, IBaseEntityCrudService<TEntity, TKey, TRepository>
        where TRepository : ICrudRepository<TEntity, TKey>
    {

        #region Constructors

        protected BaseEntityCrudService(TRepository repository, ILogger<BaseEntityCrudService<TEntity, TKey, TRepository>> logger)
            : base(repository, logger)
        {
        }

        #endregion

        #region Methods

        public virtual async Task<TEntity> SaveAsync(TEntity entity)
        {
            await ValidateBeforeSave(entity);
            return await Repository.SaveAsync(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TKey id, TEntity entity)
        {
            await ValidateBeforeSave(entity);
            return await Repository.UpdateAsync(id, entity);
        }

        public virtual Task<bool> DeleteAsync(TKey id)
        {
            return Repository.DeleteAsync(id);
        }

        /// <summary>
        /// Validate entity before add
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual Task ValidateBeforeSave(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return Task.FromResult(default(object));
        }

        #endregion
    }
}
