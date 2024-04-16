using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Application.Executors.Inventory.Commands.Subtract;

public record AppSubtractInventoryCommand(int InventoryId, decimal Quantity) : ICommand;