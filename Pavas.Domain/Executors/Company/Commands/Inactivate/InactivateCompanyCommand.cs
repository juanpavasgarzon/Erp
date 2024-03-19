using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Company.Commands.Inactivate;

public record InactivateCompanyCommand(int Id) : ICommand;