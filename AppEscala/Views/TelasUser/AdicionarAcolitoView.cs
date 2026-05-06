using AppEscala.Models.DTOs;
using AppEscala.Models.Entities;
using AppEscala.Models.Enums;
using AppEscala.Helpers;
namespace AppEscala;

public partial class AdicionarAcolitoView : UserControl
{
    private readonly Panel panelDisponibilidade = new();
    private readonly Panel panelSemana = new();
    private readonly Panel panelFimSemana = new();
    private readonly Panel panelDados = new();
    private readonly Panel panelIndisponibilidade = new();
    private readonly DataGridView dgvDatasIndisponiveis = new();
    private readonly Button btnRemoverData = new();
    private readonly Button btnVoltar = new();
    private readonly TextBox txtMotivoData = new();
    private readonly ComboBox cmbPadrinho = new();
    private readonly NumericUpDown numMissasNecessarias = new();
    private readonly Label lblMissasAcompanhadas = new();
    private readonly Dictionary<(DayOfWeek Dia, Turno Turno), CheckBox> disponibilidadeChecks = new();

    public AdicionarAcolitoView()
    {
        InitializeComponent();
        ConfigurarInterface();
        db = new Database();
        db.Initialize();
        dateTimePicker1.Value = DateTime.Today;
        CarregarPadrinhos();
    }

    private readonly Database db;
    private readonly Dictionary<DayOfWeek, TurnosDisponiveisDto> DiasDisponiveis = new();
    public event EventHandler? VoltarRequested;

    private void check_semana_CheckedChanged(object sender, EventArgs e)
    {
        AlternarChecksGrupo([DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday]);
    }

    private void check_fimDsmn_CheckedChanged(object sender, EventArgs e)
    {
        AlternarChecksGrupo([DayOfWeek.Saturday, DayOfWeek.Sunday]);
    }

    private void RemoverDiasDisponiveis(params DayOfWeek[] dias)
    {
        foreach (var dia in dias)
            DiasDisponiveis.Remove(dia);
    }

