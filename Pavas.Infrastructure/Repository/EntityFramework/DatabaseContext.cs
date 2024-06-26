using Microsoft.EntityFrameworkCore;
using Pavas.Abstractions.DatabaseContext;
using Pavas.Domain.Executors.Company;
using Pavas.Domain.Executors.Customer;
using Pavas.Domain.Executors.Employee;
using Pavas.Domain.Executors.Inventory;

namespace Pavas.Infrastructure.Repository.EntityFramework;

public sealed class DatabaseContext : BaseContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public required DbSet<Company> Companies { get; set; }
    public required DbSet<Customer> Customers { get; set; }
    public required DbSet<Employee> Employees { get; set; }
    public required DbSet<Inventory> Inventories { get; set; }
    public required DbSet<InventoryTransaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}