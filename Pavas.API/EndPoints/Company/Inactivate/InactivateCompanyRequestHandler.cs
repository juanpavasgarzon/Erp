using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Company.Commands.Inactivate;

namespace Pavas.API.EndPoints.Company.Inactivate;

public class InactivateCompanyRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPatch("/companies/inactivate/{companyId:int}", HandleAsync)
            .WithTags("Company")
            .WithDescription("Endpoint To Inactivate One Company");
    }

    private static async Task<IResult> HandleAsync([FromServices] ICommandDispatcher dispatcher, int companyId)
    {
        try
        {
            var command = new AppInactivateCompanyCommand(companyId);
            await dispatcher.DispatchAsync(command);
            return TypedResults.NoContent();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}