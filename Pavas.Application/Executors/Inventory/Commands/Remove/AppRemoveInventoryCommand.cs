using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Inventory.Commands.Remove;

public record AppRemoveInventoryCommand(
    int Code,
    decimal Quantity
) : ICommand;