using FluentValidation;
using Pavas.Domain.Executors.Customer.Constants;

namespace Pavas.API.EndPoints.Customer.Add;

public class AddCustomerRequestValidator : AbstractValidator<AddCustomerRequest>
{
    public AddCustomerRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The Id Attribute Is Required");

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("The FirstName Attribute Is Required")
            .MaximumLength(CustomerConstants.FirstNameMaxLength)
            .WithMessage("FirstName Attribute Length Is Too Loong");

        RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("The LastName Attribute Is Required")
            .MaximumLength(CustomerConstants.LastNameMaxLength)
            .WithMessage("LastName Attribute Length Is Too Loong");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("The Email Attribute Is Required")
            .MaximumLength(CustomerConstants.EmailMaxLength)
            .WithMessage("Email Attribute Length Is Too Loong");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .WithMessage("The PhoneNumber Attribute Is Required");
    }
}