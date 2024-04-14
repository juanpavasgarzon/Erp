using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Inventory;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
{
    public void Configure(EntityTypeBuilder<InventoryTransaction> builder)
    {
        builder.ToTable("Transactions");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.HasOne(t => t.Inventory)
            .WithMany(i => i.Transactions)
            .HasForeignKey(t => t.InventoryId)
            .IsRequired();
        builder.Property(t => t.Type)
            .HasConversion(
                m => m.ToString(),
                m => (MovementType)Enum.Parse(typeof(MovementType), m)
            )
            .IsRequired();
        builder.Property(i => i.Quantity)
            .HasConversion<decimal>()
            .HasDefaultValue(0);
        builder.Property(t => t.MovementDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(i => i.Reason)
            .HasConversion(
                i => i.ToString(),
                i => (TransactionReason)Enum.Parse(typeof(TransactionReason), i)
            )
            .IsRequired();
    }
}