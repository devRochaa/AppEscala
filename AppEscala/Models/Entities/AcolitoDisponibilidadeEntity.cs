using AppEscala.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEscala.Models.Entities;

public class AcolitoDisponibilidadeEntity
{
    public int Id { get; set; }

    public int AcolitoId { get; set; }
    public AcolitoEntity? Acolito { get; set; }

    public Turno Turno { get; set; }

    public DayOfWeek DiaDaSemana { get; set; }

    [NotMapped]
    public int Id_acolitos
    {
        get => AcolitoId;
        set => AcolitoId = value;
    }

    [NotMapped]
    public int IdDiaSemana
    {
        get => DiaDaSemana == DayOfWeek.Sunday ? 7 : (int)DiaDaSemana;
        set => DiaDaSemana = value == 7 ? DayOfWeek.Sunday : (DayOfWeek)value;
    }

    [NotMapped]
    public int Id_turno
    {
        get => (int)Turno;
        set => Turno = Enum.IsDefined(typeof(Turno), value) ? (Turno)value : Turno.None;
    }
}
