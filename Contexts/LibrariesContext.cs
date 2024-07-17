using Microsoft.EntityFrameworkCore;
using Library = Libraries.Modell.LibrariesModell;

namespace Libraries.Contexts
{
    public class LibrariesContext : BaseContext
    {
        public DbSet<Library> Libraries { get; set; }
        public LibrariesContext()
        {
            Database.EnsureCreated();
            Libraries.Load();
        }
    }
}
