using AutoMapper;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Customer.Commands.Add;

namespace Pavas.API.EndPoints.Customer.Add;

public class AddCustomerRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/customers", HandleAsync)
            .WithTags("Customer")
            .WithDescription("Endpoint To Create One Customer");
    }

    private static async Task<IResult> HandleAsync(
        AddCustomerRequest request,
        ICommandDispatcher dispatcher,
        IMapper mapper
    )
    {
        try
        {
            var command = mapper.Map<AppAddCustomerCommand>(request);
            await dispatcher.DispatchAsync(command);
            return TypedResults.Created();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}