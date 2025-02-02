using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppEscala.Models
{
    public class Disponibilidade
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Id_acolitos { get; set; }

        public int Id_turno { get; set; }

        public int id_dia_semana { get; set; }
    }
}
