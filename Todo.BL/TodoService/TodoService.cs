using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Todo.DAL.TodoRepository;
using Todo.Models;

namespace Todo.BL.TodoService
{
    public class TodoService : BaseEntityCrudService<TodoItem, long, ITodoRepository>, ITodoService
    {
        public TodoService(ITodoRepository repository, ILogger<TodoService> logger) : base(repository, logger)
        {
        }

        public async Task<TodoItem> GetAsync(long id)
        {
            return await Repository.GetAsync(id);
        }

        public async Task<ICollection<TodoItem>> GetListAsync()
        {
            return await Repository.GetListAsync();
        }
    }
}