using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEscala.AppDatabase.Configurations;

internal sealed class AcolitoCompromissosEntityTypeConfiguration : IEntityTypeConfiguration<AcolitoCompromissosEntity>
{
    public void Configure(EntityTypeBuilder<AcolitoCompromissosEntity> builder)
    {
        builder.ToTable("AcolitoCompromissos");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id_acolitos).IsRequired();
        builder.Property(e => e.Dia)
            .HasConversion<string>()
            .IsRequired();
        builder.Property(e => e.Motivo)
            .HasDefaultValue(string.Empty);
    }
}
