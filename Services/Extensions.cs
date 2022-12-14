using Microsoft.Extensions.DependencyInjection;
using MyProject.Repositories;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IClaimService, ClaimService>();

            services.AddAutoMapper(typeof(Mapping));//יש להתקין בפרויקט זה את הפקג' המתאים של AutoMapper....

            return services;
        }
    }
}
