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
        public async Task<List<ToDo>> Get()
        {
            return await _toDoService.GetAllToDo().ConfigureAwait(false);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var toDo = await _toDoService.GetToDo(id).ConfigureAwait(false);

            if (toDo != null)
            {
                return Ok(toDo);
            }

            return NotFound();
        }
    }
}
