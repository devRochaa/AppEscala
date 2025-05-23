﻿using System.Text.RegularExpressions;
using AppEscala.Helpers;
using MySql.Data.MySqlClient;
using AppEscala.Models;
using AppEscala.Views;
namespace AppEscala
{

    public partial class userAcolitos : UserControl
    {
        
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

            var listaAcolitos = db.BuscarUserAcolitos(txtPesquisa.Text).ToList();
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
                MessageBox.Show("Não foi encontrado nenhum nome relacionado.");
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
        private void ChamarEdicao()
        {
            
            form_editarAcolito form_edit = new form_editarAcolito();
            form_edit.id_acolito = selecionado;
            if (form_edit.ShowDialog() == DialogResult.OK) // Exibe Form2 como modal
            {
                bool editado = form_edit.atualizou;
                if (editado) { Carregar_Acolitos(); }
                // Obtém o dado da propriedade

                //string mensagem = string.Join(", ", seg);
                //MessageBox.Show($"Dado recebido: {mensagem}");
            }
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (selecionado == null)
            {
                MessageBox.Show("Primeiramente Selecione um acólito."); return;
            }
            ChamarEdicao();
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

        private void dgv_acolitos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selecionado == null)
            {
                MessageBox.Show("Primeiramente Selecione um acólito."); return;
            }
            ChamarEdicao();
        }
    }
}
