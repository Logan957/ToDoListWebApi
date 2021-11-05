using System.Threading.Tasks;
using ToDoListWebApi.Models.Comments;
using ToDoListWebApi.Repositories.Comments;

namespace ToDoListWebApi.Services.Commnets
{
    public class CommentService
    {
        private readonly ICommentRepository  _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Comment> CreateComment(Comment comment)
        {
            return await _commentRepository.CreateItem(comment).ConfigureAwait(false);
        }

        public async Task<bool> RemoveComment(int id)
        {
            return await _commentRepository.RemoveItem(id).ConfigureAwait(false);
        }
    }
}
