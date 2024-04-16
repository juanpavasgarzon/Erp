using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Inventory.Commands.Remove;

public record RemoveInventoryCommand(
    int Code,
    decimal Quantity
) : ICommand;