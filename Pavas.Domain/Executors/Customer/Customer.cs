namespace Pavas.Domain.Executors.Customer;

public class Customer(
    int id,
    string firstName,
    string lastName,
    string email,
    string phoneNumber
)
{
    public int Id { get; set; } = id;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = email;
    public string PhoneNumber { get; set; } = phoneNumber;
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
}