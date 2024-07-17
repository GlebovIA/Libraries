using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class ReplenishmentsContext : BaseContext
    {
        public DbSet<ReplenishmentsModell> Replenishments { get; set; }
        public ReplenishmentsContext()
        {
            Database.EnsureCreated();
            Replenishments.Load();
        }
    }
}
