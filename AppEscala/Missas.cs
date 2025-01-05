using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout.Element;
using iText.StyledXmlParser.Jsoup.Nodes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Encoders;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace AppEscala
{
    public partial class Missas : UserControl
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";

        public Missas()
        {
            InitializeComponent();
        }

        private void Missas_Load(object sender, EventArgs e)
        {
            MontarHorarios();
        }

        private void MontarHorarios()
        {
            var horario = new TimeSpan(0, 0, 0);
            var incremento = new TimeSpan(0, 30, 0);

            listBox1.ColumnWidth = 60;
            for (int i = 0; i < 48; i++)
            {
                listBox1.Items.Add(horario.ToString().Substring(0, 5));
                horario += incremento;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(listBox1.Text))
            {
                MessageBox.Show("Selecione um horário!");
                return;
            }

            var data = dateTimePicker1.Value.ToString().Substring(0, 10);
            var hora = listBox1.Text.TrimStart();
            MessageBox.Show($"{data} {hora}");

            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();
                cmd.CommandText = "INSERT INTO missas " +
                    "(id_igreja, data, horario)" +
                    " VALUES (@id_igreja, @data, @horario)";


                //cmd.Parameters.AddWithValue("@Id", Id);


                cmd.ExecuteNonQuery();

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

        }

        private void btn_AddIgreja_Click(object sender, EventArgs e)
        {
            form_igreja form_Igreja = new form_igreja();
            form_Igreja.Show();
        }
    }
}

