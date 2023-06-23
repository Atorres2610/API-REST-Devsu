using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Devsu.Core
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            Assembly getAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(getAssembly));
            return services;
        }
    }
}