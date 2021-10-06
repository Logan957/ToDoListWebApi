using System.Collections.Generic;
using ToDoListWebApi.Models.Comments;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.DataBase.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ToDo> ToDos { get; set; }
    }
}
