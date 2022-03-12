using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Todo.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.DAL.TodoRepository
{
    public class TodoRepository: BaseContextRepository, ITodoRepository
    {
        public TodoRepository(TodoContext context, IConfiguration config, ILogger<TodoRepository> logger) : base(context, config, logger)
        {
        }

        public async Task<TodoItem> SaveAsync(TodoItem entity)
        {
            var todoItem = new TodoItem
            {
                IsComplete = entity.IsComplete,
                Name = entity.Name
            };

            Context.TodoItems.Add(todoItem);
            await Context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<TodoItem> UpdateAsync(long id, TodoItem entity)
        {

            var todoItem = await Context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return null;
            }

            todoItem.Name = entity.Name;
            todoItem.IsComplete = entity.IsComplete;

            await Context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var todoItem = await Context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return false;
            }

            Context.TodoItems.Remove(todoItem);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<TodoItem> GetAsync(long id)
        {
            return await Context.TodoItems.FirstOrDefaultAsync(todoItem => todoItem.Id == id);
        }

        public async Task<ICollection<TodoItem>> GetListAsync()
        {
            return await Context.TodoItems
                .Select(x => x)
                .ToListAsync();
        }
    }
}