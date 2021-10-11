using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.Models.ToDoCollection;
using ToDoListWebApi.Models.ToDos;

namespace ToDoListWebApi.DataBase.Repositories.ToDoCollection
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DatabaseContext _db;

        public ToDoRepository(DatabaseContext db)
        {
            _db = db;
        }


        public async Task<ToDo> CreateItem(ToDo toDo)
        {
            if (toDo != null)
            {
                await _db.ToDos.AddAsync(toDo).ConfigureAwait(false);
                await _db.SaveChangesAsync().ConfigureAwait(false);

                return await GetItem(toDo.Id).ConfigureAwait(false);
            }

            return null;
        }

        public async Task<IReadOnlyCollection<ToDo>> GetItem(ToDoFilter filter)
        {
            return await GetToDos(filter).ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<ToDo> GetItem(int id)
        {
            return await _db.ToDos.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> RemoveItem(int id)
        {
            var toDo = await GetItem(id).ConfigureAwait(false);

            if (toDo != null)
            {
                _db.ToDos.Remove(toDo);
                await _db.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }

            return false;
        }

        public async Task<ToDo> UpdateItem(ToDo toDo)
        {
            if (toDo != null)
            {
                if (toDo.Id > 0)
                {
                    var ToDoOld = await _db.ToDos.FirstOrDefaultAsync(x => x.Id == toDo.Id).ConfigureAwait(false);

                    if (ToDoOld != null)
                    {
                        _db.Entry(ToDoOld).CurrentValues.SetValues(toDo);

                        await _db.SaveChangesAsync().ConfigureAwait(false);

                        return await GetItem(toDo.Id).ConfigureAwait(false);
                    }
                }
            }

            return null;
        }

        private IQueryable<ToDo> GetToDos(ToDoFilter filter)
        {
            IQueryable<ToDo> toDos = _db.ToDos;

            if (filter != null)
            {
                if (filter.UserIds != null)
                {
                    toDos = toDos.Where(x => filter.UserIds.Contains(x.UserId));
                }

                if (filter.IsCompleted != null)
                {
                    toDos = toDos.Where(x => x.IsCompleted == filter.IsCompleted);
                }
            }

            return toDos;
        }
    }
}