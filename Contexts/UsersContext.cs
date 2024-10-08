﻿using Libraries.Modell;
using Microsoft.EntityFrameworkCore;

namespace Libraries.Contexts
{
    public class UsersContext : BaseContext
    {
        public DbSet<UsersModell> Users { get; set; }
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
    }
}
