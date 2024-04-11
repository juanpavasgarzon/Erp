using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Employee;
using Pavas.Domain.Executors.Employee.Constants;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever()
            .IsRequired();
        builder.Property(e => e.FirstName)
            .HasMaxLength(EmployeeConstants.FirstNameMaxLength)
            .IsRequired();
        builder.Property(e => e.LastName)
            .HasMaxLength(EmployeeConstants.LastNameMaxLength)
            .IsRequired();
        builder.Property(e => e.Email)
            .HasMaxLength(EmployeeConstants.EmailMaxLength)
            .IsRequired();
        builder.HasIndex(e => e.Email)
            .IsUnique();
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(EmployeeConstants.PhoneNumberMaxLength)
            .IsRequired();
        builder.Property(e => e.HireDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(c => c.IsActive)
            .HasColumnType("boolean")
            .HasDefaultValue(true);
        builder.HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId)
            .IsRequired();
    }
}