using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class LiteratureSourcesContext : BaseContext
    {
        public DbSet<Literature_sourceModell> Literature_sources { get; set; }
        public LiteratureSourcesContext()
        {
            Database.EnsureCreated();
            Literature_sources.Load();
        }
    }
}
