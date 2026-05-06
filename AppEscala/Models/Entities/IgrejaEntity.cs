using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscala.Models.Entities;

public class IgrejaEntity
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    [NotMapped]
    public int id
    {
        get => Id;
        set => Id = value;
    }

    [NotMapped]
    public string nome
    {
        get => Nome;
        set => Nome = value;
    }
}
