using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Customer.Commands.Add;

public record AddCustomerCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
) : ICommand;