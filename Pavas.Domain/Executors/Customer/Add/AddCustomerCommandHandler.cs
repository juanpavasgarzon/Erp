using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Domain.Executors.Customer.Add;

public class AddCustomerCommandHandler(IRepository repository) : ICommandHandler<AddCustomerCommand>
{
    public async Task HandleAsync(AddCustomerCommand command, CancellationToken cancellationToken = default)
    {
        var customerExists = await repository.GetByIdAsync<Customer, int>(command.Id, cancellationToken);
        if (customerExists is not null)
        {
            throw new EntityAlreadyExistsException($"Customer With Id '{customerExists.Id}' Already Exists");
        }

        var customer = new Customer(
            command.Id,
            command.FirstName,
            command.LastName,
            command.Email,
            command.PhoneNumber
        );

        await repository.AddAsync(customer, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}