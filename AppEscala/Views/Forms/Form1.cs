using AppEscala.AppDatabase;
using AppEscala.Helpers;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
using Svg;


namespace AppEscala
{
    public partial class form_menu : Form
    {
        private readonly Panel menuPanel = new();
        private readonly Panel igrejasPanel = new();
        private readonly Button btnCadastrarIgreja = new();
        private readonly DataGridView dgvIgrejas = new();
        private readonly Label lblIgrejasVazio = new();
        private readonly Database database = new();
        private readonly Panel sidebarFooterSpacer = new();
        private readonly Dictionary<Button, string> sidebarButtonTexts = new();
        private const int SidebarExpandedWidth = 190;
        private const int SidebarCollapsedWidth = 52;
        private const int SidebarItemHeight = 52;
        private const int SidebarAnimationStep = 20;
        private bool sidebarCollapsing;

        public form_menu(AppDbContext db)
        {
            InitializeComponent();
            db.Database.EnsureCreated();
            database.Initialize();
            ModernizarInterface();
            userAcolitos.AdicionarAcolitoRequested += (_, _) => ExibirTela(userControl21, subMenu1, "NOVO ACOLITO");
            userControl21.VoltarRequested += (_, _) => ExibirTela(userAcolitos, subMenu1, "ACOLITOS");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GerarPdf();
        }

        private void GerarPdf()
        {
            var arquivo = @"C:\dados\recibo.pdf";


            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);
                var document = new Document(pdfDocument, PageSize.A4);

                //criar tabela
                float[] columnWidth = { 15, 10, 35, 15, 25 };
                Table tabela = new Table(UnitValue.CreatePercentArray(columnWidth)).UseAllAvailableWidth();

                //Título do cabeçalho da tabela
                var fonte = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                var cellFotter = new Cell(1, 5).Add(new Paragraph("Escala dos acólitos"))
                    .SetFont(fonte)
                    .SetFontSize(13)
                    .SetFontColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER);

                tabela.AddHeaderCell(cellFotter);


                tabela.AddHeaderCell(new Cell(1, 5).Add(new Paragraph("Escala dos acólitos")
                    .SetFont(fonte)
                    .SetFontSize(18)

                    .SetFontColor(ColorConstants.BLUE)
                    .SetBackgroundColor(ColorConstants.YELLOW)
                    .SetTextAlignment(TextAlignment.CENTER)));
                ;

                //Cabeçalho com os títulos das colunas da tabela

