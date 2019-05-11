using System;
using Microsoft.EntityFrameworkCore;

namespace AxwayHomeworkApp.Data
{
    public class AxwayHomeworkAppContext : DbContext
    {
        public AxwayHomeworkAppContext(DbContextOptions<AxwayHomeworkAppContext> options) : base(options)
        {
            
        }
    }
}
