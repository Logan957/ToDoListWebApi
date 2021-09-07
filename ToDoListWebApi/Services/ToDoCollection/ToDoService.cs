using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.DataBase.Repositories.ToDoCollection;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.Services.ToDoCollection
{
    public class ToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<List<ToDo>> GetAllToDo()
        {
            return await _toDoRepository.Get().ConfigureAwait(false);
        }

        public async Task<ToDo> GetToDo(string id)
        {
            if (Guid.TryParse(id, out Guid idGuid))
            {
                var toDo = await _toDoRepository.Get(id).ConfigureAwait(false);

                if (toDo != null)
                {
                    return toDo;
                }
            }

            return null;
        }

        public async Task<ToDo> CreateToDo(ToDo toDo)
        {
            return await _toDoRepository.Create(toDo).ConfigureAwait(false);
        }

        public async Task<bool> RemoveToDo(string id)
        {
           return await _toDoRepository.Remove(id).ConfigureAwait(false);
        }
    }
}
