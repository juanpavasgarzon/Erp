using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Company.Commands.Inactivate;

public record AppInactivateCompanyCommand(int Id) : ICommand;
