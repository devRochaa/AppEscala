using AppEscala.Helpers;
using AppEscala.Models.Entities;

namespace AppEscala
{
    public partial class Missas : UserControl
    {
        private readonly Database db = new();
        private int? id_selecionado;
        private string data_selecionada = string.Empty;

        public Missas()
        {
            InitializeComponent();
            ConfigurarInterface();
            db.Initialize();
            dgv_missas.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_missas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Missas_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            carregar_missas();
            MontarHorarios();
            combobox_igreja();

            cmb_quant.Items.Clear();
            for (int i = 0; i <= 15; i++)
                cmb_quant.Items.Add(i);
        }

        private void ApagarMissasAntigas()
        {
            var listaMissas = db.SelectAllMissasNova();

            foreach (var missa in listaMissas)
            {
                if (DateTime.Now > missa.Data)
                    db.DeleteMissaNova(missa.idMissa);
            }
        }

        private void carregar_missas()
        {
            ApagarMissasAntigas();
            var listaMissas = db.SelectAllMissasNova();

            dgv_missas.Rows.Clear();
            foreach (var missa in listaMissas)
            {
                int rowIndex = dgv_missas.Rows.Add();
                dgv_missas.Rows[rowIndex].Cells[0].Value = missa.Data.ToString("d");
                dgv_missas.Rows[rowIndex].Cells[1].Value = missa.Data.ToString("HH:mm");
                dgv_missas.Rows[rowIndex].Cells[2].Value = missa.Igreja;
                dgv_missas.Rows[rowIndex].Cells[3].Value = missa.idMissa;
                dgv_missas.Rows[rowIndex].Cells[4].Value = missa.Descricao;
                dgv_missas.Rows[rowIndex].Cells[5].Value = missa.Qnt_acolitos;
            }
        }

        public class Item
        {
            public string Display { get; set; } = string.Empty;
            public int Value { get; set; }

            public override string ToString() => Display;
        }

        private void combobox_igreja()
        {
            cmb_igrejas.Items.Clear();
            var listaIgreja = db.SelectAllIgreja();
            foreach (var igreja in listaIgreja)
                cmb_igrejas.Items.Add(new Item { Display = igreja.Nome, Value = igreja.Id });
        }

        private void MontarHorarios()
        {
            var horario = new TimeSpan(0, 0, 0);
            var incremento = new TimeSpan(0, 30, 0);

            listBox1.Items.Clear();
            listBox1.ColumnWidth = 60;
            for (int i = 0; i < 48; i++)
            {
                listBox1.Items.Add(horario.ToString(@"hh\:mm"));
                horario += incremento;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmb_igrejas.SelectedItem is not Item selectedItem)
            {
                MessageBox.Show("Nenhuma Igreja selecionada");
                return;
            }

            if (string.IsNullOrWhiteSpace(listBox1.Text))
            {
                MessageBox.Show("Selecione um horário!");
                return;
            }

            if (!TimeSpan.TryParse(listBox1.Text, out var horarioSelecionado))
            {
                MessageBox.Show("Horário inválido!");
                return;
            }

            int qntAcolitos = cmb_quant.SelectedIndex != -1 ? cmb_quant.SelectedIndex : 4;
            DateTime dataConvertida = dateTimePicker1.Value.Date.Add(horarioSelecionado);

            MissaEntity newMissa = new()
            {
                Id_igreja = selectedItem.Value,
                Data = dataConvertida,
                Descricao = txt_desc.Text,
                Qnt_acolitos = qntAcolitos
            };

            db.InsertMissaNova(newMissa);
            MessageBox.Show("Missa Adicionada!");
            carregar_missas();
        }

        private void btn_AddIgreja_Click(object sender, EventArgs e)
        {
            using form_igreja formIgreja = new();
            if (formIgreja.ShowDialog() == DialogResult.OK)
                combobox_igreja();
        }

        private void dgv_missas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

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
                return;

            db.DeleteMissaNova(id_selecionado.Value);
            id_selecionado = null;
            data_selecionada = string.Empty;
            carregar_missas();
        }

        private void dgv_missas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow selectedRow = dgv_missas.Rows[e.RowIndex];
            if (selectedRow.Cells[3].Value is null)
                return;

            id_selecionado = Convert.ToInt32(selectedRow.Cells[3].Value);
            data_selecionada = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            ChamarEdicao();
        }

        private void ChamarEdicao()
        {
            if (id_selecionado is null)
            {
                MessageBox.Show("Você precisa selecionar uma missa primeiro!");
                return;
            }

            using form_editar formEdit = new();
            formEdit.id_missa = id_selecionado;
            if (formEdit.ShowDialog() == DialogResult.OK)
                carregar_missas();
        }

        private void btn_recarregarIgrejas_Click(object sender, EventArgs e)
        {
            carregar_missas();
            combobox_igreja();
        }

        private void cmb_igrejas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgv_missas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                dgv_missas_CellClick(sender, new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex));

            ChamarEdicao();
        }

        private void ConfigurarInterface()
        {
            UiTheme.Apply(this);
            label1.Text = "Igreja";
            label2.Text = "Descricao";
            label3.Text = "Data";
            label4.Text = "Quantidade de acolitos";
            btn_AddIgreja.Text = "+";
            btn_recarregarIgrejas.Text = "Atualizar";
            btnAdd.Text = "Adicionar missa";

            cmb_igrejas.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dateTimePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dgv_missas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_editar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_excluir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Resize += (_, _) => AjustarLayout();
        }

        private void AjustarLayout()
        {
            const int margin = 28;
            int leftWidth = Math.Min(360, Math.Max(300, Width / 2 - 50));
            int rightX = margin + leftWidth + 28;
            int rightWidth = Math.Max(280, Width - rightX - margin);

            label1.Location = new Point(margin, 24);
            cmb_igrejas.Location = new Point(margin, 46);
            cmb_igrejas.Size = new Size(leftWidth - 126, 32);
            btn_AddIgreja.Location = new Point(margin + leftWidth - 118, 45);
            btn_AddIgreja.Size = new Size(34, 32);
            btn_recarregarIgrejas.Location = new Point(margin + leftWidth - 78, 45);
            btn_recarregarIgrejas.Size = new Size(78, 32);

            label3.Location = new Point(margin, 92);
            dateTimePicker1.Location = new Point(margin, 114);
            dateTimePicker1.Size = new Size(leftWidth, 32);

            listBox1.Location = new Point(margin, 160);
            listBox1.Size = new Size(leftWidth / 2 - 8, Math.Max(180, Height - 232));

            label2.Location = new Point(margin + leftWidth / 2 + 12, 160);
            txt_desc.Location = new Point(margin + leftWidth / 2 + 12, 184);
            txt_desc.Size = new Size(leftWidth / 2 - 12, 96);

            label4.Location = new Point(margin + leftWidth / 2 + 12, 296);
            cmb_quant.Location = new Point(margin + leftWidth / 2 + 12, 320);
            cmb_quant.Size = new Size(leftWidth / 2 - 12, 32);

            btnAdd.Location = new Point(margin, Height - 58);
            btnAdd.Size = new Size(leftWidth, 38);

            btn_excluir.Location = new Point(rightX + rightWidth - 176, 24);
            btn_excluir.Size = new Size(82, 32);
            btn_editar.Location = new Point(rightX + rightWidth - 88, 24);
            btn_editar.Size = new Size(88, 32);

            dgv_missas.Location = new Point(rightX, 68);
            dgv_missas.Size = new Size(rightWidth, Math.Max(220, Height - 92));
        }
    }
}
