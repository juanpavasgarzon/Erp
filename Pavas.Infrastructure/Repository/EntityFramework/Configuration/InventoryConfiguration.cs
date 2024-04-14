using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Inventory;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");
        builder.HasKey(i => i.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(t => t.Code)
            .HasMaxLength(InventoryConstants.CodeMaxLength)
            .IsRequired();
        builder.HasIndex(i => i.Code)
            .IsUnique();
        builder.Property(i => i.Name)
            .HasMaxLength(InventoryConstants.NameMaxLength)
            .IsRequired();
        builder.Property(i => i.Description)
            .HasMaxLength(InventoryConstants.DescriptionMaxLength)
            .IsRequired();
        builder.Property(i => i.Type)
            .HasConversion(
                t => t.ToString(),
                t => (InventoryType)Enum.Parse(typeof(InventoryType), t)
            )
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