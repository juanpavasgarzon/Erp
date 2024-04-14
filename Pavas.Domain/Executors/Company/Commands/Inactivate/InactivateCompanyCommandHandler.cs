using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Domain.Executors.Company.Commands.Inactivate;

public class InactivateCompanyCommandHandler(IRepository repository) : ICommandHandler<InactivateCompanyCommand>
{
    public async Task HandleAsync(InactivateCompanyCommand command, CancellationToken cancellationToken = default)
    {
        var company = await repository.GetByIdAsync<Company, int>(command.Id, cancellationToken);
        if (company is null)
        {
            throw new EntityNotFoundException($"Company With Id '{command.Id}' Is Not Found");
        }

        company.IsActive = false;
        await repository.UpdateAsync(company, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}