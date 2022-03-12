using Microsoft.Extensions.Logging;

namespace Todo.BL
{
    /// <summary>
    /// Base service to manipulate with <see>
    ///     <cref>BaseEntity{T}</cref>
    /// </see>
    /// </summary>
    public abstract class BaseEntityService<TRepository> : IBaseEntityService<TRepository>
    {
        #region Fields

        protected readonly TRepository Repository;
        protected ILogger<BaseEntityService<TRepository>> Logger { get; }

        #endregion

        #region Constructors

        protected BaseEntityService(TRepository repository, ILogger<BaseEntityService<TRepository>> logger)
        {
            Repository = repository;
            Logger = logger;
        }

        #endregion
    }
}