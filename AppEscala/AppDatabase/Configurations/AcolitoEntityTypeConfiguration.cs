using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEscala.AppDatabase.Configurations;

public class AcolitoEntityTypeConfiguration : IEntityTypeConfiguration<AcolitoEntity>
{
    public void Configure(EntityTypeBuilder<AcolitoEntity> builder)
    {
        builder.ToTable("Acolitos");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nome).IsRequired();
        builder.HasIndex(e => e.Nome).IsUnique();
        builder.Property(e => e.MissasAcompanhadasNecessarias).HasDefaultValue(0);
        builder.Property(e => e.MissasServidas).HasDefaultValue(0);
        builder.HasOne(e => e.Padrinho)
            .WithMany(e => e.Afilhados)
            .HasForeignKey(e => e.PadrinhoId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
