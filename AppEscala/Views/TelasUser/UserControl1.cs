using iText.IO.Font.Constants;
using AppEscala.Helpers;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Globalization;

namespace AppEscala
{
    public partial class UserControl1 : UserControl
    {
        private static readonly Database db = new();

        public UserControl1()
        {
            InitializeComponent();
            ConfigurarInterface();
            db.Initialize();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            for (int i = 0; i < 10; i++)
            {
                cmb_diasSemana.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregarGridEscala();
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            GerarPdf();
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
            var arquivo = @"C:\dados\recibo.pdf";
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(arquivo)!);

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

                foreach (Produtos prod in ObterProdutosDoGrid())
                {
                    AdicionarLinhaEscala(tabela, prod, fonte);
                }

                document.Add(tabela);

                document.Close();
                pdfDocument.Close();

                MessageBox.Show("Arquivo PDF gerado em " + arquivo);
            }
        }

        private void CarregarGridEscala()
        {
            dgvEscala.Rows.Clear();

            foreach (Produtos prod in Produtos.GetListaProdutos())
            {
                dgvEscala.Rows.Add(prod.data, prod.horario, prod.acolitos, prod.evento, prod.local, false);
            }
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

                produtos.Add(new Produtos(data, horario, acolitos, evento, local, destacar));
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


            public Produtos(string data, string horario, string acolitos, string evento, string local, bool destacar = false)
            {
                this.data = data;
                this.horario = horario;
                this.acolitos = acolitos;
                this.evento = evento;
                this.local = local;
                this.destacar = destacar;
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
                var lista = db.SelecionarAcolitoDia(dia, diaSemana, turno);
                string acolitosQpodem = "";
                int quantidade = Math.Min(lista.Count, qntAc);
                Random randNum = new();

                List<int> lstIndexAcolitos = new List<int>();

                for (int i = 0; i < quantidade; i++)
                {
                    int indexRand;

                    do
                    {
                        indexRand = randNum.Next(lista.Count);
                    } while (lstIndexAcolitos.Contains(indexRand));

                    lstIndexAcolitos.Add(indexRand);

                    if (quantidade == 1 || i + 1 == quantidade)
                    {
                        acolitosQpodem += lista[indexRand].Nome;
                        break;
                    }

                    if (i == 0)
                    {
                        acolitosQpodem += lista[indexRand].Nome + "/ ";
                    }
                    else
                    {
                        if (quantidade > 1)
                        {
                            acolitosQpodem += lista[indexRand].Nome + "/ ";
                        }
                    }


                }

                return acolitosQpodem;
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

                Dictionary<string, DateTime> ultimaEscalaPorAcolito = new();

                Random rand = new();

                foreach (var missa in listaMissa)
                {
                    int turno = HorarioParaTurno(missa.Data);
                    int diaSemanaNum = (int)missa.Data.DayOfWeek;
                    string diaConvertido = ConverterData(diaSemanaNum);
                    int diaSemanaId = DiaSemanaParaId(missa.Data.DayOfWeek);

                    var listaDisponiveis = db.SelecionarAcolitoDia(diaSemanaId, missa.Data.ToString("dd/MM/yyyy"), turno)
                        .Select(a => a.Nome)
                        .Distinct()
                        .ToList();

                    var selecionados = SelecionarPorPrioridadeUltimaEscala(
                        listaDisponiveis,
                        ultimaEscalaPorAcolito,
                        missa.Qnt_acolitos,
                        missa.Data,
                        rand);

                    string acolitos = string.Join("/ ", selecionados);

                    string dataFormatada = FormatarDataEscala(missa.Data, diaConvertido);
                    bool isDataRepetida = relProdutos.Any(p => p.data == dataFormatada);

                    if (isDataRepetida)
                    {
                        relProdutos.Add(new Produtos("", missa.Data.ToString("HH:mm"), acolitos, missa.Descricao, missa.Igreja));
                    }
                    else
                    {
                        relProdutos.Add(new Produtos(dataFormatada, missa.Data.ToString("HH:mm"), acolitos, missa.Descricao, missa.Igreja));
                    }
                }

                return relProdutos;
            }

            private static List<string> SelecionarPorPrioridadeUltimaEscala(
                List<string> listaDisponiveis,
                Dictionary<string, DateTime> ultimaEscalaPorAcolito,
                int quantidade,
                DateTime dataMissa,
                Random rand)
            {
                var selecionados = listaDisponiveis
                    .OrderBy(nome => ultimaEscalaPorAcolito.ContainsKey(nome) ? 1 : 0)
                    .ThenBy(nome => ultimaEscalaPorAcolito.GetValueOrDefault(nome))
                    .ThenBy(_ => rand.Next())
                    .Take(quantidade)
                    .ToList();

                foreach (var nome in selecionados)
                    ultimaEscalaPorAcolito[nome] = dataMissa;

                return selecionados;
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
            btnAdicionarLinha.Text = "+";
            btnRemoverLinha.Text = "-";
            btnAdicionarLinha.BackColor = UiTheme.Surface;
            btnRemoverLinha.BackColor = UiTheme.Surface;
            btnAdicionarLinha.ForeColor = UiTheme.Text;
            btnRemoverLinha.ForeColor = UiTheme.Text;
            cmb_diasSemana.DropDownStyle = ComboBoxStyle.DropDownList;
            ConfigurarGridEscala();
            Resize += (_, _) => AjustarLayout();
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

        private void AjustarLayout()
        {
            const int margin = 32;
            skyLabel1.Location = new System.Drawing.Point(margin, 28);
            cmb_diasSemana.Location = new System.Drawing.Point(margin, 92);
            cmb_diasSemana.Size = new Size(220, 32);
            button1.Location = new System.Drawing.Point(margin, 152);
            button1.Size = new Size(220, 42);
            btnGerarPdf.Location = new System.Drawing.Point(button1.Right + 12, 152);
            btnGerarPdf.Size = new Size(160, 42);
            btnRemoverLinha.Size = new Size(36, 30);
            btnRemoverLinha.Location = new System.Drawing.Point(Width - margin - btnRemoverLinha.Width, 210);
            btnAdicionarLinha.Size = new Size(36, 30);
            btnAdicionarLinha.Location = new System.Drawing.Point(btnRemoverLinha.Left - btnAdicionarLinha.Width - 8, 210);
            dgvEscala.Location = new System.Drawing.Point(margin, 248);
            dgvEscala.Size = new Size(Math.Max(320, Width - (margin * 2)), Math.Max(120, Height - 280));
        }
    }
}

   
