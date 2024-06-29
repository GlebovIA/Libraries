using Libraries.Classes.Db;
using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class FondsContext : DbContext
    {
        public DbSet<FondsModell> Fonds { get; set; }
        public FondsContext()
        {
            Database.EnsureCreated();
            Fonds.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}
