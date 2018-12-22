using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Packt.CS7;

namespace NorthWindWeb
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //CONNECTION STRING - DB
            services.AddDbContext<Northwind>(options =>
            options.UseSqlServer("Server = (localdb)\\mssqllocaldb;Database=Northwind; Trusted_Connection=True;MultipleActiveResultSets=True;")
            );

        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Run(async (context) =>
            // {
            //    await context.Response.WriteAsync("Hello World!");
            // });

            app.UseStaticFiles();
            app.UseDefaultFiles(); // index.html, default.html, and so on
            app.UseMvc();
        }
    }
    
}
