using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
                    // Obtém o dado da propriedade
                    int[] seg = formsmn.seg;
                    int[] ter = formsmn.ter;
                    int[] qua = formsmn.qua;
                    int[] qui = formsmn.qui;
                    int[] sex = formsmn.sex;
                    int tds = formsmn.tds;
                    
                    //string mensagem = string.Join(", ", seg);
                    //MessageBox.Show($"Dado recebido: {mensagem}");
                }
            }
        }

        public static string Semana(int[] a, int[] b)
        {
            if (a[0] == 1)
            {
                int m = 1;
            }
            if(a[1] == 1)
            {
                int t = 2;
            }
            if (a[2] == 1)
            {
                int n = 3;
            }
            return m + t + n;
        }
        private void check_fimDsmn_CheckedChanged(object sender, EventArgs e)
        {
            if (check_fimDsmn.Checked)
            {
                form_fimDsmn formF = new form_fimDsmn();
                if (formF.ShowDialog() == DialogResult.OK) // Exibe Form2 como modal
                {
                    int[] sab = formF.sab;
                    int[] dom = formF.dom;
                    int tds_fds = formF.tds;

                    //string dadoRecebido = formF.Dado; // Obtém o dado da propriedade
                   // MessageBox.Show($"Dado recebido: {dadoRecebido}");
                }
            }
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

                string sql = "INSERT INTO acolitos (nome) VALUES ('" + txtNome.Text + "') SELECT SCOPE_IDENTITY()";
                
                //foreach (string data in datas)
                //{ 
                //string sql3 = "INSERT INTO dia (id_acolito,dia) VALUES (,)";  
                //}


                //executar comando insert
                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                comando.ExecuteReader();
                Int32 idRetorno = Convert.ToInt32(comando.ExecuteScalar());
                //string sql2 = "INSERT INTO disponibilidade (id_acolito, dias_semana, turno) VALUES" +
                //      " ( '" + idRetorno +"' , '" + +"' , '" + +"')";
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
