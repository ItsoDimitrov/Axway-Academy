using AxwayHomeworkApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AxwayHomeworkApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AxwayHomeworkAppContext>(options =>

            //    options.UseSqlServer(
            //        this.Configuration.GetConnectionString("DefaultConnection")));
            //options.UseSqlServer(
            //    ""Server=DESKTOP-F8FBRNH\\SQLEXPRESS;Database=AxwayHomeworkApp;Integrated Security=True;""
            //));

            services.AddDbContext<AxwayHomeworkAppContext>(options =>
                options.UseSqlServer(
                    "Server=DESKTOP-F8FBRNH\\SQLEXPRESS;Database=AxwayHomeworkApp;Integrated Security=True;"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "api/{controller}/{action}/{id}"
            //    );
            //});
        }
    }
}
