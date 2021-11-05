using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListWebApi.Auth;
using ToDoListWebApi.Models.Comments;
using ToDoListWebApi.Models.ToDoCollection;
using ToDoListWebApi.Services.Commnets;

namespace ToDoListWebApi.Controllers
{
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        //fix
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateComment(Comment comment)
        {

            await _commentService.CreateComment(comment).ConfigureAwait(false);

            return CreatedAtAction(nameof(ToDoController.GetToDo),new { id = comment.ToDoId }, comment);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> DeleteComment(int id)
        {
            if (await _commentService.RemoveComment(id).ConfigureAwait(false))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}

