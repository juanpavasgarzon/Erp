using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Customer;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(c => c.LastName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();
        builder.Property(c => c.RegistrationDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(c => c.IsActive)
            .HasColumnType("boolean")
            .HasDefaultValue(true);
    }
}