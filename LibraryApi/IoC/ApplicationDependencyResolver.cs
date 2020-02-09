using LibraryApi.Repositories;
using LibraryApi.Repositories.Interfaces;
using LibraryApi.Services;
using LibraryApi.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApi.IoC
{
    public static class ApplicationDependencyResolver
    {
        public static void AddLibraryDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMasterRepositorie, MasterRepositorie>();
            services.AddScoped<IMasterService, MasterService>();
        }
    }
}
