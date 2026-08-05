using AppEscala.Helpers;
using AppEscala.Models.Entities;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AppEscala;

public sealed class ConfiguracoesView : UserControl
{
    private readonly Database db = new();
    private readonly Label titulo = new();
    private readonly Label descricao = new();
    private readonly Panel painelBackup = new();
    private readonly Label lblBackupTitulo = new();
    private readonly Label lblBackupDescricao = new();
    private readonly Button btnExportar = new();
    private readonly Button btnImportar = new();
    private readonly Panel painelGeracao = new();
    private readonly Label lblGeracaoTitulo = new();
    private readonly CheckBox chkGerarJson = new();
    private readonly Panel painelIndisponibilidades = new();
    private readonly Label lblIndisponibilidadesTitulo = new();
    private readonly Label lblIndisponibilidadesDescricao = new();
    private readonly Button btnImportarIndisponibilidades = new();
    private readonly Panel painelConfiguracoesMissa = new();
    private readonly Label lblConfiguracoesMissaTitulo = new();
    private readonly Label lblConfiguracoesMissaDescricao = new();
    private readonly Button btnAbrirConfiguracoesMissa = new();
    private readonly Button btnAjuda = new();
    private readonly Label lblRodape = new();
    private AppSettings settings = AppSettings.Load();

    public ConfiguracoesView()
    {
        db.Initialize();
        ConfigurarInterface();
    }

    private void ConfigurarInterface()
    {
        UiTheme.Apply(this);
        AutoScroll = true;

        titulo.Text = "Configurações";
        titulo.AutoSize = true;
        titulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
        titulo.ForeColor = UiTheme.Text;

        descricao.Text = "Exporte os dados do sistema, importe dados de outro computador e ajuste a geração da escala.";
        descricao.AutoSize = true;
        descricao.ForeColor = UiTheme.MutedText;

        ConfigurarPainelBackup();
        ConfigurarPainelGeracao();
        ConfigurarPainelIndisponibilidades();
        ConfigurarPainelConfiguracoesMissa();

        btnAjuda.Text = "Ajuda";
        btnAjuda.Size = new Size(120, 38);
        btnAjuda.Click += btnAjuda_Click;

        lblRodape.Text = "@devRochaa";
        lblRodape.AutoSize = true;
        lblRodape.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        lblRodape.ForeColor = Color.Gray;

        Controls.AddRange(new Control[] { titulo, descricao, painelBackup, painelGeracao, painelIndisponibilidades, painelConfiguracoesMissa, btnAjuda, lblRodape });
        Resize += (_, _) => AjustarLayout();
        AjustarLayout();
    }

    private void ConfigurarPainelBackup()
    {
        UiTheme.StylePanelSurface(painelBackup);

        lblBackupTitulo.Text = "Exportar e importar configurações";
        lblBackupTitulo.AutoSize = true;
        lblBackupTitulo.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        lblBackupTitulo.ForeColor = UiTheme.Text;

        lblBackupDescricao.Text = "Gera um arquivo com o banco de dados completo para copiar acólitos, missas, igrejas e contadores para outro computador.";
        lblBackupDescricao.AutoSize = false;
        lblBackupDescricao.ForeColor = UiTheme.MutedText;

        btnExportar.Text = "Exportar";
        btnExportar.Size = new Size(130, 38);
        btnExportar.Click += btnExportar_Click;

        btnImportar.Text = "Importar";
        btnImportar.Size = new Size(130, 38);
        btnImportar.Click += btnImportar_Click;

        painelBackup.Controls.AddRange(new Control[] { lblBackupTitulo, lblBackupDescricao, btnExportar, btnImportar });
    }

    private void ConfigurarPainelGeracao()
    {
        UiTheme.StylePanelSurface(painelGeracao);

        lblGeracaoTitulo.Text = "Geração da escala";
        lblGeracaoTitulo.AutoSize = true;
        lblGeracaoTitulo.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        lblGeracaoTitulo.ForeColor = UiTheme.Text;

        chkGerarJson.Text = "Gerar arquivo JSON junto com o PDF";
        chkGerarJson.AutoSize = true;
        chkGerarJson.Checked = settings.GerarJsonAoGerarPdf;
        chkGerarJson.CheckedChanged += (_, _) =>
        {
            settings.GerarJsonAoGerarPdf = chkGerarJson.Checked;
            settings.Save();
        };

        painelGeracao.Controls.AddRange(new Control[] { lblGeracaoTitulo, chkGerarJson });
    }

