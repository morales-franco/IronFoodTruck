using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronFoodTruck.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IronFoodTruck
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
            services.AddDbContextPool<IronFoodTruckDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IronFoodTruckDb"));
            });

            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //custom middleware
            app.Use(SayHelloMiddleware);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private RequestDelegate SayHelloMiddleware(RequestDelegate next)
        {
            return async ctx =>
            {
                //If request want to access /hello ==> return "Hello man!"
                if (ctx.Request.Path.StartsWithSegments("/hello"))
                {
                    await ctx.Response.WriteAsync("Hello man!");
                }
                else
                {
                    //Continue with the next piece of middleware
                    await next(ctx);
                }
            };
        }
    }
}
