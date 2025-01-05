using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppEscala
{
    public partial class form_igreja : Form
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";

        public form_igreja()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_igreja.TextLength == 0) 
            {
                MessageBox.Show("Você precisa escrever o nome antes!");
                return;
            }
            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();
                cmd.CommandText = "INSERT INTO igreja " +
                    "(nome)" +
                    " VALUES (@nome)";


                cmd.Parameters.AddWithValue("@nome", txt_igreja.Text);


                cmd.ExecuteNonQuery();
                MessageBox.Show($"Igreja {txt_igreja.Text} foi adicionada!");
                Close();
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
    }
}
