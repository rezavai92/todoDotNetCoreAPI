using Microsoft.EntityFrameworkCore;
namespace todoAPI.models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
        {
        }

        public DbSet<ToDoItem> TodoItems { get; set; } = null!;
    }
}
