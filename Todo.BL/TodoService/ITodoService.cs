using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.DAL.TodoRepository;
using Todo.Models;

namespace Todo.BL.TodoService
{
    public interface ITodoService : IBaseEntityCrudService<TodoItem, long, ITodoRepository>
    {
        Task<TodoItem> GetAsync(long id);

        Task<ICollection<TodoItem>> GetListAsync();
    }
}