using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEscala.AppDatabase.Configurations;

public class MissaEntityTypeConfiguration : IEntityTypeConfiguration<MissaEntity>
{
    public void Configure(EntityTypeBuilder<MissaEntity> builder)
    {
        builder.ToTable("Missas");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Data).IsRequired();
        builder.Property(e => e.Ativo).HasDefaultValue(true);
        builder.HasOne(e => e.Igreja)
            .WithMany()
            .HasForeignKey(e => e.IgrejaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
