using AutoMapper;
using Pavas.API.EndPoints.Company.Add;
using Pavas.API.EndPoints.Company.Inactivate;
using Pavas.Application.Executors.Company.Commands.Add;
using Pavas.Application.Executors.Company.Commands.Inactivate;

namespace Pavas.API.Mappers.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<AddCompanyRequest, AppAddCompanyCommand>();
        CreateMap<InactivateCompanyRequest, AppInactivateCompanyCommand>();
    }
}