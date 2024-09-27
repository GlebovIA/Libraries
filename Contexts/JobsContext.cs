using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class JobsContext : BaseContext
    {
        public DbSet<JobsModell> Jobs { get; set; }
        public JobsContext()
        {
            Database.EnsureCreated();
            Jobs.Load();
        }
    }
}
