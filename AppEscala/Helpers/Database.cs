using AppEscala.AppDatabase;
using AppEscala.Models.Entities;
using AppEscala.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AppEscala.Helpers;

public sealed class Database : IDisposable
{
    private static readonly object InstancesLock = new();
    private static readonly List<WeakReference<Database>> Instances = [];
    private AppDbContext? db;
    private bool disposed;

    public Database()
    {
        lock (InstancesLock)
            Instances.Add(new WeakReference<Database>(this));
    }

    public void Initialize()
    {
        ObjectDisposedException.ThrowIf(disposed, this);
        db?.Dispose();
        db = new AppDbContext();
        db.Database.EnsureCreated();
        EnsureSchema();
    }

    private void EnsureSchema()
    {
        Context.Database.ExecuteSqlRaw("""
            CREATE TABLE IF NOT EXISTS Acolitos (
                Id INTEGER NOT NULL CONSTRAINT PK_Acolitos PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                PadrinhoId INTEGER NULL,
                MissasAcompanhadasNecessarias INTEGER NOT NULL DEFAULT 0,
                MissasServidas INTEGER NOT NULL DEFAULT 0
            );
            """);
        EnsureAcolitoColumns();
        EnsureAcolitoNomeUnicoIndex();

        Context.Database.ExecuteSqlRaw("""
            CREATE TABLE IF NOT EXISTS AcolitoDisponibilidade (
                Id INTEGER NOT NULL CONSTRAINT PK_AcolitoDisponibilidade PRIMARY KEY AUTOINCREMENT,
                AcolitoId INTEGER NOT NULL,
                Turno TEXT NOT NULL,
                DiaDaSemana INTEGER NOT NULL
            );
            """);

        Context.Database.ExecuteSqlRaw("""
            CREATE TABLE IF NOT EXISTS AcolitoCompromissos (
                Id INTEGER NOT NULL CONSTRAINT PK_AcolitoCompromissos PRIMARY KEY AUTOINCREMENT,
                Id_acolitos INTEGER NOT NULL,
                Dia TEXT NOT NULL,
                Motivo TEXT NOT NULL DEFAULT ''
            );
            """);

        EnsureMotivoColumn();

        Context.Database.ExecuteSqlRaw("""
            CREATE TABLE IF NOT EXISTS Igrejas (
                Id INTEGER NOT NULL CONSTRAINT PK_Igrejas PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL
            );
            """);

        Context.Database.ExecuteSqlRaw("""
            CREATE TABLE IF NOT EXISTS Missas (
                Id INTEGER NOT NULL CONSTRAINT PK_Missas PRIMARY KEY AUTOINCREMENT,
                IgrejaId INTEGER NOT NULL,
                Data TEXT NOT NULL,
                Descricao TEXT NOT NULL,
                QntAcolitos INTEGER NOT NULL,
                Ativo INTEGER NOT NULL DEFAULT 1
            );
            """);
        EnsureColumn("Missas", "Ativo", "INTEGER NOT NULL DEFAULT 1");
    }

    private AppDbContext Context
    {
        get
        {
            ObjectDisposedException.ThrowIf(disposed, this);

            if (db is null)
                Initialize();

            return db!;
        }
    }

    public static void DisposeAll()
    {
        lock (InstancesLock)
        {
            foreach (var reference in Instances.ToList())
            {
                if (reference.TryGetTarget(out var database))
                    database.CloseContext();
            }
        }
    }

    public void Dispose()
    {
        if (disposed)
            return;

        CloseContext();
        disposed = true;
    }

    private void CloseContext()
    {
        db?.Dispose();
        db = null;
    }

    public int InsertAcolito(AcolitoEntity acolito)
    {
        acolito.Nome = NormalizarNomeAcolito(acolito.Nome);
        ValidarNomeAcolitoUnico(acolito.Nome, null);
        Context.Set<AcolitoEntity>().Add(acolito);
        Context.SaveChanges();
        return acolito.Id;
    }

    public void InsertDisponibilidade(AcolitoDisponibilidadeEntity dados)
    {
        if (dados.Turno == Turno.None)
            return;

        Context.Set<AcolitoDisponibilidadeEntity>().Add(dados);
        Context.SaveChanges();
    }

    public void InsertDias(AcolitoCompromissosEntity dados)
    {
        Context.Set<AcolitoCompromissosEntity>().Add(dados);
        Context.SaveChanges();
    }

