using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ToDoListWebApi.Models.ToDoCollection
{
    public class ToDo
    {
        [BsonId]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
