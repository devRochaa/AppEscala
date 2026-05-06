using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEscala.AppDatabase.Configurations;

internal sealed class AcolitoDisponibilidadeEntityTypeConfiguration : IEntityTypeConfiguration<AcolitoDisponibilidadeEntity>
{
    public void Configure(EntityTypeBuilder<AcolitoDisponibilidadeEntity> builder)
    {
        builder.ToTable("AcolitoDisponibilidade");
        builder.HasKey(t => t.Id);
        builder.HasOne(t => t.Acolito)
            .WithMany()
            .HasForeignKey(t => t.AcolitoId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Property(e => e.Turno)
            .HasConversion<string>()
            .IsRequired();
    }
}