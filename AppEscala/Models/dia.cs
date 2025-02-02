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
