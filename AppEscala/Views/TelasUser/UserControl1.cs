using iText.IO.Font.Constants;
using AppEscala.Helpers;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Data;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AppEscala
{
    public partial class UserControl1 : UserControl
    {
        private static readonly Database db = new();
        private readonly Button btnOficializarEscala = new();
        private readonly Button btnImportarPdf = new();
        private readonly Button btnImportarJson = new();
        private readonly Label lblCaminhoPdf = new();
        private readonly TextBox txtCaminhoPdf = new();
        private readonly Button btnSelecionarPdf = new();

        public UserControl1()
        {
            InitializeComponent();
            ConfigurarInterface();
            db.Initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregarGridEscala();
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            GerarPdf();
        }

        private void btnSelecionarPdf_Click(object? sender, EventArgs e)
        {
            string caminhoAtual = txtCaminhoPdf.Text.Trim();
            string? diretorioAtual = System.IO.Path.GetDirectoryName(caminhoAtual);

            using SaveFileDialog dialog = new()
            {
                Title = "Salvar escala em PDF",
                Filter = "Arquivos PDF (*.pdf)|*.pdf",
                FileName = string.IsNullOrWhiteSpace(caminhoAtual)
                    ? ObterNomePadraoArquivoEscala()
                    : System.IO.Path.GetFileName(caminhoAtual),
                InitialDirectory = !string.IsNullOrWhiteSpace(diretorioAtual) && Directory.Exists(diretorioAtual)
                    ? diretorioAtual
                    : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                AddExtension = true,
                DefaultExt = "pdf",
                OverwritePrompt = true
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
                txtCaminhoPdf.Text = dialog.FileName;
        }

        private void btnImportarPdf_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dialog = new()
            {
                Title = "Importar PDF da escala",
                Filter = "Arquivos PDF (*.pdf)|*.pdf"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                ImportarPdfEscala(dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível importar o PDF: {ex.Message}");
            }
        }

        private void btnImportarJson_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog dialog = new()
            {
                Title = "Importar JSON da escala",
                Filter = "Arquivos JSON (*.json)|*.json"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                ImportarJsonEscala(dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível importar o JSON: {ex.Message}");
            }
        }

        private void btnOficializarEscala_Click(object? sender, EventArgs e)
        {
            bool existeLinhaSemIds = dgvEscala.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Any(row => !string.IsNullOrWhiteSpace(ObterTextoCelula(row, "acolitos")) && row.Tag is not List<int>);

            if (existeLinhaSemIds)
            {
                MessageBox.Show("Há linhas editadas ou adicionadas manualmente. Gere a escala novamente antes de oficializar.");
                return;
            }

            var idsPorMissa = dgvEscala.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => row.Tag as List<int>)
                .Where(ids => ids is not null && ids.Count > 0)
                .Select(ids => ids!.Distinct().ToList())
                .ToList();

            if (idsPorMissa.Count == 0)
            {
                MessageBox.Show("Gere a escala antes de oficializar.");
                return;
            }

            int totalServicos = idsPorMissa.Sum(ids => ids.Count);
            DialogResult resultado = MessageBox.Show(
                $"Oficializar esta escala e somar {totalServicos} serviço(s) aos acólitos escalados?",
                "Oficializar escala",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            db.IncrementarMissasServidas(idsPorMissa.SelectMany(ids => ids));
            btnOficializarEscala.Enabled = false;
            MessageBox.Show("Escala oficializada e missas servidas atualizadas.");
        }

        private void btnAdicionarLinha_Click(object sender, EventArgs e)
        {
            int indice = ObterIndiceLinhaSelecionada();
            int novoIndice = indice >= 0 ? indice + 1 : dgvEscala.Rows.Count;

            if (novoIndice > dgvEscala.Rows.Count)
                novoIndice = dgvEscala.Rows.Count;

            dgvEscala.Rows.Insert(novoIndice, "", "", "", "", "", false);
            dgvEscala.CurrentCell = dgvEscala.Rows[novoIndice].Cells["data"];
            dgvEscala.BeginEdit(true);
        }

        private void btnRemoverLinha_Click(object sender, EventArgs e)
        {
            int indice = ObterIndiceLinhaSelecionada();

            if (indice < 0 || dgvEscala.Rows[indice].IsNewRow)
                return;

            dgvEscala.Rows.RemoveAt(indice);
        }

        private void dgvEscala_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvEscala.Columns[e.ColumnIndex].Name != "data")
                return;

            AbrirSeletorData(e.RowIndex, e.ColumnIndex);
        }

        private void dgvEscala_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvEscala.Columns[e.ColumnIndex].Name != "acolitos")
                return;

            dgvEscala.Rows[e.RowIndex].Tag = null;
        }

        private void AbrirSeletorData(int rowIndex, int columnIndex)
        {
            using Form seletor = new()
            {
                Text = "Selecionar data",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(280, 118)
            };

            DateTimePicker dateTimePicker = new()
            {
                Format = DateTimePickerFormat.Short,
                Value = ObterDataInicialSeletor(rowIndex, columnIndex),
                Width = 220,
                Location = new System.Drawing.Point(30, 18)
            };

            Button btnConfirmar = new()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(94, 62),
                Size = new Size(86, 32)
            };

            seletor.Controls.Add(dateTimePicker);
            seletor.Controls.Add(btnConfirmar);
            seletor.AcceptButton = btnConfirmar;

            if (seletor.ShowDialog(this) == DialogResult.OK)
            {
                dgvEscala.Rows[rowIndex].Cells[columnIndex].Value = Produtos.FormatarDataEscala(
                    dateTimePicker.Value.Date,
                    Produtos.ConverterData((int)dateTimePicker.Value.DayOfWeek));
            }
        }

        private DateTime ObterDataInicialSeletor(int rowIndex, int columnIndex)
        {
            string texto = dgvEscala.Rows[rowIndex].Cells[columnIndex].Value?.ToString() ?? string.Empty;

            if (int.TryParse(texto.Split('-')[0].Trim(), out int dia))
            {
                DateTime hoje = DateTime.Today;
                int ultimoDiaMes = DateTime.DaysInMonth(hoje.Year, hoje.Month);

                if (dia >= 1 && dia <= ultimoDiaMes)
                    return new DateTime(hoje.Year, hoje.Month, dia);
            }

            return DateTime.Today;
        }

        private int ObterIndiceLinhaSelecionada()
        {
            if (dgvEscala.CurrentCell is not null)
                return dgvEscala.CurrentCell.RowIndex;

            return dgvEscala.SelectedRows.Count > 0
                ? dgvEscala.SelectedRows[0].Index
                : -1;
        }

        private void GerarPdf()
        {
            string arquivo = txtCaminhoPdf.Text.Trim();
            if (string.IsNullOrWhiteSpace(arquivo))
            {
                MessageBox.Show("Informe onde o PDF deve ser salvo.");
                return;
            }

            if (!string.Equals(System.IO.Path.GetExtension(arquivo), ".pdf", StringComparison.OrdinalIgnoreCase))
                arquivo = System.IO.Path.ChangeExtension(arquivo, ".pdf");

            var produtos = ObterProdutosDoGrid();
            string? diretorio = System.IO.Path.GetDirectoryName(arquivo);
            if (!string.IsNullOrWhiteSpace(diretorio))
                Directory.CreateDirectory(diretorio);

            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);
                var document = new Document(pdfDocument, PageSize.A4);
                document.SetMargins(44, 42, 36, 42);

                var fonte = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                var fonteNegrito = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                string mes = DateTime.Now.ToString("MMMM", new CultureInfo("pt-BR"));
                mes = char.ToUpper(mes[0]) + mes.Substring(1);

                var titulo = new Paragraph($"ESCALA DE ACÓLITOS- {mes}- {DateTime.Now.Year}")
                    .SetFont(fonteNegrito)
                    .SetFontSize(11)
                    .SetFontColor(ColorConstants.BLACK)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(18);

                document.Add(titulo);

                Table tabela = CriarTabelaEscala(fonte, fonteNegrito);

                foreach (Produtos prod in produtos)
                {
                    AdicionarLinhaEscala(tabela, prod, fonte);
                }

                document.Add(tabela);

                document.Close();
                pdfDocument.Close();

                string? jsonPath = null;
                if (AppSettings.Load().GerarJsonAoGerarPdf)
                {
                    jsonPath = System.IO.Path.ChangeExtension(arquivo, ".json");
                    ExportarJsonEscala(jsonPath, produtos);
                }

                string mensagem = $"Arquivo PDF gerado em {arquivo}";
                if (jsonPath is not null)
                    mensagem += $"\nJSON gerado em {jsonPath}";

                MessageBox.Show(mensagem);
            }
        }

        private void CarregarGridEscala()
        {
            dgvEscala.Rows.Clear();
            btnOficializarEscala.Enabled = true;

            foreach (Produtos prod in Produtos.GetListaProdutos())
            {
                int rowIndex = dgvEscala.Rows.Add(prod.data, prod.horario, prod.acolitos, prod.evento, prod.local, false);
                dgvEscala.Rows[rowIndex].Tag = prod.acolitoIds;
            }
        }

        private static void ExportarJsonEscala(string caminhoJson, List<Produtos> produtos)
        {
            var arquivo = new EscalaJson(
                1,
                DateTime.Now,
                produtos.Select(p => new EscalaJsonLinha(
                    p.data,
                    p.horario,
                    p.acolitos,
                    p.evento,
                    p.local,
                    p.destacar,
                    p.acolitoIds)).ToList());

            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(caminhoJson, JsonSerializer.Serialize(arquivo, options));
        }

        private void ImportarJsonEscala(string caminhoJson)
        {
            var arquivo = JsonSerializer.Deserialize<EscalaJson>(File.ReadAllText(caminhoJson))
                ?? throw new InvalidOperationException("JSON inválido.");

            dgvEscala.Rows.Clear();
            foreach (var linha in arquivo.Linhas)
            {
                int rowIndex = dgvEscala.Rows.Add(
                    linha.Data,
                    linha.Horario,
                    linha.Acolitos,
                    linha.Evento,
                    linha.Local,
                    linha.Destacar);

                dgvEscala.Rows[rowIndex].Tag = linha.AcolitoIds.Distinct().ToList();
            }

            btnOficializarEscala.Enabled = arquivo.Linhas.Any(l => l.AcolitoIds.Count > 0);
            MessageBox.Show("JSON importado com sucesso.");
        }

        private void ImportarPdfEscala(string caminhoPdf)
        {
            var produtos = LerProdutosDoPdf(caminhoPdf);
            if (produtos.Count == 0)
            {
                MessageBox.Show("Nenhuma linha de escala foi encontrada no PDF.");
                return;
            }

            var acolitosPorNome = db.SelectAllAcolitos()
                .GroupBy(a => NormalizarNome(a.Nome))
                .ToDictionary(g => g.Key, g => g.First().Id);

            dgvEscala.Rows.Clear();
            List<string> nomesNaoEncontrados = [];

            foreach (var produto in produtos)
            {
                var vinculo = ResolverAcolitosImportados(produto.acolitos, acolitosPorNome);
                foreach (var nome in vinculo.NomesNaoEncontrados)
                    nomesNaoEncontrados.Add(nome);

                int rowIndex = dgvEscala.Rows.Add(produto.data, produto.horario, produto.acolitos, produto.evento, produto.local, false);
                dgvEscala.Rows[rowIndex].Tag = vinculo.TodosReconhecidos ? vinculo.Ids : null;
            }

            btnOficializarEscala.Enabled = nomesNaoEncontrados.Count == 0;

            if (nomesNaoEncontrados.Count > 0)
            {
                string nomes = string.Join(", ", nomesNaoEncontrados.Distinct());
                MessageBox.Show($"PDF importado, mas estes acólitos não foram encontrados no cadastro: {nomes}");
                return;
            }

            MessageBox.Show("PDF importado com sucesso.");
        }

        private static List<Produtos> LerProdutosDoPdf(string caminhoPdf)
        {
            using PdfReader reader = new(caminhoPdf);
            using PdfDocument pdf = new(reader);
            List<PdfTextChunk> chunks = [];

            for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
            {
                var listener = new PositionalTextExtractionStrategy();
                var processor = new PdfCanvasProcessor(listener);
                processor.ProcessPageContent(pdf.GetPage(i));
                chunks.AddRange(listener.Chunks);
            }

            return ExtrairProdutosDosChunks(chunks);
        }

        private static List<Produtos> ExtrairProdutosDosChunks(List<PdfTextChunk> chunks)
        {
            List<Produtos> produtos = [];
            var linhas = chunks
                .Where(c => !string.IsNullOrWhiteSpace(c.Text))
                .Where(c => c.Y < 760)
                .GroupBy(c => Math.Round(c.Y / 8) * 8)
                .OrderByDescending(g => g.Key)
                .Select(g => g.OrderBy(c => c.X).ToList())
                .ToList();

            foreach (var linha in linhas)
            {
                var colunas = new string[5];

                foreach (var chunk in linha)
                {
                    int coluna = ObterColunaPdf(chunk.X);
                    if (coluna < 0)
                        continue;

                    colunas[coluna] = string.IsNullOrWhiteSpace(colunas[coluna])
                        ? chunk.Text.Trim()
                        : $"{colunas[coluna]} {chunk.Text.Trim()}";
                }

                if (colunas.All(string.IsNullOrWhiteSpace))
                    continue;

                if (EhCabecalhoOuTitulo(colunas))
                    continue;

                string data = (colunas[0] ?? string.Empty).Trim();
                string horario = NormalizarHorarioImportado((colunas[1] ?? string.Empty).Trim());
                string acolitos = (colunas[2] ?? string.Empty).Trim();
                string evento = (colunas[3] ?? string.Empty).Trim();
                string local = (colunas[4] ?? string.Empty).Trim();

                if (string.IsNullOrWhiteSpace(horario)
                    && string.IsNullOrWhiteSpace(acolitos)
                    && string.IsNullOrWhiteSpace(evento)
                    && string.IsNullOrWhiteSpace(local))
                {
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(horario) && !EhHorarioEscala(horario))
                    continue;

                produtos.Add(new Produtos(data, horario, acolitos, evento, local));
            }

            return produtos;
        }

        private static int ObterColunaPdf(float x)
        {
            if (x < 100)
                return 0;
            if (x < 150)
                return 1;
            if (x < 360)
                return 2;
            if (x < 430)
                return 3;
            if (x < 560)
                return 4;

            return -1;
        }

        private static bool EhCabecalhoOuTitulo(string[] colunas)
        {
            string texto = string.Join(" ", colunas).Trim();
            return texto.StartsWith("ESCALA DE", StringComparison.OrdinalIgnoreCase)
                || texto.Contains("DATA", StringComparison.OrdinalIgnoreCase)
                || texto.Contains("HORÁRIO", StringComparison.OrdinalIgnoreCase)
                || texto.Equals("LOCAL", StringComparison.OrdinalIgnoreCase);
        }

        private static bool EhDataEscala(string texto)
            => Regex.IsMatch(texto, @"^\d{2}\s*-\s*");

        private static bool EhHorarioEscala(string texto)
            => TimeSpan.TryParse(texto, out _)
                || Regex.IsMatch(texto, @"^\d{1,2}h(s|\d{2})?$", RegexOptions.IgnoreCase);

        private static string NormalizarHorarioImportado(string texto)
        {
            if (TimeSpan.TryParse(texto, out var time))
                return time.ToString(@"hh\:mm");

            var match = Regex.Match(texto, @"^(?<h>\d{1,2})h(?<m>\d{2})?$", RegexOptions.IgnoreCase);
            if (!match.Success)
                return texto;

            int hora = int.Parse(match.Groups["h"].Value, CultureInfo.InvariantCulture);
            int minuto = match.Groups["m"].Success ? int.Parse(match.Groups["m"].Value, CultureInfo.InvariantCulture) : 0;
            return new TimeSpan(hora, minuto, 0).ToString(@"hh\:mm");
        }

        private static (bool TodosReconhecidos, List<int> Ids, List<string> NomesNaoEncontrados) ResolverAcolitosImportados(
            string textoAcolitos,
            Dictionary<string, int> acolitosPorNome)
        {
            List<int> ids = [];
            List<string> naoEncontrados = [];
            var nomes = textoAcolitos
                .Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Where(nome => !string.IsNullOrWhiteSpace(nome))
                .ToList();

            foreach (var nome in nomes)
            {
                if (acolitosPorNome.TryGetValue(NormalizarNome(nome), out int id))
                    ids.Add(id);
                else
                    naoEncontrados.Add(nome);
            }

            return (nomes.Count > 0 && naoEncontrados.Count == 0, ids, naoEncontrados);
        }

        private static string NormalizarNome(string nome)
            => Regex.Replace(nome.Trim(), @"\s+", " ").ToUpperInvariant();

        private sealed record EscalaJson(int Versao, DateTime GeradoEm, List<EscalaJsonLinha> Linhas);

        private sealed record EscalaJsonLinha(
            string Data,
            string Horario,
            string Acolitos,
            string Evento,
            string Local,
            bool Destacar,
            List<int> AcolitoIds);

        private sealed record PdfTextChunk(string Text, float X, float Y);

        private sealed class PositionalTextExtractionStrategy : IEventListener
        {
            public List<PdfTextChunk> Chunks { get; } = [];

            public void EventOccurred(IEventData data, EventType type)
            {
                if (type != EventType.RENDER_TEXT || data is not TextRenderInfo renderInfo)
                    return;

                string text = renderInfo.GetText();
                if (string.IsNullOrWhiteSpace(text))
                    return;

                var start = renderInfo.GetBaseline().GetStartPoint();
                Chunks.Add(new PdfTextChunk(text, start.Get(Vector.I1), start.Get(Vector.I2)));
            }

            public ICollection<EventType>? GetSupportedEvents()
                => [EventType.RENDER_TEXT];
        }

        private List<Produtos> ObterProdutosDoGrid()
        {
            if (dgvEscala.Rows.Count == 0 || dgvEscala.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
                CarregarGridEscala();

            var produtos = new List<Produtos>();

            foreach (DataGridViewRow row in dgvEscala.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string data = ObterTextoCelula(row, "data");
                string horario = ObterTextoCelula(row, "horario");
                string acolitos = ObterTextoCelula(row, "acolitos");
                string evento = ObterTextoCelula(row, "evento");
                string local = ObterTextoCelula(row, "local");
                bool destacar = ObterBooleanoCelula(row, "destacar");

                if (string.IsNullOrWhiteSpace(data)
                    && string.IsNullOrWhiteSpace(horario)
                    && string.IsNullOrWhiteSpace(acolitos)
                    && string.IsNullOrWhiteSpace(evento)
                    && string.IsNullOrWhiteSpace(local))
                {
                    continue;
                }

                var acolitoIds = row.Tag is List<int> ids ? ids.ToList() : new List<int>();
                produtos.Add(new Produtos(data, horario, acolitos, evento, local, destacar, acolitoIds));
            }

            return produtos;
        }

        private static string ObterTextoCelula(DataGridViewRow row, string coluna)
            => row.Cells[coluna].Value?.ToString() ?? string.Empty;

        private static bool ObterBooleanoCelula(DataGridViewRow row, string coluna)
            => row.Cells[coluna].Value is bool valor && valor;

        private static Table CriarTabelaEscala(PdfFont fonte, PdfFont fonteNegrito)
        {
            float[] columnWidth = { 12, 10, 41, 13, 24 };
            Table tabela = new Table(UnitValue.CreatePercentArray(columnWidth)).UseAllAvailableWidth();
            tabela.SetBorder(new SolidBorder(ColorConstants.BLACK, 0.6f));
            tabela.SetSkipFirstHeader(false);

            tabela.AddHeaderCell(CriarCelulaCabecalho("DATA", fonteNegrito));
            tabela.AddHeaderCell(CriarCelulaCabecalho("HORÁRIO", fonteNegrito));
            tabela.AddHeaderCell(CriarCelulaCabecalho("", fonteNegrito));
            tabela.AddHeaderCell(CriarCelulaCabecalho("", fonteNegrito));
            tabela.AddHeaderCell(CriarCelulaCabecalho("LOCAL", fonteNegrito));

            return tabela;
        }

        private static Cell CriarCelulaCabecalho(string texto, PdfFont fonte)
            => CriarCelulaBase(texto, fonte)
                .SetFontSize(9)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetPaddingBottom(8);

        private static void AdicionarLinhaEscala(Table tabela, Produtos prod, PdfFont fonte)
        {
            bool linhaEvento = string.IsNullOrWhiteSpace(prod.acolitos) && !string.IsNullOrWhiteSpace(prod.evento);
            string servico = linhaEvento ? prod.evento : prod.acolitos;
            string observacao = linhaEvento ? "" : prod.evento;
            bool destacarLinha = prod.destacar || linhaEvento;
            iText.Kernel.Colors.Color corLinha = destacarLinha ? ColorConstants.RED : ColorConstants.BLACK;

            tabela.AddCell(CriarCelulaBase(prod.data, fonte).SetTextAlignment(TextAlignment.CENTER).SetFontColor(corLinha));
            tabela.AddCell(CriarCelulaBase(FormatarHorario(prod.horario), fonte)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(corLinha));
            tabela.AddCell(CriarCelulaBase(servico, fonte)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(corLinha));
            tabela.AddCell(CriarCelulaBase(observacao, fonte)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontColor(corLinha));
            tabela.AddCell(CriarCelulaBase(prod.local, fonte)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(corLinha));
        }

        private static Cell CriarCelulaBase(string texto, PdfFont fonte)
            => new Cell()
                .Add(new Paragraph(texto)
                    .SetFont(fonte)
                    .SetFontSize(9)
                    .SetMultipliedLeading(1.05f))
                .SetBorder(new SolidBorder(ColorConstants.BLACK, 0.6f))
                .SetPaddingLeft(2)
                .SetPaddingRight(2)
                .SetPaddingTop(1)
                .SetPaddingBottom(1)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE);

        private static string FormatarHorario(string horario)
        {
            if (!TimeSpan.TryParse(horario, out var hora))
                return horario;

            return hora.Minutes == 0
                ? $"{hora.Hours}hs"
                : $"{hora.Hours}h{hora.Minutes:00}";
        }

        public class Produtos
        {
            public string data { get; set; }
            public string horario { get; set; }
            public string acolitos { get; set; }
            public string evento { get; set; }
            public string local { get; set; }
            public bool destacar { get; set; }
            public List<int> acolitoIds { get; set; }


            public Produtos(string data, string horario, string acolitos, string evento, string local, bool destacar = false, List<int>? acolitoIds = null)
            {
                this.data = data;
                this.horario = horario;
                this.acolitos = acolitos;
                this.evento = evento;
                this.local = local;
                this.destacar = destacar;
                this.acolitoIds = acolitoIds ?? [];
            }

            public string EncaixarAcolitos(string data, string horario, int quant)
            {
                if (!DateTime.TryParse(data, out DateTime dataConvertida) || !TimeSpan.TryParse(horario, out var horaConvertida))
                    return string.Empty;

                int dia = DiaSemanaParaId(dataConvertida.DayOfWeek);
                int turno = HorarioParaTurno(dataConvertida.Date.Add(horaConvertida));
                return SelecionarAcolitos(dia, dataConvertida.ToString("dd/MM/yyyy"), turno, quant);
            }
            public static string ConverterData(int indexDia)
            {
                string[] dias = ["Domingo", "2ª.feira", "3ª.feira", "4ª.feira", "5ª.feira", "6ª.Feira", "Sábado"];
                return dias[indexDia];
            }

            public static string SelecionarAcolitos(int dia, string diaSemana, int turno, int qntAc)
            {
                var candidatos = ObterCandidatosDisponiveis(dia, diaSemana, turno);
                var selecionados = SelecionarAcolitosParaMissa(
                    candidatos,
                    new Dictionary<int, DateTime>(),
                    new HashSet<int>(),
                    qntAc,
                    DateTime.Today,
                    new Random());

                return string.Join("/ ", selecionados.Select(a => a.Nome));
            }

            public static int HorarioParaTurno(DateTime horario)
            {
                if (horario.Hour < 12)
                {
                    return 1;
                }
                if (horario.Hour >= 12 && horario.Hour < 18)
                {
                    return 2;
                }
                return 3;

            }

            private static int DiaSemanaParaId(DayOfWeek diaSemana)
                => diaSemana == DayOfWeek.Sunday ? 7 : (int)diaSemana;

            public static List<Produtos> GetListaProdutos()
            {
                var listaMissa = db.SelectAllMissasNova();
                var relProdutos = new List<Produtos>();

                Dictionary<int, DateTime> ultimaEscalaPorAcolito = new();
                HashSet<int> acolitosJaNaEscala = [];

                Random rand = new();

                foreach (var missa in listaMissa)
                {
                    int turno = HorarioParaTurno(missa.Data);
                    int diaSemanaNum = (int)missa.Data.DayOfWeek;
                    string diaConvertido = ConverterData(diaSemanaNum);
                    int diaSemanaId = DiaSemanaParaId(missa.Data.DayOfWeek);

                    var listaDisponiveis = ObterCandidatosDisponiveis(diaSemanaId, missa.Data.ToString("dd/MM/yyyy"), turno);

                    var selecionados = SelecionarAcolitosParaMissa(
                        listaDisponiveis,
                        ultimaEscalaPorAcolito,
                        acolitosJaNaEscala,
                        missa.Qnt_acolitos,
                        missa.Data,
                        rand);

                    string acolitos = string.Join("/ ", selecionados.Select(a => a.Nome));
                    var acolitoIds = selecionados.Select(a => a.Id).ToList();

                    string dataFormatada = FormatarDataEscala(missa.Data, diaConvertido);
                    bool isDataRepetida = relProdutos.Any(p => p.data == dataFormatada);

                    if (isDataRepetida)
                    {
                        relProdutos.Add(new Produtos("", missa.Data.ToString("HH:mm"), acolitos, missa.Descricao, missa.Igreja, acolitoIds: acolitoIds));
                    }
                    else
                    {
                        relProdutos.Add(new Produtos(dataFormatada, missa.Data.ToString("HH:mm"), acolitos, missa.Descricao, missa.Igreja, acolitoIds: acolitoIds));
                    }
                }

                return relProdutos;
            }

            private static List<AcolitoEscala> ObterCandidatosDisponiveis(int diaSemanaId, string data, int turno)
                => db.SelecionarAcolitoDia(diaSemanaId, data, turno)
                    .GroupBy(a => a.Id_acolito)
                    .Select(g =>
                    {
                        var item = g.First();
                        return new AcolitoEscala(
                            item.Id_acolito,
                            item.Nome,
                            item.PadrinhoId,
                            item.MissasAcompanhadasNecessarias,
                            item.MissasServidas);
                    })
                    .ToList();

            private static List<AcolitoEscala> SelecionarAcolitosParaMissa(
                List<AcolitoEscala> listaDisponiveis,
                Dictionary<int, DateTime> ultimaEscalaPorAcolito,
                HashSet<int> acolitosJaNaEscala,
                int quantidade,
                DateTime dataMissa,
                Random rand)
            {
                var candidatosPorId = listaDisponiveis.ToDictionary(a => a.Id);
                HashSet<int> selecionadosIds = [];
                HashSet<int> padrinhosUsadosComAfilhado = [];
                List<AcolitoEscala> selecionados = [];

                var paresAcompanhamento = listaDisponiveis
                    .Where(a => a.PrecisaAcompanhamento
                        && a.PadrinhoId is not null
                        && candidatosPorId.ContainsKey(a.PadrinhoId.Value))
                    .OrderBy(a => acolitosJaNaEscala.Contains(a.Id) ? 1 : 0)
                    .ThenBy(a => ultimaEscalaPorAcolito.GetValueOrDefault(a.Id, DateTime.MinValue))
                    .ThenBy(_ => rand.Next())
                    .ToList();

                foreach (var afilhado in paresAcompanhamento)
                {
                    int padrinhoId = afilhado.PadrinhoId!.Value;
                    if (selecionados.Count + 2 > quantidade)
                        break;

                    if (selecionadosIds.Contains(afilhado.Id)
                        || selecionadosIds.Contains(padrinhoId)
                        || padrinhosUsadosComAfilhado.Contains(padrinhoId))
                    {
                        continue;
                    }

                    selecionados.Add(afilhado);
                    selecionados.Add(candidatosPorId[padrinhoId]);
                    selecionadosIds.Add(afilhado.Id);
                    selecionadosIds.Add(padrinhoId);
                    padrinhosUsadosComAfilhado.Add(padrinhoId);
                }

                var restantes = listaDisponiveis
                    .Where(a => !selecionadosIds.Contains(a.Id))
                    .Where(a => !a.PrecisaAcompanhamento)
                    .OrderBy(a => acolitosJaNaEscala.Contains(a.Id) ? 1 : 0)
                    .ThenBy(a => ultimaEscalaPorAcolito.GetValueOrDefault(a.Id, DateTime.MinValue))
                    .ThenBy(_ => rand.Next())
                    .Take(Math.Max(0, quantidade - selecionados.Count))
                    .ToList();

                selecionados.AddRange(restantes);

                foreach (var acolito in selecionados)
                {
                    ultimaEscalaPorAcolito[acolito.Id] = dataMissa;
                    acolitosJaNaEscala.Add(acolito.Id);
                }

                return selecionados;
            }

            private sealed record AcolitoEscala(
                int Id,
                string Nome,
                int? PadrinhoId,
                int MissasAcompanhadasNecessarias,
                int MissasServidas)
            {
                public bool PrecisaAcompanhamento =>
                    PadrinhoId is not null && MissasServidas < MissasAcompanhadasNecessarias;
            }

            public static string FormatarDataEscala(DateTime data, string diaConvertido)
            {
                string separador = data.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday ? "-" : "- ";
                return $"{data.Day:00}{separador}{diaConvertido}";
            }

        }

       
        private void ConfigurarInterface()
        {
            UiTheme.Apply(this);
            skyLabel1.Text = "Gerar escala";
            skyLabel1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            skyLabel1.ForeColor = UiTheme.Text;
            button1.Text = "Gerar escala";
            button1.PrimaryColor = UiTheme.Primary;
            button1.TextColor = System.Drawing.Color.White;
            btnGerarPdf.Text = "Gerar PDF";
            btnGerarPdf.PrimaryColor = UiTheme.Primary;
            btnGerarPdf.TextColor = System.Drawing.Color.White;
            lblCaminhoPdf.Text = "Salvar PDF em";
            lblCaminhoPdf.ForeColor = UiTheme.Text;
            lblCaminhoPdf.AutoSize = true;
            Controls.Add(lblCaminhoPdf);
            txtCaminhoPdf.Text = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                ObterNomePadraoArquivoEscala());
            txtCaminhoPdf.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(txtCaminhoPdf);
            btnSelecionarPdf.Text = "...";
            btnSelecionarPdf.BackColor = UiTheme.Surface;
            btnSelecionarPdf.ForeColor = UiTheme.Text;
            btnSelecionarPdf.Click += btnSelecionarPdf_Click;
            Controls.Add(btnSelecionarPdf);
            btnImportarPdf.Text = "Importar PDF";
            btnImportarPdf.Size = new Size(140, 36);
            btnImportarPdf.BackColor = UiTheme.Surface;
            btnImportarPdf.ForeColor = UiTheme.Text;
            btnImportarPdf.Click += btnImportarPdf_Click;
            Controls.Add(btnImportarPdf);
            btnImportarJson.Text = "Importar JSON";
            btnImportarJson.Size = new Size(140, 36);
            btnImportarJson.BackColor = UiTheme.Surface;
            btnImportarJson.ForeColor = UiTheme.Text;
            btnImportarJson.Click += btnImportarJson_Click;
            Controls.Add(btnImportarJson);
            btnAdicionarLinha.Text = "+";
            btnRemoverLinha.Text = "-";
            btnOficializarEscala.Text = "Oficializar escala";
            btnOficializarEscala.Size = new Size(160, 36);
            btnOficializarEscala.BackColor = UiTheme.Surface;
            btnOficializarEscala.ForeColor = UiTheme.Text;
            btnOficializarEscala.Click += btnOficializarEscala_Click;
            Controls.Add(btnOficializarEscala);
            btnAdicionarLinha.BackColor = UiTheme.Surface;
            btnRemoverLinha.BackColor = UiTheme.Surface;
            btnAdicionarLinha.ForeColor = UiTheme.Text;
            btnRemoverLinha.ForeColor = UiTheme.Text;
            ConfigurarGridEscala();
            Resize += (_, _) => AjustarLayout();
            AjustarLayout();
        }

        private void ConfigurarGridEscala()
        {
            dgvEscala.Columns.Clear();
            dgvEscala.AutoGenerateColumns = false;
            dgvEscala.AllowUserToAddRows = true;
            dgvEscala.AllowUserToDeleteRows = true;
            dgvEscala.ReadOnly = false;
            dgvEscala.MultiSelect = false;
            dgvEscala.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvEscala.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEscala.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEscala.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEscala.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEscala.RowHeadersVisible = false;
            dgvEscala.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEscala.CellValueChanged -= dgvEscala_CellValueChanged;
            dgvEscala.CellValueChanged += dgvEscala_CellValueChanged;

            dgvEscala.Columns.Add(CriarColunaTexto("data", "DATA", 95, DataGridViewAutoSizeColumnMode.AllCells));
            dgvEscala.Columns.Add(CriarColunaTexto("horario", "HORÁRIO", 80, DataGridViewAutoSizeColumnMode.AllCells));
            dgvEscala.Columns.Add(CriarColunaTexto("acolitos", "ACÓLITOS", 260, DataGridViewAutoSizeColumnMode.Fill));
            dgvEscala.Columns.Add(CriarColunaTexto("evento", "EVENTO", 130, DataGridViewAutoSizeColumnMode.Fill));
            dgvEscala.Columns.Add(CriarColunaTexto("local", "LOCAL", 170, DataGridViewAutoSizeColumnMode.Fill));
            dgvEscala.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "destacar",
                DataPropertyName = "destacar",
                HeaderText = "DESTACAR",
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        private static DataGridViewTextBoxColumn CriarColunaTexto(
            string nome,
            string cabecalho,
            int largura,
            DataGridViewAutoSizeColumnMode modo)
            => new()
            {
                Name = nome,
                DataPropertyName = nome,
                HeaderText = cabecalho,
                Width = largura,
                AutoSizeMode = modo,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

        private static string ObterNomePadraoArquivoEscala()
        {
            string mes = DateTime.Now.ToString("MMMM", new CultureInfo("pt-BR"));
            mes = char.ToUpper(mes[0], new CultureInfo("pt-BR")) + mes[1..];
            return $"ESCALA DE ACÓLITOS_{mes}_{DateTime.Now.Year}.pdf";
        }

        private void AjustarLayout()
        {
            const int margin = 32;
            const int gap = 12;
            skyLabel1.Location = new System.Drawing.Point(margin, 28);

            int caminhoTop = 76;
            lblCaminhoPdf.Location = new System.Drawing.Point(margin, caminhoTop);
            btnSelecionarPdf.Size = new Size(42, 28);
            btnSelecionarPdf.Location = new System.Drawing.Point(Width - margin - btnSelecionarPdf.Width, caminhoTop + 24);
            txtCaminhoPdf.Location = new System.Drawing.Point(margin, caminhoTop + 25);
            txtCaminhoPdf.Size = new Size(Math.Max(240, btnSelecionarPdf.Left - margin - gap), 28);

            int primaryTop = 142;
            button1.Location = new System.Drawing.Point(margin, primaryTop);
            button1.Size = new Size(220, 42);
            btnGerarPdf.Location = new System.Drawing.Point(button1.Right + gap, primaryTop);
            btnGerarPdf.Size = new Size(160, 42);

            int secondaryTop = 196;
            btnImportarPdf.Location = new System.Drawing.Point(margin, secondaryTop);
            btnImportarPdf.Size = new Size(140, 36);
            btnImportarJson.Location = new System.Drawing.Point(btnImportarPdf.Right + gap, secondaryTop);
            btnImportarJson.Size = new Size(140, 36);
            btnOficializarEscala.Location = new System.Drawing.Point(btnImportarJson.Right + gap, secondaryTop);
            btnOficializarEscala.Size = new Size(160, 36);

            btnRemoverLinha.Size = new Size(36, 30);
            btnRemoverLinha.Location = new System.Drawing.Point(Width - margin - btnRemoverLinha.Width, secondaryTop + 3);
            btnAdicionarLinha.Size = new Size(36, 30);
            btnAdicionarLinha.Location = new System.Drawing.Point(btnRemoverLinha.Left - btnAdicionarLinha.Width - 8, secondaryTop + 3);

            dgvEscala.Location = new System.Drawing.Point(margin, 252);
            dgvEscala.Size = new Size(Math.Max(320, Width - (margin * 2)), Math.Max(120, Height - 284));
        }
    }
}

   
