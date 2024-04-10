namespace Pavas.Domain.Executors.Employee;

public class Employee(
    int id,
    string firstName,
    string lastName,
    string email,
    string phoneNumber,
    int companyId,
    DateTime hireDate
)
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = email;
    public string PhoneNumber { get; set; } = phoneNumber;
    public int CompanyId { get; set; } = companyId;
    public Company.Company Company { get; init; } = null!;
    public DateTime HireDate { get; set; } = hireDate;
    public bool IsActive { get; set; } = true;
}