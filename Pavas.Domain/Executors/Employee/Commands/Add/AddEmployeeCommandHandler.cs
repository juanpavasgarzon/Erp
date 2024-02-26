using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Domain.Executors.Employee.Commands.Add;

public class AddEmployeeCommandHandler(IRepository repository) : ICommandHandler<AddEmployeeCommand>
{
    public async Task HandleAsync(AddEmployeeCommand command, CancellationToken cancellationToken = default)
    {
        var employeeExists = await repository.GetByIdAsync<Employee, int>(command.Id, cancellationToken);
        if (employeeExists is not null)
        {
            throw new EntityAlreadyExistsException($"Employee With Id '{employeeExists.Id}' Already Exists");
        }

        var employee = new Employee(
            command.Id,
            command.FirstName,
            command.LastName,
            command.Email,
            command.PhoneNumber,
            command.CompanyId,
            command.HireDate
        );

        await repository.AddAsync(employee, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}