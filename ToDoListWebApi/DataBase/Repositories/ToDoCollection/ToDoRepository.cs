using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.DataBase.Repositories.ToDoCollection
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IMongoCollection<ToDo> _toDo;

        public ToDoRepository(IToDoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _toDo = database.GetCollection<ToDo>(settings.ToDoCollectionName);
        }


        public async Task<List<ToDo>> Get()
        {
            return await _toDo.Find(toDo => true).ToListAsync().ConfigureAwait(false);
        }

        public async Task<ToDo> Get(string id)
        {
            return await _toDo.Find<ToDo>(toDo => toDo.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<ToDo> Create(ToDo toDo)
        {
            await _toDo.InsertOneAsync(toDo).ConfigureAwait(false);

            return toDo;
        }

        public async Task<bool> Remove(string id)
        {
            await _toDo.DeleteOneAsync(toDo => toDo.Id == id).ConfigureAwait(false);

            if (await Get(id) == null)
            {
                return true;
            }
            return false;
        }
    }
}
