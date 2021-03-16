using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeDomain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CoffeeMachine.Interfaces;
using CoffeeMachine.Services;

namespace CoffeeMachine
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
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<CoffeeDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("CoffeeConnection"),
                    b => b.MigrationsAssembly("CoffeeMachine"));
            });


            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDrinkHistoryService, DrinkHistoryService>();
            services.AddScoped<IDrinkService, DrinkService>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
