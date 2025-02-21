﻿using System.Text.RegularExpressions;
using AppEscala.Helpers;
using MySql.Data.MySqlClient;
using AppEscala.Models;
using AppEscala.Views;
namespace AppEscala
{

    public partial class userAcolitos : UserControl
    {
        private MySqlConnection Conexao;
        private string data_source = "datasource=localhost;Port=3307;username=root;password=;database=escala_acolitos;";
        private Database db;
        public userAcolitos()
        {
            InitializeComponent();

            dgv_acolitos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }


        private void acolitos_Load(object sender, EventArgs e)
        {
            db = new Database();
            db.Initialize();
            Carregar_Acolitos();
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

            var listaAcolitos = db.ListaUserAcolitos().ToList();
            dgv_acolitos.Rows.Clear();
            txt_aviso.Visible = false;

            string[] row = new string[9];
            int idAtual = 0;
            foreach (var acolitoL in listaAcolitos)
            {
                int id_agora = acolitoL.Id_acolito; //define id_agora como o id dessa volta do for
                if (idAtual == 0) //se o id_atual for igual a 0, vai ser o primeiro item
                {
                    idAtual = acolitoL.Id_acolito; //entao ele vai definir o id atual como o id
                }                                  //dessa volta, para passar fora do proximo if
                if (id_agora != idAtual)
                { //se o id_agora for diferente do atual, significa que acabou os registro dql acolito
                    dgv_acolitos.Rows.Add(row); //entao é adicionado oq foi feito até agora
                    row = new string[9]; // Limpa o array para a próxima linha
                    idAtual = id_agora; //e define o idatual assim para nao passar pelos 2 ifs
                }
                row[0] = acolitoL.Nome;
                row[8] = acolitoL.Id_acolito.ToString();

                string turno = acolitoL.Turno;
                int id_dia = acolitoL.IdDiaSemana;

                if (id_dia >= 1 && id_dia <= 7) // Considerando id_dia válido entre 1 e 7
                {
                    row[id_dia] = string.IsNullOrEmpty(row[id_dia]) ? turno : $"{row[id_dia]}\n{turno}";
                    // se o dia segunda estiver vazio nessa volta ele vai definir como o turno dessa volta
                    //mas se não estiver vazio ele definira como ja estava adicionado antes + o turno dessa volta
                }
            }
            if (!string.IsNullOrEmpty(row[0]))
            //quando chegar no ultima volta ele nao vai ter um id diferente para ativar o add row
            // entao se o row de nome nao for vazio ele vai adicionar o ultimo.
            {
                dgv_acolitos.Rows.Add(row);
            }
            if (string.IsNullOrEmpty(row[0])) // se não encontrar nenhum registro
            {
                txt_aviso.Visible = true;
            }

            //try
            //{
            //    Conexao = new MySqlConnection(data_source);
            //    Conexao.Open();

            //    MySqlCommand cmd = new MySqlCommand();
            //    cmd.Connection = Conexao;

            //    cmd.CommandText = "SELECT a.nome, s.dia_semana, t.turno, d.id_dia_semana, a.id " +
            //        "FROM acolitos AS a " +
            //        "LEFT JOIN disponibilidade AS d ON a.id = d.id_acolito " +
            //        "RIGHT JOIN dias_semana AS s ON d.id_dia_semana = s.id " +
            //        "RIGHT JOIN turno AS t ON d.id_turno = t.id ORDER BY a.id";

            //    int idA = 0;
            //    MySqlDataReader reader = cmd.ExecuteReader();
            //    dgv_acolitos.Rows.Clear();
            //    string[] row = new string[9];
            //    while (reader.Read())
            //    {
            //        int id_agora = reader.GetInt32(4);
            //        if (idA == 0)
            //        {
            //            idA = reader.GetInt32(4);
            //        }
            //        if (id_agora != idA)
            //        {
            //            dgv_acolitos.Rows.Add(row);                     
            //            row = new string[9]; // Limpa o array para a próxima linha
            //            idA = id_agora;
            //        }
            //        string nome = reader.GetString(0);
            //        string turno = reader.GetString(2);
            //        int id_dia = reader.GetInt32(3);
            //        row[0] = nome;
            //        row[8] = idA.ToString();
            //        if (id_dia >= 1 && id_dia <= 7) // Considerando id_dia válido entre 1 e 7
            //        {
            //            row[id_dia] = string.IsNullOrEmpty(row[id_dia]) ? turno : $"{row[id_dia]}\n{turno}";
            //        }

            //    }
            //    if (!string.IsNullOrEmpty(row[0]))
            //        //quando chegar no ultima volta ele nao vai ter um id diferente para ativar o add row
            //        // entao se o row de nome nao for vazio ele vai adicionar o ultimo.
            //    {
            //        dgv_acolitos.Rows.Add(row);
            //    }
            //    if (string.IsNullOrEmpty(row[0])) // se não encontrar nenhum registro
            //    {
            //        MessageBox.Show("Não foi encontrado nenhum nome relacionado.");
            //    }

            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show($"Erro MySQL: {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Erro geral: {ex.Message}");
            //}
            //finally
            //{
            //    Conexao.Close();
            //}
        }
        private void dgv_acolitos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void TurnosEditarPalavras(System.Windows.Forms.TextBox txt1,
            System.Windows.Forms.TextBox txt2,
            System.Windows.Forms.TextBox txt3,
            MatchCollection palavras)
        {


            int i = 1;
            foreach (Match palavra in palavras)
            {
                if (i == 1) { txt1.Text = palavra.Value; }
                if (i == 2) { txt2.Text = palavra.Value; }
                if (i == 3) { txt3.Text = palavra.Value; }
                i++;
            }
        }
        int id_acolito_selecionado = 0;
        int? selecionado = null;
        private void dgv_acolitos_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridViewSelectedRowCollection itens_selecionados = dgv_acolitos.SelectedRows;
            //DataGridViewSelectedCellCollection item_selecionado = dgv_acolitos.SelectedCells;
            //foreach (DataGridView item in itens_selecionados)
            //{
            //    txt_nome.Text = item.SelectedRows.Cells[0];
            //}

