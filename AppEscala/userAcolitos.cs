using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.StyledXmlParser.Jsoup.Nodes;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppEscala
{

    public partial class userAcolitos : UserControl
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";

        public userAcolitos()
        {
            InitializeComponent();
            Carregar_Acolitos();
            dgv_acolitos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }


        private void acolitos_Load(object sender, EventArgs e)
        {

        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {

            try
            {
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;

                cmd.CommandText = "SELECT a.nome, s.dia_semana, t.turno, d.id_dia_semana, a.id " +
                    "FROM acolitos AS a " +
                    "LEFT JOIN disponibilidade AS d ON a.id = d.id_acolito " +
                    "RIGHT JOIN dias_semana AS s ON d.id_dia_semana = s.id " +
                    "RIGHT JOIN turno AS t ON d.id_turno = t.id " +
                    "WHERE a.nome LIKE @q ORDER BY d.id";


                cmd.Parameters.AddWithValue("@q", "%" + txtPesquisa.Text + "%");

                MySqlDataReader reader = cmd.ExecuteReader();
                dgv_acolitos.Rows.Clear();
                string[] row = new string[8];
                int idA = 0;
                while (reader.Read())
                {
                    int id_agora = reader.GetInt32(4);
                    if (idA == 0)
                    {
                        idA = reader.GetInt32(4);
                    }
                    if (id_agora != idA)
                    {
                        dgv_acolitos.Rows.Add(row);
                        row = new string[8]; // Limpa o array para a próxima linha
                        idA = id_agora;
                    }

                    string nome = reader.GetString(0);
                    string turno = reader.GetString(2);
                    int id_dia = reader.GetInt32(3);
                    row[0] = nome;

                    if (id_dia >= 1 && id_dia <= 7) // Considerando id_dia válido entre 1 e 7
                    {
                        row[id_dia] = string.IsNullOrEmpty(row[id_dia]) ? turno : $"{row[id_dia]}\n{turno}";
                    }
                }

                if (!string.IsNullOrEmpty(row[0]))
                {
                    dgv_acolitos.Rows.Add(row);
                }
                if (string.IsNullOrEmpty(row[0]))
                {
                    MessageBox.Show("Não foi encontrado nenhum nome relacionado.");
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
                Conexao.Close();
            }
        }

        private void Carregar_Acolitos()
        {
            try
            {
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao;

                cmd.CommandText = "SELECT a.nome, s.dia_semana, t.turno, d.id_dia_semana, a.id " +
                    "FROM acolitos AS a " +
                    "LEFT JOIN disponibilidade AS d ON a.id = d.id_acolito " +
                    "RIGHT JOIN dias_semana AS s ON d.id_dia_semana = s.id " +
                    "RIGHT JOIN turno AS t ON d.id_turno = t.id ORDER BY a.id";

                int idA = 0;
                MySqlDataReader reader = cmd.ExecuteReader();
                dgv_acolitos.Rows.Clear();
                string[] row = new string[8];
                while (reader.Read())
                {
                    int id_agora = reader.GetInt32(4);
                    if (idA == 0)
                    {
                        idA = reader.GetInt32(4);
                    }
                    if (id_agora != idA)
                    {
                        dgv_acolitos.Rows.Add(row);
                        row = new string[8]; // Limpa o array para a próxima linha
                        idA = id_agora;
                    }
                    string nome = reader.GetString(0);
                    string turno = reader.GetString(2);
                    int id_dia = reader.GetInt32(3);
                    row[0] = nome;

                    if (id_dia >= 1 && id_dia <= 7) // Considerando id_dia válido entre 1 e 7
                    {
                        row[id_dia] = string.IsNullOrEmpty(row[id_dia]) ? turno : $"{row[id_dia]}\n{turno}";
                    }

                }
                if (!string.IsNullOrEmpty(row[0]))
                {
                    dgv_acolitos.Rows.Add(row);
                }
                if (string.IsNullOrEmpty(row[0]))
                {
                    MessageBox.Show("Não foi encontrado nenhum nome relacionado.");
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
                Conexao.Close();
            }
        }
        private void dgv_acolitos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_acolitos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection itens_selecionados = dgv_acolitos.SelectedRows;
            DataGridViewSelectedCellCollection item_selecionado = dgv_acolitos.SelectedCells;
            foreach (DataGridView item in itens_selecionados)
            {
                txt_nome.Text = item.SelectedRows.Cells[0];
            }
        }
    }
}
