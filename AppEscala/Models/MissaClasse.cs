using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppEscala.Models
{
    public class MissaClasse
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int Id_igreja { get; set; }
        [NotNull]
        public DateTime Data { get; set; }
        [NotNull]
        public string Descricao { get; set; }
        [NotNull]
        public int Qnt_acolitos { get; set; }
    }
}
