using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class FondsContext : BaseContext
    {
        public DbSet<FondsModell> Fonds { get; set; }
        public FondsContext()
        {
            Database.EnsureCreated();
            Fonds.Load();
        }
    }
}
