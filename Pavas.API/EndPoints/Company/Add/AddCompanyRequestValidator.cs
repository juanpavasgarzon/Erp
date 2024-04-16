using FluentValidation;
using Pavas.Domain.Executors.Company.Constants;

namespace Pavas.API.EndPoints.Company.Add;

public class AddCompanyRequestValidator : AbstractValidator<AddCompanyRequest>
{
    public AddCompanyRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The Id Attribute Is Required");

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("The Name Attribute Is Required")
            .MaximumLength(CompanyConstants.NameMaxLength)
            .WithMessage("Name Attribute Length Is Too Loong");

        RuleFor(c => c.Industry)
            .NotEmpty()
            .WithMessage("The Industry Attribute Is Required")
            .MaximumLength(CompanyConstants.IndustryMaxLength)
            .WithMessage("Industry Attribute Length Is Too Loong");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("The Email Attribute Is Required")
            .MaximumLength(CompanyConstants.EmailMaxLength)
            .WithMessage("Email Attribute Length Is Too Loong");

        RuleFor(c => c.FoundedDate)
            .NotEmpty()
            .WithMessage("The Email Attribute Is Required")
            .Must(d => !d.Equals(default))
            .WithMessage("Date is not valid.");
    }
}