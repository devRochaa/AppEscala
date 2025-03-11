using SQLite;

namespace AppEscala.Models
{
    public class Disponibilidade
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public int Id_acolitos { get; set; }
        [NotNull]
        public int Id_turno { get; set; }
        [NotNull]
        public int IdDiaSemana { get; set; }
    }
}
