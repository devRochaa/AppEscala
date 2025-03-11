using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEscala.Helpers;
using AppEscala.Models;
using iText.Bouncycastle.Crypto.Modes;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace AppEscala.Views
{
    public partial class form_editarAcolito : Form
    {
        private Database db;
        public int? id_acolito { get; set; }
        int id_dia = -1;
        public bool atualizou = false;
        public form_editarAcolito()
        {
            InitializeComponent();
        }


        private void form_editarAcolito_Load(object sender, EventArgs e)
        {
            db = new Database();
            db.Initialize();

            carregar_acolito();
            ComboBoxDias();
            carregarListView();

            dtp_add.Format = DateTimePickerFormat.Custom;
            dtp_add.CustomFormat = "dd/MM/yyyy";

            dtp_edit.Format = DateTimePickerFormat.Custom;
            dtp_edit.CustomFormat = "dd/MM/yyyy";
        }

        private void carregar_acolito()
        {

            int i = 1;
            var listaAcolitos = db.Acolitos_Dias(id_acolito).ToList();
            foreach (var acolitoL in listaAcolitos)
            {
                txt_nome.Text = acolitoL.Nome;

                if (cmb_dias.SelectedIndex != -1)
                {
                    if (cmb_dias.SelectedItem is Item selectedItem)
                    {
                        id_dia = selectedItem.Value;
                        if (acolitoL.IdDiaSemana == selectedItem.Value)
                        {
                            if (i == 1)
                            {
                                cmb_turno1.SelectedIndex = acolitoL.Id_Turno - 1;
                                id_turnoAntigo1 = acolitoL.Id_Turno;
                            }
                            if (i == 2)
                            {
                                cmb_turno2.SelectedIndex = acolitoL.Id_Turno - 1;
                                id_turnoAntigo2 = acolitoL.Id_Turno;
                            }
                            if (i == 3)
                            {
                                cmb_turno3.SelectedIndex = acolitoL.Id_Turno - 1;
                                id_turnoAntigo3 = acolitoL.Id_Turno;
                            }
                            i++;
                        }

                    }
                }
            }
        }

        private void carregarListView()
        {
            lst_dias.Items.Clear();
            var listaDias = db.SelectDiasAcolito(id_acolito);

            foreach (Dia item in listaDias)
            {
                lst_dias.Items.Add(item.dia);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void UpdateTurno()
        {

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
        private void ComboBoxDias()
        {
            var listaDias = db.SelectDiasSemana().ToList();
            foreach (var dia in listaDias)
            {
                cmb_dias.Items.Add(new Item { Display = dia.Nome, Value = dia.Id });
            }

            var listaTurnos = db.SelectTurnos().ToList();
            foreach (var turno in listaTurnos)
            {
                cmb_turno1.Items.Add(new Item { Display = turno.Nome, Value = turno.Id });
                cmb_turno2.Items.Add(new Item { Display = turno.Nome, Value = turno.Id });
                cmb_turno3.Items.Add(new Item { Display = turno.Nome, Value = turno.Id });
            }
        }


        private void cmb_dias_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregar_acolito();
            lbl_dia.Text = cmb_dias.SelectedItem.ToString() + ":";
        }

        private void cmb_turno1_TextUpdate(object sender, EventArgs e)
        {
            //confirmar que o texto foi alterado
            teste.Text = "vish";
        }

        int id_turnoNovo1 = -1;
        int id_turnoNovo2 = -1;
        int id_turnoNovo3 = -1;
        int id_turnoAntigo1 = -1;
        int id_turnoAntigo2 = -1;
        int id_turnoAntigo3 = -1;

        private void cmb_turno1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_turno1.SelectedItem is Item selectedItem)
            {
                id_turnoNovo1 = selectedItem.Value;
            }
        }
        private void cmb_turno2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_turno2.SelectedItem is Item selectedItem)
            {
                id_turnoNovo2 = selectedItem.Value;
            }
        }
        private void cmb_turno3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_turno3.SelectedItem is Item selectedItem)
            {
                id_turnoNovo3 = selectedItem.Value;
            }
        }

        private void salvarTurno()
        {

            if (id_turnoNovo1 != -1)
            {
                atualizou = db.UpdateTurnoAcolito(id_acolito, id_dia, id_turnoAntigo1, id_turnoNovo1);
            }
            if (id_turnoNovo2 != -1)
            {
                atualizou = db.UpdateTurnoAcolito(id_acolito, id_dia, id_turnoAntigo2, id_turnoNovo2);
            }
            if (id_turnoNovo3 != -1)
            {
                atualizou = db.UpdateTurnoAcolito(id_acolito, id_dia, id_turnoAntigo3, id_turnoNovo3);
            }

        }

        private void editarData()
        {
            string dataNova = dtp_edit.Value.ToString();
            db.UpdateDias(id_acolito, lst_dias.Text, dtp_edit.Text);
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            int FoiChamado = 0;
            if (id_turnoNovo1 == -1 && id_turnoNovo2 == -1 && id_turnoNovo3 == -1)
            {
                FoiChamado++;
            }
            else
            {
                salvarTurno();
            }
            if (diaSelecionado == true)
            {
                if (lst_dias.SelectedItem != null)
                {
                    if (dtp_edit.Text != lst_dias.SelectedItem.ToString())
                    {
                        editarData();
                    }
                    else
                    {
                        FoiChamado++;
                    }
                }
                else { FoiChamado++; }

            }
            else
            {
                FoiChamado++;
            }
            if (FoiChamado >= 2 && diasEditado == false) { MessageBox.Show("Você tem que editar ao menos 1 coisa para poder salvar."); return; }
            MessageBox.Show("Suas alterações foram salvas!");
            DialogResult = DialogResult.OK; // Define o resultado do diálogo
            this.Close();
        }

        bool diaSelecionado = false;

        private void lst_dias_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string horaTexto = lst_dias.Text;
            diaSelecionado = true;

            if (DateTime.TryParse(horaTexto, out DateTime hora))
            {
                dtp_edit.Value = hora;
            }
            else
            {
                MessageBox.Show("Formato de data/hora inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool diasEditado = false;
        private void btn_excluirDia_Click(object sender, EventArgs e)
        {
            if (lst_dias.SelectedItem == null)
            {
                MessageBox.Show("Para apagar, selecione um dia primeiro!");
                return;
            }
            db.DeleteDias(id_acolito.Value, lst_dias.SelectedItem.ToString());
            
            carregarListView();
            diasEditado = true;
        }

        private void btn_addDia_Click(object sender, EventArgs e)
        {
            string dataDia = dtp_add.Value.ToString().Substring(0, 10);
            foreach (string dia in lst_dias.Items) 
            { 
                if (dia == dataDia)
                {
                    MessageBox.Show("Essa data já foi adicionada!");
                    return;
                }
            }
            Dia novoDia = new Dia() { Id_acolitos = id_acolito.Value, dia = dataDia  };
            db.InsertDias(novoDia);
            carregarListView();
            diasEditado = true;
        }
    }
}
