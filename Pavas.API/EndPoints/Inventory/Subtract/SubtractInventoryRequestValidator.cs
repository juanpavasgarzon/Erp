using FluentValidation;

namespace Pavas.API.EndPoints.Inventory.Subtract;

public class SubtractInventoryRequestValidator : AbstractValidator<SubtractInventoryRequest>
{
    public SubtractInventoryRequestValidator()
    {
        RuleFor(i => i.Quantity)
            .NotEmpty()
            .WithMessage("The Quantity Is Required")
            .GreaterThan(0)
            .WithMessage("The Quantity Must Be Greater Than Zero");
    }
}