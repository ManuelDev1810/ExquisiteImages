﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using ExquisiteImagesApi.Models;
using Microsoft.Extensions.Configuration;
using ExquisiteImagesApi.Services.Interfaces;
using ExquisiteImagesApi.Services.Repositories;


namespace ExquisiteImagesApi
{
    public class Startup
    {

        IConfiguration Configuration;

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Cors
            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("http://localhost:7000/")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    );
            });

            //Db Context
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(Configuration["Data:ExquisiteModels:ConnectionString"]);
            });

            //Dependecy Injection
            services.AddTransient<IImageRepository, ImageReposiory>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            services.AddMvc();

            //Applying cors Globally
            services.Configure<MvcOptions>(options => {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
        }
    }
}
