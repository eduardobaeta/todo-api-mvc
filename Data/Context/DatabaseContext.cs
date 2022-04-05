using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

        public DbSet<TodoModel> TodoModels { get; set; }
    }
}