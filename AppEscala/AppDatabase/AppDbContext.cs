using AppEscala.AppDatabase.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppEscala.AppDatabase;

public class AppDbContext : DbContext
{
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

        string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string dbPath = Path.Combine(folder, "appescala.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcolitoEntityTypeConfiguration).Assembly);
    }
}
