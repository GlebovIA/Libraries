using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class LiteratureTypesContext : BaseContext
    {
        public DbSet<Literature_typesModell> Literature_types { get; set; }
        public LiteratureTypesContext()
        {
            Database.EnsureCreated();
            Literature_types.Load();
        }
    }
}
