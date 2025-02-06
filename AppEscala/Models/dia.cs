using SQLite;

namespace AppEscala.Models
{
    public class Dia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public int Id_acolitos { get; set; }
        [NotNull]
        public string dia { get; set; }
    }
}
