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


namespace AppEscala
{
    public partial class Form1 : Form
    {
        public Form1()
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

            var texto = "Você completou o Mr.Math asssine para confirmar:";

            var data = "Dia 22 de novembro de 2024";
            var assinatura = "Assinatura:_____________________";

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
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height == )
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
