using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEscala.AppDatabase.Configurations;

internal sealed class ConfiguracaoMissaEntityTypeConfiguration : IEntityTypeConfiguration<ConfiguracaoMissaEntity>
{
    public void Configure(EntityTypeBuilder<ConfiguracaoMissaEntity> builder)
    {
        builder.ToTable("ConfiguracoesMissa");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Horario)
            .HasConversion(
                value => value.HasValue ? value.Value.ToString(@"hh\:mm") : null,
                value => string.IsNullOrWhiteSpace(value) ? null : TimeSpan.Parse(value));

        builder.HasOne(e => e.Igreja)
            .WithMany()
            .HasForeignKey(e => e.IgrejaId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
