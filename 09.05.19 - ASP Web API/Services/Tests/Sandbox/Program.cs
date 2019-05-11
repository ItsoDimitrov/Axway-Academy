using System;
using System.IO;
using System.Linq;
using System.Text;
using AxwayHomeworkApp.Data;
using AxwayHomeworkApp.Models;
using AxwayHomeworkApp.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<AxwayHomeworkAppContext>();
            var gameName = db.Games.Select(g => new
            {
                GameName = g.Name
            });
            Console.WriteLine(gameName);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", false, true)
            //    .Build();

            services.AddDbContext<AxwayHomeworkAppContext>(options =>
                options.UseSqlServer(
                    "Server=DESKTOP-F8FBRNH\\SQLEXPRESS;Database=AxwayHomeworkApp;Integrated Security=True;"));

        }
    }
}
