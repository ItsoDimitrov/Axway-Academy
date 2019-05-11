using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AngleSharp;
using AngleSharp.Dom;
using AxwayHomeworkApp.Data;
using AxwayHomeworkApp.Models;
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
           // Using Anglesharp 
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            for (int i = 2; i <= 9; i++)
            {
                var address = "https://www.pcgamer.com/2013-preview/" + i + "/?page=2";
                var document = context.OpenAsync(address).GetAwaiter().GetResult();
                var gameGenre = document.QuerySelector(".content-wrapper h2:nth-child(2)").TextContent;
                var gameTitle = document.QuerySelector(".content-wrapper h2:nth-child(3)").TextContent;
                if (!string.IsNullOrEmpty(gameGenre) && !string.IsNullOrEmpty(gameTitle))
                {
                    var game = db.Games.FirstOrDefault(g => g.Name == gameTitle);
                    if (game == null)
                    {
                        game = new Game
                        {
                            Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(gameTitle.ToLower()),
                            Genre = gameGenre,
                            ReleaseDate = DateTime.UtcNow

                        };
                    }

                    db.Games.Add(game);
                    db.SaveChanges();
                }
            }
            //var cells = document.QuerySelector();
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
