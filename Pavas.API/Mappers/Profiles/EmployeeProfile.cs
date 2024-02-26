using AutoMapper;
using Pavas.API.EndPoints.Employee.Add;
using Pavas.Application.Executors.Employee.Commands;

namespace Pavas.API.Mappers.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<AddEmployeeRequest, AppAddEmployeeCommand>();
    }
}