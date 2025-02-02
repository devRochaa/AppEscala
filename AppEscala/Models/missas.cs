using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppEscala.Models
{
    public class Missas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Id_igreja { get; set; }

        public string Data { get; set; }

        public string Horario { get; set; }

        public string Descricao {  get; set; }

        public int Qnt_acolitos {  get; set; }
    }
}
