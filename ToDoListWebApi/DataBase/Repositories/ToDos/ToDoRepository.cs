using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.DataBase.Repositories.ToDoCollection
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DatabaseContext _db;

        public ToDoRepository(DatabaseContext db)
        {
            _db = db;
        }


        public async Task<ToDo> Create(ToDo toDo)
        {
            if (toDo != null)
            {
                await _db.ToDos.AddAsync(toDo).ConfigureAwait(false);
                await _db.SaveChangesAsync().ConfigureAwait(false);

                return await Get(toDo.Id).ConfigureAwait(false);
            }

            return null;
        }

        public async Task<IReadOnlyCollection<ToDo>> Get()
        {
            return await _db.ToDos.ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<ToDo> Get(int id)
        {
            return await _db.ToDos.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> Remove(int id)
        {
            var toDo = await Get(id).ConfigureAwait(false);

            if (toDo != null)
            {
                _db.ToDos.Remove(toDo);
                await _db.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }

            return false;
        }

        public async Task<ToDo> Update(ToDo toDo)
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

                        return await Get(toDo.Id).ConfigureAwait(false);
                    }
                }
            }

            return null;
        }
    }
}
