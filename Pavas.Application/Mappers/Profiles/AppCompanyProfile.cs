using AutoMapper;
using Pavas.Application.Executors.Company.Commands.Add;
using Pavas.Domain.Executors.Company.Commands.Add;

namespace Pavas.Application.Mappers.Profiles;

public class AppCompanyProfile : Profile
{
    public AppCompanyProfile()
    {
        CreateMap<AppAddCompanyCommand, AddCompanyCommand>();
    }
}