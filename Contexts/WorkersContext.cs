using Libraries.Classes.Db;
using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class WorkersContext : DbContext
    {
        public DbSet<WorkersModell> Workers { get; set; }
        public WorkersContext()
        {
            Database.EnsureCreated();
            Workers.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}
