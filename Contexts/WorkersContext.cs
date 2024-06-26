using Libraries.Classes.Db;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class WorkersContext : DbContext
    {
        public DbSet<WorkersContext> Workers { get; set; }
        public WorkersContext()
        {
            Database.EnsureCreated();
            Workers.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}
