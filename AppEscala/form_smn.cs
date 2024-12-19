using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscala
{
    public partial class form_smn : Form
    {
        public string Dado { get; set; }
        public form_smn()
        {
            InitializeComponent();
        }

        private void form_smn_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void airButton1_Click(object sender, EventArgs e)
        {
            Dado = "teste"; // Pega o texto do TextBox
            DialogResult = DialogResult.OK; // Define o resultado do diálogo
            this.Close();
        }
    }
}
