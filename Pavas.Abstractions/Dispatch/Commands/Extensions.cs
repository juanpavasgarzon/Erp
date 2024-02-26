using Microsoft.Extensions.DependencyInjection;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Scrutor;

namespace Pavas.Abstractions.Dispatch.Commands;

public static class Extensions
{
    public static void AddCommands(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();

        services.Scan(scan =>
            scan.FromApplicationDependencies()
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip).AsImplementedInterfaces().WithScopedLifetime()
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip).AsImplementedInterfaces().WithScopedLifetime()
        );
    }
}