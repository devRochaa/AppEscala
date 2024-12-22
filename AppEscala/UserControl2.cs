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
    public partial class UserControl2 : UserControl
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";


        public UserControl2()
        {
            InitializeComponent();
        }


        private void check_semana_CheckedChanged(object sender, EventArgs e)
        {
            if (check_semana.Checked)
            {

                form_smn formsmn = new form_smn();
                if (formsmn.ShowDialog() == DialogResult.OK) // Exibe Form2 como modal
                {
                    string dadoRecebido = formsmn.Dado; // Obtém o dado da propriedade
                    MessageBox.Show($"Dado recebido: {dadoRecebido}");
                }
            }
        }
        private void check_fimDsmn_CheckedChanged(object sender, EventArgs e)
        {
            if (check_fimDsmn.Checked)
            {
                form_fimDsmn formF = new form_fimDsmn();
                if (formF.ShowDialog() == DialogResult.OK) // Exibe Form2 como modal
                {
                    string dadoRecebido = formF.Dado; // Obtém o dado da propriedade
                    MessageBox.Show($"Dado recebido: {dadoRecebido}");
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        List<string> datas = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {

            foreach (string data in datas)
            {
                if (data == dateTimePicker1.Text)
                {
                    MessageBox.Show("Você já adicionou essa data!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            listView1.Items.Add(dateTimePicker1.Text);
            datas.Add(dateTimePicker1.Text);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.View = View.List;
            listView1.Alignment = ListViewAlignment.Top;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                //Criar conexão com mysql
                Conexao = new MySqlConnection(data_source);

                string sql = "INSERT INTO acolitos (nome) VALUES ('" + txtNome.Text + "')";
                //string sql2 = "INSERT INTO disponibilidade (id_acolito, seg, ter, qua, qui, sex, sab, dom) VALUES" +
                //    " ( '"+ +"', '"+ +"', '"+ +"', '"+ +"', '"+ +"', '"+ +"', '"+ +"', '"+ +"')";
                //foreach (string data in datas)
                //{ 
                //string sql3 = "INSERT INTO dia (id_acolito,dia) VALUES (,)";  
                //}


                //executar comando insert

                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                Conexao.Open();

                comando.ExecuteReader();
                MessageBox.Show("Deu tudo certo!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { 
                Conexao.Close();
            }
        }
    }
}
