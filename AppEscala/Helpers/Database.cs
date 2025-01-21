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
        SQLiteConnection db;
        public void Inititialize() 
        {
            this.db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db"));
            this.db.CreateTable<igreja>();
            
        }
        public void InsertIgreja(igreja dados_igreja)
        {
            this.db.Insert(dados_igreja);
        }
        public TableQuery<igreja> SelectAllIgreja()
        {
            return this.db.Table<igreja>();                        
        }
        public void UpdateIgrejas(int id, igreja DadosAtualizados)
        {
            var registro = this.db.Find<igreja>(id);
            registro.id = DadosAtualizados.id;
            registro.nome = DadosAtualizados.nome;
            this.db.Update(registro);
        }
        public void DeleteIgrejas(int id)
        {
            var registro = this.db.Find<igreja>(id);
            this.db.Delete(registro);
        }

        public void SelectTeste()
        {
            string comando = "SELECT nome FROM igreja WHERE id = 1;";
            this.db.Query<igreja>(comando);
        }
    }
}
