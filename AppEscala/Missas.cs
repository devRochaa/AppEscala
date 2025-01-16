using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using Mysqlx.Prepare;
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
            dgv_missas.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Permitir quebra de linha
            dgv_missas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void Missas_Load(object sender, EventArgs e)
        {
            carregar_missas();
            MontarHorarios();
            combobox_igreja();

        }

        private void ApagarMissasAntigas(int id, string dataMissa)
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();
                cmd.CommandText = "DELETE FROM missas WHERE id = @id";
                
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Missas do dia {dataMissa} foram retiradas do banco.");
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
        private void carregar_missas()
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();
                cmd.CommandText = "SELECT data, id from missas";                  
                MySqlDataReader reader = cmd.ExecuteReader();
                                       
                DateTime dataAtual = DateTime.Now;
                   
                while (reader.Read())
                {
                    string dataMissa_String = reader.GetString(0);
                    DateTime dataMissa = DateTime.Parse(dataMissa_String);
                    if (dataAtual > dataMissa)
                    {                       
                        ApagarMissasAntigas(reader.GetInt32(1), dataMissa.ToString().Substring(0, 10));
                    }           
                }
                reader.Close();

                cmd.CommandText = "SELECT m.data, m.horario, i.nome, m.id from missas m " +
                "INNER JOIN igreja i ON m.id_igreja = i.id;";
                reader = cmd.ExecuteReader();
                dgv_missas.Rows.Clear();
                int rowIndex = 0;

                while (reader.Read())
                {
                    dgv_missas.Rows.Add();

                    dgv_missas.Rows[rowIndex].Cells[0].Value = reader.GetString(0);
                    dgv_missas.Rows[rowIndex].Cells[1].Value = reader.GetString(1);  // m.horario
                    dgv_missas.Rows[rowIndex].Cells[2].Value = reader.GetString(2);
                    dgv_missas.Rows[rowIndex].Cells[3].Value = reader.GetInt32(3);

                    rowIndex++;
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
                MessageBox.Show($"Linha do erro: " + new StackTrace(ex, true).GetFrame(0).GetFileLineNumber());
            }
            finally
            {
                if (Conexao != null && Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }
            }
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
            if (cmb_igrejas.SelectedItem == null)
            {
                MessageBox.Show($"Nenhuma Igreja selecionada");
                return;
            }

            if (string.IsNullOrEmpty(listBox1.Text))
            {
                MessageBox.Show("Selecione um horário!");
                return;
            }


            var data = dateTimePicker1.Value.ToString().Substring(0, 10);
            var hora = listBox1.Text.TrimStart();

            string igrejaSelecionada = cmb_igrejas.SelectedItem.ToString();

            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();

                cmd.CommandText = "INSERT INTO missas" +
                    "(id_igreja, data, horario)" +
                    "SELECT id, @data, @horario from igreja where nome = @igreja";


                cmd.Parameters.AddWithValue("@igreja", igrejaSelecionada);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@horario", hora);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Missa adicionada");
                carregar_missas();
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

        private void dgv_missas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int? id_selecionado;
        string data_selecionada = "";

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (!id_selecionado.HasValue)
            {
                MessageBox.Show("Selecione uma missa antes");
                return;
            }
            DialogResult result = MessageBox.Show($"Tem certeza que deseja apagar a missa do dia {data_selecionada}", "Atenção",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                MessageBox.Show("Você escolheu Não!");
                return;
            }
            try
            {
                Conexao = new MySqlConnection(data_source);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;
                Conexao.Open();

                cmd.CommandText = "DELETE FROM missas " +
                    "WHERE id = @id";


                cmd.Parameters.AddWithValue("@id", id_selecionado);


                cmd.ExecuteNonQuery();
                carregar_missas();
                MessageBox.Show("Missa deletada");
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

        private void dgv_missas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Certifique-se de que não é um clique no cabeçalho
            {
                DataGridViewRow selectedRow = dgv_missas.Rows[e.RowIndex];

                // Acessando valores da linha selecionada
                id_selecionado = Convert.ToInt32(selectedRow.Cells[3].Value);
                data_selecionada = selectedRow.Cells[0].Value?.ToString();
                //MessageBox.Show($"{id_selecionado} {data_selecionada}");
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (id_selecionado != null)
            {
                form_editar form_edit = new form_editar();
                form_edit.id_missa = id_selecionado;
                if (form_edit.ShowDialog() == DialogResult.OK) // Exibe Form2 como modal
                {
                    carregar_missas();
                    // Obtém o dado da propriedade

                    //string mensagem = string.Join(", ", seg);
                    //MessageBox.Show($"Dado recebido: {mensagem}");
                }
            }
            else
            {
                MessageBox.Show("Você precisa selecionar uma missa primeiro!");
            }
        }

        private void btn_recarregarIgrejas_Click(object sender, EventArgs e)
        {
            carregar_missas();
            combobox_igreja();
        }
    }
}   

