using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Pavas.Abstractions.Authentication.Contracts;

namespace Pavas.Abstractions.Authentication.Middlewares;

public class AuthMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IAuthContextFactory authContextFactory)
    {
        var token = context.Request.Headers[HeaderNames.Authorization].FirstOrDefault();
        if (token is not null)
        {
            authContextFactory.Create(1, "Juan");
        }

        await next(context);
    }
}