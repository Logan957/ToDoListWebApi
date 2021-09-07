using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.Models.ToDoCollection;
using ToDoListWebApi.Services.ToDoCollection;

namespace ToDoListWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<List<ToDo>> GetToDo()
        {
            int x = 0;
            int v = 5 / x;
            return await _toDoService.GetAllToDo().ConfigureAwait(false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDo(string id)
        {
            var toDo = await _toDoService.GetToDo(id).ConfigureAwait(false);

            if (toDo != null)
            {
                return Ok(toDo);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateToDo(ToDo toDo)
        {
            await _toDoService.CreateToDo(toDo).ConfigureAwait(false);

            return CreatedAtAction(nameof(GetToDo), new { id = toDo.Id }, toDo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> DeleteToDo(string id)
        {
            if (await _toDoService.RemoveToDo(id).ConfigureAwait(false))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
