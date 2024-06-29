using Libraries.Classes.Db;
using Microsoft.EntityFrameworkCore;
using Library = Libraries.Modell.LibrariesModell;

namespace Libraries.Contexts
{
    public class LibrariesContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public LibrariesContext()
        {
            Database.EnsureCreated();
            Libraries.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}
