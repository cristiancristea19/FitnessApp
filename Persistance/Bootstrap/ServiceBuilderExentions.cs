using Application.Interfaces;
using Common;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Persistance.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(t => t.WithAttribute<MapServiceDependency>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}