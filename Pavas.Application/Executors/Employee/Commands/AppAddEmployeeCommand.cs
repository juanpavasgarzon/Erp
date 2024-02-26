using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Employee.Commands;

public record AppAddEmployeeCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    int CompanyId,
    DateTime HireDate
) : ICommand;