using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.Models;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.DataBase.Repositories.ToDoCollection
{
    public interface IToDoRepository
    {
        /// <summary>
        /// Create ToDo
        /// </summary>
        /// <param name="toDo">ToDo</param>
        Task<ToDo> Create(ToDo toDo);

        /// <summary>
        /// Get all ToDO
        /// </summary>
        Task<List<ToDo>> Get();

        /// <summary>
        /// Get ToDo by id
        /// </summary>
        /// <param name="id">Id ToDo</param>
        Task<ToDo> Get(string id);

        /// <summary>
        /// Remove ToDo by id
        /// </summary>
        /// <param name="id">Id ToDo</param>
        Task<bool> Remove(string id);

        /// <summary>
        /// Update  ToDo
        /// </summary>
        /// <param name="toDo">ToDo</param>
        Task<ToDo> Update(ToDo ToDo);
    }
}