using AppEscala.Helpers;
using AppEscala.Models.Entities;

namespace AppEscala;

public sealed class FormConfiguracoesMissa : Form
{
    private readonly Database db = new();
    private readonly Label titulo = new();
    private readonly Label descricao = new();
    private readonly ComboBox cmbIgreja = new();
    private readonly ComboBox cmbDia = new();
    private readonly ComboBox cmbQuantidade = new();
    private readonly ComboBox cmbHorario = new();
    private readonly Button btnAdicionar = new();
    private readonly Button btnRemover = new();
    private readonly Button btnFechar = new();
    private readonly DataGridView dgvConfiguracoes = new();

    public FormConfiguracoesMissa()
    {
        db.Initialize();
        ConfigurarInterface();
        CarregarOpcoes();
        CarregarConfiguracoes();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            db.Dispose();

        base.Dispose(disposing);
    }

    private void ConfigurarInterface()
    {
        Text = "Padroes para novas missas";
        StartPosition = FormStartPosition.CenterParent;
        MinimumSize = new Size(760, 520);
        ClientSize = new Size(820, 540);
        UiTheme.Apply(this);

        titulo.Text = "Padroes para novas missas";
        titulo.AutoSize = true;
        titulo.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        titulo.ForeColor = UiTheme.Text;

        descricao.Text = "Cadastre regras para preencher automaticamente quantidade de acolitos e/ou horario ao criar missas.";
        descricao.AutoSize = false;
        descricao.ForeColor = UiTheme.MutedText;

        cmbIgreja.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDia.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbQuantidade.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbHorario.DropDownStyle = ComboBoxStyle.DropDownList;

        btnAdicionar.Text = "Adicionar";
        btnAdicionar.Click += btnAdicionar_Click;

        btnRemover.Text = "Remover";
        btnRemover.Click += btnRemover_Click;

        btnFechar.Text = "Fechar";
        btnFechar.Click += (_, _) => Close();

        dgvConfiguracoes.AllowUserToAddRows = false;
        dgvConfiguracoes.AllowUserToDeleteRows = false;
        dgvConfiguracoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvConfiguracoes.MultiSelect = false;
        dgvConfiguracoes.ReadOnly = true;
        dgvConfiguracoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvConfiguracoes.Columns.Clear();
        dgvConfiguracoes.Columns.Add("id", "Id");
        dgvConfiguracoes.Columns.Add("igreja", "Igreja");
        dgvConfiguracoes.Columns.Add("dia", "Dia");
        dgvConfiguracoes.Columns.Add("quantidade", "Quantidade");
        dgvConfiguracoes.Columns.Add("horario", "Horario");
        dgvConfiguracoes.Columns["id"].Visible = false;

        Controls.AddRange(new Control[]
        {
            titulo,
            descricao,
            cmbIgreja,
            cmbDia,
            cmbQuantidade,
            cmbHorario,
            btnAdicionar,
            btnRemover,
            btnFechar,
            dgvConfiguracoes
        });

        Resize += (_, _) => AjustarLayout();
        AjustarLayout();
    }

    private void CarregarOpcoes()
    {
        cmbIgreja.Items.Clear();
        cmbIgreja.Items.Add(new ComboItem("Qualquer igreja", null));
        foreach (var igreja in db.SelectAllIgreja())
            cmbIgreja.Items.Add(new ComboItem(igreja.Nome, igreja.Id));
        cmbIgreja.SelectedIndex = 0;

        cmbDia.Items.Clear();
        cmbDia.Items.Add(new ComboItem("Qualquer dia", null));
        foreach (DayOfWeek dia in new[]
        {
            DayOfWeek.Sunday,
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday
        })
        {
            cmbDia.Items.Add(new ComboItem(NomeDiaSemana(dia), (int)dia));
        }
        cmbDia.SelectedIndex = 0;

        cmbQuantidade.Items.Clear();
        cmbQuantidade.Items.Add(new ComboItem("Nao alterar quantidade", null));
        for (int i = 0; i <= 15; i++)
            cmbQuantidade.Items.Add(new ComboItem(i.ToString(), i));
        cmbQuantidade.SelectedIndex = 0;

        cmbHorario.Items.Clear();
        cmbHorario.Items.Add("Nao alterar horario");
        TimeSpan horario = TimeSpan.Zero;
        for (int i = 0; i < 48; i++)
        {
            cmbHorario.Items.Add(horario.ToString(@"hh\:mm"));
            horario = horario.Add(TimeSpan.FromMinutes(30));
        }
        cmbHorario.SelectedIndex = 0;
    }

