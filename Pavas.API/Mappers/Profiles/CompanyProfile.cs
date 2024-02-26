using AutoMapper;
using Pavas.API.EndPoints.Company.Add;
using Pavas.Application.Executors.Company.Commands.Add;

namespace Pavas.API.Mappers.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<AddCompanyRequest, AppAddCompanyCommand>();
    }
}