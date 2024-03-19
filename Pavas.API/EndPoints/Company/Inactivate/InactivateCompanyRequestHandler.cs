using AutoMapper;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Company.Commands.Inactivate;

namespace Pavas.API.EndPoints.Company.Inactivate;

public class InactivateCompanyRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPatch("/company/inactivate", HandleAsync)
            .WithTags("Company")
            .WithDescription("Endpoint To Inactivate One Company");
    }

    private static async Task<IResult> HandleAsync(
        InactivateCompanyRequest request,
        ICommandDispatcher dispatcher,
        IMapper mapper
    )
    {
        try
        {
            var command = mapper.Map<AppInactivateCompanyCommand>(request);
            await dispatcher.DispatchAsync<>(command);
            return TypedResults.Ok();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}