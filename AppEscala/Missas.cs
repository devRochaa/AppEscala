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
using AppEscala.Helpers;
using AppEscala.Models;
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
        private Database db;
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
            db = new Database();
            db.Initialize();
            carregar_missas();
            MontarHorarios();
            combobox_igreja();

            for (int i = 0; i <= 15; i++) 
            {
                cmb_quant.Items.Add(i);
            }
            
        }

        private void ApagarMissasAntigas()
        {
            var listaMissas = db.SelectAllMissas();

            foreach (var missa in listaMissas) //apagar missa que passaram da data atual
            {
                DateTime dataAtual = DateTime.Now;
                string dataMissa_String = missa.Data;
                DateTime dataMissa = DateTime.Parse(dataMissa_String);
                if (dataAtual > dataMissa)
                {
                    db.DeleteMissa(missa.idMissa);
                    MessageBox.Show($"Missas do dia {dataMissa} foram retiradas do banco.");
                }
            }
           
        }
        private void carregar_missas()
        {
            ApagarMissasAntigas();
            var listaMissas = db.SelectAllMissas();

            dgv_missas.Rows.Clear();
            int rowIndex = 0;
            foreach (var missa in listaMissas)
            {
                dgv_missas.Rows.Add(); //adiciona uma nova linha

                dgv_missas.Rows[rowIndex].Cells[0].Value = missa.Data; //add as informações de acordo com a linha
                dgv_missas.Rows[rowIndex].Cells[1].Value = missa.Horario;  
                dgv_missas.Rows[rowIndex].Cells[2].Value = missa.Igreja;
                dgv_missas.Rows[rowIndex].Cells[3].Value = missa.idMissa;
                dgv_missas.Rows[rowIndex].Cells[4].Value = missa.Descricao;
                dgv_missas.Rows[rowIndex].Cells[5].Value = missa.Qnt_acolitos;

                rowIndex++; //aumenta o index para add os valores na proxima linha 
            }

            
        }
        public class Item
        {
            public string Display { get; set; } // O texto visível
            public int Value { get; set; } // O valor oculto

            public override string ToString()
            {
                return Display; // Exibe apenas o texto no ComboBox
            }
        }
        private void combobox_igreja()
        {
            var listaIgreja = db.SelectAllIgreja();
            foreach (var igreja in listaIgreja)
            {
                cmb_igrejas.Items.Add(new Item { Display = igreja.nome, Value = igreja.id });
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

            string data = dateTimePicker1.Value.ToString().Substring(0, 10);
            string hora = listBox1.Text.TrimStart();
            int qnt_acolitos = cmb_quant.SelectedIndex != -1 ? cmb_quant.SelectedIndex : 4;
            MessageBox.Show($"{qnt_acolitos}");
            int idIgrejaSelecionada = -1;

            if(cmb_igrejas.SelectedItem is Item selectedItem){
                idIgrejaSelecionada = selectedItem.Value;
            }
            if (idIgrejaSelecionada == -1)
            {
                MessageBox.Show("Ocorreu um erro em relação a seleção da Igreja!");
                return;
            }
            
            MissasC novaMissa = new MissasC() { Id_igreja = idIgrejaSelecionada, 
                Data = data, 
                Horario = hora,
                Descricao = txt_desc.Text,
                Qnt_acolitos = qnt_acolitos
            };
            db.InsertMissa( novaMissa );
            MessageBox.Show("Missa Adicionada!");
            carregar_missas();
            

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
            db.DeleteMissa( id_selecionado.Value );
            carregar_missas();

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

        private void cmb_igrejas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}   

