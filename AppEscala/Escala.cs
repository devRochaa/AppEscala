using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace AppEscala
{
    public partial class Escala : UserControl
    {
        public Escala()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                

                return relProdutos;
            }
        }

    }
}
