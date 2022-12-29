using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyProject.Context;
using MyProject.Mock;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.WebAPI.Middlewares;
using Services;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyProject.WebAPI
{
    public class Startup
    {
        private readonly string _myOrigin = "tami";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject.WebAPI", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: _myOrigin,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin().AllowAnyMethod();
                                  });
            });
            services.AddServices();
            services.AddDbContext<IContext,DataContext>(options=> options.UseSqlServer(b => b.MigrationsAssembly("MyProject.WebAPI")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_myOrigin);
            app.UseAuthorization();
            app.Use(async (Context, next) =>
            {
                DateOnly d=DateOnly.FromDateTime(DateTime.Now);
                if(d.DayOfWeek== DayOfWeek.Thursday)
                {
                    Context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    //Context.Response.status(400).json({ 'error':'User already exists.'});
                    //Context.Response.ContentType = "application/json";
                    //JsonResult json = new JsonResult("Shabbes!",Context);
                    //Context.Response.HttpContext = "";
                    var bytes = Encoding.UTF8.GetBytes("Hello World");

                    await Context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                }
                     
                else
                    await next(Context);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseTrack();
        }
    }
}
