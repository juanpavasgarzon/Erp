using Microsoft.Extensions.DependencyInjection;
using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Scrutor;

namespace Pavas.Abstractions.Dispatch.Queries;

public static class Extensions
{
    public static void AddQueries(this IServiceCollection services)
    {
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        services.Scan(scan =>
            scan.FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip).AsImplementedInterfaces().WithScopedLifetime()
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip).AsImplementedInterfaces().WithScopedLifetime()
        );
    }
}