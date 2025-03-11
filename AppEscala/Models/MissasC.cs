using SQLite;

namespace AppEscala.Models
{
    public class MissasC
    {      
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [NotNull]
            public int Id_igreja { get; set; }
            [NotNull]
            public string Data { get; set; }
            [NotNull]
            public string Horario { get; set; }
            [NotNull]
            public string Descricao { get; set; }
            [NotNull]
            public int Qnt_acolitos { get; set; }
        
    }
}
