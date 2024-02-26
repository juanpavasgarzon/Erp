using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Employee;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(e => e.HireDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(c => c.IsActive)
            .HasColumnType("boolean")
            .HasDefaultValue(true);
        builder.HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId);
    }
}