    public void DeleteDias(int idAcolito, string dia)
    {
        var registro = SelectDiasAcolito(idAcolito)
            .FirstOrDefault(d => d.dia == dia);

        if (registro is null)
            throw new InvalidOperationException("Registro nao encontrado.");

        Context.Set<AcolitoCompromissosEntity>().Remove(registro);
        Context.SaveChanges();
    }

    public void InsertIgreja(IgrejaEntity dadosIgreja)
    {
        Context.Set<IgrejaEntity>().Add(dadosIgreja);
        Context.SaveChanges();
    }

    public List<IgrejaEntity> SelectAllIgreja()
        => Context.Set<IgrejaEntity>()
            .AsNoTracking()
            .OrderBy(i => i.Nome)
            .ToList();

    public List<AcolitoEntity> SelectAllAcolitos()
        => Context.Set<AcolitoEntity>()
            .Include(a => a.Padrinho)
            .AsNoTracking()
            .OrderBy(a => a.Nome)
            .ToList();

    public void UpdateAcolito(int? id, string nome)
    {
        if (id is null)
            return;

        nome = NormalizarNomeAcolito(nome);
        ValidarNomeAcolitoUnico(nome, id.Value);

        var registro = Context.Set<AcolitoEntity>().Find(id.Value)
            ?? throw new InvalidOperationException("Acolito nao encontrado.");

        registro.Nome = nome;
        Context.SaveChanges();
    }

    public void UpdateAcolito(
        int? id,
        string nome,
        int? padrinhoId,
        int missasAcompanhadasNecessarias,
        int missasServidas)
    {
        if (id is null)
            return;

        nome = NormalizarNomeAcolito(nome);
        ValidarNomeAcolitoUnico(nome, id.Value);

        if (padrinhoId == id.Value)
            throw new InvalidOperationException("O acólito não pode ser padrinho dele mesmo.");

        if (padrinhoId is not null && CriariaCicloDePadrinhos(id.Value, padrinhoId.Value))
            throw new InvalidOperationException("Essa relação criaria um ciclo de padrinhos.");

        var registro = Context.Set<AcolitoEntity>().Find(id.Value)
            ?? throw new InvalidOperationException("Acolito nao encontrado.");

        registro.Nome = nome;
        registro.PadrinhoId = padrinhoId;
        registro.MissasAcompanhadasNecessarias = Math.Max(0, missasAcompanhadasNecessarias);
        registro.MissasServidas = Math.Max(0, missasServidas);
        Context.SaveChanges();
    }

    public void DeleteAcolito(int? id)
    {
        if (id is null)
            return;

        var registro = Context.Set<AcolitoEntity>().Find(id.Value)
            ?? throw new InvalidOperationException("Acolito nao encontrado.");

        var disponibilidades = Context.Set<AcolitoDisponibilidadeEntity>()
            .Where(d => d.AcolitoId == id.Value)
            .ToList();
        var compromissos = Context.Set<AcolitoCompromissosEntity>()
            .Where(d => d.Id_acolitos == id.Value)
            .ToList();
        var afilhados = Context.Set<AcolitoEntity>()
            .Where(a => a.PadrinhoId == id.Value)
            .ToList();

        foreach (var afilhado in afilhados)
            afilhado.PadrinhoId = null;

        Context.Set<AcolitoDisponibilidadeEntity>().RemoveRange(disponibilidades);
        Context.Set<AcolitoCompromissosEntity>().RemoveRange(compromissos);
        Context.Set<AcolitoEntity>().Remove(registro);
        Context.SaveChanges();
    }

    public void UpdateIgrejas(int id, IgrejaEntity dadosAtualizados)
    {
        var registro = Context.Set<IgrejaEntity>().Find(id)
            ?? throw new InvalidOperationException("Registro nao encontrado.");

        registro.Nome = dadosAtualizados.Nome;
        Context.SaveChanges();
    }

    public void DeleteIgrejas(int id)
    {
        var registro = Context.Set<IgrejaEntity>().Find(id)
            ?? throw new InvalidOperationException("Registro nao encontrado.");

        Context.Set<IgrejaEntity>().Remove(registro);
        Context.SaveChanges();
    }

    public List<AcolitoDisponibilidade> ListaUserAcolitos()
        => QueryAcolitosDisponibilidade().ToList();

