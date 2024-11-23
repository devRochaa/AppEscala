using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
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
                float[] columnWidth = { 10, 40, 5, 15 };
                Table tabela = new Table(UnitValue.CreatePercentArray(columnWidth)).UseAllAvailableWidth();

                //Título do cabeçalho da tabela
                var fonte = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                tabela.AddHeaderCell(new Cell(1, 4).Add(new Paragraph("Tabela de preços dos produtos")
                    .SetFont(fonte)
                    .SetFontSize(18)
                    .SetPadding(10)
                    .SetFontColor(ColorConstants.BLUE)
                    .SetBackgroundColor(ColorConstants.YELLOW)
                    .SetTextAlignment(TextAlignment.CENTER)));
                ;

                //Cabeçalho com os títulos das colunas da tabela

                tabela.AddHeaderCell(new Cell()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .Add(new Paragraph("Código")));
                tabela.AddHeaderCell(new Cell()
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetPaddingLeft(5)  
                    .Add(new Paragraph("Descrição do produto")));
                tabela.AddHeaderCell(new Cell()
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("UN")));
                tabela.AddHeaderCell(new Cell()
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetPaddingRight(10)
                    .Add(new Paragraph("Preço")));
                tabela.SetSkipFirstHeader(false);


                document.Add(tabela);

                //fecha do documento
                document.Close();
                pdfDocument.Close();

                MessageBox.Show("Arquivo PDF gerado em " + arquivo);
            }
        }
    }
}