    private void ConfigurarPainelIndisponibilidades()
    {
        UiTheme.StylePanelSurface(painelIndisponibilidades);

        lblIndisponibilidadesTitulo.Text = "Importar indisponibilidades";
        lblIndisponibilidadesTitulo.AutoSize = true;
        lblIndisponibilidadesTitulo.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        lblIndisponibilidadesTitulo.ForeColor = UiTheme.Text;

        lblIndisponibilidadesDescricao.Text = "Cole uma lista no formato NOME (dia, dia, dia) para cadastrar rapidamente os dias em que os acólitos não podem servir em um mês.";
        lblIndisponibilidadesDescricao.AutoSize = false;
        lblIndisponibilidadesDescricao.ForeColor = UiTheme.MutedText;

        btnImportarIndisponibilidades.Text = "Importar dias";
        btnImportarIndisponibilidades.Size = new Size(150, 38);
        btnImportarIndisponibilidades.Click += btnImportarIndisponibilidades_Click;
        AplicarEstiloBotaoPrimario(btnImportarIndisponibilidades);

        painelIndisponibilidades.Controls.AddRange(new Control[] { lblIndisponibilidadesTitulo, lblIndisponibilidadesDescricao, btnImportarIndisponibilidades });
    }

    private void ConfigurarPainelConfiguracoesMissa()
    {
        UiTheme.StylePanelSurface(painelConfiguracoesMissa);

        lblConfiguracoesMissaTitulo.Text = "Padroes para novas missas";
        lblConfiguracoesMissaTitulo.AutoSize = true;
        lblConfiguracoesMissaTitulo.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
        lblConfiguracoesMissaTitulo.ForeColor = UiTheme.Text;

        lblConfiguracoesMissaDescricao.Text = "Defina quantidade de acolitos e horario que serao preenchidos automaticamente conforme igreja e/ou dia da semana.";
        lblConfiguracoesMissaDescricao.AutoSize = false;
        lblConfiguracoesMissaDescricao.ForeColor = UiTheme.MutedText;

        btnAbrirConfiguracoesMissa.Text = "Configurar padroes";
        btnAbrirConfiguracoesMissa.Size = new Size(170, 38);
        btnAbrirConfiguracoesMissa.Click += btnAbrirConfiguracoesMissa_Click;
        AplicarEstiloBotaoPrimario(btnAbrirConfiguracoesMissa);

        painelConfiguracoesMissa.Controls.AddRange(new Control[]
        {
            lblConfiguracoesMissaTitulo,
            lblConfiguracoesMissaDescricao,
            btnAbrirConfiguracoesMissa
        });
    }

