namespace AppEscala.Models.Entities;

public class ConfiguracaoMissaEntity
{
    public int Id { get; set; }
    public int? IgrejaId { get; set; }
    public IgrejaEntity? Igreja { get; set; }
    public int? DiaDaSemana { get; set; }
    public int? QntAcolitos { get; set; }
    public TimeSpan? Horario { get; set; }
}
