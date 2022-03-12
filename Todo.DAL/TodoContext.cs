using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todo.Models;

namespace Todo.DAL
{
    public class TodoContext : DbContext
    {
        private readonly IConfiguration _config;
        public TodoContext(IConfiguration config)
        {
            _config = config;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_config.GetConnectionString("Todo"));
        
        public virtual DbSet<TodoItem> TodoItems { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (ValidationException  ex)
            {
                var fullErrorMessage = string.Join("; ", ex.Message);

                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new ValidationException (exceptionMessage, ex);
            }
        }
    }
}