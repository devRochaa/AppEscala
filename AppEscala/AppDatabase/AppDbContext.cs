using AppEscala.AppDatabase.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppEscala.AppDatabase;

public class AppDbContext : DbContext
{
    public static string DatabasePath
        => EnsureDatabasePath();

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

    private static string EnsureDatabasePath()
    {
        string folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AppEscala");
        Directory.CreateDirectory(folder);

        string databasePath = Path.Combine(folder, "appescala.db");
        string legacyDesktopPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "appescala.db");

        if (!File.Exists(databasePath) && File.Exists(legacyDesktopPath))
            File.Move(legacyDesktopPath, databasePath);

        return databasePath;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcolitoEntityTypeConfiguration).Assembly);
    }
}