    List<(DateOnly Data, string Motivo)> datas = new();
    private void button1_Click(object sender, EventArgs e)
    {
        DateOnly data = DateOnly.FromDateTime(dateTimePicker1.Value.Date);

        foreach (var cadastrada in datas)
        {
            if (cadastrada.Data == data)
            {
                MessageBox.Show("Você já adicionou essa data!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        string motivo = txtMotivoData.Text.Trim();
        datas.Add((data, motivo));
        dgvDatasIndisponiveis.Rows.Add(FormatarData(data), ObterNomeDiaSemana(dateTimePicker1.Value), motivo);
        txtMotivoData.Clear();
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        listView1.View = View.List;
        listView1.Alignment = ListViewAlignment.Top;


    }
    private void AddDias(int Id)
    {
        foreach (var data in ObterDatasIndisponiveisParaSalvar())
        {
            AcolitoCompromissosEntity dados_dia = new()
            {
                Id_acolitos = Id,
                Dia = data.Data,
                Motivo = data.Motivo
            };
            db.InsertDias(dados_dia);
        }

        //    try
        //{
        //    Conexao = new MySqlConnection(data_source);

        //    MySqlCommand cmd = new MySqlCommand();
        //    cmd.Connection = Conexao;
        //    Conexao.Open();
        //    cmd.CommandText = "INSERT INTO dia (id_acolito,dia) VALUES (@Id, @dia)";
        //    foreach (string data in datas)
        //    {
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@Id", Id);
        //        cmd.Parameters.AddWithValue("@dia", data);
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        //catch (MySqlException ex)
        //{
        //    MessageBox.Show($"Erro MySQL: {ex.Message}");
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show($"Erro geral: {ex.Message}");
        //}
        //finally
        //{
        //    if (Conexao != null && Conexao.State == ConnectionState.Open)
        //    {
        //        Conexao.Close();
        //    }
        //}

    }

    private void AdicionarDisponibilidades(int acolitoId)
    {
        AtualizarDiasDisponiveisPelosChecks();

        foreach (var dia in DiasDisponiveis)
        {
            if (dia.Value.Morning)
                db.InsertDisponibilidade(new AcolitoDisponibilidadeEntity { AcolitoId = acolitoId, DiaDaSemana = dia.Key, Turno = Turno.Morning });

            if (dia.Value.Afternoon)
                db.InsertDisponibilidade(new AcolitoDisponibilidadeEntity { AcolitoId = acolitoId, DiaDaSemana = dia.Key, Turno = Turno.Afternoon });

            if (dia.Value.Night)
                db.InsertDisponibilidade(new AcolitoDisponibilidadeEntity { AcolitoId = acolitoId, DiaDaSemana = dia.Key, Turno = Turno.Night });
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            MessageBox.Show("O nome do acólito não pode estar vazio!",
            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        AtualizarDiasDisponiveisPelosChecks();

        AcolitoEntity novoAcolito = new()
        {
            Nome = txtNome.Text.Trim(),
            PadrinhoId = ObterPadrinhoSelecionadoId(),
            MissasAcompanhadasNecessarias = (int)numMissasNecessarias.Value,
            MissasServidas = 0
        };
        int id_inserido;
        try
        {
            id_inserido = db.InsertAcolito(novoAcolito);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
        if (DiasDisponiveis.Count != 0)
        {
            AdicionarDisponibilidades(id_inserido);
        }
        if (datas.Count != 0)
        {
            AddDias(id_inserido);
        }

        MessageBox.Show("O Acólito foi adicionado");
        txtNome.Clear();
        listView1.Items.Clear();
        dgvDatasIndisponiveis.Rows.Clear();
        datas.Clear();
        DiasDisponiveis.Clear();
        cmbPadrinho.SelectedIndex = 0;
        numMissasNecessarias.Value = 0;
        check_semana.Checked = false;
        check_fimDsmn.Checked = false;
        foreach (var checkBox in disponibilidadeChecks.Values)
            checkBox.Checked = false;

        //if (string.IsNullOrEmpty(txtNome.Text)) 
        //{
        //    MessageBox.Show("O nome do acólito não pode estar vazio!",
        //    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    return;
        //}
        //try
        //{

        //    //Criar conexão com mysql
        //    Conexao = new MySqlConnection(data_source);
        //    Conexao.Open();
        //    MySqlCommand cmd = new MySqlCommand();
        //    cmd.Connection = Conexao;
        //    cmd.CommandText = "INSERT INTO acolitos (nome) VALUES (@nome); SELECT LAST_INSERT_ID();";

        //    cmd.Parameters.AddWithValue("@nome", txtNome.Text);

        //    //foreach (string data in datas)
        //    //{ 
        //    //string sql3 = "INSERT INTO dia (id_acolito,dia) VALUES (,)";  
        //    //}


        //    //executar comando insert


        //    object result = cmd.ExecuteScalar();
        //    int idRetorno = Convert.ToInt32(result);

        //    //adiciona dias da semana:
        //    ProcessarSemana(seg, idRetorno, 1); ProcessarSemana(ter, idRetorno, 2); ProcessarSemana(qua, idRetorno, 3);
        //    ProcessarSemana(qui, idRetorno, 4); ProcessarSemana(sex, idRetorno, 5);
        //    ProcessarSemana(sab, idRetorno, 6); ProcessarSemana(dom, idRetorno, 7);

        //    //adiciona dias:
        //    if(datas.Count != 0)
        //    {
        //        AddDias(idRetorno);
        //    }


        //    MessageBox.Show("O Acólito foi adicionado");
        //}
        //catch (MySqlException ex)
        //{
        //    MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
        //    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //finally
        //{
        //    if (Conexao != null && Conexao.State == ConnectionState.Open)
        //    {
        //        Conexao.Close();
        //    }
        //}
    }

    private void UserControl2_Load(object sender, EventArgs e)
    {
        AjustarLayout();
    }

    private void ConfigurarInterface()
    {
        UiTheme.Apply(this);
        AutoScroll = true;
        UiTheme.StyleTitle(label1);
        label1.Text = "Novo acólito";
        label2.Text = "Nome";
        label3.Text = "Dias em que não pode servir";
        txtNome.PlaceholderText = "Nome completo";
        txtMotivoData.PlaceholderText = "Motivo opcional";
        cmbPadrinho.DropDownStyle = ComboBoxStyle.DropDownList;
        numMissasNecessarias.Minimum = 0;
        numMissasNecessarias.Maximum = 1000;
        button1.Text = "+";
        button2.Text = "Salvar acólito";
        btnVoltar.Text = "Voltar";
        btnVoltar.Size = new Size(84, 36);
        btnVoltar.Click += (_, _) => VoltarRequested?.Invoke(this, EventArgs.Empty);
        Controls.Add(btnVoltar);
        listView1.View = View.List;
        listView1.Alignment = ListViewAlignment.Top;
        listView1.Visible = false;
        check_semana.Visible = false;
        check_fimDsmn.Visible = false;
        ConfigurarPainelDisponibilidade();
        ConfigurarGridDatasIndisponiveis();
        ConfigurarBotaoRemoverData();
        ConfigurarPainelDados();
        ConfigurarPainelIndisponibilidade();

        txtNome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        txtMotivoData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        Resize += (_, _) => AjustarLayout();
    }

    private void ConfigurarPainelDisponibilidade()
    {
        panelDisponibilidade.BackColor = UiTheme.Background;
        panelDisponibilidade.Controls.Clear();
        panelSemana.Controls.Clear();
        panelFimSemana.Controls.Clear();

        panelDisponibilidade.BackColor = UiTheme.Surface;
        panelDisponibilidade.BorderStyle = BorderStyle.FixedSingle;

        Label titulo = new()
        {
            AutoSize = true,
            Text = "Dias em que pode servir",
            Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
            ForeColor = UiTheme.Text,
            Location = new Point(20, 148)
        };

        Label lblPadrinho = new()
        {
            AutoSize = true,
            Text = "Padrinho",
            ForeColor = UiTheme.Text,
            Location = new Point(20, 82)
        };

        cmbPadrinho.Location = new Point(20, 104);
        cmbPadrinho.Size = new Size(208, 32);

        lblMissasAcompanhadas.AutoSize = true;
        lblMissasAcompanhadas.Text = "Missas acomp.";
        lblMissasAcompanhadas.ForeColor = UiTheme.Text;
        lblMissasAcompanhadas.Location = new Point(240, 82);

        numMissasNecessarias.Location = new Point(240, 104);
        numMissasNecessarias.Size = new Size(96, 32);

        panelSemana.Location = new Point(20, 178);
        panelSemana.Size = new Size(456, 170);
        CriarGrupoDias(panelSemana, new[]
        {
            (DayOfWeek.Monday, "Segunda"),
            (DayOfWeek.Tuesday, "Terça"),
            (DayOfWeek.Wednesday, "Quarta"),
            (DayOfWeek.Thursday, "Quinta"),
            (DayOfWeek.Friday, "Sexta")
        });

        panelFimSemana.Location = new Point(20, 348);
        panelFimSemana.Size = new Size(456, 70);
        CriarGrupoDias(panelFimSemana, new[]
        {
            (DayOfWeek.Saturday, "Sábado"),
            (DayOfWeek.Sunday, "Domingo")
        });

        Button btnMarcarSemana = new()
        {
            Text = "Marcar semana",
            Location = new Point(20, 416),
            Size = new Size(140, 34)
        };
        btnMarcarSemana.Click += (_, _) => AlternarChecksGrupo([DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday]);

        Button btnMarcarFimSemana = new()
        {
            Text = "Marcar final de semana",
            Location = new Point(172, 416),
            Size = new Size(170, 34)
        };
        btnMarcarFimSemana.Click += (_, _) => AlternarChecksGrupo([DayOfWeek.Saturday, DayOfWeek.Sunday]);

        panelDisponibilidade.Controls.AddRange(new Control[] { label2, txtNome, lblPadrinho, cmbPadrinho, lblMissasAcompanhadas, numMissasNecessarias, titulo, panelSemana, panelFimSemana, btnMarcarSemana, btnMarcarFimSemana });
        Controls.Add(panelDisponibilidade);
    }

    private void CriarGrupoDias(Panel parent, (DayOfWeek Dia, string Nome)[] dias)
    {
        int y = 0;
        int index = 0;
        foreach (var dia in dias)
        {
                Panel row = new()
                {
                    Location = new Point(0, y),
                    Size = new Size(442, 24),
                BackColor = index % 2 == 0 ? Color.FromArgb(248, 250, 252) : Color.White
            };

            Label titulo = new()
            {
                AutoSize = true,
                Text = dia.Nome,
                ForeColor = UiTheme.Text,
                Location = new Point(12, 6)
            };

            row.Controls.Add(titulo);
            CriarCheckTurno(row, dia.Dia, Turno.Morning, "", 168, 5);
            CriarCheckTurno(row, dia.Dia, Turno.Afternoon, "", 258, 5);
            CriarCheckTurno(row, dia.Dia, Turno.Night, "", 348, 5);
            parent.Controls.Add(row);
                y += 32;
            index++;
        }
    }

    private void CriarCheckTurno(Control parent, DayOfWeek dia, Turno turno, string texto, int x, int y)
    {
        CheckBox checkBox = new()
        {
            AutoSize = true,
            Text = texto,
            Location = new Point(x, y)
        };

        disponibilidadeChecks[(dia, turno)] = checkBox;
        parent.Controls.Add(checkBox);
    }

    private void ConfigurarGridDatasIndisponiveis()
    {
        dgvDatasIndisponiveis.AllowUserToAddRows = false;
        dgvDatasIndisponiveis.AllowUserToDeleteRows = false;
        dgvDatasIndisponiveis.BackgroundColor = UiTheme.Surface;
        dgvDatasIndisponiveis.BorderStyle = BorderStyle.None;
        dgvDatasIndisponiveis.Columns.Clear();
        dgvDatasIndisponiveis.MultiSelect = false;
        dgvDatasIndisponiveis.ReadOnly = true;
        dgvDatasIndisponiveis.RowHeadersVisible = false;
        dgvDatasIndisponiveis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDatasIndisponiveis.CellContentClick += dgvDatasIndisponiveis_CellContentClick;
        dgvDatasIndisponiveis.Columns.Add(new DataGridViewTextBoxColumn { Name = "data", HeaderText = "Data", Width = 120 });
        dgvDatasIndisponiveis.Columns.Add(new DataGridViewTextBoxColumn { Name = "dia", HeaderText = "Dia", Width = 120 });
        dgvDatasIndisponiveis.Columns.Add(new DataGridViewTextBoxColumn { Name = "motivo", HeaderText = "Motivo", Width = 150 });
        dgvDatasIndisponiveis.Columns.Add(new DataGridViewButtonColumn
        {
            Name = "remover",
            HeaderText = "",
            Width = 38,
            Text = "X",
            UseColumnTextForButtonValue = true
        });
    }

    private void ConfigurarBotaoRemoverData()
    {
        btnRemoverData.Text = "Remover";
        btnRemoverData.Visible = false;
        btnRemoverData.Click += (_, _) => RemoverDataSelecionada();
    }

    private void dgvDatasIndisponiveis_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvDatasIndisponiveis.Columns[e.ColumnIndex].Name != "remover")
            return;

        RemoverDataNaLinha(e.RowIndex);
    }

    private void RemoverDataSelecionada()
    {
        if (dgvDatasIndisponiveis.CurrentRow is null || dgvDatasIndisponiveis.CurrentRow.IsNewRow)
            return;

        string? data = dgvDatasIndisponiveis.CurrentRow.Cells["data"].Value?.ToString();
        if (TryParseData(data, out var dataParsed))
            datas.RemoveAll(item => item.Data == dataParsed);

        dgvDatasIndisponiveis.Rows.RemoveAt(dgvDatasIndisponiveis.CurrentRow.Index);
    }

    private void RemoverDataNaLinha(int rowIndex)
    {
        string? data = dgvDatasIndisponiveis.Rows[rowIndex].Cells["data"].Value?.ToString();
        if (TryParseData(data, out var dataParsed))
            datas.RemoveAll(item => item.Data == dataParsed);

        dgvDatasIndisponiveis.Rows.RemoveAt(rowIndex);
    }

    private void AtualizarDiasDisponiveisPelosChecks()
    {
        DiasDisponiveis.Clear();

        foreach (var item in disponibilidadeChecks)
        {
            if (!item.Value.Checked)
                continue;

            if (!DiasDisponiveis.TryGetValue(item.Key.Dia, out var turnos))
            {
                turnos = new TurnosDisponiveisDto();
                DiasDisponiveis[item.Key.Dia] = turnos;
            }

            if (item.Key.Turno == Turno.Morning)
                turnos.Morning = true;
            else if (item.Key.Turno == Turno.Afternoon)
                turnos.Afternoon = true;
            else if (item.Key.Turno == Turno.Night)
                turnos.Night = true;
        }
    }

    private void AlternarChecksGrupo(DayOfWeek[] dias)
    {
        var checks = disponibilidadeChecks
            .Where(item => dias.Contains(item.Key.Dia))
            .Select(item => item.Value)
            .ToList();
        bool marcar = checks.Any(checkBox => !checkBox.Checked);

        foreach (var checkBox in checks)
            checkBox.Checked = marcar;
    }

    private void DefinirChecksGrupo(DayOfWeek[] dias, bool marcado)
    {
        foreach (var dia in dias)
        {
            foreach (Turno turno in new[] { Turno.Morning, Turno.Afternoon, Turno.Night })
            {
                if (disponibilidadeChecks.TryGetValue((dia, turno), out var checkBox))
                    checkBox.Checked = marcado;
            }
        }
    }

    private void ConfigurarPainelDados()
    {
        panelDados.Visible = false;
        label2.Location = new Point(20, 18);
        txtNome.Location = new Point(20, 40);
        txtNome.Size = new Size(300, 32);
    }

    private void ConfigurarPainelIndisponibilidade()
    {
        panelIndisponibilidade.Controls.Clear();
        panelIndisponibilidade.BackColor = UiTheme.Surface;
        panelIndisponibilidade.BorderStyle = BorderStyle.FixedSingle;
        panelIndisponibilidade.Location = new Point(568, 108);
        panelIndisponibilidade.Size = new Size(560, 626);

        Label titulo = new()
        {
            AutoSize = true,
            Text = "Datas em que não pode servir",
            Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
            ForeColor = UiTheme.Text,
            Location = new Point(20, 18)
        };

        Label descricao = new()
        {
            AutoSize = true,
            Text = "Use para viagem, trabalho, escola ou outros compromissos pontuais.",
            ForeColor = UiTheme.MutedText,
            Location = new Point(20, 48)
        };

        label3.Location = new Point(20, 78);
        label3.Text = "Adicionar data";
        dateTimePicker1.Location = new Point(20, 98);
        dateTimePicker1.Size = new Size(126, 32);
        txtMotivoData.Location = new Point(188, 98);
        txtMotivoData.Size = new Size(150, 32);
        button1.Location = new Point(420, 98);
        button1.Size = new Size(34, 32);
        dgvDatasIndisponiveis.Location = new Point(20, 136);
        dgvDatasIndisponiveis.Size = new Size(520, 254);
        btnRemoverData.Location = new Point(20, 436);
        btnRemoverData.Size = new Size(112, 34);

        panelIndisponibilidade.Controls.AddRange(new Control[]
        {
            titulo,
            descricao,
            label3,
            dateTimePicker1,
            txtMotivoData,
            button1,
            dgvDatasIndisponiveis,
            btnRemoverData
        });
        Controls.Add(panelIndisponibilidade);
    }

    private static string ObterNomeDiaSemana(DateTime data)
    {
        string[] dias = ["Domingo", "2ª.feira", "3ª.feira", "4ª.feira", "5ª.feira", "6ª.feira", "Sábado"];
        return dias[(int)data.DayOfWeek];
    }

    private IEnumerable<(DateOnly Data, string Motivo)> ObterDatasIndisponiveisParaSalvar()
    {
        Dictionary<DateOnly, string> resultado = [];

        foreach (var item in datas)
            resultado[item.Data] = item.Motivo;

        foreach (DataGridViewRow row in dgvDatasIndisponiveis.Rows)
        {
            if (row.IsNewRow)
                continue;

            string? dataTexto = row.Cells["data"].Value?.ToString();
            if (!TryParseData(dataTexto, out var data))
                continue;

            resultado[data] = row.Cells["motivo"].Value?.ToString()?.Trim() ?? string.Empty;
        }

        return resultado
            .OrderBy(item => item.Key)
            .Select(item => (item.Key, item.Value));
    }

    private static string FormatarData(DateOnly data)
        => data.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));

    private static bool TryParseData(string? texto, out DateOnly data)
    {
        if (DateOnly.TryParse(texto, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None, out data))
            return true;

        if (DateTime.TryParse(texto, System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None, out var dateTime))
        {
            data = DateOnly.FromDateTime(dateTime);
            return true;
        }

        data = default;
        return false;
    }

    private void AjustarLayout()
    {
        const int margin = 32;
        int contentWidth = Math.Max(640, Width - (margin * 2));
        int gap = 24;
        int leftWidth = Math.Max(360, (contentWidth - gap) * 48 / 100);
        int rightWidth = Math.Max(320, contentWidth - gap - leftWidth);
        int topPanels = 76;

        label1.Location = new Point(margin, 24);
        btnVoltar.Location = new Point(margin, 24);
        label1.Location = new Point(btnVoltar.Right + 16, 26);
        button2.Location = new Point(margin + contentWidth - 170, 24);
        button2.Size = new Size(170, 38);

        panelDados.Visible = false;
        AjustarPainelDados(leftWidth);

        panelDisponibilidade.Location = new Point(margin, topPanels);
        panelDisponibilidade.Size = new Size(leftWidth, 468);
        AjustarPainelDisponibilidade(leftWidth);

        panelIndisponibilidade.Location = new Point(margin + leftWidth + gap, topPanels);
        panelIndisponibilidade.Size = new Size(rightWidth, 468);
        AjustarPainelIndisponibilidade(rightWidth);

        int contentBottom = Math.Max(panelDisponibilidade.Bottom, panelIndisponibilidade.Bottom);
        AutoScrollMinSize = new Size(0, contentBottom + 8);
    }

    private void AjustarPainelDados(int panelWidth)
    {
        txtNome.Size = new Size(Math.Max(300, panelWidth - 40), 32);
    }

    private void AjustarPainelDisponibilidade(int panelWidth)
    {
        int innerWidth = Math.Max(320, panelWidth - 40);
        cmbPadrinho.Size = new Size(Math.Min(220, Math.Max(180, innerWidth * 58 / 100)), 32);
        numMissasNecessarias.Location = new Point(Math.Min(cmbPadrinho.Right + 12, panelWidth - 136), 104);
        lblMissasAcompanhadas.Location = new Point(numMissasNecessarias.Left, 82);
        AjustarGrupoDias(panelSemana, innerWidth);
        AjustarGrupoDias(panelFimSemana, innerWidth);
    }

    private void AjustarGrupoDias(Panel parent, int innerWidth)
    {
        int nomeX = 12;
        int col1 = Math.Max(150, innerWidth * 42 / 100);
        int col2 = Math.Max(col1 + 70, innerWidth * 62 / 100);
        int col3 = Math.Max(col2 + 70, innerWidth * 82 / 100);

        foreach (Control control in parent.Controls)
        {
            if (control is Label label)
            {
                if (label.Text == "Manhã" || label.Text == "Tarde" || label.Text == "Noite")
                    label.Visible = false;
            }

            if (control is Panel row)
            {
                row.Size = new Size(Math.Max(300, innerWidth - 14), row.Height);
                foreach (Control rowChild in row.Controls)
                {
                    if (rowChild is Label)
                        rowChild.Location = new Point(nomeX, rowChild.Location.Y);
                    else if (rowChild is CheckBox checkBox)
                    {
                        int currentIndex = row.Controls.OfType<CheckBox>().ToList().IndexOf(checkBox);
                        int x = currentIndex == 0 ? col1 : currentIndex == 1 ? col2 : col3;
                        checkBox.Location = new Point(x, checkBox.Location.Y);
                    }
                }
            }
        }
    }

    private void AjustarPainelIndisponibilidade(int panelWidth)
    {
        int innerWidth = Math.Max(300, panelWidth - 40);
        int addButtonWidth = 34;
        int gap = 8;
        int dateWidth = Math.Min(132, Math.Max(110, innerWidth * 38 / 100));
        int motivoWidth = Math.Max(110, innerWidth - dateWidth - addButtonWidth - (gap * 2));

        dateTimePicker1.Location = new Point(20, 98);
        dateTimePicker1.Size = new Size(dateWidth, 32);
        txtMotivoData.Location = new Point(dateTimePicker1.Right + gap, 98);
        txtMotivoData.Size = new Size(motivoWidth, 32);
        button1.Location = new Point(txtMotivoData.Right + gap, 98);
        button1.Size = new Size(addButtonWidth, 32);

        dgvDatasIndisponiveis.Location = new Point(20, 136);
        dgvDatasIndisponiveis.Size = new Size(innerWidth, Math.Min(230, Math.Max(170, panelIndisponibilidade.Height - 220)));
        btnRemoverData.Location = new Point(20, dgvDatasIndisponiveis.Bottom + 16);
        btnRemoverData.Size = new Size(112, 34);
    }

    private void CarregarPadrinhos()
    {
        cmbPadrinho.Items.Clear();
        cmbPadrinho.Items.Add(new PadrinhoItem("", null));

        foreach (var acolito in db.SelectAllAcolitos())
            cmbPadrinho.Items.Add(new PadrinhoItem(acolito.Nome, acolito.Id));

        cmbPadrinho.SelectedIndex = 0;
    }

    private int? ObterPadrinhoSelecionadoId()
        => cmbPadrinho.SelectedItem is PadrinhoItem item ? item.Id : null;

    private sealed record PadrinhoItem(string Nome, int? Id)
    {
        public override string ToString() => Nome;
    }
}
