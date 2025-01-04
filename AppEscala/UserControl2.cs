using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
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


        private int[] seg;
        private int[] ter;
        private int[] qua;
        private int[] qui;
        private int[] sex;
        private int tds_smn;
        private int[] sab;
        private int[] dom;
        private int tds_fds;
        private void check_semana_CheckedChanged(object sender, EventArgs e)
        {
            if (check_semana.Checked)
            {

                form_smn formsmn = new form_smn();
                if (formsmn.ShowDialog() == DialogResult.OK) // Exibe Form2 como modal
                {
                    // Obtém o dado da propriedade
                    seg = formsmn.seg;
                    ter = formsmn.ter;
                    qua = formsmn.qua;
                    qui = formsmn.qui;
                    sex = formsmn.sex;
                    tds_smn = formsmn.tds;

                    //string mensagem = string.Join(", ", seg);
                    //MessageBox.Show($"Dado recebido: {mensagem}");
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
                    sab = formF.sab;
                    dom = formF.dom;
                    tds_fds = formF.tds;

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
        private void AddDias(int Id)             
        {
            try
            {
                Conexao = new MySqlConnection(data_source);

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();
                cmd.CommandText = "INSERT INTO dia (id_acolito,dia) VALUES (@Id, @dia)";
                foreach (string data in datas)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@dia", data);
                    cmd.ExecuteNonQuery();
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

        }
        private void ProcessarSemana(int[] array, Int32 Id, int dia)
        {
            if (array != null)
            {

                // Processar os dados conforme a lógica necessária
                int i = 1;
                int index = 0;
                foreach (int valor in array)
                {
                    
                    if (valor == 1)
                    {
                        array[index] = i;
                    }
                    else
                    {
                        array[index] = 4;
                    }
                    index++;
                    i++;
                }
                //string mensagem = string.Join(", ", array);
                //MessageBox.Show($"Valores sab: {mensagem}");
                
            }
            AdicionarSemana(array, Id, dia);    
            

        }
        private void AdicionarSemana(int[] array, Int32 Id, int dia)
        {
            if (array == null || array.Length == 0) return;
            Conexao = new MySqlConnection(data_source);
            try
            {

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Conexao;
                    Conexao.Open();
                    cmd.CommandText = "INSERT INTO disponibilidade (id_acolito, id_dia_semana, id_turno) VALUES (@Id, @Dia, @Turno)";
                    
                foreach (int valor in array)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Dia", dia);
                    cmd.Parameters.AddWithValue("@Turno", valor);

                    cmd.ExecuteNonQuery();                    
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

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text)) 
            {
                MessageBox.Show("O nome do acólito não pode estar vazio!",
                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                //Criar conexão com mysql
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                cmd.CommandText = "INSERT INTO acolitos (nome) VALUES (@nome); SELECT LAST_INSERT_ID();";
                
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);

                //foreach (string data in datas)
                //{ 
                //string sql3 = "INSERT INTO dia (id_acolito,dia) VALUES (,)";  
                //}


                //executar comando insert


                object result = cmd.ExecuteScalar();
                int idRetorno = Convert.ToInt32(result);
                
                //adiciona dias da semana:
                ProcessarSemana(seg, idRetorno, 1); ProcessarSemana(ter, idRetorno, 2); ProcessarSemana(qua, idRetorno, 3);
                ProcessarSemana(qui, idRetorno, 4); ProcessarSemana(sex, idRetorno, 5);
                ProcessarSemana(sab, idRetorno, 6); ProcessarSemana(dom, idRetorno, 7);

                //adiciona dias:
                if(datas.Count != 0)
                {
                    AddDias(idRetorno);
                }
                

                MessageBox.Show("O Acólito foi adicionado");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
