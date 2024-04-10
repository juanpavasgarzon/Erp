using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pavas.Domain.Executors.Transaction;

namespace Pavas.Infrastructure.Repository.EntityFramework.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Inventory)
            .WithMany(i => i.Transactions)
            .HasForeignKey(t => t.InventoryId)
            .IsRequired();
        builder.Property(t => t.Type)
            .HasConversion<int>()
            .IsRequired();
        builder.Property(i => i.Quantity)
            .HasConversion<decimal>()
            .HasDefaultValue(0);
        builder.Property(t => t.MovementDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(t => t.Reason)
            .HasConversion<int>()
            .IsRequired();
    }
}