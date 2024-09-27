using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class EducationsContext : BaseContext
    {
        public DbSet<EducationsModell> Educations { get; set; }
        public EducationsContext()
        {
            Database.EnsureCreated();
            Educations.Load();
        }
    }
}
