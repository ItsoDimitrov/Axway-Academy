using System;
using System.Collections.Generic;
using Axway.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Axway.Database
{
    public class AxwayContext : DbContext
    {
        public AxwayContext() {}

        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.CONNECTION_STRING); // Your connection string here
            }
        }

        
    }
}
