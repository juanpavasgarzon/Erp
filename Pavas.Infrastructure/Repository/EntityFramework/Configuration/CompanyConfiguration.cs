using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Company;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(c => c.Industry)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.FoundedDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(c => c.IsActive)
            .HasColumnType("boolean")
            .HasDefaultValue(true);
        builder.HasMany(c => c.Employees)
            .WithOne(e => e.Company);
    }
}