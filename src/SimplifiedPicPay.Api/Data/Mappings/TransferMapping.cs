using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplifiedPicPay.Api.Modules.Transfers.Domain;

namespace SimplifiedPicPay.Api.Data.Mappings;

public sealed class TransferMapping : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("transfers");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");

        builder.Property(t => t.PayerId)
            .HasColumnName("payer_id")
            .IsRequired();

        builder.Property(t => t.PayeeId)
            .HasColumnName("payee_id")
            .IsRequired();

        builder.Property(t => t.Value)
            .HasColumnName("value")
            .IsRequired();

        builder.Property(t => t.TransferDate)
            .HasColumnName("transfer_date")
            .IsRequired();
    }
}
