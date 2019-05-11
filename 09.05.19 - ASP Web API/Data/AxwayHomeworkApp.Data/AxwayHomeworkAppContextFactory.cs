using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace AxwayHomeworkApp.Data
{
    public class AxwayHomeworkAppContextFactory : IDesignTimeDbContextFactory<AxwayHomeworkAppContext>
    {
        public AxwayHomeworkAppContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();

            TODO: // Need to fix the specific path for appssetings file . Error i get when trying to add migration -
            // The configuration file 'appsettings.json' was not found and is not optional. The physical path is .. "
            
            var builder = new DbContextOptionsBuilder<AxwayHomeworkAppContext>();

            var connectionString =
                "Server=DESKTOP-F8FBRNH\\SQLEXPRESS;Database=AxwayHomeworkApp;Integrated Security=True;";


            //var connectionString = "Server=DESKTOP-F8FBRNH\\SQLEXPRESS;Database=AxwayHomeworkApp;Integrated Security=True;";



            builder.UseSqlServer(connectionString);

            // Stop client query evaluation
            builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new AxwayHomeworkAppContext(builder.Options);
        }
    }
}
