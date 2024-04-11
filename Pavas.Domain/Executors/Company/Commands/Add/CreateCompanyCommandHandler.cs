using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Domain.Executors.Company.Commands.Add;

public class CreateCompanyCommandHandler(IRepository repository) : ICommandHandler<AddCompanyCommand>
{
    public async Task HandleAsync(AddCompanyCommand command, CancellationToken cancellationToken = default)
    {
        var companyExists = await repository.GetByIdAsync<Company, int>(command.Id, cancellationToken);
        if (companyExists is not null)
        {
            throw new EntityAlreadyExistsException($"Company With Id '{command.Id}' Already Exists");
        }

        var company = new Company(
            command.Id,
            command.Name,
            command.Industry,
            command.Email,
            command.FoundedDate
        );

        await repository.AddAsync(company, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}