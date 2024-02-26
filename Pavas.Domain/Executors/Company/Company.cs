namespace Pavas.Domain.Executors.Company;

public class Company(
    int id,
    string name,
    string industry,
    DateTime foundedDate
)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Industry { get; set; } = industry;
    public DateTime FoundedDate { get; set; } = foundedDate;
    public bool IsActive { get; set; } = true;
    public List<Employee.Employee> Employees { get; init; } = [];
}