namespace Pavas.API.EndPoints.Customer.Add;

public record AddCustomerRequest(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
);