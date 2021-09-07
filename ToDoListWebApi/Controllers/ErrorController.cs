using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListWebApi.Controllers
{
    public class ErrorController : ControllerBase
    {
        [HttpGet("[controller]/{code}")]
        public IActionResult Error() => Problem();
    }
}
