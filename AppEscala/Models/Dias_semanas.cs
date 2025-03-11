using SQLite;

namespace AppEscala.Models
{
    public class Dias_semanas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nome { get; set; }
    }
}