    public List<AcolitoDisponibilidade> BuscarUserAcolitos(string inputNome)
        => QueryAcolitosDisponibilidade()
            .Where(a => a.Nome.Contains(inputNome, StringComparison.CurrentCultureIgnoreCase))
            .ToList();

    public List<AcolitoDisponibilidade> Acolitos_Dias(int? id)
        => QueryAcolitosDisponibilidade()
            .Where(a => a.Id_acolito == id)
            .ToList();

    public bool UpdateTurnoAcolito(int? id, int idDia, int idTurno, int novoId)
    {
        if (id is null)
            return false;

        var diaSemana = DiaSemanaFromLegacyId(idDia);
        var turnoAntigo = TurnoFromLegacyId(idTurno);
        var registro = Context.Set<AcolitoDisponibilidadeEntity>()
            .FirstOrDefault(d => d.AcolitoId == id.Value && d.DiaDaSemana == diaSemana && d.Turno == turnoAntigo);

        if (registro is null)
            throw new InvalidOperationException("Registro nao encontrado.");

        registro.Turno = TurnoFromLegacyId(novoId);
        Context.SaveChanges();
        return true;
    }

    public bool SalvarTurnoAcolito(int? id, int idDia, int idTurnoAntigo, int idTurnoNovo)
    {
        if (id is null || idDia <= 0 || idTurnoNovo <= 0)
            return false;

        var diaSemana = DiaSemanaFromLegacyId(idDia);
        var novoTurno = TurnoFromLegacyId(idTurnoNovo);

        if (novoTurno == Turno.None)
            return false;

        if (idTurnoAntigo > 0)
        {
            var turnoAntigo = TurnoFromLegacyId(idTurnoAntigo);
            var registro = Context.Set<AcolitoDisponibilidadeEntity>()
                .FirstOrDefault(d => d.AcolitoId == id.Value && d.DiaDaSemana == diaSemana && d.Turno == turnoAntigo);

            if (registro is null)
                return false;

            registro.Turno = novoTurno;
            Context.SaveChanges();
            return true;
        }

        bool jaExiste = Context.Set<AcolitoDisponibilidadeEntity>()
            .Any(d => d.AcolitoId == id.Value && d.DiaDaSemana == diaSemana && d.Turno == novoTurno);

        if (jaExiste)
            return false;

        Context.Set<AcolitoDisponibilidadeEntity>().Add(new AcolitoDisponibilidadeEntity
        {
            AcolitoId = id.Value,
            DiaDaSemana = diaSemana,
            Turno = novoTurno
        });
        Context.SaveChanges();
        return true;
    }

    public void SetDisponibilidadesAcolito(int? id, IEnumerable<(int Dia, int Turno)> disponibilidades)
    {
        if (id is null)
            return;

        var registros = Context.Set<AcolitoDisponibilidadeEntity>()
            .Where(d => d.AcolitoId == id.Value)
            .ToList();

        Context.Set<AcolitoDisponibilidadeEntity>().RemoveRange(registros);

        foreach (var disponibilidade in disponibilidades.Distinct())
        {
            var turno = TurnoFromLegacyId(disponibilidade.Turno);
            if (turno == Turno.None)
                continue;

            Context.Set<AcolitoDisponibilidadeEntity>().Add(new AcolitoDisponibilidadeEntity
            {
                AcolitoId = id.Value,
                DiaDaSemana = DiaSemanaFromLegacyId(disponibilidade.Dia),
                Turno = turno
            });
        }

        Context.SaveChanges();
    }

    public List<DiaSemanaItem> SelectDiasSemana()
        => new()
        {
            new DiaSemanaItem(1, "Segunda"),
            new DiaSemanaItem(2, "Terca"),
            new DiaSemanaItem(3, "Quarta"),
            new DiaSemanaItem(4, "Quinta"),
            new DiaSemanaItem(5, "Sexta"),
            new DiaSemanaItem(6, "Sabado"),
            new DiaSemanaItem(7, "Domingo")
        };

    public List<TurnoItem> SelectTurnos()
        => new()
        {
            new TurnoItem(1, "Manha"),
            new TurnoItem(2, "Tarde"),
            new TurnoItem(3, "Noite")
        };

    public List<AcolitoCompromissosEntity> SelectDiasAcolito(int? id)
    {
        if (id is null)
            return [];

        return Context.Set<AcolitoCompromissosEntity>()
            .AsNoTracking()
            .Where(d => d.Id_acolitos == id.Value)
            .OrderBy(d => d.Dia)
            .ToList();
    }

