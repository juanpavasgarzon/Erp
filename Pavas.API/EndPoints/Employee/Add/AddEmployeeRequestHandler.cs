using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Employee.Commands;

namespace Pavas.API.EndPoints.Employee.Add;

public class AddEmployeeRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/employees", HandleAsync)
            .WithTags("Employee")
            .WithDescription("Endpoint To Create One Employee");
    }

    private static async Task<IResult> HandleAsync(
        [FromBody] AddEmployeeRequest request,
        [FromServices] ICommandDispatcher dispatcher,
        [FromServices] IMapper mapper
    )
    {
        try
        {
            var command = mapper.Map<AppAddEmployeeCommand>(request);
            await dispatcher.DispatchAsync(command);
            return TypedResults.Created();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}