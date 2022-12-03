using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyProject.Mock;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using Services;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddTransient<IClaimRepository, ClaimRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IClaimService, ClaimService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IPermissionService, IPermissionService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddAutoMapper(typeof(Mapping));
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IClaimService,ClaimService>();
            services.AddScoped<IPermissionService, IPermissionService>();
            services.AddAutoMapper(typeof(Mapping));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
