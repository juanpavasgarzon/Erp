using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Company;
using Pavas.Domain.Executors.Company.Constants;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .IsRequired();
        builder.Property(c => c.Name)
            .HasMaxLength(CompanyConstants.NameMaxLength)
            .IsRequired();
        builder.Property(c => c.Industry)
            .HasMaxLength(CompanyConstants.IndustryMaxLength)
            .IsRequired();
        builder.Property(c => c.Email)
            .HasMaxLength(CompanyConstants.EmailMaxLength)
            .IsRequired();
        builder.HasIndex(c => c.Email)
            .IsUnique();
        builder.Property(e => e.FoundedDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(c => c.IsActive)
            .HasColumnType("boolean")
            .HasDefaultValue(true);
        builder.HasMany(c => c.Employees)
            .WithOne(e => e.Company);
        builder.HasMany(c => c.Inventories)
            .WithOne(i => i.Company);
    }
}