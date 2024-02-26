namespace Pavas.API.EndPoints.Employee.Add;

public record AddEmployeeRequest(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    int CompanyId,
    DateTime HireDate
);