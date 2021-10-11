using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.DataBase.Repositories.ToDoCollection;
using ToDoListWebApi.Models.ToDoCollection;
using ToDoListWebApi.Models.ToDos;

namespace ToDoListWebApi.Services.ToDoCollection
{
    public class ToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<IReadOnlyCollection<ToDo>> GetToDo(ToDoFilter filter)
        {
            return await _toDoRepository.GetItem(filter).ConfigureAwait(false);
        }

        public async Task<ToDo> GetToDo(int id)
        {
            return await _toDoRepository.GetItem(id).ConfigureAwait(false);
        }

        public async Task<ToDo> CreateToDo(ToDo toDo)
        {
            return await _toDoRepository.CreateItem(toDo).ConfigureAwait(false);
        }

        public async Task<bool> RemoveToDo(int id)
        {
            return await _toDoRepository.RemoveItem(id).ConfigureAwait(false);
        }

        public async Task<ToDo> UpdateToDo(ToDo toDo)
        {
            return await _toDoRepository.UpdateItem(toDo).ConfigureAwait(false);
        }
    }
}
