using AutoMapper;
using Pavas.API.EndPoints.Inventory.Add;
using Pavas.API.EndPoints.Inventory.Remove;
using Pavas.Application.Executors.Inventory.Commands.Add;
using Pavas.Application.Executors.Inventory.Commands.Remove;

namespace Pavas.API.Mappers.Profiles;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<AddInventoryRequest, AppAddInventoryCommand>();
        CreateMap<RemoveInventoryRequest, AppRemoveInventoryCommand>();
    }
}