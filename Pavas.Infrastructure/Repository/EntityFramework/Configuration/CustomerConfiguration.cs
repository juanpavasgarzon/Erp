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
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(c => c.RegistrationDate)
            .IsRequired()
            .HasColumnType("date");
        builder.Property(c => c.IsActive)
            .HasColumnType("boolean")
            .HasDefaultValue(true); 
    }
}