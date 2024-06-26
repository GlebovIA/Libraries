﻿using Libraries.Classes.Db;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class LiteratureSourcesContext : DbContext
    {
        public DbSet<LiteratureSourcesContext> Literature_sources { get; set; }
        public LiteratureSourcesContext()
        {
            Database.EnsureCreated();
            Literature_sources.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(DbConnection.OpenConnection());
    }
}