using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.Auth;
using ToDoListWebApi.DataBase.Models.Users;
using ToDoListWebApi.Models.ToDoCollection;
using ToDoListWebApi.Models.ToDos;
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

        [Authorize]
        [HttpGet]
        public async Task<IReadOnlyCollection<ToDo>> GetToDo(bool isCompleted)
        {
            User user = (User)HttpContext.Items["User"];

            return await _toDoService.GetToDo(new ToDoFilter().SetCompletedStatus(isCompleted).SetUserIds(user.Id)).ConfigureAwait(false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDo(int id)
        {
            var toDo = await _toDoService.GetToDo(id).ConfigureAwait(false);

            if (toDo != null)
            {
                return Ok(toDo);
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateToDo(ToDo toDo)
        {
            User user = (User)HttpContext.Items["User"];
            toDo.User = user;

            await _toDoService.CreateToDo(toDo).ConfigureAwait(false);

            return CreatedAtAction(nameof(GetToDo), new { id = toDo.Id }, toDo);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> DeleteToDo(int id)
        {
            if (await _toDoService.RemoveToDo(id).ConfigureAwait(false))
            {
                return Ok();
            }

            return NotFound();
        }

        [Authorize]
        [HttpPatch]
        public async Task<ActionResult<ToDo>> UpdateToDo(ToDo todo)
        {
            if (await _toDoService.UpdateToDo(todo).ConfigureAwait(false) != null)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
