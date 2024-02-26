using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Customer.Commands.Add;

public record AppAddCustomerCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
) : ICommand;