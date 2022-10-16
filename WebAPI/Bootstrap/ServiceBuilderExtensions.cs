﻿using Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WebAPI
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterWebAPIServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(t => t.WithAttribute<MapServiceDependency>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}