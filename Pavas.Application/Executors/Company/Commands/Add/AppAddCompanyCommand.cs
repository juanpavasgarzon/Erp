using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Company.Commands.Add;

public record AppAddCompanyCommand(
    int Id,
    string Name,
    string Industry,
    string Email,
    DateTime FoundedDate
) : ICommand;