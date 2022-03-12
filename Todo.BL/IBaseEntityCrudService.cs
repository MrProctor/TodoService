using System.Threading.Tasks;

namespace Todo.BL
{
    /// <summary>
    /// Base interface for services which implements CRUD operations
    /// </summary>
    /// <typeparam name="TEntity"> entity </typeparam>
    /// <typeparam name="TKey"> key </typeparam>
    /// <typeparam name="TRepository"> repository </typeparam>
    public interface IBaseEntityCrudService<TEntity, in TKey, TRepository> : IBaseEntityService<TRepository>
    {
        /// <summary>
        /// Update existing entity in DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> SaveAsync(TEntity entity);

        /// <summary>
        /// Update existing entity in DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TKey id, TEntity entity);

        /// <summary>
        /// Delete entity in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TKey id);
    }
}
