using AppEscala.AppDatabase;
using Microsoft.Data.Sqlite;

namespace AppEscala.Helpers;

internal static class DatabaseBackup
{
    public static string DatabasePath => AppDbContext.DatabasePath;

    public static void Exportar(string destino)
    {
        string? directory = Path.GetDirectoryName(destino);
        if (!string.IsNullOrWhiteSpace(directory))
            Directory.CreateDirectory(directory);

        SqliteConnection.ClearAllPools();
        File.Copy(DatabasePath, destino, overwrite: true);
    }

    public static void Importar(string origem)
    {
        if (!File.Exists(origem))
            throw new FileNotFoundException("Arquivo de configurações não encontrado.", origem);

        ValidarBanco(origem);

        string? directory = Path.GetDirectoryName(DatabasePath);
        if (!string.IsNullOrWhiteSpace(directory))
            Directory.CreateDirectory(directory);

        SqliteConnection.ClearAllPools();
        File.Copy(origem, DatabasePath, overwrite: true);
        SqliteConnection.ClearAllPools();
    }

    private static void ValidarBanco(string caminho)
    {
        using SqliteConnection connection = new($"Data Source={caminho};Mode=ReadOnly");
        connection.Open();

        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = """
            SELECT COUNT(*)
            FROM sqlite_master
            WHERE type = 'table'
              AND name IN ('Acolitos', 'AcolitoDisponibilidade', 'AcolitoCompromissos', 'Igrejas', 'Missas');
            """;

        long tabelas = (long)(command.ExecuteScalar() ?? 0L);
        if (tabelas < 5)
            throw new InvalidOperationException("O arquivo selecionado não parece ser um backup válido do App Escala.");
    }
}
