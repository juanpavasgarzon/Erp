using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Customer;
using Pavas.Domain.Executors.Customer.Constants;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
            .HasMaxLength(CustomerConstants.FirstNameMaxLength)
            .IsRequired();
        builder.Property(c => c.LastName)
            .HasMaxLength(CustomerConstants.LastNameMaxLength)
            .IsRequired();
        builder.Property(c => c.Email)
            .HasMaxLength(CustomerConstants.EmailMaxLength)
            .IsRequired();
        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(CustomerConstants.PhoneNumberMaxLength)
            .IsRequired();
        builder.Property(c => c.RegistrationDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(c => c.IsActive)
            .HasColumnType("boolean")
            .HasDefaultValue(true);
    }
}