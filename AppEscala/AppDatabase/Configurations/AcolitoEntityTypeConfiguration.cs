using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQLite;

namespace AppEscala.AppDatabase.Configurations;

public class AcolitoEntityTypeConfiguration : IEntityTypeConfiguration<AcolitoEntity>
    {
    public void Configure(EntityTypeBuilder<AcolitoEntity> builder)
    {
        builder.ToTable("Acolitos");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nome).IsRequired();
    }
}