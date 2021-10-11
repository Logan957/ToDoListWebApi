using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.Models.ToDoCollection;
using ToDoListWebApi.Models.ToDos;

namespace ToDoListWebApi.DataBase.Repositories.ToDoCollection
{
    public interface IToDoRepository
    {
        /// <summary>
        /// Create ToDo
        /// </summary>
        /// <param name="toDo">ToDo</param>
        Task<ToDo> CreateItem(ToDo toDo);

        /// <summary>
        /// Get ToDO
        /// </summary>
        Task<IReadOnlyCollection<ToDo>> GetItem(ToDoFilter filter);

        /// <summary>
        /// Get ToDo by id
        /// </summary>
        /// <param name="id">Id ToDo</param>
        Task<ToDo> GetItem(int id);

        /// <summary>
        /// Remove ToDo by id
        /// </summary>
        /// <param name="id">Id ToDo</param>
        Task<bool> RemoveItem(int id);

        /// <summary>
        /// Update  ToDo
        /// </summary>
        /// <param name="toDo">ToDo</param>
        Task<ToDo> UpdateItem(ToDo ToDo);
    }
}