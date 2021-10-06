using Microsoft.EntityFrameworkCore;
using ToDoListWebApi.DataBase.Models.Users;
using ToDoListWebApi.Models.Comments;
using ToDoListWebApi.Models.ToDoCollection;

namespace ToDoListWebApi.DataBase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
