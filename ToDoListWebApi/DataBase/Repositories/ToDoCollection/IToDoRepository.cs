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
        /// <param name="toDo"></param>
        /// <returns></returns>
        Task<ToDo> Create(ToDo toDo);

        /// <summary>
        /// Get all ToDO
        /// </summary>
        /// <returns></returns>
        Task<List<ToDo>> Get();

        /// <summary>
        /// Get ToDo by id
        /// </summary>
        /// <param name="id">Id ToDo</param>
        /// <returns></returns>
        Task<ToDo> Get(string id);

        /// <summary>
        /// Remove ToDo by id
        /// </summary>
        /// <param name="id">Id ToDo</param>
        Task Remove(string id);
    }
}