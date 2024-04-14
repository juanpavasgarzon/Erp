using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pavas.Abstractions.Authentication.Contracts;
using Pavas.Abstractions.Authentication.Middlewares;

namespace Pavas.Abstractions.Authentication;

public static class Extensions
{
    public static void UseAuthContextMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<AuthMiddleware>();
    }

    public static void AddAuthContextServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthContextAccessor, AuthContextAccessor>();
        services.AddTransient<IAuthContextFactory, AuthContextFactory>();
    }
}