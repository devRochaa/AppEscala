using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscala.Models.Entities;

public class AcolitoEntity
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    [NotMapped]
    public int id
    {
        get => Id;
        set => Id = value;
    }
}