    private void CarregarConfiguracoes()
    {
        dgvConfiguracoes.Rows.Clear();
        foreach (var configuracao in db.SelectAllConfiguracoesMissa())
        {
            dgvConfiguracoes.Rows.Add(
                configuracao.Id,
                configuracao.Igreja,
                configuracao.DiaDaSemanaNome,
                configuracao.QuantidadeTexto,
                configuracao.HorarioTexto);
        }

        btnRemover.Enabled = dgvConfiguracoes.Rows.Count > 0;
    }

    private void btnAdicionar_Click(object? sender, EventArgs e)
    {
        int? igrejaId = cmbIgreja.SelectedItem is ComboItem igreja ? igreja.Value : null;
        int? diaDaSemana = cmbDia.SelectedItem is ComboItem dia ? dia.Value : null;
        int? quantidade = cmbQuantidade.SelectedItem is ComboItem quantidadeItem ? quantidadeItem.Value : null;
        TimeSpan? horario = cmbHorario.SelectedIndex > 0 && TimeSpan.TryParse(cmbHorario.Text, out var horarioSelecionado)
            ? horarioSelecionado
            : null;

        try
        {
            db.InsertConfiguracaoMissa(new ConfiguracaoMissaEntity
            {
                IgrejaId = igrejaId,
                DiaDaSemana = diaDaSemana,
                QntAcolitos = quantidade,
                Horario = horario
            });

            CarregarConfiguracoes();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Configuracoes de missa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnRemover_Click(object? sender, EventArgs e)
    {
        if (dgvConfiguracoes.CurrentRow is null)
        {
            MessageBox.Show("Selecione uma configuracao para remover.");
            return;
        }

        int id = Convert.ToInt32(dgvConfiguracoes.CurrentRow.Cells["id"].Value);
        db.DeleteConfiguracaoMissa(id);
        CarregarConfiguracoes();
    }

    private void AjustarLayout()
    {
        const int margin = 24;
        int contentWidth = Math.Max(320, ClientSize.Width - (margin * 2));
        int fieldGap = 10;
        int fieldWidth = Math.Max(130, (contentWidth - (fieldGap * 3) - 120) / 4);

        titulo.Location = new Point(margin, 22);
        descricao.Location = new Point(margin, 58);
        descricao.Size = new Size(contentWidth, 44);

        cmbIgreja.Location = new Point(margin, 116);
        cmbIgreja.Size = new Size(fieldWidth, 32);
        cmbDia.Location = new Point(cmbIgreja.Right + fieldGap, 116);
        cmbDia.Size = new Size(fieldWidth, 32);
        cmbQuantidade.Location = new Point(cmbDia.Right + fieldGap, 116);
        cmbQuantidade.Size = new Size(fieldWidth, 32);
        cmbHorario.Location = new Point(cmbQuantidade.Right + fieldGap, 116);
        cmbHorario.Size = new Size(fieldWidth, 32);
        btnAdicionar.Location = new Point(ClientSize.Width - margin - 110, 115);
        btnAdicionar.Size = new Size(110, 34);

        dgvConfiguracoes.Location = new Point(margin, 170);
        dgvConfiguracoes.Size = new Size(contentWidth, Math.Max(220, ClientSize.Height - 238));

        btnRemover.Location = new Point(margin, ClientSize.Height - 48);
        btnRemover.Size = new Size(100, 34);
        btnFechar.Location = new Point(ClientSize.Width - margin - 100, ClientSize.Height - 48);
        btnFechar.Size = new Size(100, 34);
    }

    private static string NomeDiaSemana(DayOfWeek dia)
        => dia switch
        {
            DayOfWeek.Sunday => "Domingo",
            DayOfWeek.Monday => "Segunda",
            DayOfWeek.Tuesday => "Terca",
            DayOfWeek.Wednesday => "Quarta",
            DayOfWeek.Thursday => "Quinta",
            DayOfWeek.Friday => "Sexta",
            DayOfWeek.Saturday => "Sabado",
            _ => string.Empty
        };

    private sealed record ComboItem(string Display, int? Value)
    {
        public override string ToString() => Display;
    }
}
