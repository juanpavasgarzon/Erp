namespace Pavas.Domain.Executors.Company;

public class Company(
    int id,
    string name,
    string industry,
    string email,
    DateTime foundedDate
)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Industry { get; set; } = industry;
    public string Email { get; set; } = email;
    public DateTime FoundedDate { get; set; } = foundedDate;
    public bool IsActive { get; set; } = true;
    public List<Employee.Employee> Employees { get; init; } = [];
    public List<Inventory.Inventory> Inventories { get; init; } = [];
}