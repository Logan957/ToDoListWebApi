using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWebApi.DataBase.Models.Users;

namespace ToDoListWebApi.DataBase.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _db;

        public UserRepository(DatabaseContext db)
        {
            _db = db;
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            var result = _db.Users.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                //todo: need to add logger
                return null;
            }

            return result;
        }

        public async Task<int> Add(User user)
        {
            var result = await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return result.Entity.Id;
        }
    }

}