    private static void AplicarEstiloBotaoPrimario(Button button)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = UiTheme.Primary;
        button.ForeColor = Color.White;
        button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        button.Cursor = Cursors.Hand;
        button.UseVisualStyleBackColor = false;
    }

    private void btnAbrirConfiguracoesMissa_Click(object? sender, EventArgs e)
    {
        using FormConfiguracoesMissa form = new();
        form.ShowDialog(this);
    }

    private void btnExportar_Click(object? sender, EventArgs e)
    {
        string nomePadrao = $"AppEscala_Backup_{DateTime.Now:yyyyMMdd_HHmm}.appescala";
        using SaveFileDialog dialog = new()
        {
            Title = "Exportar configurações",
            Filter = "Backup App Escala (*.appescala)|*.appescala|Banco SQLite (*.db)|*.db",
            FileName = nomePadrao,
            AddExtension = true,
            DefaultExt = "appescala",
            OverwritePrompt = true
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            DatabaseBackup.Exportar(dialog.FileName);
            MessageBox.Show($"Configurações exportadas em:\n{dialog.FileName}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível exportar as configurações: {ex.Message}");
        }
    }

    private void btnImportar_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog dialog = new()
        {
            Title = "Importar configurações",
            Filter = "Backup App Escala (*.appescala;*.db)|*.appescala;*.db|Todos os arquivos (*.*)|*.*"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        DialogResult confirmacao = MessageBox.Show(
            "Importar este arquivo vai substituir os dados atuais do sistema. Deseja continuar?",
            "Importar configurações",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirmacao != DialogResult.Yes)
            return;

        try
        {
            DatabaseBackup.Importar(dialog.FileName);
            MessageBox.Show("Configurações importadas. O sistema será reiniciado para carregar os dados importados.");
            Application.Restart();
            Environment.Exit(0);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível importar as configurações: {ex.Message}");
        }
    }

    private void btnImportarIndisponibilidades_Click(object? sender, EventArgs e)
    {
        using Form dialog = CriarDialogImportacaoIndisponibilidades(out DateTimePicker seletorMes, out TextBox txtLista);
        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        ResultadoImportacaoIndisponibilidades resultado;
        try
        {
            resultado = ImportarIndisponibilidades(seletorMes.Value, txtLista.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível importar as indisponibilidades: {ex.Message}");
            return;
        }

        StringBuilder mensagem = new();
        mensagem.AppendLine($"{resultado.DiasCadastrados} indisponibilidade(s) cadastrada(s).");

        if (resultado.DiasIgnorados > 0)
            mensagem.AppendLine($"{resultado.DiasIgnorados} dia(s) já existiam ou eram inválidos e foram ignorados.");

        if (resultado.NomesNaoReconhecidos.Count > 0)
        {
            mensagem.AppendLine();
            mensagem.AppendLine("Nomes não reconhecidos:");
            foreach (string nome in resultado.NomesNaoReconhecidos)
                mensagem.AppendLine($"- {nome}");
        }

        if (resultado.LinhasInvalidas.Count > 0)
        {
            mensagem.AppendLine();
            mensagem.AppendLine("Linhas fora do formato esperado:");
            foreach (string linha in resultado.LinhasInvalidas)
                mensagem.AppendLine($"- {linha}");
        }

        MessageBox.Show(mensagem.ToString(), "Importar indisponibilidades");
    }

    private static Form CriarDialogImportacaoIndisponibilidades(out DateTimePicker seletorMes, out TextBox txtLista)
    {
        Form dialog = new()
        {
            Text = "Importar indisponibilidades",
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false,
            ClientSize = new Size(620, 460)
        };

        Label lblMes = new()
        {
            AutoSize = true,
            Text = "Mês",
            Location = new Point(24, 22)
        };

        seletorMes = new DateTimePicker
        {
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "MM/yyyy",
            ShowUpDown = true,
            Location = new Point(24, 46),
            Size = new Size(120, 32)
        };

        Label lblLista = new()
        {
            AutoSize = true,
            Text = "Lista",
            Location = new Point(24, 92)
        };

        txtLista = new TextBox
        {
            AcceptsReturn = true,
            AcceptsTab = true,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            PlaceholderText = "NOME (dia, dia, dia)\r\nNOME (dia, dia, dia)",
            Location = new Point(24, 116),
            Size = new Size(572, 270)
        };

        Button btnCancelar = new()
        {
            Text = "Cancelar",
            DialogResult = DialogResult.Cancel,
            Location = new Point(396, 410),
            Size = new Size(96, 34)
        };

        Button btnImportar = new()
        {
            Text = "Importar",
            DialogResult = DialogResult.OK,
            Location = new Point(500, 410),
            Size = new Size(96, 34)
        };

        dialog.Controls.AddRange(new Control[] { lblMes, seletorMes, lblLista, txtLista, btnCancelar, btnImportar });
        dialog.AcceptButton = btnImportar;
        dialog.CancelButton = btnCancelar;
        return dialog;
    }

    private static ResultadoImportacaoIndisponibilidades ImportarIndisponibilidades(DateTime mesSelecionado, string texto)
    {
        ResultadoImportacaoIndisponibilidades resultado = new();
        if (string.IsNullOrWhiteSpace(texto))
            return resultado;

        using Database db = new();
        db.Initialize();

        List<AcolitoEntity> acolitos = db.SelectAllAcolitos();
        Dictionary<string, AcolitoEntity> acolitosPorNome = acolitos
            .GroupBy(a => NormalizarTextoBusca(a.Nome))
            .Where(g => !string.IsNullOrWhiteSpace(g.Key) && g.Count() == 1)
            .ToDictionary(g => g.Key, g => g.Single());

        int ano = mesSelecionado.Year;
        int mes = mesSelecionado.Month;
        int ultimoDia = DateTime.DaysInMonth(ano, mes);

        foreach (string linhaOriginal in texto.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
        {
            string linha = linhaOriginal.Trim();
            Match match = Regex.Match(linha, @"^(?<nome>.+?)\s*\((?<dias>[^)]*)\)\s*$");
            if (!match.Success)
            {
                resultado.LinhasInvalidas.Add(linha);
                continue;
            }

            string nomeInformado = match.Groups["nome"].Value.Trim();
            AcolitoEntity? acolito = EncontrarAcolito(nomeInformado, acolitos, acolitosPorNome, out bool ambiguo);
            if (acolito is null)
            {
                resultado.NomesNaoReconhecidos.Add(ambiguo ? $"{nomeInformado} (mais de um acólito possível)" : nomeInformado);
                continue;
            }

            HashSet<DateOnly> datasExistentes = db.SelectDiasAcolito(acolito.Id).Select(d => d.Dia).ToHashSet();
            foreach (int dia in ExtrairDias(match.Groups["dias"].Value).Distinct())
            {
                if (dia < 1 || dia > ultimoDia)
                {
                    resultado.DiasIgnorados++;
                    continue;
                }

                DateOnly data = new(ano, mes, dia);
                if (!datasExistentes.Add(data))
                {
                    resultado.DiasIgnorados++;
                    continue;
                }

                db.InsertDias(new AcolitoCompromissosEntity
                {
                    Id_acolitos = acolito.Id,
                    Dia = data,
                    Motivo = "Importado pelas configurações"
                });
                resultado.DiasCadastrados++;
            }
        }

        return resultado;
    }

    private static AcolitoEntity? EncontrarAcolito(
        string nomeInformado,
        List<AcolitoEntity> acolitos,
        Dictionary<string, AcolitoEntity> acolitosPorNome,
        out bool ambiguo)
    {
        ambiguo = false;
        string nomeBusca = NormalizarTextoBusca(nomeInformado);
        if (string.IsNullOrWhiteSpace(nomeBusca))
            return null;

        if (acolitosPorNome.TryGetValue(nomeBusca, out var exato))
            return exato;

        List<AcolitoEntity> candidatos = acolitos
            .Where(a =>
            {
                string nomeAcolito = NormalizarTextoBusca(a.Nome);
                return nomeAcolito.Contains(nomeBusca, StringComparison.Ordinal) ||
                       nomeBusca.Contains(nomeAcolito, StringComparison.Ordinal);
            })
            .Take(2)
            .ToList();

        if (candidatos.Count == 1)
            return candidatos[0];

        ambiguo = candidatos.Count > 1;
        return null;
    }

    private static IEnumerable<int> ExtrairDias(string texto)
    {
        foreach (Match match in Regex.Matches(texto, @"\d+"))
        {
            if (int.TryParse(match.Value, NumberStyles.None, CultureInfo.InvariantCulture, out int dia))
                yield return dia;
        }
    }

    private static string NormalizarTextoBusca(string texto)
    {
        string normalizado = texto.Trim().Normalize(NormalizationForm.FormD);
        StringBuilder builder = new();

        foreach (char c in normalizado)
        {
            UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
            if (category == UnicodeCategory.NonSpacingMark)
                continue;

            builder.Append(char.IsLetterOrDigit(c) ? char.ToUpperInvariant(c) : ' ');
        }

        return Regex.Replace(builder.ToString(), @"\s+", " ").Trim();
    }

    private sealed class ResultadoImportacaoIndisponibilidades
    {
        public int DiasCadastrados { get; set; }
        public int DiasIgnorados { get; set; }
        public List<string> NomesNaoReconhecidos { get; } = [];
        public List<string> LinhasInvalidas { get; } = [];
    }

    private void btnAjuda_Click(object? sender, EventArgs e)
    {
        string manualPath = Path.Combine(AppContext.BaseDirectory, "Manual.html");

        if (!File.Exists(manualPath))
        {
            MessageBox.Show("Manual.html nao encontrado na pasta do aplicativo.");
            return;
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = manualPath,
            UseShellExecute = true
        });
    }

    private void AjustarLayout()
    {
        const int margin = 32;
        int contentWidth = Math.Max(320, Width - (margin * 2));

        titulo.Location = new Point(margin, 30);
        descricao.Location = new Point(margin + 2, 78);
        descricao.MaximumSize = new Size(contentWidth, 0);

        painelBackup.Location = new Point(margin, 120);
        painelBackup.Size = new Size(contentWidth, 148);
        lblBackupTitulo.Location = new Point(24, 22);
        lblBackupDescricao.Location = new Point(24, 58);
        lblBackupDescricao.Size = new Size(Math.Max(240, painelBackup.Width - 48), 42);
        btnExportar.Location = new Point(24, 100);
        btnImportar.Location = new Point(btnExportar.Right + 12, 100);

        painelGeracao.Location = new Point(margin, painelBackup.Bottom + 18);
        painelGeracao.Size = new Size(contentWidth, 104);
        lblGeracaoTitulo.Location = new Point(24, 22);
        chkGerarJson.Location = new Point(24, 60);

        painelIndisponibilidades.Location = new Point(margin, painelGeracao.Bottom + 18);
        painelIndisponibilidades.Size = new Size(contentWidth, 132);
        lblIndisponibilidadesTitulo.Location = new Point(24, 22);
        btnImportarIndisponibilidades.Size = new Size(150, 38);

        if (painelIndisponibilidades.Width >= 560)
        {
            btnImportarIndisponibilidades.Location = new Point(painelIndisponibilidades.Width - btnImportarIndisponibilidades.Width - 24, 72);
            lblIndisponibilidadesDescricao.Location = new Point(24, 58);
            lblIndisponibilidadesDescricao.Size = new Size(Math.Max(240, btnImportarIndisponibilidades.Left - 48), 48);
        }
        else
        {
            painelIndisponibilidades.Size = new Size(contentWidth, 164);
            lblIndisponibilidadesDescricao.Location = new Point(24, 58);
            lblIndisponibilidadesDescricao.Size = new Size(Math.Max(240, painelIndisponibilidades.Width - 48), 48);
            btnImportarIndisponibilidades.Location = new Point(24, 112);
        }

        painelConfiguracoesMissa.Location = new Point(margin, painelIndisponibilidades.Bottom + 18);
        painelConfiguracoesMissa.Size = new Size(contentWidth, 132);
        lblConfiguracoesMissaTitulo.Location = new Point(24, 22);
        lblConfiguracoesMissaDescricao.Location = new Point(24, 56);
        btnAbrirConfiguracoesMissa.Size = new Size(170, 38);

        if (painelConfiguracoesMissa.Width >= 560)
        {
            btnAbrirConfiguracoesMissa.Location = new Point(painelConfiguracoesMissa.Width - btnAbrirConfiguracoesMissa.Width - 24, 72);
            lblConfiguracoesMissaDescricao.Size = new Size(Math.Max(240, btnAbrirConfiguracoesMissa.Left - 48), 48);
        }
        else
        {
            painelConfiguracoesMissa.Size = new Size(contentWidth, 164);
            lblConfiguracoesMissaDescricao.Size = new Size(Math.Max(240, painelConfiguracoesMissa.Width - 48), 48);
            btnAbrirConfiguracoesMissa.Location = new Point(24, 112);
        }

        btnAjuda.Location = new Point(margin, painelConfiguracoesMissa.Bottom + 22);
        lblRodape.Location = new Point(
            Math.Max(margin, margin + ((contentWidth - lblRodape.Width) / 2)),
            Math.Max(btnAjuda.Bottom + 22, Height - lblRodape.Height - 18));
        AutoScrollMinSize = new Size(0, lblRodape.Bottom + 18);
    }
}
