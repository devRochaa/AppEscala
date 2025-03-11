using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Image = iText.Layout.Element.Image;
using AppEscala.Views;


namespace AppEscala
{
    public partial class form_menu : Form
    {

        

        public form_menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GerarPdf();
        }

        private void GerarPdf()
        {
            var arquivo = @"C:\dados\recibo.pdf";

            var texto = "Voc� completou o Mr.Math asssine para confirmar:";

            var data = "Dia 22 de novembro de 2024";
            var assinatura = "Assinatura:_____________________";

            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);
                var document = new Document(pdfDocument, PageSize.A4);

                //criar tabela
                float[] columnWidth = { 15, 10, 35, 15, 25 };
                Table tabela = new Table(UnitValue.CreatePercentArray(columnWidth)).UseAllAvailableWidth();

                //T�tulo do cabe�alho da tabela
                var fonte = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                var cellFotter = new Cell(1, 5).Add(new Paragraph("Escala dos ac�litos"))
                    .SetFont(fonte)
                    .SetFontSize(13)
                    .SetFontColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER);

                tabela.AddHeaderCell(cellFotter);


                tabela.AddHeaderCell(new Cell(1, 5).Add(new Paragraph("Escala dos ac�litos")
                    .SetFont(fonte)
                    .SetFontSize(18)

                    .SetFontColor(ColorConstants.BLUE)
                    .SetBackgroundColor(ColorConstants.YELLOW)
                    .SetTextAlignment(TextAlignment.CENTER)));
                ;

                //Cabe�alho com os t�tulos das colunas da tabela

                tabela.AddHeaderCell(new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .Add(new Paragraph("DATA")));
                tabela.AddHeaderCell(new Cell()
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("HOR�RIO")));
                tabela.AddHeaderCell(new Cell()
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("AC�LITOS")));
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

                //Aqui � o quanto que a o menu vai descer
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
                //aqui � o qunato que o menu vai subir(quanto maior o valor,menos ele vai subir)
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
            userControl11.Hide();
            userControl21.Hide();
            missas1.Hide();
            panel1.BringToFront();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            userControl11.Hide();
            userAcolitos.Hide();
            userControl21.Hide();

            missas1.Show();

        }
        bool sidebarExpand = true;
        private void timerSideBarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                //velocidade em que a barra horizontal vai fechar
                sidebar.Width -= 5;
                //regula o quanto que o sidebar(barra lateral preta) vai fechar 
                if (sidebar.Width <= 40)
                {

                    timerSideBarTransition.Stop();
                    sidebarExpand = false;
                    //permitem que as palavras ap�s os icones surjam apenas quando a transi��o de expan��o estiver completa 
                    pnConfig.Width = sidebar.Width;
                    pnEscala.Width = sidebar.Width;
                    pnInfo.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                    MenuContainer.Width = sidebar.Width;
                }
            }
            else
            {
                //velocidade em que a barra horizontal vai abrir
                sidebar.Width += 5;
                //regula o quanto que o sidebar(barra lateral preta) vai abrir 
                if (sidebar.Width >= 189)
                {
                    sidebarExpand = true;
                    timerSideBarTransition.Stop();
                    //permitem que as palavras ap�s os icones surjam apenas quando a transi��o de expan��o estiver completa 
                    pnConfig.Width = sidebar.Width;
                    pnEscala.Width = sidebar.Width;
                    pnInfo.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                    MenuContainer.Width = sidebar.Width;
                }
            }
        }
        //
        private void btnHam_Click(object sender, EventArgs e)
        {
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

            // esconder as outras telas
            userControl21.Hide();
            userControl11.Hide();
            missas1.Hide();
            //mostrar a que quer
            userAcolitos.Show();



        }

        

        private void subMenu2_Click(object sender, EventArgs e)
        {
            // esconder as outras telas
            userControl11.Hide();
            userAcolitos.Hide();
            missas1.Hide();
            //mostrar a que quer
            userControl21.Show();

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
            userAcolitos.Hide();
            missas1.Hide();
            userControl21.Hide();
            //mostrar a que quer
            userControl11.Show();
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


            relProdutos.Add(new Produtos("02-6�.Feira", "19h30", "Daniel/Gabriel/Jo�o/Felipe", "", "Matriz"));
            relProdutos.Add(new Produtos("22-S�bado", "09h00", "Luisa/Gabriela", "Novena", "Sto. Frei Galv�o/Sta. Filomena"));
            relProdutos.Add(new Produtos("01-S�bado", "08h00", "Ana/Marcos/Jo�o", "Matriz", "Cemit�rio"));
            relProdutos.Add(new Produtos("03-Domingo", "07h00", "Carlos/Marina/Fernando", "", "S�o Jos�"));
            relProdutos.Add(new Produtos("04-2�.Feira", "15h00", "Lucas/Sofia/Paulo", "Novena", "Matriz"));
            relProdutos.Add(new Produtos("05-3�.Feira", "19h30", "Mateus/Bruna/Renata", "", "Matriz"));
            relProdutos.Add(new Produtos("06-4�.Feira", "18h00", "Tiago/J�lia/Pedro", "Novena", "Sto. Frei Galv�o"));
            relProdutos.Add(new Produtos("07-5�.Feira", "19h30", "Andr�/Larissa/Felipe", "", "S�o Sebasti�o"));
            relProdutos.Add(new Produtos("08-6�.Feira", "20h00", "D�bora/Rafael/Victor", "Novena", "Cristo Rei"));
            relProdutos.Add(new Produtos("09-S�bado", "17h00", "Joana/Marcelo/Helena", "", "Santa Cec�lia"));
            relProdutos.Add(new Produtos("10-Domingo", "09h00", "Carla/Thiago/Vin�cius", "Novena", "Matriz"));
            relProdutos.Add(new Produtos("11-2�.Feira", "19h30", "Ester/Leonardo/Natalia", "", "Santa Catarina"));
            relProdutos.Add(new Produtos("12-3�.Feira", "18h30", "Aline/Ricardo/Gustavo", "Novena", "N.S. Gra�as"));
            relProdutos.Add(new Produtos("13-4�.Feira", "19h00", "Fernanda/Luiz/Amanda", "", "Cristo Rei"));
            relProdutos.Add(new Produtos("14-5�.Feira", "20h00", "Isabela/Renato/Clara", "Novena", "Sto. Frei Galv�o"));
            relProdutos.Add(new Produtos("15-6�.Feira", "19h30", "S�rgio/Patr�cia/Luana", "", "S�o Jos�"));
            relProdutos.Add(new Produtos("16-S�bado", "16h00", "Rodrigo/Mariana/T�nia", "Novena", "Santa Cec�lia"));
            relProdutos.Add(new Produtos("17-Domingo", "18h00", "Igor/Rafaela/Davi/Clementina/Z�.Felipe/Daniel/Rocha/Oliveira", "", "N.S. Aparecida"));
            relProdutos.Add(new Produtos("18-2�.Feira", "19h30", "Camila/Fabiano/Fl�via", "Novena", "S�o Sebasti�o"));
            relProdutos.Add(new Produtos("19-3�.Feira", "07h00", "Beatriz/Mateus/Rose", "", "Santa Catarina"));
            relProdutos.Add(new Produtos("20-4�.Feira", "18h30", "Juliano/Priscila/Samuel", "Novena", "Sto. Frei Galv�o"));
            relProdutos.Add(new Produtos("21-5�.Feira", "19h00", "Viviane/Anderson/L�gia", "", "Cristo Rei"));
            relProdutos.Add(new Produtos("23-6�.Feira", "20h00", "Eduardo/Susana/Elisa", "Novena", "S�o Jos�"));
            relProdutos.Add(new Produtos("24-S�bado", "17h00", "Paulo/Let�cia/Fernando", "", "Santa Cec�lia"));
            relProdutos.Add(new Produtos("25-Domingo", "08h00", "Luciana/Ronaldo/Regina", "Novena", "N.S. Gra�as"));
            relProdutos.Add(new Produtos("26-2�.Feira", "19h30", "Henrique/Gl�ria/M�rcia", "", "S�o Sebasti�o"));
            relProdutos.Add(new Produtos("27-3�.Feira", "07h00", "Alexandre/Daniela/Eliane", "Novena", "Sto. Frei Galv�o"));
            relProdutos.Add(new Produtos("28-4�.Feira", "18h30", "Vitor/Rosana/Danilo", "", "Cristo Rei"));
            relProdutos.Add(new Produtos("29-5�.Feira", "20h00", "J�ssica/Artur/Talita", "Novena", "S�o Jos�"));
            relProdutos.Add(new Produtos("30-Sexta", "19h00", "Gabriela/Emanuel/Caio", "", "N.S. Aparecida"));
            relProdutos.Add(new Produtos("31-S�bado", "18h00", "Clarice/Osvaldo/Breno", "Novena", "Santa Cec�lia"));


            return relProdutos;
        }
    }

}
