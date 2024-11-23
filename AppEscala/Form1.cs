using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

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

            var texto = "Esse é um texto de teste asssine para confirmar:";

            var data = "Dia 22 de novembro de 2024";
            var assinatura = "Assinatura:_____________________";

            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(wPdf);

                var document = new Document(pdfDocument, PageSize.A4);
                document.Add(new Paragraph("Recibo:"));
                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph(texto));
                document.Add(new Paragraph("\n\n\n"));
                document.Add(new Paragraph(data));
                document.Add(new Paragraph(assinatura));
                document.Add(new Paragraph("Programação Plena."));
                document.Close();

                pdfDocument.Close();

                MessageBox.Show("Arquivo PDF gerado em " + arquivo);
            }
        }
    }
}
