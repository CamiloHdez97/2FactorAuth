using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
        .HasColumnName("iduser")
        .HasColumnType("int")
        .ValueGeneratedOnAdd();

        builder.Property(p => p.DateUp)
        .HasColumnName("dateup")
        .HasColumnType("datetime")
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(p => p.Email)
        .HasColumnName("email")
        .HasColumnType("varchar(250)")
        .IsRequired();

        builder.Property(p => p.Password)
        .HasColumnName("password")
        .HasColumnType("varbinary(32)");

        builder.Property(x => x.TwoFactorSecret)            
        .HasColumnName("two_factor_secret")
        .HasColumnType("varchar(32)");

        builder.Property(p => p.DateDown)
        .HasColumnName("datedown")
        .HasColumnType("datetime")
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

    }
}