using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Domain.Executors.Inventory.Commands.Add;

public record AddInventoryCommand(
    int Code,
    string Name,
    string Description,
    int CompanyId,
    InventoryType Type,
    decimal Price,
    decimal Quantity
) : ICommand;