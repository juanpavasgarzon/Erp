using AutoMapper;
using Pavas.API.EndPoints.Customer.Add;
using Pavas.Application.Executors.Customer.Commands.Add;

namespace Pavas.API.Mappers.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<AddCustomerRequest, AppAddCustomerCommand>();
    }
}