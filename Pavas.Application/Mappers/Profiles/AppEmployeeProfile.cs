using AutoMapper;
using Pavas.Application.Executors.Employee.Commands;
using Pavas.Domain.Executors.Employee.Commands.Add;

namespace Pavas.Application.Mappers.Profiles;

public class AppEmployeeProfile : Profile
{
    public AppEmployeeProfile()
    {
        CreateMap<AppAddEmployeeCommand, AddEmployeeCommand>();
    }
}