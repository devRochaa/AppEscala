using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace AppEscala.Models.Entities;

public class AcolitoCompromissosEntity
{
    public int Id { get; set; }
    public int Id_acolitos { get; set; }
    public DateOnly Dia { get; set; }
    public string Motivo { get; set; } = string.Empty;

    [NotMapped]
    public string dia
    {
        get => Dia.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"));
        set
        {
            if (DateOnly.TryParse(value, CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var parsed))
            {
                Dia = parsed;
                return;
            }

            if (DateTime.TryParse(value, CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var dateTime))
            {
                Dia = DateOnly.FromDateTime(dateTime);
                return;
            }

            Dia = default;
        }
    }
}
