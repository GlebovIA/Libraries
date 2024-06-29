using Libraries.Classes.Db;
using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class ReplenishmentsContext : DbContext
    {
        public DbSet<Replenishments> Replenishments { get; set; }
        public ReplenishmentsContext()
        {
            Database.EnsureCreated();
            Replenishments.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}
