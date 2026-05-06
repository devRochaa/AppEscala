using AppEscala.Models.DTOs;
using AppEscala.Models.Enums;
using AppEscala.Helpers;

namespace AppEscala;

public partial class form_smn : Form
{
    public string Dado { get; set; } = string.Empty;
    private Dictionary<DayOfWeek, TurnosDisponiveisDto> DiasDisponiveis = new();
    public form_smn()
    {
        InitializeComponent();
        UiTheme.Apply(this);
        WireTurnoHandlers(panel_days);
        foreach (var day in Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>())
        {
            if(day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                continue;
            DiasDisponiveis[day] = new TurnosDisponiveisDto();
        }
    }

    public Dictionary<DayOfWeek, TurnosDisponiveisDto> GetDiasDisponiveis() => 
        DiasDisponiveis;

    private void airButton1_Click(object sender, EventArgs e)
    {
        // Pega o texto do TextBox
        DialogResult = DialogResult.OK; // Define o resultado do diálogo
        this.Close();
    }
    private void CheckTurno_CheckedChanged(object? sender, EventArgs e)
    {
        if (sender is not CheckBox checkBox)
            return;

        var rawValue = checkBox.Tag?.ToString() ?? checkBox.Name;
        var parts = rawValue.Split('_');

        if (parts.Length != 2)
            return;

        if (!Enum.TryParse(parts[0], out DayOfWeek day))
            return;

        if (!Enum.TryParse(parts[1], out Turno turno))
            return;

        var diaDto = DiasDisponiveis.FirstOrDefault(d => d.Key == day);

        if (diaDto.Value == null)
            return;

        switch (turno)
        {
            case Turno.Morning:
                diaDto.Value.Morning = checkBox.Checked;
                break;
            case Turno.Afternoon:
                diaDto.Value.Afternoon = checkBox.Checked;
                break;
            case Turno.Night:
                diaDto.Value.Night = checkBox.Checked;
                break;
        }
    }

    private void check_tds_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = check_tds.Checked;

        foreach (var checkBox in GetTurnoCheckBoxes(panel_days))
        {
            checkBox.Checked = isChecked;
        }
    }

    private void WireTurnoHandlers(Control parent)
    {
        foreach (var checkBox in GetTurnoCheckBoxes(parent))
        {
            checkBox.CheckedChanged -= CheckTurno_CheckedChanged;
            checkBox.CheckedChanged += CheckTurno_CheckedChanged;
        }
    }

    private static IEnumerable<CheckBox> GetTurnoCheckBoxes(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is CheckBox checkBox)
                yield return checkBox;

            foreach (var child in GetTurnoCheckBoxes(control))
                yield return child;
        }
    }
}
