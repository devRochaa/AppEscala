using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppEscala.Helpers;
using AppEscala.Models;

namespace AppEscala.Views
{
    public partial class form_editarAcolito : Form
    {
        private Database db;
        public int? id_acolito { get; set; }
        public form_editarAcolito()
        {
            InitializeComponent();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void form_editarAcolito_Load(object sender, EventArgs e)
        {
            db = new Database();
            db.Initialize();

            carregar_acolito();
            ComboBoxDias();
        }

        private void carregar_acolito()
        {
            txt_turno1.Text = "";
            txt_turno2.Text = "";
            txt_turno3.Text = "";
            int i = 1;
            var listaAcolitos = db.Acolitos_Dias(id_acolito).ToList();
            foreach (var acolitoL in listaAcolitos)
            {
                txt_nome.Text = acolitoL.Nome;

                if (cmb_dias.SelectedIndex != -1)
                {
                    if (cmb_dias.SelectedItem is Item selectedItem)
                    {
                        if (acolitoL.IdDiaSemana == selectedItem.Value)
                        {
                            if (i == 1)
                            {
                                cmb_turno1.SelectedIndex = acolitoL.Id_Turno - 1;
                            }
                            if (i == 2)
                            {
                                cmb_turno2.SelectedIndex = acolitoL.Id_Turno - 1;
                            }
                            if (i == 3)
                            {
                                cmb_turno3.SelectedIndex = acolitoL.Id_Turno - 1;
                            }
                            i++;
                        }

                    }
                }
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
            var listaDias = db.SelectDias().ToList();
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

        private void CarregarTurnos()
        {

        }


        private void cmb_dias_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregar_acolito();
            lbl_dia.Text = cmb_dias.SelectedItem.ToString() + ":";
        }

        private void cmb_turno1_TextUpdate(object sender, EventArgs e)
        {
            //confirmar que o texto foi alterado
        }
    }
}
