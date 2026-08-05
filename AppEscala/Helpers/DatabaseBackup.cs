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

        string databaseFullPath = Path.GetFullPath(DatabasePath);
        string sourceFullPath = Path.GetFullPath(origem);
        if (string.Equals(databaseFullPath, sourceFullPath, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("O arquivo selecionado ja e o banco de dados atual.");

        string tempPath = Path.Combine(
            directory ?? Path.GetTempPath(),
            $"appescala_import_{Guid.NewGuid():N}.tmp");
        string backupPath = Path.Combine(
            directory ?? Path.GetTempPath(),
            $"appescala_before_import_{DateTime.Now:yyyyMMdd_HHmmss}.bak");

        File.Copy(origem, tempPath, overwrite: true);

        Database.DisposeAll();
        SqliteConnection.ClearAllPools();

        try
        {
            if (File.Exists(DatabasePath))
                File.Replace(tempPath, DatabasePath, backupPath, ignoreMetadataErrors: true);
            else
                File.Move(tempPath, DatabasePath);
        }
        finally
        {
            if (File.Exists(tempPath))
                File.Delete(tempPath);

            SqliteConnection.ClearAllPools();
        }
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
