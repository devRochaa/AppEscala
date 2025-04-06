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

            for (int i = 0; i < 10; i++)
            {
                cmb_diasSemana.Items.Add(i);
            }
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
                float[] columnWidth = { 15, 10, 40, 10, 25 };
                Table tabela = new Table(UnitValue.CreatePercentArray(columnWidth)).UseAllAvailableWidth();

                //Título do cabeçalho da tabela
                var fonte = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                var fonteNegrito = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                string day = DateTime.Now.Day.ToString();
                string mes = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("pt-BR"));
                mes = char.ToUpper(mes[0]) + mes.Substring(1);

                var cellFotter = new Cell(1, 5).Add(new Paragraph("Escala dos acólitos " + day + " - " + mes))
                    .SetFont(fonteNegrito)
                    .SetFontSize(10)
                    .SetFontColor(ColorConstants.BLACK)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER);

                tabela.AddHeaderCell(cellFotter);




                //Cabeçalho com os títulos das colunas da tabela

                tabela.AddHeaderCell(new Cell()
                    .SetFont(fonteNegrito)
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .Add(new Paragraph("DATA")));
                tabela.AddHeaderCell(new Cell()
                    .SetFont(fonteNegrito)
                    .SetFontSize(10)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("HORÁRIO")));
                tabela.AddHeaderCell(new Cell()
                    .SetFont(fonteNegrito)
                    .SetFontSize(10)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph("ACÓLITOS")));
                tabela.AddHeaderCell(new Cell()
                    .SetFont(fonteNegrito)
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .Add(new Paragraph(" ")));
                tabela.SetSkipFirstHeader(false);
                tabela.AddHeaderCell(new Cell()
                    .SetFont(fonteNegrito)
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.WHITE)
                    .Add(new Paragraph("LOCAL")));
                tabela.SetSkipFirstHeader(false);

                var listaProdutos = Produtos.GetListaProdutos();

                foreach (Produtos prod in listaProdutos)
                {
                    //primeira coluna data
                    tabela.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(9).Add(new
                        Paragraph(prod.data)));

                    //SEGUNDA COLUNA horario
                    tabela.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).SetFontSize(9).Add(new
                        Paragraph(prod.horario)));

                    //TERCEIRA COLUNA acolitos
                    tabela.AddCell(new Cell()
                        .SetTextAlignment(TextAlignment.LEFT).SetMinWidth(40).SetMaxWidth(50).SetFontSize(9).Add(new
                        Paragraph(prod.acolitos)));

                    //QUARTA COLUNA evento
                    tabela.AddCell(new Cell()
                        .SetTextAlignment(TextAlignment.CENTER).SetFontSize(9).SetFontColor(ColorConstants.RED).Add(new
                        Paragraph(prod.evento)));

                    //QUARTA COLUNA local
                    tabela.AddCell(new Cell()
                        .SetTextAlignment(TextAlignment.CENTER).SetFontSize(9).Add(new
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

            public static string SelecionarAcolitos(int dia, string diaS, int turno, int qntAc)
            {
                dia = dia + 1;
                var lista = db.SelecionarAcolitoDia(dia, diaS, turno);
                string acolitosQpodem = "";
                int indice = lista.Count;
                if (lista.Count >= qntAc)
                {
                    indice = qntAc;
                }
                Random randNum = new Random();

                List<int> lstIndexAcolitos = new List<int>();

                for (int i = 0; i < indice; i++)
                {
                    int indexRand;

                    // Garante que o número seja único na lista
                    do
                    {
                        indexRand = randNum.Next(indice);
                    } while (lstIndexAcolitos.Contains(indexRand));

                    lstIndexAcolitos.Add(indexRand);
                    string strLista = string.Join(", ", lstIndexAcolitos);
                    //MessageBox.Show($"indice: {indice} qntAC:{qntAc} randNUm: {indexRand} listaRNome : {lista[indexRand].Nome} acolitos: {acolitosQpodem} listaIndex:{strLista} ");

                    if (indice == 1 || i + 1 == indice)
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
                        if (indice > 1)
                        {
                            acolitosQpodem += lista[indexRand].Nome + "/ ";
                        }
                    }


                }

                return acolitosQpodem;
            }

            public static int HorarioParaTurno(string horario)
            {
                DateTime horaConvertida = DateTime.Parse(horario);
                //MessageBox.Show($" {horaConvertida.Hour}");
                if (horaConvertida.Hour > 0 && horaConvertida.Hour < 11)
                {
                    return 1;
                }
                if (horaConvertida.Hour >= 12 && horaConvertida.Hour < 18)
                {
                    return 2;
                }
                return 3;

            }
            public static List<Produtos> GetListaProdutos()
            {
                var listaMissa = db.SelectAllMissas();
                var relProdutos = new List<Produtos>();

                foreach (var missa in listaMissa)
                {
                    int turno = HorarioParaTurno(missa.Horario);


                    DateTime dataConvertida = DateTime.Parse(missa.Data);
                    int diaSemanaNum = (int)dataConvertida.DayOfWeek;
                    string diaConvertido = ConverterData(diaSemanaNum);
                    string acolitos = SelecionarAcolitos(diaSemanaNum, missa.Data, turno, missa.Qnt_acolitos);

                    bool isDataRepetida = false;

                    foreach (Produtos p in relProdutos)
                    {
                        string dataJunta = dataConvertida.Day.ToString() + "-" + diaConvertido;
                        if (p.data == dataJunta)
                        {
                            isDataRepetida = true;
                        }

                    }

                    if (isDataRepetida == true)
                    {
                        relProdutos.Add(new Produtos("", missa.Horario, acolitos, missa.Descricao, missa.Igreja));
                    }
                    else
                    {
                        relProdutos.Add(new Produtos(dataConvertida.Day + "-" + diaConvertido, missa.Horario, acolitos, missa.Descricao, missa.Igreja));
                    }

                }


                //instanciar um objeto Lista de produtos


                //relProdutos.Add(new Produtos("02-6ª.Feira", "19h30", "Daniel/Gabriel/João/Felipe", "", "Matriz"));

                return relProdutos;
            }

        }

       
    }
}

   