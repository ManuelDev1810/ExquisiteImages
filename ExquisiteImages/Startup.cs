using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ExquisiteImages.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ExquisiteImages.Infrastructure.ImageClient;
using ExquisiteImages.Infrastructure.CommentClient;

namespace ExquisiteImages
{
    public class Startup
    {
        IConfiguration Configuration;
        public Startup(IConfiguration confi)
        {
            Configuration  = confi;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Db Context
            services.AddDbContext<AppIdentityDbContext>(opts => {
                opts.UseSqlServer(Configuration["Data:ExquisiteUsers:ConnectionString"]);
            });

            //Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            //Dependecy Injections
            services.AddTransient<IImageClient, ImageClient>();
            services.AddTransient<ICommentClient, CommentClient>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
