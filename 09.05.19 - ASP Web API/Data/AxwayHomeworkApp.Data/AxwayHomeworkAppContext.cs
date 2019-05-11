using System;
using AxwayHomeworkApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AxwayHomeworkApp.Data
{
    public class AxwayHomeworkAppContext : DbContext
    {
        public AxwayHomeworkAppContext(DbContextOptions<AxwayHomeworkAppContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
        
    }
}
