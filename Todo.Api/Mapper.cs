using System.Collections.Generic;
using System.Linq;
using Todo.Models;
using TodoApi.DTO;

namespace TodoApi
{
    public static class Mapper
    {
        public static TodoItemDTO MapToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };

        public static IEnumerable<TodoItemDTO> MapToDTO(IEnumerable<TodoItem> todoItems)
        {
            return todoItems.Select(item => new TodoItemDTO {Id = item.Id, Name = item.Name, IsComplete = item.IsComplete}).ToList();
        }

        public static TodoItem MapToEntity(TodoItemDTO todoItem) =>
            new TodoItem
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            }; 
        
        public static IEnumerable<TodoItem> MapToEntity(IEnumerable<TodoItemDTO> todoItems)
        {
            return todoItems.Select(item => new TodoItem {Id = item.Id, Name = item.Name, IsComplete = item.IsComplete}).ToList();
        }
    }
}