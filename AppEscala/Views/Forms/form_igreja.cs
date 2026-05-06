using AppEscala.Helpers;
using AppEscala.Models.Entities;

namespace AppEscala
{
    public partial class form_igreja : Form
    {
        private readonly Database db = new();

        public form_igreja()
        {
            InitializeComponent();
            UiTheme.Apply(this);
            Text = "Nova igreja";
            label1.Text = "Nome da igreja";
            txt_igreja.PlaceholderText = "Ex.: Matriz";
            btn_add.Text = "Salvar";
            db.Initialize();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_igreja.Text))
            {
                MessageBox.Show("Você precisa escrever o nome antes!");
                return;
            }

            IgrejaEntity novaIgreja = new() { Nome = txt_igreja.Text.Trim() };
            db.InsertIgreja(novaIgreja);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