    public void UpdateDias(int? id, string diaAntes, string diaNovo)
        => UpdateDias(id, diaAntes, diaNovo, null);

    public void UpdateDias(int? id, string diaAntes, string diaNovo, string? motivo)
    {
        if (id is null)
            return;

        var registro = SelectDiasAcolito(id)
            .FirstOrDefault(x => x.dia == diaAntes)
            ?? throw new InvalidOperationException("Registro nao encontrado.");

        Context.Attach(registro);
        registro.dia = diaNovo;
        if (motivo is not null)
            registro.Motivo = motivo;
        Context.SaveChanges();
    }

    private void EnsureMotivoColumn()
    {
        var columns = Context.Database
            .SqlQueryRaw<string>("SELECT name AS Value FROM pragma_table_info('AcolitoCompromissos')")
            .ToList();

        if (columns.Contains("Motivo", StringComparer.OrdinalIgnoreCase))
            return;

        Context.Database.ExecuteSqlRaw("ALTER TABLE AcolitoCompromissos ADD COLUMN Motivo TEXT NOT NULL DEFAULT ''");
    }

    public void InsertMissaNova(MissaEntity dadosMissa)
    {
        Context.Set<MissaEntity>().Add(dadosMissa);
        Context.SaveChanges();
    }

    public MissaNovaDadosCompletos SelectMissaNova(int? id)
        => SelectAllMissasNova()
            .FirstOrDefault(m => m.idMissa == id)
            ?? throw new InvalidOperationException("Missa nao encontrada.");

    public void UpdateMissaNova(int? id, MissaEntity dadosMissa)
    {
        if (id is null)
            return;

        var registro = Context.Set<MissaEntity>().Find(id.Value)
            ?? throw new InvalidOperationException("Missa nao encontrada.");

        registro.IgrejaId = dadosMissa.IgrejaId;
        registro.Data = dadosMissa.Data;
        registro.Descricao = dadosMissa.Descricao;
        registro.QntAcolitos = dadosMissa.QntAcolitos;
        registro.Ativo = dadosMissa.Ativo;
        Context.SaveChanges();
    }

    public void DeleteMissaNova(int idMissa)
        => SetMissaAtiva(idMissa, false);

    public void SetMissaAtiva(int idMissa, bool ativo)
    {
        var registro = Context.Set<MissaEntity>().Find(idMissa)
            ?? throw new InvalidOperationException("Missa nao encontrada.");

        registro.Ativo = ativo;
        Context.SaveChanges();
    }

    public void InativarMissas(IEnumerable<int> missaIds)
    {
        var ids = missaIds.Distinct().ToList();
        if (ids.Count == 0)
            return;

        var missas = Context.Set<MissaEntity>()
            .Where(m => ids.Contains(m.Id))
            .ToList();

        foreach (var missa in missas)
            missa.Ativo = false;

        Context.SaveChanges();
    }

    public List<MissaNovaDadosCompletos> SelectAllMissasNova()
        => Context.Set<MissaEntity>()
            .Include(m => m.Igreja)
            .AsNoTracking()
            .OrderBy(m => m.Data)
            .Select(m => new MissaNovaDadosCompletos
            {
                Data = m.Data,
                Igreja = m.Igreja != null ? m.Igreja.Nome : string.Empty,
                idMissa = m.Id,
                Descricao = m.Descricao,
                Qnt_acolitos = m.QntAcolitos,
                Id_igreja = m.IgrejaId,
                Ativo = m.Ativo
            })
            .ToList();

    public List<MissaNovaDadosCompletos> SelectMissasAtivasNova()
        => SelectAllMissasNova()
            .Where(m => m.Ativo)
            .ToList();

    public List<AcolitoDisponibilidade> SelecionarAcolitoPorDias(int[] diasNum)
    {
        var dias = diasNum.Select(DiaSemanaFromLegacyId).ToHashSet();
        return QueryAcolitosDisponibilidade()
            .Where(a => dias.Contains(DiaSemanaFromLegacyId(a.IdDiaSemana)))
            .ToList();
    }

    public List<AcolitoDisponibilidade> SelecionarAcolitoDia(int dia, string diaQnaoPode, int turno)
    {
        var diaNaoPode = NormalizarData(diaQnaoPode);
        var compromissos = Context.Set<AcolitoCompromissosEntity>()
            .AsNoTracking()
            .ToList()
            .Where(d => d.dia == diaNaoPode)
            .Select(d => d.Id_acolitos)
            .ToHashSet();

        return QueryAcolitosDisponibilidade()
            .Where(a => a.IdDiaSemana == dia && a.Id_Turno == turno && !compromissos.Contains(a.Id_acolito))
            .ToList();
    }

