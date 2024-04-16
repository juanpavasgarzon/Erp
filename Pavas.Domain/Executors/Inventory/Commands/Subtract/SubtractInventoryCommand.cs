using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Inventory.Commands.Subtract;

public record SubtractInventoryCommand(int InventoryId, decimal Quantity) : ICommand;