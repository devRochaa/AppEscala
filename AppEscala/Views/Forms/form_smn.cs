using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;

namespace AppEscala
{
    public partial class form_smn : Form
    {
        public string Dado { get; set; }
        public form_smn()
        {
            InitializeComponent();

        }
        public int[] seg = new int[3];
        public int[] ter = new int[3];
        public int[] qua = new int[3];
        public int[] qui = new int[3];
        public int[] sex = new int[3];
        public int tds;


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
             // Pega o texto do TextBox
            DialogResult = DialogResult.OK; // Define o resultado do diálogo
            this.Close();
        }
        private void check_segM_CheckedChanged(object sender, EventArgs e)
        {
            seg[0] = 0;
            if (check_segM.Checked)
            {
                seg[0] = 1;
            }
        }

        private void check_terM_CheckedChanged(object sender, EventArgs e)
        {
            ter[0] = 0;
            if (check_terM.Checked)
            {
                ter[0] = 1;
            }
        }

        private void check_quaM_CheckedChanged(object sender, EventArgs e)
        {
            qua[0] = 0;
            if (check_quaM.Checked)
            {
                qua[0] = 1;
            }
        }

        private void check_quiM_CheckedChanged(object sender, EventArgs e)
        {
            qui[0] = 0;
            if (check_quiM.Checked)
            {
                qui[0] = 1;
            }
        }

        private void check_sexM_CheckedChanged(object sender, EventArgs e)
        {
            sex[0] = 0;
            if (check_sexM.Checked)
            {
                sex[0] = 1;
            }
        }
        private void check_segT_CheckedChanged(object sender, EventArgs e)
        {
            seg[1] = 0;
            if (check_segT.Checked)
            {
                seg[1] = 1;
            }
        }

        private void check_terT_CheckedChanged(object sender, EventArgs e)
        {
            ter[1] = 0;
            if (check_terT.Checked)
            {
                ter[1] = 1;
            }
        }

        private void check_quaT_CheckedChanged(object sender, EventArgs e)
        {
            qua[1] = 0;
            if (check_quaT.Checked)
            {
                qua[1] = 1;
            }
        }

        private void check_quiT_CheckedChanged(object sender, EventArgs e)
        {
            qui[1] = 0;
            if (check_quiT.Checked)
            {
                qui[1] = 1;
            }
        }

        private void check_sexT_CheckedChanged(object sender, EventArgs e)
        {
            sex[1] = 0;
            if (check_sexT.Checked)
            {
                sex[1] = 1;
            }
        }
        private void check_segN_CheckedChanged(object sender, EventArgs e)
        {
            seg[2] = 0;
            if (check_segN.Checked)
            {
                seg[2] = 1;
            }
        }

        private void check_terN_CheckedChanged(object sender, EventArgs e)
        {
            ter[2] = 0;
            if (check_terN.Checked)
            {
                ter[2] = 1;
            }
        }

        private void check_quaN_CheckedChanged(object sender, EventArgs e)
        {
            qua[2] = 0;
            if (check_quaN.Checked)
            {
                qua[2] = 1;
            }
        }

        private void check_quiN_CheckedChanged(object sender, EventArgs e)
        {
            qui[2] = 0;
            if (check_quiN.Checked)
            {
                qui[2] = 1;
            }
        }

        private void check_sexN_CheckedChanged(object sender, EventArgs e)
        {
            sex[2] = 0;
            if (check_sexN.Checked)
            {
                sex[2] = 1;
            }
        }

        private void check_tds_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = check_tds.Checked;

            foreach (Control ctrl in panel_seg.Controls)
            {
                if (ctrl is CheckBox checkBox)
                {
                    checkBox.Checked = isChecked;
                }
            }
            foreach (Control ctrl in panel_ter.Controls)
            {
                if (ctrl is CheckBox checkBox)
                {
                    checkBox.Checked = isChecked;
                }
            }
            foreach (Control ctrl in panel_qua.Controls)
            {
                if (ctrl is CheckBox checkBox)
                {
                    checkBox.Checked = isChecked;
                }
            }
            foreach (Control ctrl in panel_qui.Controls)
            {
                if (ctrl is CheckBox checkBox)
                {
                    checkBox.Checked = isChecked;
                }
            }
            foreach (Control ctrl in panel_sex.Controls)
            {
                if (ctrl is CheckBox checkBox)
                {
                    checkBox.Checked = isChecked;
                }
            }

        
       
    }
    }
}