    public AcolitoEntity? SelectAcolito(int? id)
    {
        if (id is null)
            return null;

        return Context.Set<AcolitoEntity>()
            .Include(a => a.Padrinho)
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id.Value);
    }

    public AcolitoEntity? SelectAcolitoPorNome(string nome)
    {
        string nomeNormalizado = NormalizarNomeAcolito(nome);
        return Context.Set<AcolitoEntity>()
            .AsNoTracking()
            .FirstOrDefault(a => a.Nome.ToUpper() == nomeNormalizado.ToUpper());
    }

    public void IncrementarMissasServidas(IEnumerable<int> acolitoIds)
    {
        var incrementosPorId = acolitoIds
            .GroupBy(id => id)
            .ToDictionary(g => g.Key, g => g.Count());

        if (incrementosPorId.Count == 0)
            return;

        var acolitos = Context.Set<AcolitoEntity>()
            .Where(a => incrementosPorId.Keys.Contains(a.Id))
            .ToList();

        foreach (var acolito in acolitos)
            acolito.MissasServidas += incrementosPorId[acolito.Id];

        Context.SaveChanges();
    }

    private IEnumerable<AcolitoDisponibilidade> QueryAcolitosDisponibilidade()
    {
        var disponibilidades = Context.Set<AcolitoDisponibilidadeEntity>()
            .Include(d => d.Acolito)
            .ThenInclude(a => a!.Padrinho)
            .AsNoTracking()
            .OrderBy(d => d.AcolitoId)
            .ThenBy(d => d.DiaDaSemana)
            .ThenBy(d => d.Turno)
            .ToList();

        var resultado = disponibilidades
            .Select(d => new AcolitoDisponibilidade
            {
                Nome = d.Acolito != null ? d.Acolito.Nome : string.Empty,
                PadrinhoId = d.Acolito?.PadrinhoId,
                NomePadrinho = d.Acolito?.Padrinho?.Nome ?? string.Empty,
                MissasAcompanhadasNecessarias = d.Acolito?.MissasAcompanhadasNecessarias ?? 0,
                MissasServidas = d.Acolito?.MissasServidas ?? 0,
                DiaSemana = DiaSemanaNome(d.DiaDaSemana),
                Turno = TurnoNome(d.Turno),
                IdDiaSemana = d.IdDiaSemana,
                Id_acolito = d.AcolitoId,
                Id_Turno = (int)d.Turno
            })
            .ToList();

        var idsComDisponibilidade = resultado.Select(a => a.Id_acolito).ToHashSet();
        var acolitosSemDisponibilidade = Context.Set<AcolitoEntity>()
            .AsNoTracking()
            .Where(a => !idsComDisponibilidade.Contains(a.Id))
            .OrderBy(a => a.Nome)
            .Select(a => new AcolitoDisponibilidade
            {
                Nome = a.Nome,
                Id_acolito = a.Id,
                PadrinhoId = a.PadrinhoId,
                NomePadrinho = a.Padrinho != null ? a.Padrinho.Nome : string.Empty,
                MissasAcompanhadasNecessarias = a.MissasAcompanhadasNecessarias,
                MissasServidas = a.MissasServidas
            })
            .ToList();

        resultado.AddRange(acolitosSemDisponibilidade);
        return resultado
            .OrderBy(a => a.Id_acolito)
            .ThenBy(a => a.IdDiaSemana)
            .ThenBy(a => a.Id_Turno)
            .ToList();
    }

    private static DayOfWeek DiaSemanaFromLegacyId(int id)
        => id == 7 ? DayOfWeek.Sunday : (DayOfWeek)id;

    private static string NormalizarData(string data)
    {
        if (DateTime.TryParse(data, out var dateTime))
            return dateTime.ToString("dd/MM/yyyy");

        return data;
    }

    private static Turno TurnoFromLegacyId(int id)
        => Enum.IsDefined(typeof(Turno), id) ? (Turno)id : Turno.None;

    private void EnsureAcolitoColumns()
    {
        EnsureColumn("Acolitos", "PadrinhoId", "INTEGER NULL");
        EnsureColumn("Acolitos", "MissasAcompanhadasNecessarias", "INTEGER NOT NULL DEFAULT 0");
        EnsureColumn("Acolitos", "MissasServidas", "INTEGER NOT NULL DEFAULT 0");
    }

    private void EnsureAcolitoNomeUnicoIndex()
    {
        var duplicados = Context.Set<AcolitoEntity>()
            .AsNoTracking()
            .GroupBy(a => a.Nome.ToUpper())
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicados.Count > 0)
            throw new InvalidOperationException("Existem acólitos com nomes duplicados. Corrija os cadastros antes de continuar.");

        Context.Database.ExecuteSqlRaw("CREATE UNIQUE INDEX IF NOT EXISTS IX_Acolitos_Nome_Unico ON Acolitos (Nome COLLATE NOCASE)");
    }

    private void ValidarNomeAcolitoUnico(string nome, int? ignorarId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new InvalidOperationException("O nome do acólito não pode ficar vazio.");

        bool existe = Context.Set<AcolitoEntity>()
            .AsNoTracking()
            .Any(a => a.Nome.ToUpper() == nome.ToUpper() && (ignorarId == null || a.Id != ignorarId.Value));

        if (existe)
            throw new InvalidOperationException("Já existe um acólito cadastrado com esse nome.");
    }

    private static string NormalizarNomeAcolito(string nome)
        => nome.Trim();

    private void EnsureColumn(string tableName, string columnName, string definition)
    {
        ValidarIdentificadorSql(tableName);
        ValidarIdentificadorSql(columnName);

        string pragmaSql = $"SELECT name AS Value FROM pragma_table_info('{tableName}')";
        var columns = Context.Database
            .SqlQueryRaw<string>(pragmaSql)
            .ToList();

        if (columns.Contains(columnName, StringComparer.OrdinalIgnoreCase))
            return;

        string alterSql = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {definition}";
        Context.Database.ExecuteSqlRaw(alterSql);
    }

    private static void ValidarIdentificadorSql(string identifier)
    {
        if (identifier.Any(c => !char.IsLetterOrDigit(c) && c != '_'))
            throw new InvalidOperationException("Identificador SQL invalido.");
    }

    private bool CriariaCicloDePadrinhos(int acolitoId, int padrinhoId)
    {
        int? atual = padrinhoId;
        HashSet<int> visitados = [];

        while (atual is not null)
        {
            if (atual == acolitoId)
                return true;

            if (!visitados.Add(atual.Value))
                return true;

            atual = Context.Set<AcolitoEntity>()
                .AsNoTracking()
                .Where(a => a.Id == atual.Value)
                .Select(a => a.PadrinhoId)
                .FirstOrDefault();
        }

        return false;
    }

    private static string DiaSemanaNome(DayOfWeek day)
        => day switch
        {
            DayOfWeek.Monday => "Segunda",
            DayOfWeek.Tuesday => "Terca",
            DayOfWeek.Wednesday => "Quarta",
            DayOfWeek.Thursday => "Quinta",
            DayOfWeek.Friday => "Sexta",
            DayOfWeek.Saturday => "Sabado",
            DayOfWeek.Sunday => "Domingo",
            _ => string.Empty
        };

    private static string TurnoNome(Turno turno)
        => turno switch
        {
            Turno.Morning => "Manha",
            Turno.Afternoon => "Tarde",
            Turno.Night => "Noite",
            _ => string.Empty
        };

    public sealed class AcolitoDisponibilidade
    {
        public string Nome { get; set; } = string.Empty;
        public int? PadrinhoId { get; set; }
        public string NomePadrinho { get; set; } = string.Empty;
        public int MissasAcompanhadasNecessarias { get; set; }
        public int MissasServidas { get; set; }
        public bool PrecisaAcompanhamento => PadrinhoId is not null && MissasServidas < MissasAcompanhadasNecessarias;
        public string DiaSemana { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
        public int IdDiaSemana { get; set; }
        public int Id_acolito { get; set; }
        public int Id_Turno { get; set; }
    }

    public sealed class MissaNovaDadosCompletos
    {
        public DateTime Data { get; set; }
        public string Igreja { get; set; } = string.Empty;
        public int idMissa { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Qnt_acolitos { get; set; }
        public int Id_igreja { get; set; }
        public bool Ativo { get; set; }
    }

    public sealed record DiaSemanaItem(int Id, string Nome);
    public sealed record TurnoItem(int Id, string Nome);
}
