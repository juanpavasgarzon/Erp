using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Company.Commands.Add;

public record AddCompanyCommand(
    int Id,
    string Name,
    string Industry,
    DateTime FoundedDate
) : ICommand;


