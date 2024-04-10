using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Inventory;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(i => i.Name)
            .IsUnique();
        builder.Property(i => i.Description)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(i => i.Type)
            .HasConversion<int>()
            .IsRequired();
        builder.HasOne(i => i.Company)
            .WithMany(c => c.Inventories)
            .HasForeignKey(i => i.CompanyId)
            .IsRequired();
        builder.Property(i => i.Price)
            .HasConversion<decimal>()
            .HasDefaultValue(0);
        builder.Property(i => i.Quantity)
            .HasConversion<decimal>()
            .HasDefaultValue(0);
    }
}