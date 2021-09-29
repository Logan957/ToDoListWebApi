using System.Collections.Generic;
using ToDoListWebApi.Models.Comments;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
    }
}
