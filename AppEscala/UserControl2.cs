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
        private int[] ProcessarSemana(int[] array, Int32 Id, int dia)
        {
            if (array != null)
            {

                // Processar os dados conforme a lógica necessária
                int i = 1;
                int index = 0;
                foreach (int valor in array)
                {
                    MessageBox.Show($"Valores antes sab: {valor}");
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
                string mensagem = string.Join(", ", array);
                MessageBox.Show($"Valores sab: {mensagem}");
                
            }
            AdicionarSemana(array, Id, dia);    
            return array;

        }
        private int[] AdicionarSemana(int[] array, Int32 Id, int dia)
        {
            if (array == null || array.Length == 0) return array;
            Conexao = new MySqlConnection(data_source);
            try
            {
                Conexao.Open();

                foreach (int valor in array)
                {
                    string sql = "INSERT INTO disponibilidade (id_acolito, id_dia_semana, id_turno) VALUES" +
                      " ( '" + Id + "' , '" + dia + "' , '" + valor + "')";
                    MySqlCommand comando = new MySqlCommand(sql, Conexao);

                    comando.ExecuteNonQuery();

                }
            }
            catch (Exception ex) { MessageBox.Show($"Erro ao adicionar semana: {ex.Message}");}
            finally
            {
                if (Conexao != null && Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }

            return array;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                //Criar conexão com mysql
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();
                string sql = "INSERT INTO acolitos (nome) VALUES (@nome); SELECT LAST_INSERT_ID()";
                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                comando.Parameters.AddWithValue("@nome", txtNome.Text);

                //foreach (string data in datas)
                //{ 
                //string sql3 = "INSERT INTO dia (id_acolito,dia) VALUES (,)";  
                //}


                //executar comando insert
                
                
                object result = comando.ExecuteScalar();
                int idRetorno = Convert.ToInt32(result);   
                
                
                if(tds_smn == 0) { 
                ProcessarSemana(seg, idRetorno, 1); ProcessarSemana(ter, idRetorno, 2); ProcessarSemana(qua, idRetorno, 3);
                ProcessarSemana(qui, idRetorno, 4); ProcessarSemana(sex, idRetorno, 5);
                }
                if(tds_smn == 1) 
                {
                        int valor = 1;
                    for (int dia = 1; dia < 8; dia++)
                    {
                        string sql3 = "INSERT INTO disponibilidade (id_acolito, id_dia_semana, id_turno) VALUES (@idAcolito, @dia, @turno)";
                        MySqlCommand cmd = new MySqlCommand(sql3, Conexao);
                        cmd.Parameters.AddWithValue("@idAcolito", idRetorno);
                        cmd.Parameters.AddWithValue("@id_dia_semana", dia);
                        cmd.Parameters.AddWithValue("@id_turno", valor);
                        cmd.ExecuteNonQuery();

                        if (valor <= 3)
                        {
                        valor++;
                        }
                        else
                        {
                            valor = 1;
                        }
                    }
                }
                if (tds_fds == 0)
                {
                    ProcessarSemana(sab, idRetorno, 6);
                    ProcessarSemana(dom, idRetorno, 7);
                }
                if(tds_fds == 1)
                {
                    int valor = 1;
                    for (int dia = 6; dia < 8; dia++)
                    {
                        string sql3 = "INSERT INTO disponibilidade (id_acolito, id_dia_semana, id_turno) VALUES (@idAcolito, @dia, @turno)";
                        MySqlCommand cmd = new MySqlCommand(sql3, Conexao);
                        cmd.Parameters.AddWithValue("@idAcolito", idRetorno);
                        cmd.Parameters.AddWithValue("@id_dia_semana", dia);
                        cmd.Parameters.AddWithValue("@id_turno", valor);
                        cmd.ExecuteNonQuery();
                        if (valor <= 3)
                        {
                            valor++;
                        }
                        else
                        {
                            valor = 1;
                        }
                    }
                }
                
                
                MessageBox.Show("Deu tudo certo!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Conexao != null && Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
        }

        private void ribbonButtonCenter1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
