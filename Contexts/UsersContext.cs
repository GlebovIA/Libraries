using Libraries.Modell;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Libraries.Contexts
{
    public class UsersContext : DbContext
    {
        public DbSet<UserModell> Users { get; set; }
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Classes.Db.DbConnection.OpenConnection() as DbConnection);
    }
}
