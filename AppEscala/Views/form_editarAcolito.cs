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
        }

        private void carregar_acolito()
        {
            var listaAcolitos = db.Acolitos_Dias(id_acolito).ToList();
            foreach (var acolitoL in listaAcolitos)
            {
                txt_nome.Text = acolitoL.Nome;
                int id_dia = acolitoL.IdDiaSemana;

                if (id_dia == 1)
                {
                    txt_seg.Text = txt_seg.Text + acolitoL.Turno + " ";
                }
                if (id_dia == 2)
                {
                    txt_ter.Text = txt_ter.Text + acolitoL.Turno + " ";
                }
                if (id_dia == 3)
                {
                    txt_qua.Text = txt_qua.Text + acolitoL.Turno + " ";
                }
                if (id_dia == 4)
                {
                    txt_qui.Text = txt_qui.Text + acolitoL.Turno + " ";
                }
                if (id_dia == 5)
                {
                    txt_sex.Text = txt_sex.Text + acolitoL.Turno + " ";
                }
                if (id_dia == 6)
                {
                    txt_sab.Text = txt_sab.Text + acolitoL.Turno + " ";
                }
                if (id_dia == 7)
                {
                    txt_dom.Text = txt_dom.Text + acolitoL.Turno + " ";
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
