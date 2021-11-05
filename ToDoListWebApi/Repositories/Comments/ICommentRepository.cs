using System.Threading.Tasks;
using ToDoListWebApi.Models.Comments;

namespace ToDoListWebApi.Repositories.Comments
{
    public interface ICommentRepository
    {
        Task<Comment> CreateItem(Comment comment);
        Task<Comment> GetItem(int id);
        Task<bool> RemoveItem(int id);
    }
}