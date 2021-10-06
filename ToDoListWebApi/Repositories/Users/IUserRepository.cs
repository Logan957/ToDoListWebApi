using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.DataBase.Models.Users;

namespace ToDoListWebApi.DataBase.Repositories.Users
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        List<User> GetAll();
        User GetById(int id);
    }
}