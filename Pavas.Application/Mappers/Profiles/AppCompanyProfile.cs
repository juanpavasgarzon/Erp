using AutoMapper;
using Pavas.Application.Executors.Company.Commands.Add;
using Pavas.Application.Executors.Company.Commands.Inactivate;
using Pavas.Domain.Executors.Company.Commands.Add;
using Pavas.Domain.Executors.Company.Commands.Inactivate;

namespace Pavas.Application.Mappers.Profiles;

public class AppCompanyProfile : Profile
{
    public AppCompanyProfile()
    {
        CreateMap<AppAddCompanyCommand, AddCompanyCommand>();
        CreateMap<AppInactivateCompanyCommand, InactivateCompanyCommand>();
    }
}