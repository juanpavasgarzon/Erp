using Microsoft.Extensions.DependencyInjection;

namespace Pavas.Application.Mappers;

public static class Extensions
{
    public static void AddApplicationMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}