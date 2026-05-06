using AppEscala.Helpers;

namespace AppEscala;

public sealed class ConfiguracoesView : UserControl
{
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
    private readonly Button btnAjuda = new();
    private AppSettings settings = AppSettings.Load();

    public ConfiguracoesView()
    {
        ConfigurarInterface();
    }

    private void ConfigurarInterface()
    {
        UiTheme.Apply(this);

        titulo.Text = "Configurações";
        titulo.AutoSize = true;
        titulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
        titulo.ForeColor = UiTheme.Text;

        descricao.Text = "Exporte os dados do sistema, importe dados de outro computador e ajuste a geração da escala.";
        descricao.AutoSize = true;
        descricao.ForeColor = UiTheme.MutedText;

        ConfigurarPainelBackup();
        ConfigurarPainelGeracao();

        btnAjuda.Text = "Ajuda";
        btnAjuda.Size = new Size(120, 38);
        btnAjuda.Enabled = false;

        Controls.AddRange(new Control[] { titulo, descricao, painelBackup, painelGeracao, btnAjuda });
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
            MessageBox.Show("Configurações importadas. Feche e abra o sistema novamente para carregar todos os dados importados.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível importar as configurações: {ex.Message}");
        }
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

        btnAjuda.Location = new Point(margin, painelGeracao.Bottom + 22);
    }
}
