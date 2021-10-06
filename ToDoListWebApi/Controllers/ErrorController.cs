using Microsoft.AspNetCore.Mvc;

namespace ToDoListWebApi.Controllers
{
    public class ErrorController : ControllerBase
    {
        [HttpGet("[controller]/{code}")]
        public IActionResult Error() => Problem();
    }
}
