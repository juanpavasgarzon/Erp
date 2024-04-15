using AutoMapper;
using Pavas.Application.Executors.Inventory.Commands.Add;
using Pavas.Application.Executors.Inventory.Commands.Remove;
using Pavas.Application.Executors.Inventory.Queries.GetAll;
using Pavas.Domain.Executors.Inventory.Commands.Add;
using Pavas.Domain.Executors.Inventory.Commands.Remove;
using Pavas.Domain.Executors.Inventory.Queries.GetAll;

namespace Pavas.Application.Mappers.Profiles;

public class AppInventoryProfile : Profile
{
    public AppInventoryProfile()
    {
        CreateMap<AppAddInventoryCommand, AddInventoryCommand>();
        CreateMap<AppRemoveInventoryCommand, RemoveInventoryCommand>();
        CreateMap<AppGetAllInventoryQuery, GetAllInventoryQuery>();
    }
}