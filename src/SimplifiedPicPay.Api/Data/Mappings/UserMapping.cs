using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplifiedPicPay.Api.Modules.Users.Domain;

namespace SimplifiedPicPay.Api.Data.Mappings;

public sealed class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasIndex(u => new { u.Email, u.CpfCnpj }).IsUnique();

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");

        builder.Property(u => u.FullName)
            .HasColumnName("full_name")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(254)
            .IsRequired();

        builder.Property(u => u.Password)
            .HasColumnName("password")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.CpfCnpj)
            .HasColumnName("cpf_cnpj")
            .HasColumnType("varchar")
            .HasMaxLength(18)
            .IsRequired();

        builder.Property(u => u.WalletBalance)
            .HasColumnName("wallet_balance")
            .IsRequired();

        builder.Property(u => u.Type)
            .HasColumnName("type")
            .HasColumnType("varchar")
            .HasMaxLength(8)
            .HasConversion<string>();
    }
}
