using AppEscala.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEscala.AppDatabase.Configurations;

public class IgrejasEntityTypeConfiguration : IEntityTypeConfiguration<IgrejaEntity>
{
    public void Configure(EntityTypeBuilder<IgrejaEntity> builder)
    {
        builder.ToTable("Igrejas");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nome).IsRequired();
    }
}