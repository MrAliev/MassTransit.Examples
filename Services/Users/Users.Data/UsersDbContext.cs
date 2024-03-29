﻿using Microsoft.EntityFrameworkCore;
using Users.Model;

namespace Users.Data
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
