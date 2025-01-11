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
    public partial class form_editar : Form
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";
        public int? id_missa { get; set; }
        public form_editar()
        {
            InitializeComponent();
        }

        private void form_editar_Load(object sender, EventArgs e)
        {
            combobox_igreja();
            carregar_missaSelecionada();
        }

        private void combobox_igreja()
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();
                cmd.CommandText = "SELECT id, nome from igreja;";
                MySqlDataReader reader = cmd.ExecuteReader();
                cmb_igrejas.Items.Clear();

                while (reader.Read())
                {
                    cmb_igrejas.Items.Add(reader.GetString(1));
                }
                reader.Close();

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

        DateTime dataConvertida;
        string hora;
        string igreja;
        private void carregar_missaSelecionada()
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();
                cmd.CommandText = "SELECT m.data, m.horario, i.nome from missas m " +
                    "INNER JOIN igreja i ON m.id_igreja = i.id WHERE m.id = @id_missa;";
                cmd.Parameters.AddWithValue("@id_missa", id_missa);
                MySqlDataReader reader = cmd.ExecuteReader();
                //dgv_missas.Rows.Clear();
                int rowIndex = 0;

                while (reader.Read())
                {
                    string data_bruta = reader.GetString(0);
                    if (DateTime.TryParse(data_bruta, out dataConvertida))
                    {
                        
                        dtp_missa.Value = dataConvertida;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível converter a data");
                    }
                    hora = reader.GetString(1);                    
                    txt_hora1.Text = hora.Substring(0 , 2);
                    txt_hora2.Text = hora.Substring(3);
                    igreja = reader.GetString(2);
                    cmb_igrejas.SelectedItem = igreja;
                }
                reader.Close();


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

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                int conn_atv = 0;
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;

                if (igreja != cmb_igrejas.SelectedItem.ToString() && cmb_igrejas.SelectedItem.ToString() != null)
                {
                    
                    cmd.CommandText = "UPDATE missas SET id_igreja = " +
                            "(SELECT id FROM igreja WHERE nome = @igreja_nova) " +
                            "WHERE id = @id_missa";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@igreja_nova", cmb_igrejas.SelectedItem);
                    cmd.Parameters.AddWithValue("@id_missa", id_missa);

                    Conexao.Open();
                    conn_atv = 1;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Igreja Atualizada");
                }

                if (hora.Substring(0, 2) != txt_hora1.Text || hora.Substring(3) != txt_hora2.Text)
                {
                    if (txt_hora1.TextLength == 0)
                    {
                        txt_hora1.Text = "00";
                    }
                    if (txt_hora2.TextLength == 0)
                    {
                        txt_hora2.Text = "00";
                    }
                    string hora_nova = txt_hora1.Text + ":" + txt_hora2.Text;
                    
                    cmd.CommandText = "UPDATE missas SET horario = @horario_novo " +
                        "WHERE id = @id_missa";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@horario_novo", hora_nova);
                    cmd.Parameters.AddWithValue("@id_missa", id_missa);
                    if(conn_atv == 0)
                    {
                    Conexao.Open();
                     conn_atv = 1;
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Hora Atualizada");
                }
            

                if(dataConvertida != dtp_missa.Value)
                {
                    string data_nova = dtp_missa.Value.ToString();
                    
                    cmd.CommandText = "UPDATE missas SET data = @data_nova " +
                        "WHERE id = @id_missa";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@data_nova", data_nova);
                    cmd.Parameters.AddWithValue("@id_missa", id_missa);
                    if(conn_atv == 0)
                    {
                        Conexao.Open();
                        conn_atv = 1;
                    }
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Data Atualizada");
                }
                if (conn_atv == 0) 
                {
                    MessageBox.Show($"Você não alterou nenhuma informação!");
                    return;
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

       
    }
}
