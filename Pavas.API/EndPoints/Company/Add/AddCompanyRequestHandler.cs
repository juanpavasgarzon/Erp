using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Company.Commands.Add;

namespace Pavas.API.EndPoints.Company.Add;

public class AddCompanyRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/companies/add", HandleAsync)
            .WithTags("Company")
            .WithDescription("Endpoint To Create One Company");
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] IValidator<AddCompanyRequest> validator,
        [FromServices] ICommandDispatcher dispatcher,
        [FromBody] AddCompanyRequest request
    )
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest<object>(new
            {
                Detail = validationResult.ToDictionary(),
                Status = StatusCodes.Status400BadRequest
            });
        }

        try
        {
            var command = new AppAddCompanyCommand(
                request.Id,
                request.Name,
                request.Industry,
                request.Email,
                request.FoundedDate
            );
            await dispatcher.DispatchAsync(command);
            return TypedResults.Created();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}