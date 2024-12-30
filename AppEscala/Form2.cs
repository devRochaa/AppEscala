namespace AppEscala
{
    public partial class form_fimDsmn : Form
    {
        public string Dado { get; set; }
        public form_fimDsmn()
        {
            InitializeComponent();
        }

        public int[] sab = new int[3];
        public int[] dom = new int[3];
        public int tds; 
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void airButton1_Click(object sender, EventArgs e)
        {
             // Pega o texto do TextBox
            DialogResult = DialogResult.OK; // Define o resultado do diálogo
            this.Close();
        }

        private void check_sabM_CheckedChanged(object sender, EventArgs e)
        {
            sab[0] = 0;
            if (check_sabM.Checked)
            {
                sab[0] = 1;
            }
        }


        private void check_sabT_CheckedChanged(object sender, EventArgs e)
        {
            sab[1] = 0;
            if (check_sabT.Checked)
            {
                sab[1] = 1;
            }
        }

        private void check_sabN_CheckedChanged(object sender, EventArgs e)
        {
            sab[2] = 0;
            if (check_sabN.Checked)
            {
                sab[2] = 1;
            }
        }
        private void check_domM_CheckedChanged(object sender, EventArgs e)
        {
            dom[0] = 0;
            if (check_sabM.Checked)
            {
                dom[0] = 1;
            }
        }

        private void check_domT_CheckedChanged(object sender, EventArgs e)
        {
            dom[1] = 0;
            if (check_domT.Checked)
            {
                dom[1] = 1;
            }
        }

        private void check_domN_CheckedChanged(object sender, EventArgs e)
        {
            dom[2] = 0;
            if (check_domN.Checked)
            {
                dom[2] = 1;
            }
        }

        private void check_tds_CheckedChanged(object sender, EventArgs e)
        {
            tds = 0;
            if (check_tds.Checked)
            {
                tds = 1;
            }
        }
    }
}
