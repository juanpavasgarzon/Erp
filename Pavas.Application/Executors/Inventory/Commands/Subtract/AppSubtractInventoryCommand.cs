using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Inventory.Commands.Subtract;

public record AppRemoveInventoryCommand(int InventoryId, decimal Quantity) : ICommand;