using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Todo.DAL.Repository
{
    public class BaseContextRepository : BaseRepository
    {
        protected TodoContext Context { get; }

        protected BaseContextRepository(TodoContext context, IConfiguration configuration, ILogger<BaseContextRepository> logger) : base(configuration, logger)
        {
            Context = context;
        }
    }
}