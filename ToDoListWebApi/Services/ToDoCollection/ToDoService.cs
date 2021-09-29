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

        public async Task<IReadOnlyCollection<ToDo>> GetAllToDo()
        {
            return await _toDoRepository.Get().ConfigureAwait(false);
        }

        public async Task<ToDo> GetToDo(int id)
        {
            return await _toDoRepository.Get(id).ConfigureAwait(false);
        }

        public async Task<ToDo> CreateToDo(ToDo toDo)
        {
            return await _toDoRepository.Create(toDo).ConfigureAwait(false);
        }

        public async Task<bool> RemoveToDo(int id)
        {
            return await _toDoRepository.Remove(id).ConfigureAwait(false);
        }

        public async Task<ToDo> UpdateToDo(ToDo toDo)
        {
            return await _toDoRepository.Update(toDo).ConfigureAwait(false);
        }
    }
}
