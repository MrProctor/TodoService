using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.DAL.Repository;
using Todo.Models;

namespace Todo.DAL.TodoRepository
{
    public interface ITodoRepository: ICrudRepository<TodoItem, long>
    {
        Task<TodoItem> GetAsync(long id);
        
        Task<ICollection<TodoItem>> GetListAsync();
    }
}