using Libraries.Classes.Db;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class LibrariesContext : DbContext
    {
        public static DbSet<LibrariesContext> Libraries { get; set; }
        public LibrariesContext()
        {
            Database.EnsureCreated();
            Libraries.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}
