using FluentValidation;

namespace Pavas.API.EndPoints.Inventory.Add;

public class AddInventoryRequestValidator : AbstractValidator<AddInventoryRequest>
{
    public AddInventoryRequestValidator()
    {
        RuleFor(i => i.Code)
            .NotEmpty()
            .WithMessage("The Code Attribute Is Required");

        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("The Name Attribute Is Required");

        RuleFor(i => i.Description)
            .NotEmpty()
            .WithMessage("The Description Attribute Is Required");

        RuleFor(i => i.CompanyId)
            .NotEmpty()
            .WithMessage("The CompanyId Attribute Is Required");

        RuleFor(i => i.Type)
            .NotEmpty()
            .WithMessage("The Type Attribute Is Required")
            .IsInEnum()
            .WithMessage("The Type must be a valid enum value");

        RuleFor(i => i.Price)
            .NotEmpty()
            .WithMessage("The Price Attribute Is Required")
            .GreaterThan(0)
            .WithMessage("The Price Must Be Greater Than Zero.");

        RuleFor(i => i.Quantity)
            .NotEmpty()
            .WithMessage("The Quantity Is Required")
            .GreaterThan(0)
            .WithMessage("The Quantity Must Be Greater Than Zero");
    }
}