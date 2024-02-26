using AutoMapper;
using Pavas.Application.Executors.Customer.Commands.Add;
using Pavas.Domain.Executors.Customer.Add;

namespace Pavas.Application.Mappers.Profiles;

public class AppCustomerProfile : Profile
{
    public AppCustomerProfile()
    {
        CreateMap<AppAddCustomerCommand, AddCustomerCommand>();
    }
}