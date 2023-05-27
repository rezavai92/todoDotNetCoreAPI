using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using todoAPI.models;

namespace todoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoContext _context;
        private ToDoService _todoService ;

        public ToDoItemsController(ToDoService todoService)
        {
           _todoService = todoService;  
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItems()
        {
            var got = await _todoService.GetToDoItemsAsync();

            return Ok(got);


    
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(string id)
        {
            var found = _todoService.GetToDoItemByIdAsync(id);

          if (found == null)
          {
              return NotFound();
          }
            

            return Ok(found);
        }

        // PUT: api/ToDoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(string id, ToDoItem toDoItem)
        {

            var found = await _todoService.GetToDoItemByIdAsync(id);

            if(found == null)
            {
                return NotFound();
            }
            toDoItem.Id = found.Id;
              await _todoService.UpdateToDoItem(id, toDoItem);


            return NoContent();
        }

        // POST: api/ToDoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
           await _todoService.CreateToDoAsync(toDoItem);

            return CreatedAtAction("GetToDoItem", new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(string id)
        {

            var found = await _todoService.GetToDoItemByIdAsync(id);

            if (found == null)
            {
                return NotFound();
            }
            await _todoService.RemoveToDoItem(id);

            return NoContent();
        }

 
    }
}
