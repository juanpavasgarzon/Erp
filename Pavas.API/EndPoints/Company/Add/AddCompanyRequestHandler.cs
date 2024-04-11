using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Company.Commands.Add;

namespace Pavas.API.EndPoints.Company.Add;

public class AddCompanyRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/companies", HandleAsync)
            .WithTags("Company")
            .WithDescription("Endpoint To Create One Company");
    }

    private static async Task<IResult> HandleAsync(
        [FromBody] AddCompanyRequest request,
        [FromServices] ICommandDispatcher dispatcher,
        [FromServices] IMapper mapper
    )
    {
        try
        {
            var command = mapper.Map<AppAddCompanyCommand>(request);
            await dispatcher.DispatchAsync(command);
            return TypedResults.Created();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}