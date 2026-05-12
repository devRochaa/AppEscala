using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscala.Models.Entities;

public class MissaEntity
{
    public int Id { get; set; }
    public int IgrejaId { get; set; }
    public IgrejaEntity? Igreja { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int QntAcolitos { get; set; }
    public bool Ativo { get; set; } = true;

    [NotMapped]
    public int Id_igreja
    {
        get => IgrejaId;
        set => IgrejaId = value;
    }

    [NotMapped]
    public int Qnt_acolitos
    {
        get => QntAcolitos;
        set => QntAcolitos = value;
    }
}
