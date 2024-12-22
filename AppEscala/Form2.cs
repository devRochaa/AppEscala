namespace AppEscala
{
    public partial class form_fimDsmn : Form
    {
        public string Dado { get; set; }
        public form_fimDsmn()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
