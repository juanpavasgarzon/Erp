using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Inventory.Commands.Remove;

public class AppRemoveInventoryCommand(
    int Code,
    int Quantity
) : ICommand;