using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.BL.TodoService;
using TodoApi.DTO;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoItemsController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var result = await _todoService.GetListAsync();
            return Ok(Mapper.MapToDTO(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var result = await _todoService.GetAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Mapper.MapToDTO(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            var entity = Mapper.MapToEntity(todoItemDTO);
            var result = await _todoService.UpdateAsync(id, entity);
            if (result == null)
            {
                return BadRequest("Entity doesn't exist");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var entity = Mapper.MapToEntity(todoItemDTO);
            var result = await _todoService.SaveAsync(entity);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var result = await _todoService.DeleteAsync(id);
            if (!result)
            {
                return Problem();
            }

            return Ok();
        }
    }
}