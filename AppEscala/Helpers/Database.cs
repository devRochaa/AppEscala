using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEscala.Models;
using SQLite;

namespace AppEscala.Helpers
{
    public class Database
    {
        readonly SQLiteAsyncConnection _conn;
        public Database(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Acolitos>().Wait();
            _conn.CreateTableAsync<Dia>().Wait();
            _conn.CreateTableAsync<Dias_semanas>().Wait();
            _conn.CreateTableAsync<Turno>().Wait();
            _conn.CreateTableAsync<Disponibilidade>().Wait();
            _conn.CreateTableAsync<Igreja>().Wait();
            _conn.CreateTableAsync<Missas>().Wait();
        }
        
        public async Task Inititialize()
        {
            string[] dias_semanas = {"Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado","Domingo"};

            foreach (string dia in dias_semanas)
            {
                var novoDia = new Dias_semanas { Nome = dia };
                await _conn.InsertAsync(novoDia);
            }

            string[] turnos = {"Manhã", "Tarde","Noite"};
            foreach (string turno in turnos)
            {
                var novoTurno = new Turno { Nome = turno };
                await _conn.InsertAsync(novoTurno);
            }
        }

        public Task<int> Insert(Acolitos a)
        { 
            return _conn.InsertAsync(a);
        }

        public Task<List<Acolitos>> Update(Acolitos a)
        {
            string sql = "UPDATE Acolitos SET nome= ? WHERE id = ?";
            return _conn.QueryAsync<Acolitos>(sql, a.Nome, a.Id);
        }
       

        public Task<int> Delete(int id)
        {
            return _conn.Table<Acolitos>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Acolitos>> GetAll() 
        {
            return _conn.Table<Acolitos>().ToListAsync();
        }


        public Task<List<Acolitos>> Search(string q) 
        {
            string sql = "SELECT * from Acolitos WHERE id LIKE '%" + q + "%'";
            return _conn.QueryAsync<Acolitos>(sql);
        }

        public Task<List<Acolitos>> SelectListaAcolitos()
        {
            string sql = "SELECT a.nome, s.dia_semana, t.turno, d.id_dia_semana, a.id " +
                    "FROM acolitos AS a " +
                    "LEFT JOIN disponibilidade AS d ON a.id = d.id_acolito " +
                    "RIGHT JOIN dias_semana AS s ON d.id_dia_semana = s.id " +
                    "RIGHT JOIN turno AS t ON d.id_turno = t.id ORDER BY a.id";

            return _conn.QueryAsync<Acolitos>(sql);
        }

        //SQLiteConnection db;
        //public void Inititialize() 
        //{
        //    this.db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db"));
        //    this.db.CreateTable<Igreja>();

        //}
        //public void InsertIgreja(Igreja dados_igreja)
        //{
        //    this.db.Insert(dados_igreja);
        //}
        //public TableQuery<Igreja> SelectAllIgreja()
        //{
        //    return this.db.Table<Igreja>();                        
        //}
        //public void UpdateIgrejas(int id, Igreja DadosAtualizados)
        //{
        //    var registro = this.db.Find<Igreja>(id);
        //    registro.id = DadosAtualizados.id;
        //    registro.nome = DadosAtualizados.nome;
        //    this.db.Update(registro);
        //}
        //public void DeleteIgrejas(int id)
        //{
        //    var registro = this.db.Find<Igreja>(id);
        //    this.db.Delete(registro);
        //}

        //public void SelectTeste()
        //{
        //    string comando = "SELECT nome FROM igreja WHERE id = 1;";
        //    this.db.Query<Igreja>(comando);
        //}
    }
}
