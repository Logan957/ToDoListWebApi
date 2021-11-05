using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.DataBase;
using ToDoListWebApi.Models.Comments;

namespace ToDoListWebApi.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext _db;

        public CommentRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Comment> GetItem(int id)
        {
            return await _db.Comments.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<Comment> CreateItem(Comment comment)
        {
            if (comment != null)
            {
                await _db.Comments.AddAsync(comment).ConfigureAwait(false);
                await _db.SaveChangesAsync().ConfigureAwait(false);

                return await GetItem(comment.Id).ConfigureAwait(false);
            }

            return null;
        }

        public async Task<bool> RemoveItem(int id)
        {
            var comment = await GetItem(id).ConfigureAwait(false);

            if (comment != null)
            {
                _db.Comments.Remove(comment);
                await _db.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }

            return false;
        }
    }
}
