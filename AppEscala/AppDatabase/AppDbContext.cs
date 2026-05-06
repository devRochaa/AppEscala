using AppEscala.AppDatabase.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppEscala.AppDatabase;

public class AppDbContext : DbContext
{
    public static string DatabasePath
        => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "appescala.db");

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcolitoEntityTypeConfiguration).Assembly);
    }
}
