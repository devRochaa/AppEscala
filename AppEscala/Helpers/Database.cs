using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscala.Models;
using Microsoft.Win32;
using SQLite;

namespace AppEscala.Helpers
{
    public class Database
    {
        SQLiteConnection db;
        public void Initialize()
        {
            try
            {
                this.db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db"));
                this.db.CreateTable<Acolitos>();
                this.db.CreateTable<Dia>();
                this.db.CreateTable<Dias_semanas>();
                this.db.CreateTable<Turno>();
                this.db.CreateTable<Disponibilidade>();
                this.db.CreateTable<Igreja>();
                this.db.CreateTable<MissasC>();

                this.db.BeginTransaction();
                try
                {
                    string[] dias_da_semana = { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado", "Domingo" };
                    foreach (string dia in dias_da_semana)
                    {
                        // Verifica se o dia já existe antes de inserir
                        var diaExistente = this.db.Table<Dias_semanas>().FirstOrDefault(d => d.Nome == dia);
                        if (diaExistente == null)
                        {
                            Dias_semanas novoDia = new Dias_semanas { Nome = dia };
                            this.db.Insert(novoDia);
                        }

                    }

                    string[] turnos = { "Manhã", "Tarde", "Noite", "-----" };
                    foreach (string turno in turnos)
                    {
                        var turnoExistente = this.db.Table<Turno>().FirstOrDefault(t => t.Nome == turno);
                        if (turnoExistente == null)
                        {
                            Turno novoTurno = new Turno { Nome = turno };
                            this.db.Insert(novoTurno);
                        }
                    }

                    this.db.Commit();
                }
                catch
                {
                    this.db.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar o banco de dados: " + ex.ToString());
            }
        }
        public int InsertAcolito(Acolitos AcolitoNome)
        {
            try
            {
                this.db.Insert(AcolitoNome); // Insere o registro
                return AcolitoNome.Id; // Retorna o ID correto
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir igreja: " + ex.Message);
            }
        }


        //public void InsertDisponibilidade(int id,)
        public void InsertDisponibilidade(Disponibilidade dados_d)
        {
            try
            {
                this.db.Insert(dados_d);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir igreja: " + ex.Message);
            }
        }

        public void InsertDias(Dia dados_dia)
        {
            try
            {
                this.db.Insert(dados_dia);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir igreja: " + ex.Message);
            }
        }

        public void InsertIgreja(Igreja dados_igreja)
        {
            try
            {
                this.db.Insert(dados_igreja);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir igreja: " + ex.Message);
            }
        }
        public TableQuery<Igreja> SelectAllIgreja()
        {
            return this.db.Table<Igreja>();
        }
        public List<Acolitos> SelectAllAcolitos()
        {
            try
            {
                string comando = "SELECT Nome FROM Acolitos;";
                return this.db.Query<Acolitos>(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
        }
        public void UpdateIgrejas(int id, Igreja DadosAtualizados)
        {
            try
            {
                var registro = this.db.Find<Igreja>(id);
                if (registro != null)
                {

                    registro.nome = DadosAtualizados.nome;
                    this.db.Update(registro);

                }
                else
                {
                    throw new Exception("Registro não encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar igreja: " + ex.Message);
            }
        }
        public void DeleteIgrejas(int id)
        {
            try
            {
                var registro = this.db.Find<Igreja>(id);
                if (registro != null)
                {
                    this.db.Delete(registro);
                }
                else
                {
                    throw new Exception("Registro não encontrado.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir igreja: " + ex.Message);
            }
        }

        public Igreja SelectTeste()
        {
            try
            {
                string comando = "SELECT nome FROM igreja WHERE id = 1;";
                return this.db.Query<Igreja>(comando).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
        }
        public class AcolitoDisponibilidade
        {
            public string Nome { get; set; }
            public string DiaSemana { get; set; }
            public string Turno { get; set; }
            public int IdDiaSemana { get; set; }
            public int Id_acolito { get; set; }
            public int Id_Turno { get; set; }
        }
        public List<AcolitoDisponibilidade> ListaUserAcolitos()
        {
            try
            {
                string comando = @"SELECT a.Nome AS Nome, s.Nome AS DiaSemana, t.Nome AS Turno 
                    , d.IdDiaSemana AS IdDiaSemana, a.Id AS Id_acolito 
                    FROM Acolitos AS a 
                    INNER JOIN Disponibilidade AS d ON a.id = d.Id_acolitos 
                    INNER JOIN Dias_semanas AS s ON d.IdDiaSemana = s.Id 
                    INNER JOIN Turno AS t ON d.Id_turno = t.Id ORDER BY a.Id";
                return this.db.Query<AcolitoDisponibilidade>(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
        }

        public List<AcolitoDisponibilidade> Acolitos_Dias(int? id)
        {
            try
            {
                string comando = @"SELECT a.Nome AS Nome, s.Nome AS DiaSemana, t.Nome AS Turno 
                    , d.IdDiaSemana AS IdDiaSemana, a.Id AS Id_acolito, t.Id AS Id_Turno
                    FROM Acolitos AS a 
                    INNER JOIN Disponibilidade AS d ON a.id = d.Id_acolitos 
                    INNER JOIN Dias_semanas AS s ON d.IdDiaSemana = s.Id 
                    INNER JOIN Turno AS t ON d.Id_turno = t.Id WHERE a.Id = " + id + ";";
                return this.db.Query<AcolitoDisponibilidade>(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
        }

        public bool UpdateTurnoAcolito(int? id, int id_dia, int id_turno, int novo_id)
        {
            try
            {
                string comando = "SELECT * FROM Disponibilidade WHERE Id_acolitos = " + id + " AND IdDiaSemana = " + id_dia + " AND Id_Turno = " + id_turno + ";";
                Disponibilidade registro = this.db.Query<Disponibilidade>(comando).FirstOrDefault(); ;
                if (registro != null)
                {
                    registro.Id_turno = novo_id;
                    this.db.Update(registro);
                    return true;
                }
                else
                {
                    throw new Exception("Registro não encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar acolito: " + ex.Message);
            }
        }

        public TableQuery<Dias_semanas> SelectDiasSemana()
        {
            try
            {
                return this.db.Table<Dias_semanas>();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar igreja: " + ex.Message);
            }
        }

        public TableQuery<Turno> SelectTurnos()
        {
            try
            {
                return this.db.Table<Turno>();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar igreja: " + ex.Message);
            }
        }

        public List<Dia> SelectDiasAcolito(int? id)
        {
            try
            {
                string comando = "SELECT * FROM Dia WHERE Id_Acolitos = " + id;
                return this.db.Query<Dia>(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }
            
        }

        public void UpdateDias(int? id, string diaAntes, string diaNovo)
        {
            try
            {

                var registro = db.Table<Dia>().FirstOrDefault(x => x.Id_acolitos == id && x.dia == diaAntes);
                if (registro != null)
                {

                    registro.dia = diaNovo;
                    this.db.Update(registro);

                }
                else
                {
                    throw new Exception("Registro não encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar igreja: " + ex.Message);
            }
        }

        //readonly SQLiteAsyncConnection _conn;
        //public Database(string path)
        //{
        //    _conn = new SQLiteAsyncConnection(path);
        //    _conn.CreateTableAsync<Acolitos>().Wait();
        //    _conn.CreateTableAsync<Dia>().Wait();
        //    _conn.CreateTableAsync<Dias_semanas>().Wait();
        //    _conn.CreateTableAsync<Turno>().Wait();
        //    _conn.CreateTableAsync<Disponibilidade>().Wait();
        //    _conn.CreateTableAsync<Igreja>().Wait();
        //    _conn.CreateTableAsync<Missas>().Wait();
        //}

        //public async Task Inititialize()
        //{
        //    string[] dias_semanas = {"Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado","Domingo"};

        //    foreach (string dia in dias_semanas)
        //    {
        //        var novoDia = new Dias_semanas { Nome = dia };
        //        await _conn.InsertAsync(novoDia);
        //    }

        //    string[] turnos = {"Manhã", "Tarde","Noite"};
        //    foreach (string turno in turnos)
        //    {
        //        var novoTurno = new Turno { Nome = turno };
        //        await _conn.InsertAsync(novoTurno);
        //    }
        //}

        //public Task<int> Insert(Acolitos a)
        //{ 
        //    return _conn.InsertAsync(a);
        //}

        //public Task<List<Acolitos>> Update(Acolitos a)
        //{
        //    string sql = "UPDATE Acolitos SET nome= ? WHERE id = ?";
        //    return _conn.QueryAsync<Acolitos>(sql, a.Nome, a.Id);
        //}


        //public Task<int> Delete(int id)
        //{
        //    return _conn.Table<Acolitos>().DeleteAsync(i => i.Id == id);
        //}

        //public Task<List<Acolitos>> GetAll() 
        //{
        //    return _conn.Table<Acolitos>().ToListAsync();
        //}


        //public Task<List<Acolitos>> Search(string q) 
        //{
        //    string sql = "SELECT * from Acolitos WHERE id LIKE '%" + q + "%'";
        //    return _conn.QueryAsync<Acolitos>(sql);
        //}

        //public Task<List<Acolitos>> SelectListaAcolitos()
        //{
        //    string sql = "SELECT a.nome, s.dia_semana, t.turno, d.id_dia_semana, a.id " +
        //            "FROM acolitos AS a " +
        //            "LEFT JOIN disponibilidade AS d ON a.id = d.id_acolito " +
        //            "RIGHT JOIN dias_semana AS s ON d.id_dia_semana = s.id " +
        //            "RIGHT JOIN turno AS t ON d.id_turno = t.id ORDER BY a.id";

        //    return _conn.QueryAsync<Acolitos>(sql);
        //}

    }
}
