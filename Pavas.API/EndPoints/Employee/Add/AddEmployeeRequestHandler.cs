using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Employee.Commands;

namespace Pavas.API.EndPoints.Employee.Add;

public class AddEmployeeRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/employees/add", HandleAsync)
            .WithTags("Employee")
            .WithDescription("Endpoint To Create One Employee");
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] IValidator<AddEmployeeRequest> validator,
        [FromServices] ICommandDispatcher dispatcher,
        [FromBody] AddEmployeeRequest request
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
            var command = new AppAddEmployeeCommand(
                request.Id,
                request.FirstName,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.CompanyId,
                request.HireDate
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