                tabela.AddHeaderCell(new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .Add(new Paragraph("DATA")));
                tabela.AddHeaderCell(new Cell()
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("HORÁRIO")));
                tabela.AddHeaderCell(new Cell()
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("ACÓLITOS")));
                tabela.AddHeaderCell(new Cell()
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .Add(new Paragraph(" ")));
                tabela.SetSkipFirstHeader(false);
                tabela.AddHeaderCell(new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .Add(new Paragraph("LOCAL")));
                tabela.SetSkipFirstHeader(false);

                var listaProdutos = Produtos.GetListaProdutos();

                foreach (Produtos prod in listaProdutos)
                {
                    //primeira coluna data
                    tabela.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new
                        Paragraph(prod.data)));

                    //SEGUNDA COLUNA horario
                    tabela.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new
                        Paragraph(prod.horario)));

                    //TERCEIRA COLUNA acolitos
                    tabela.AddCell(new Cell()
                        .SetTextAlignment(TextAlignment.CENTER).SetMinWidth(40).SetMaxWidth(50).Add(new
                        Paragraph(prod.acolitos)));

                    //QUARTA COLUNA evento
                    tabela.AddCell(new Cell()
                        .SetTextAlignment(TextAlignment.CENTER).Add(new
                        Paragraph(prod.evento)));

                    //QUARTA COLUNA local
                    tabela.AddCell(new Cell()
                        .SetTextAlignment(TextAlignment.CENTER).Add(new
                        Paragraph(prod.local)));
                }

                document.Add(tabela);

                //fecha do documento
                document.Close();
                pdfDocument.Close();

                MessageBox.Show("Arquivo PDF gerado em " + arquivo);
            }
        }

        bool menuExpand = false;


        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                //velocidade de descidada do menu
                MenuContainer.Height += 3;

                //Aqui é o quanto que a o menu vai descer
                if (MenuContainer.Height >= 145)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            //kkakaak
            else
            {
                //velocidade de subida 
                MenuContainer.Height -= 3;
                //aqui é o qunato que o menu vai subir(quanto maior o valor,menos ele vai subir)
                if (MenuContainer.Height <= 65)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExibirTela(menuPanel, menu, "MENU");
            panel1.BringToFront();
            AjustarLayout();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ExibirTela(menuPanel, menu, "MENU");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            ExibirTela(missas1, button7, "MISSAS");

        }
        bool sidebarExpand = true;
        private void timerSideBarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                //velocidade em que a barra horizontal vai fechar
                sidebar.Width = Math.Max(SidebarCollapsedWidth, sidebar.Width - SidebarAnimationStep);
                //regula o quanto que o sidebar(barra lateral preta) vai fechar 
                if (sidebar.Width <= SidebarCollapsedWidth)
                {

                    timerSideBarTransition.Stop();
                    sidebarExpand = false;
                    sidebar.Width = SidebarCollapsedWidth;
                    sidebarCollapsing = false;
                    //permitem que as palavras após os icones surjam apenas quando a transição de expanção estiver completa 
                }
            }
            else
            {
                //velocidade em que a barra horizontal vai abrir
                sidebar.Width = Math.Min(SidebarExpandedWidth, sidebar.Width + SidebarAnimationStep);
                //regula o quanto que o sidebar(barra lateral preta) vai abrir 
                if (sidebar.Width >= SidebarExpandedWidth)
                {
                    sidebarExpand = true;
                    timerSideBarTransition.Stop();
                    sidebar.Width = SidebarExpandedWidth;
                    //permitem que as palavras após os icones surjam apenas quando a transição de expanção estiver completa 
                }
            }

            AjustarLayout();
        }
        //
        private void btnHam_Click(object sender, EventArgs e)
        {
            if (timerSideBarTransition.Enabled)
                return;

            sidebarCollapsing = sidebarExpand;
            AplicarEstadoSidebar();
            timerSideBarTransition.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void subMenu1_Click(object sender, EventArgs e)
        {
            //if (sub1 == null)
            //{
            //    sub1 = new FrmSub1();
            //    sub1.FormClosed += sub1_FormClosed;
            //    sub1.MdiParent = this;
            //    sub1.Dock = DockStyle.Fill;
            //    sub1.Show();

            //}
            //else
            //{
            //    sub1.Activate();
            //}

            ExibirTela(userAcolitos, subMenu1, "ACOLITOS");
        }

        

        private void subMenu2_Click(object sender, EventArgs e)
        {
            ExibirTela(userControl21, subMenu1, "NOVO ACOLITO");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExibirTela(userControl11, button3, "GERAR ESCALA");
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            ExibirTela(igrejasPanel, button2, "IGREJAS");
        }

        private void ModernizarInterface()
        {
            UiTheme.Apply(this);
            BackColor = System.Drawing.Color.FromArgb(246, 248, 251);
            ClientSize = new Size(980, 620);
            MinimumSize = new Size(900, 560);

            panel1.BackColor = System.Drawing.Color.White;
            panel1.Height = 56;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label1.ForeColor = UiTheme.Text;
            label1.Text = "App Escala";
            label1.Location = new System.Drawing.Point(60, 18);

            btnHam.Size = new Size(32, 32);
            btnHam.Location = new System.Drawing.Point(16, 12);
            btnHam.Cursor = Cursors.Hand;
            timerSideBarTransition.Interval = 10;

            sidebar.BackColor = UiTheme.Sidebar;
            sidebar.Padding = new Padding(0, 18, 0, 0);
            sidebar.Width = SidebarExpandedWidth;
            sidebar.WrapContents = false;
            MenuContainer.BackColor = UiTheme.Sidebar;
            MenuContainer.Height = SidebarItemHeight;
            MenuContainer.Controls.Clear();
            MenuContainer.Controls.Add(panel3);
            panel4.Visible = false;
            sidebar.Controls.Add(panel2);
            sidebar.Controls.SetChildIndex(panel2, 1);
            if (!sidebar.Controls.Contains(sidebarFooterSpacer))
                sidebar.Controls.Add(sidebarFooterSpacer);
            sidebar.Controls.SetChildIndex(sidebarFooterSpacer, sidebar.Controls.IndexOf(pnLogout));
            sidebarFooterSpacer.Margin = Padding.Empty;
            sidebarFooterSpacer.BackColor = UiTheme.Sidebar;
            button9.Visible = false;

            menu.Text = "      Menu";
            subMenu1.Text = "    Acólitos";
            button7.Text = "     Missas";
            button3.Text = "     Escalas";
            button2.Text = "      Igrejas";
            button8.Text = "     Sair";

            sidebarButtonTexts.Clear();
            sidebarButtonTexts[menu] = "Menu";
            sidebarButtonTexts[subMenu1] = "Acólitos";
            sidebarButtonTexts[button7] = "Missas";
            sidebarButtonTexts[button3] = "Escalas";
            sidebarButtonTexts[button2] = "Igrejas";
            sidebarButtonTexts[button8] = "Sair";
            AtribuirIconesSidebar();

            foreach (var button in new[] { menu, subMenu1, button7, button3, button2, button8 })
                UiTheme.StyleSidebarButton(button);

            button2.Enabled = true;
            button2.Click += button2_Click;
            button8.BackColor = System.Drawing.Color.FromArgb(127, 29, 29);

            CriarTelaMenu();
            CriarTelaIgrejas();
            Controls.Add(menuPanel);
            Controls.Add(igrejasPanel);

            Resize += (_, _) => AjustarLayout();
        }

        private void AjustarLayout()
        {
            panel1.Width = ClientSize.Width;
            nightControlBox1.Location = new System.Drawing.Point(ClientSize.Width - nightControlBox1.Width - 8, 10);

            sidebar.Location = new System.Drawing.Point(0, panel1.Height);
            sidebar.Height = ClientSize.Height - panel1.Height;

            int contentX = sidebar.Width;
            int contentY = panel1.Height;
            int contentWidth = Math.Max(320, ClientSize.Width - contentX);
            int contentHeight = Math.Max(260, ClientSize.Height - contentY);

            foreach (Control tela in new Control[] { menuPanel, igrejasPanel, userControl11, userControl21, userAcolitos, missas1 })
                tela.Bounds = new System.Drawing.Rectangle(contentX, contentY, contentWidth, contentHeight);

            foreach (Panel panel in new[] { panel3, panel2, pnEscala, pnInfo, pnConfig, pnLogout })
            {
                panel.Width = sidebar.Width;
                panel.Height = SidebarItemHeight;
                panel.Margin = Padding.Empty;
                if (panel.Controls.Count > 0)
                    panel.Controls[0].Bounds = new System.Drawing.Rectangle(0, 0, sidebar.Width, SidebarItemHeight);
            }

            MenuContainer.Width = sidebar.Width;
            MenuContainer.Height = SidebarItemHeight;
            sidebarFooterSpacer.Width = sidebar.Width;
            sidebarFooterSpacer.Height = CalcularAlturaEspacadorSidebar();
            AplicarEstadoSidebar();

            dgvIgrejas.Size = new Size(Math.Max(320, igrejasPanel.Width - 68), Math.Max(180, igrejasPanel.Height - 208));
        }

        private void ExibirTela(Control telaAtiva, Button botaoAtivo, string titulo)
        {
            foreach (Control tela in new Control[] { menuPanel, igrejasPanel, userControl11, userControl21, userAcolitos, missas1 })
                tela.Hide();

            foreach (var button in new[] { menu, subMenu1, button7, button3, button2, button8 })
                UiTheme.StyleSidebarButton(button);

            UiTheme.StyleSidebarButton(botaoAtivo, active: true);
            AplicarEstadoSidebar();
            label1.Text = $"App Escala | {titulo}";
            if (telaAtiva == igrejasPanel)
                CarregarIgrejas();

            telaAtiva.Show();
            telaAtiva.BringToFront();
            panel1.BringToFront();
            sidebar.BringToFront();
        }

        private void AtribuirIconesSidebar()
        {
            menu.Image = CriarIconeSvg("escala.svg");
            subMenu1.Image = CriarIconeSvg("acolitos.svg");
            button7.Image = CriarIconeSvg("missa.svg");
            button3.Image = CriarIconeSvg("escala.svg");
            button2.Image = CriarIconeSvg("igreja.svg");
            button8.Image = CriarIconeSvg("sair.svg");
        }

        private void AplicarEstadoSidebar()
        {
            bool fechado = sidebarCollapsing || !sidebarExpand || sidebar.Width <= SidebarCollapsedWidth + 8;

            foreach (var item in sidebarButtonTexts)
            {
                Button button = item.Key;
                button.Text = fechado ? string.Empty : $"      {item.Value}";
                button.Padding = fechado ? Padding.Empty : new Padding(14, 0, 0, 0);
                button.ImageAlign = fechado ? ContentAlignment.MiddleCenter : ContentAlignment.MiddleLeft;
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.TextImageRelation = TextImageRelation.Overlay;
                button.FlatAppearance.MouseOverBackColor = UiTheme.SidebarHover;
            }
        }

        private int CalcularAlturaEspacadorSidebar()
        {
            int itensAntesDoRodape = 5;
            int alturaUsada = sidebar.Padding.Top + (itensAntesDoRodape * SidebarItemHeight) + SidebarItemHeight;
            return Math.Max(0, sidebar.Height - alturaUsada);
        }

        private static Bitmap CriarIconeSvg(string nomeArquivo)
        {
            string caminho = System.IO.Path.Combine(AppContext.BaseDirectory, "Resources", nomeArquivo);
            if (!File.Exists(caminho))
                caminho = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", nomeArquivo);

            string svg = File.ReadAllText(caminho)
                .Replace("currentColor", "#FFFFFF", StringComparison.OrdinalIgnoreCase)
                .Replace("#000000", "#FFFFFF", StringComparison.OrdinalIgnoreCase);

            SvgDocument document = SvgDocument.FromSvg<SvgDocument>(svg);
            Bitmap bitmap = document.Draw(24, 24);
            bitmap.SetResolution(96, 96);
            return bitmap;
        }

        private void CriarTelaMenu()
        {
            menuPanel.Controls.Clear();
            UiTheme.Apply(menuPanel);

            Label titulo = new()
            {
                AutoSize = true,
                Text = "Menu",
                Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold),
                ForeColor = UiTheme.Text,
                Location = new System.Drawing.Point(32, 30)
            };

            Button btnAcolitos = CriarAtalho("Acólitos", (_, _) => ExibirTela(userAcolitos, subMenu1, "ACOLITOS"));
            Button btnMissas = CriarAtalho("Missas", (_, _) => ExibirTela(missas1, button7, "MISSAS"));
            Button btnEscalas = CriarAtalho("Escalas", (_, _) => ExibirTela(userControl11, button3, "GERAR ESCALA"));
            Button btnIgrejas = CriarAtalho("Igrejas", (_, _) => ExibirTela(igrejasPanel, button2, "IGREJAS"));

            btnAcolitos.Location = new System.Drawing.Point(32, 100);
            btnMissas.Location = new System.Drawing.Point(218, 100);
            btnEscalas.Location = new System.Drawing.Point(404, 100);
            btnIgrejas.Location = new System.Drawing.Point(590, 100);

            menuPanel.Controls.AddRange(new Control[] { titulo, btnAcolitos, btnMissas, btnEscalas, btnIgrejas });
            UiTheme.Apply(menuPanel);
            titulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            titulo.ForeColor = UiTheme.Text;
        }

        private void CriarTelaIgrejas()
        {
            igrejasPanel.Controls.Clear();
            UiTheme.Apply(igrejasPanel);

            Label titulo = new()
            {
                AutoSize = true,
                Text = "Igrejas",
                Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold),
                ForeColor = UiTheme.Text,
                Location = new System.Drawing.Point(32, 30)
            };

            Label descricao = new()
            {
                AutoSize = true,
                Text = "Cadastre igrejas para usar ao montar as missas.",
                ForeColor = UiTheme.MutedText,
                Location = new System.Drawing.Point(34, 78)
            };

            btnCadastrarIgreja.Text = "Adicionar igreja";
            btnCadastrarIgreja.Size = new Size(160, 38);
            btnCadastrarIgreja.Location = new System.Drawing.Point(34, 120);
            btnCadastrarIgreja.Click += (_, _) =>
            {
                using form_igreja formIgreja = new();
                if (formIgreja.ShowDialog() == DialogResult.OK)
                    CarregarIgrejas();
            };

            dgvIgrejas.AllowUserToAddRows = false;
            dgvIgrejas.AllowUserToDeleteRows = false;
            dgvIgrejas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIgrejas.Columns.Clear();
            dgvIgrejas.Columns.Add("id", "Id");
            dgvIgrejas.Columns.Add("nome", "Nome");
            dgvIgrejas.Columns["id"].Width = 70;
            dgvIgrejas.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvIgrejas.Location = new System.Drawing.Point(34, 178);
            dgvIgrejas.MultiSelect = false;
            dgvIgrejas.ReadOnly = true;
            dgvIgrejas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIgrejas.Size = new Size(560, 300);
            dgvIgrejas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblIgrejasVazio.AutoSize = true;
            lblIgrejasVazio.Text = "Nenhuma igreja cadastrada.";
            lblIgrejasVazio.ForeColor = UiTheme.MutedText;
            lblIgrejasVazio.Location = new System.Drawing.Point(40, 190);
            lblIgrejasVazio.Visible = false;

            igrejasPanel.Controls.AddRange(new Control[] { titulo, descricao, btnCadastrarIgreja, dgvIgrejas, lblIgrejasVazio });
            UiTheme.Apply(igrejasPanel);
            titulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            titulo.ForeColor = UiTheme.Text;
            descricao.ForeColor = UiTheme.MutedText;
        }

        private void CarregarIgrejas()
        {
            dgvIgrejas.Rows.Clear();

            foreach (var igreja in database.SelectAllIgreja())
                dgvIgrejas.Rows.Add(igreja.Id, igreja.Nome);

            bool vazio = dgvIgrejas.Rows.Count == 0;
            dgvIgrejas.Visible = !vazio;
            lblIgrejasVazio.Visible = vazio;
        }

        private static Button CriarAtalho(string texto, EventHandler click)
        {
            Button button = new()
            {
                Text = texto,
                Size = new Size(160, 54)
            };
            button.Click += click;
            return button;
        }
    }
    public class Produtos
    {
        public string data { get; set; }
        public string horario { get; set; }
        public string acolitos { get; set; }
        public string evento { get; set; }
        public string local { get; set; }


        public Produtos(string data, string horario, string acolitos, string evento, string local)
        {
            this.data = data;
            this.horario = horario;
            this.acolitos = acolitos;
            this.evento = evento;
            this.local = local;
        }


        public static List<Produtos> GetListaProdutos()
        {
            //instanciar um objeto Lista de produtos
            var relProdutos = new List<Produtos>();


            relProdutos.Add(new Produtos("02-6ª.Feira", "19h30", "Daniel/Gabriel/João/Felipe", "", "Matriz"));
            relProdutos.Add(new Produtos("22-Sábado", "09h00", "Luisa/Gabriela", "Novena", "Sto. Frei Galvão/Sta. Filomena"));
            relProdutos.Add(new Produtos("01-Sábado", "08h00", "Ana/Marcos/João", "Matriz", "Cemitério"));
            relProdutos.Add(new Produtos("03-Domingo", "07h00", "Carlos/Marina/Fernando", "", "São José"));
            relProdutos.Add(new Produtos("04-2ª.Feira", "15h00", "Lucas/Sofia/Paulo", "Novena", "Matriz"));
            relProdutos.Add(new Produtos("05-3ª.Feira", "19h30", "Mateus/Bruna/Renata", "", "Matriz"));
            relProdutos.Add(new Produtos("06-4ª.Feira", "18h00", "Tiago/Júlia/Pedro", "Novena", "Sto. Frei Galvão"));
            relProdutos.Add(new Produtos("07-5ª.Feira", "19h30", "André/Larissa/Felipe", "", "São Sebastião"));
            relProdutos.Add(new Produtos("08-6ª.Feira", "20h00", "Débora/Rafael/Victor", "Novena", "Cristo Rei"));
            relProdutos.Add(new Produtos("09-Sábado", "17h00", "Joana/Marcelo/Helena", "", "Santa Cecília"));
            relProdutos.Add(new Produtos("10-Domingo", "09h00", "Carla/Thiago/Vinícius", "Novena", "Matriz"));
            relProdutos.Add(new Produtos("11-2ª.Feira", "19h30", "Ester/Leonardo/Natalia", "", "Santa Catarina"));
            relProdutos.Add(new Produtos("12-3ª.Feira", "18h30", "Aline/Ricardo/Gustavo", "Novena", "N.S. Graças"));
            relProdutos.Add(new Produtos("13-4ª.Feira", "19h00", "Fernanda/Luiz/Amanda", "", "Cristo Rei"));
            relProdutos.Add(new Produtos("14-5ª.Feira", "20h00", "Isabela/Renato/Clara", "Novena", "Sto. Frei Galvão"));
            relProdutos.Add(new Produtos("15-6ª.Feira", "19h30", "Sérgio/Patrícia/Luana", "", "São José"));
            relProdutos.Add(new Produtos("16-Sábado", "16h00", "Rodrigo/Mariana/Tânia", "Novena", "Santa Cecília"));
            relProdutos.Add(new Produtos("17-Domingo", "18h00", "Igor/Rafaela/Davi/Clementina/Zé.Felipe/Daniel/Rocha/Oliveira", "", "N.S. Aparecida"));
            relProdutos.Add(new Produtos("18-2ª.Feira", "19h30", "Camila/Fabiano/Flávia", "Novena", "São Sebastião"));
            relProdutos.Add(new Produtos("19-3ª.Feira", "07h00", "Beatriz/Mateus/Rose", "", "Santa Catarina"));
            relProdutos.Add(new Produtos("20-4ª.Feira", "18h30", "Juliano/Priscila/Samuel", "Novena", "Sto. Frei Galvão"));
            relProdutos.Add(new Produtos("21-5ª.Feira", "19h00", "Viviane/Anderson/Lígia", "", "Cristo Rei"));
            relProdutos.Add(new Produtos("23-6ª.Feira", "20h00", "Eduardo/Susana/Elisa", "Novena", "São José"));
            relProdutos.Add(new Produtos("24-Sábado", "17h00", "Paulo/Letícia/Fernando", "", "Santa Cecília"));
            relProdutos.Add(new Produtos("25-Domingo", "08h00", "Luciana/Ronaldo/Regina", "Novena", "N.S. Graças"));
            relProdutos.Add(new Produtos("26-2ª.Feira", "19h30", "Henrique/Glória/Márcia", "", "São Sebastião"));
            relProdutos.Add(new Produtos("27-3ª.Feira", "07h00", "Alexandre/Daniela/Eliane", "Novena", "Sto. Frei Galvão"));
            relProdutos.Add(new Produtos("28-4ª.Feira", "18h30", "Vitor/Rosana/Danilo", "", "Cristo Rei"));
            relProdutos.Add(new Produtos("29-5ª.Feira", "20h00", "Jéssica/Artur/Talita", "Novena", "São José"));
            relProdutos.Add(new Produtos("30-Sexta", "19h00", "Gabriela/Emanuel/Caio", "", "N.S. Aparecida"));
            relProdutos.Add(new Produtos("31-Sábado", "18h00", "Clarice/Osvaldo/Breno", "Novena", "Santa Cecília"));


            return relProdutos;
        }
    }

}
