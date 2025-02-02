using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppEscala.Models
{
    public class Dia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public int Id_acolitos { get; set; }

        public string dia { get; set; }
    }
}
