using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Application.Executors.Inventory.Commands.Add;

public record AppAddInventoryCommand(
    int Code,
    string Name,
    string Description,
    int CompanyId,
    InventoryType Type,
    decimal Price,
    int Quantity
) : ICommand;