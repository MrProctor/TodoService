using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Todo.DAL.Repository
{
    public class BaseRepository
    {
        protected string ConnectionString { get; }
        protected ILogger<BaseRepository> Logger { get; }

        public BaseRepository(IConfiguration configuration, ILogger<BaseRepository> logger)
        {
            Logger = logger;
            ConnectionString = configuration.GetConnectionString("Citygate");
        }

        protected SqlConnection GetSqlConnection()
        {
            return new(ConnectionString);
        }
    }
}