            if (dgv_acolitos.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_acolitos.SelectedRows[0];
                //selecionado = int.Parse(selectedRow.Cells[8].Value.ToString());
                // Verifica se a célula não é nula antes de acessar
                if (selectedRow.Cells[1].Value != null && selectedRow.Cells.Count > 1)
                {
                    txt_seg1.Text = ""; txt_seg2.Text = ""; txt_seg3.Text = "";
                    txt_ter1.Text = ""; txt_ter2.Text = ""; txt_ter3.Text = "";
                    txt_qua1.Text = ""; txt_qua2.Text = ""; txt_qua3.Text = "";
                    txt_qui1.Text = ""; txt_qui2.Text = ""; txt_qui3.Text = "";
                    txt_sex1.Text = ""; txt_sex2.Text = ""; txt_sex3.Text = "";
                    txt_sab1.Text = ""; txt_sab2.Text = ""; txt_sab3.Text = "";
                    txt_dom1.Text = ""; txt_dom2.Text = ""; txt_dom3.Text = "";

                    txt_nome.Text = selectedRow.Cells[0].Value.ToString();
                    string[] dias = new string[7];
                    string pattern = "(Manhã|Tarde|Noite)";
                    MatchCollection separar = Regex.Matches("", "vazio");
                    int g = 0;
                    id_acolito_selecionado = int.Parse(selectedRow.Cells[8].Value.ToString());
                    for (int i = 1; i <= 7; i++)
                    {

                        if (selectedRow.Cells[i].Value != null)
                        {

                            dias[g] = selectedRow.Cells[i].Value.ToString();
                            separar = Regex.Matches(dias[g], pattern);
                            g++;
                            switch (i)
                            {
                                case 1:
                                    TurnosEditarPalavras(txt_seg1, txt_seg2, txt_seg3, separar);
                                    break;

                                case 2:
                                    TurnosEditarPalavras(txt_ter1, txt_ter2, txt_ter3, separar);
                                    break;

                                case 3:
                                    TurnosEditarPalavras(txt_qua1, txt_qua2, txt_qua3, separar);
                                    break;

                                case 4:
                                    TurnosEditarPalavras(txt_qui1, txt_qui2, txt_qui3, separar);
                                    break;

                                case 5:
                                    TurnosEditarPalavras(txt_sex1, txt_sex2, txt_sex3, separar);
                                    break;

                                case 6:
                                    TurnosEditarPalavras(txt_sab1, txt_sab2, txt_sab3, separar);
                                    break;

                                case 7:
                                    TurnosEditarPalavras(txt_dom1, txt_dom2, txt_dom3, separar);
                                    break;

                            }

                        }
                        else { selectedRow.Cells[i].Value = ""; }
                    }


                }
                else
                {
                    txt_nome.Text = ""; // Ou algum valor padrão
                }
            }

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {

        }

        private void userAcolitos_Enter(object sender, EventArgs e)
        {

        }

        private void userAcolitos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) // Só executa quando o controle estiver visível
            {
                Carregar_Acolitos();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (selecionado == null)
            {
                MessageBox.Show("Primeiramente Selecione um acólito."); return;
            }

                form_editarAcolito form_edit = new form_editarAcolito();
                form_edit.id_acolito = selecionado;
                if (form_edit.ShowDialog() == DialogResult.OK) // Exibe Form2 como modal
                {
                    
                    // Obtém o dado da propriedade

                    //string mensagem = string.Join(", ", seg);
                    //MessageBox.Show($"Dado recebido: {mensagem}");
                }
            
            

        }

        private void dgv_acolitos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Certifique-se de que não é um clique no cabeçalho
            {
                DataGridViewRow selectedRow = dgv_acolitos.Rows[e.RowIndex];

                // Acessando valores da linha selecionada
                selecionado = Convert.ToInt32(selectedRow.Cells[8].Value);
               
                //MessageBox.Show($"{id_selecionado} {data_selecionada}");
            }
        }
    }
}
