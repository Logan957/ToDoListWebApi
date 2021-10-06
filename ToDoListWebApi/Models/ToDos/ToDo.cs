using System.Collections.Generic;
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
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
