﻿using Libraries.Classes.Db;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class LiteratureTypesContext : DbContext
    {
        public DbSet<LiteratureTypesContext> Literature_types { get; set; }
        public LiteratureTypesContext()
        {
            Database.EnsureCreated();
            Literature_types.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}