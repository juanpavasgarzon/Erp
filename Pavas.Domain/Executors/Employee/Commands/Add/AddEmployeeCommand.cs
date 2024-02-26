using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Employee.Commands.Add;

public record AddEmployeeCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    int CompanyId,
    DateTime HireDate
) : ICommand;