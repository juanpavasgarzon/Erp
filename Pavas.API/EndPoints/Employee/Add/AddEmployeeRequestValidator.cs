using FluentValidation;
using Pavas.Domain.Executors.Employee.Constants;

namespace Pavas.API.EndPoints.Employee.Add;

public class AddEmployeeRequestValidator : AbstractValidator<AddEmployeeRequest>
{
    public AddEmployeeRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The Id Attribute Is Required");

        RuleFor(e => e.FirstName)
            .NotEmpty()
            .WithMessage("The FirstName Attribute Is Required")
            .MaximumLength(EmployeeConstants.FirstNameMaxLength)
            .WithMessage("FirstName Attribute Length Is Too Loong");

        RuleFor(e => e.LastName)
            .NotEmpty()
            .WithMessage("The LastName Attribute Is Required")
            .MaximumLength(EmployeeConstants.LastNameMaxLength)
            .WithMessage("LastName Attribute Length Is Too Loong");

        RuleFor(e => e.Email)
            .NotEmpty()
            .WithMessage("The Email Attribute Is Required")
            .MaximumLength(EmployeeConstants.EmailMaxLength)
            .WithMessage("Email Attribute Length Is Too Loong");

        RuleFor(e => e.PhoneNumber)
            .NotEmpty()
            .WithMessage("The PhoneNumber Attribute Is Required");

        RuleFor(e => e.PhoneNumber)
            .NotEmpty()
            .WithMessage("The PhoneNumber Attribute Is Required");

        RuleFor(e => e.PhoneNumber)
            .NotEmpty()
            .WithMessage("The PhoneNumber Attribute Is Required");

        RuleFor(e => e.CompanyId)
            .NotEmpty()
            .WithMessage("The CompanyId Attribute Is Required");

        RuleFor(e => e.HireDate)
            .NotEmpty()
            .WithMessage("The Email Attribute Is Required")
            .Must(d => !d.Equals(default))
            .WithMessage("Date is not valid.");
    }
}