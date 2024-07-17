using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class WorkersContext : BaseContext
    {
        public DbSet<WorkersModell> Workers { get; set; }
        public WorkersContext()
        {
            Database.EnsureCreated();
            Workers.Load();
        }
    }
}
