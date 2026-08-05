using AppEscala.Helpers;
using AppEscala.Models.Entities;

namespace AppEscala
{
    public partial class form_igreja : Form
    {
        private readonly Database db = new();
        private readonly int? igrejaId;

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

        public form_igreja(IgrejaEntity igreja)
            : this()
        {
            igrejaId = igreja.Id;
            Text = "Editar igreja";
            txt_igreja.Text = igreja.Nome;
            txt_igreja.SelectAll();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_igreja.Text))
            {
                MessageBox.Show("Você precisa escrever o nome antes!");
                return;
            }

            try
            {
                IgrejaEntity igreja = new() { Nome = txt_igreja.Text.Trim() };

                if (igrejaId is null)
                    db.InsertIgreja(igreja);
                else
                    db.UpdateIgrejas(igrejaId.Value, igreja);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao salvar igreja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
