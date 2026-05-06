using AppEscala.AppDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppEscala;


internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        // Configurar Dependency Injection
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        ApplicationConfiguration.Initialize();
        // Obter o form principal com DI
        var mainForm = ServiceProvider.GetRequiredService<form_menu>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Registrar o DbContext
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string dbPath = Path.Combine(folder, "appescala.db");
        string connectionString = $"Data Source={dbPath}";

        services.AddDbContextFactory<AppDbContext>(options => 
            options.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Registrar os forms
        services.AddTransient<form_menu>();

        // Adicione outros serviços aqui conforme necessário
    }
}
