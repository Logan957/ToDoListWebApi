using Microsoft.EntityFrameworkCore;
using ToDoListWebApi.Models.Users;

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
    }
}
