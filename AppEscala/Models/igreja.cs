using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppEscala.Models
{
    public class Igreja
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string nome { get; set; }
    }
}
