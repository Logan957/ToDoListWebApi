using System.Collections.Generic;
using System.Text.Json.Serialization;
using ToDoListWebApi.DataBase.Models.Users;
using ToDoListWebApi.Models.Comments;

namespace ToDoListWebApi.Models.ToDoCollection
{
    public class ToDo
    {    
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
