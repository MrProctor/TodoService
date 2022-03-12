using System.Threading.Tasks;

namespace Todo.DAL.Repository
{
    /// <summary>
    /// Base interface for repositories which implements CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">entity model</typeparam>
    /// <typeparam name="TKey">primary key</typeparam>
    public interface ICrudRepository<TEntity, TKey>
    {
        /// <summary>
        /// Save entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>Updated item</returns>
        Task<TEntity> SaveAsync(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id">update entity ID</param>
        /// <param name="entity">Entity to update</param>
        /// <returns>Updated item</returns>
        Task<TEntity> UpdateAsync(TKey id, TEntity entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">deleting item id</param>
        /// <returns>no return</returns>
        Task<bool> DeleteAsync(TKey id);
    }
}