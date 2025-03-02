using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscala.Models;
using Microsoft.Win32;
using SQLite;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

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

        public List<AcolitoDisponibilidade> BuscarUserAcolitos(string inputNome)
        {
            try
            {
                string comando = @"SELECT a.Nome AS Nome, s.Nome AS DiaSemana, t.Nome AS Turno 
                    , d.IdDiaSemana AS IdDiaSemana, a.Id AS Id_acolito 
                    FROM Acolitos AS a 
                    INNER JOIN Disponibilidade AS d ON a.id = d.Id_acolitos 
                    INNER JOIN Dias_semanas AS s ON d.IdDiaSemana = s.Id 
                    INNER JOIN Turno AS t ON d.Id_turno = t.Id WHERE a.Nome LIKE '%" + inputNome + "%' ORDER BY a.Id";
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

        public void InsertMissa(MissasC dadosMissa)
        {
            try
            {
                this.db.Insert(dadosMissa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir igreja: " + ex.Message);
            }
        }

        public class MissasDadosCompletos
        {
            public string Data { get; set; }
            public string Horario { get; set; }
            public string Igreja { get; set; }
            public int idMissa { get; set; }
            public string Descricao { get; set; }
            public int Qnt_acolitos { get; set; }
        }

        public List<MissasDadosCompletos> SelectAllMissas()
        {
            try
            {
                string comando = "SELECT m.Data AS Data, m.Horario AS Horario, i.nome as Igreja, m.Id AS idMissa, m.Descricao AS Descricao, m.Qnt_acolitos AS Qnt_acolitos from MissasC m " +
                "INNER JOIN Igreja i ON m.Id_igreja = i.id;";
                return this.db.Query<MissasDadosCompletos>(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }

        }
        public MissasDadosCompletos SelectMissa(int? id)
        {

            try
            {
                string comando = "SELECT m.Data AS Data, m.Horario AS Horario, i.nome as Igreja, m.Id AS idMissa, m.Descricao AS Descricao, m.Qnt_acolitos AS Qnt_acolitos from MissasC m " +
                "INNER JOIN Igreja i ON m.Id_igreja = i.id WHERE m.Id = " + id;
                return this.db.Query<MissasDadosCompletos>(comando).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar consulta: " + ex.Message);
            }

        }

        public void DeleteMissa(int idMissa)
        {
            try
            {
                var registro = this.db.Find<MissasC>(idMissa);
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
    }
}
