using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
using MySql.Data.MySqlClient;
using AppEscala.Models;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;

namespace AppEscala
{
    public partial class UserControl1 : UserControl
    {
        private static Database db;
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";
        
        public UserControl1()
        {
            InitializeComponent();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            db = new Database();
            db.Initialize();
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


            //    public static List<Produtos> GetListaProdutos()
            //    {
            //        //instanciar um objeto Lista de produtos
            //        var relProdutos = new List<Produtos>();


            //        relProdutos.Add(new Produtos("02-6ª.Feira", "19h30", "Daniel/Gabriel/João/Felipe", "", "Matriz"));
            //        relProdutos.Add(new Produtos("22-Sábado", "09h00", "Luisa/Gabriela", "Novena", "Sto. Frei Galvão/Sta. Filomena"));
            //        relProdutos.Add(new Produtos("01-Sábado", "08h00", "Ana/Marcos/João", "Matriz", "Cemitério"));
            //        relProdutos.Add(new Produtos("03-Domingo", "07h00", "Carlos/Marina/Fernando", "", "São José"));
            //        relProdutos.Add(new Produtos("04-2ª.Feira", "15h00", "Lucas/Sofia/Paulo", "Novena", "Matriz"));
            //        relProdutos.Add(new Produtos("05-3ª.Feira", "19h30", "Mateus/Bruna/Renata", "", "Matriz"));
            //        relProdutos.Add(new Produtos("06-4ª.Feira", "18h00", "Tiago/Júlia/Pedro", "Novena", "Sto. Frei Galvão"));
            //        relProdutos.Add(new Produtos("07-5ª.Feira", "19h30", "André/Larissa/Felipe", "", "São Sebastião"));
            //        relProdutos.Add(new Produtos("08-6ª.Feira", "20h00", "Débora/Rafael/Victor", "Novena", "Cristo Rei"));
            //        relProdutos.Add(new Produtos("09-Sábado", "17h00", "Joana/Marcelo/Helena", "", "Santa Cecília"));
            //        relProdutos.Add(new Produtos("10-Domingo", "09h00", "Carla/Thiago/Vinícius", "Novena", "Matriz"));
            //        relProdutos.Add(new Produtos("11-2ª.Feira", "19h30", "Ester/Leonardo/Natalia", "", "Santa Catarina"));
            //        relProdutos.Add(new Produtos("12-3ª.Feira", "18h30", "Aline/Ricardo/Gustavo", "Novena", "N.S. Graças"));
            //        relProdutos.Add(new Produtos("13-4ª.Feira", "19h00", "Fernanda/Luiz/Amanda", "", "Cristo Rei"));
            //        relProdutos.Add(new Produtos("14-5ª.Feira", "20h00", "Isabela/Renato/Clara", "Novena", "Sto. Frei Galvão"));
            //        relProdutos.Add(new Produtos("15-6ª.Feira", "19h30", "Sérgio/Patrícia/Luana", "", "São José"));
            //        relProdutos.Add(new Produtos("16-Sábado", "16h00", "Rodrigo/Mariana/Tânia", "Novena", "Santa Cecília"));
            //        relProdutos.Add(new Produtos("17-Domingo", "18h00", "Igor/Rafaela/Davi/Clementina/Zé.Felipe/Daniel/Rocha/Oliveira", "", "N.S. Aparecida"));
            //        relProdutos.Add(new Produtos("18-2ª.Feira", "19h30", "Camila/Fabiano/Flávia", "Novena", "São Sebastião"));
            //        relProdutos.Add(new Produtos("19-3ª.Feira", "07h00", "Beatriz/Mateus/Rose", "", "Santa Catarina"));
            //        relProdutos.Add(new Produtos("20-4ª.Feira", "18h30", "Juliano/Priscila/Samuel", "Novena", "Sto. Frei Galvão"));
            //        relProdutos.Add(new Produtos("21-5ª.Feira", "19h00", "Viviane/Anderson/Lígia", "", "Cristo Rei"));
            //        relProdutos.Add(new Produtos("23-6ª.Feira", "20h00", "Eduardo/Susana/Elisa", "Novena", "São José"));
            //        relProdutos.Add(new Produtos("24-Sábado", "17h00", "Paulo/Letícia/Fernando", "", "Santa Cecília"));
            //        relProdutos.Add(new Produtos("25-Domingo", "08h00", "Luciana/Ronaldo/Regina", "Novena", "N.S. Graças"));
            //        relProdutos.Add(new Produtos("26-2ª.Feira", "19h30", "Henrique/Glória/Márcia", "", "São Sebastião"));
            //        relProdutos.Add(new Produtos("27-3ª.Feira", "07h00", "Alexandre/Daniela/Eliane", "Novena", "Sto. Frei Galvão"));
            //        relProdutos.Add(new Produtos("28-4ª.Feira", "18h30", "Vitor/Rosana/Danilo", "", "Cristo Rei"));
            //        relProdutos.Add(new Produtos("29-5ª.Feira", "20h00", "Jéssica/Artur/Talita", "Novena", "São José"));
            //        relProdutos.Add(new Produtos("30-Sexta", "19h00", "Gabriela/Emanuel/Caio", "", "N.S. Aparecida"));
            //        relProdutos.Add(new Produtos("31-Sábado", "18h00", "Clarice/Osvaldo/Breno", "Novena", "Santa Cecília"));


            //        return relProdutos;
            //    }
            private static MySqlConnection Conexao;
            private static string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";
            public string EncaixarAcolitos(string data, string horario, int quant)
            {


                string acolitos;
                DateTime dataConvertida = DateTime.Parse(data);
                DayOfWeek diaSemana = dataConvertida.DayOfWeek;
                int horas = int.Parse(horario.Substring(0, 2));
                if (horas < 12) 
                {
                    int turnoMissa = 1;
                }
                if (horas > 12 && horas < 18)
                {
                    int turnoMissa = 2;
                }
                if (horas > 18 || horas == 0)
                {
                    int turnoMissa = 3;
                }
                try
                {
                    Conexao = new MySqlConnection(data_source);
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conexao;
                    Conexao.Open();
                    cmd.CommandText = "SELECT A.nome FROM acolitos A " +
                "INNER JOIN disponibilidade D ON D.id_acolito = A.id" +
                "INNER JOIN dias_semana S on S.id = D.id_dia_semana " +
                "WHERE S.dia_semana = @diaSemana AND D.id_turno = @turnoMissa;";

                    MySqlDataReader reader = cmd.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;  // Contar as linhas
                    }
                    while (reader.Read())
                    {
                        Random random = new Random();                       
                        int numeroAleatorio = random.Next(0, count);
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erro MySQL: {ex.Message}");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro geral: {ex.Message}");

                }

                finally
                {
                    if (Conexao != null && Conexao.State == ConnectionState.Open)
                    {
                        Conexao.Close();
                    }
                }
                return "";
            }
            public static string ConverterData(int indexDia)
            {
                string[] dias = ["Domingo", "2ª.feira", "3ª.feira", "4ª.feira", "5ª.feira", "6ª.feira", "Sábado"];
                return dias[indexDia];
            }
            public static List<Produtos> GetListaProdutos()
            {
                var listaMissa = db.SelectAllMissas();
                var relProdutos = new List<Produtos>();
                foreach(var missa in listaMissa)
                {
                    //string format = "dddd";
                    //string cultureInfo = "pt-BR";
                    //MessageBox.Show($"{dataConvertida.ToString(format, new CultureInfo(cultureInfo))}");
                    //MessageBox.Show($"{diaConvertido}");
                    DateTime dataConvertida = DateTime.Parse(missa.Data);
                    string diaConvertido = ConverterData((int)dataConvertida.DayOfWeek);

                    relProdutos.Add(new Produtos(diaConvertido, missa.Horario, "Daniel/Gabriel/João/Felipe", missa.Descricao, missa.Igreja));
                }


                //try
                //{
                //    Conexao = new MySqlConnection(data_source);
                //    MySqlCommand cmd = new MySqlCommand();
                //    cmd.Connection = Conexao;
                //    Conexao.Open();
                //    cmd.CommandText = "SELECT m.data, m.horario, m.descricao, i.nome from missas m " +
                //"INNER JOIN igreja i ON m.id_igreja = i.id;";

                //    MySqlDataReader reader = cmd.ExecuteReader();
                    
                //    while (reader.Read())
                //    {
                //        relProdutos.Add(new Produtos(reader.GetString(0), reader.GetString(1), "Daniel/Gabriel/João/Felipe", reader.GetString(2), reader.GetString(3)));
                //    }

                //}
                //catch (MySqlException ex)
                //{
                //    MessageBox.Show($"Erro MySQL: {ex.Message}");

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"Erro geral: {ex.Message}");

                //}

                //finally
                //{
                //    if (Conexao != null && Conexao.State == ConnectionState.Open)
                //    {
                //        Conexao.Close();
                //    }
                //}
                //instanciar um objeto Lista de produtos
                

                //relProdutos.Add(new Produtos("02-6ª.Feira", "19h30", "Daniel/Gabriel/João/Felipe", "", "Matriz"));

                return relProdutos;
            }
        }

    }
}
