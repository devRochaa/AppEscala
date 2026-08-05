using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscala.Models.Entities;

public class AcolitoEntity
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public int? PadrinhoId { get; set; }

    public AcolitoEntity? Padrinho { get; set; }

    public List<AcolitoEntity> Afilhados { get; set; } = [];

    public int MissasAcompanhadasNecessarias { get; set; }

    public int MissasServidas { get; set; }

    [NotMapped]
    public bool PrecisaAcompanhamento =>
        PadrinhoId is not null && MissasServidas < MissasAcompanhadasNecessarias;

    [NotMapped]
    public int id
    {
        get => Id;
        set => Id = value;
    }
}
