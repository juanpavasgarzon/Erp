using System.Reflection;
using Pavas.API.MinimalApi.Contracts;

namespace Pavas.API.MinimalApi;

public static class Extensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        var collection = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany((Func<Assembly, IEnumerable<Type>>)(s => s.GetTypes()))
            .Where(t => t.GetInterfaces().Contains(typeof(IEndpoint)))
            .Where(t => !t.IsAbstract)
            .Where(t => !t.IsInterface);

        foreach (var implementationType in collection)
        {
            services.AddScoped(typeof(IEndpoint), implementationType);
        }
    }

    public static void MapEndpoints(this WebApplication builder)
    {
        foreach (var service in builder.Services.CreateScope().ServiceProvider.GetServices<IEndpoint>())
        {
            service.Configure(builder);
        }
    }
}