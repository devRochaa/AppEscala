using AppEscala.Helpers;
using AppEscala.Models.Entities;
using static AppEscala.Helpers.Database;

namespace AppEscala
{
    public partial class form_editar : Form
    {
        private readonly Database db = new();
        private readonly CheckBox chkAtivo = new();

        public int? id_missa { get; set; }

        public form_editar()
        {
            InitializeComponent();
            UiTheme.Apply(this);
            Text = "Editar missa";
            ConfigurarAtivo();
        }

        private void form_editar_Load(object sender, EventArgs e)
        {
            db.Initialize();

            cmb_quant.Items.Clear();
            for (int i = 0; i <= 15; i++)
                cmb_quant.Items.Add(i);

            combobox_igreja();
            carregar_missaSelecionada();
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

        private DateTime dataAntiga;
        private string horaAntiga = string.Empty;
        private string igrejaAntiga = string.Empty;
        private int qntAntiga = -1;
        private string descAntiga = string.Empty;
        private bool ativoAntigo = true;

        private void carregar_missaSelecionada()
        {
            if (id_missa is null)
            {
                MessageBox.Show("Nenhuma missa selecionada.");
                Close();
                return;
            }

            MissaNovaDadosCompletos missaSelecionada = db.SelectMissaNova(id_missa);

            dataAntiga = missaSelecionada.Data;
            horaAntiga = missaSelecionada.Data.ToString("HH:mm");
            igrejaAntiga = missaSelecionada.Igreja;
            qntAntiga = missaSelecionada.Qnt_acolitos;
            descAntiga = missaSelecionada.Descricao;
            ativoAntigo = missaSelecionada.Ativo;
            chkAtivo.Checked = missaSelecionada.Ativo;

            dtp_missa.Value = missaSelecionada.Data;
            txt_hora1.Text = missaSelecionada.Data.ToString("HH");
            txt_hora2.Text = missaSelecionada.Data.ToString("mm");

            foreach (Item item in cmb_igrejas.Items)
            {
                if (item.Value == missaSelecionada.Id_igreja)
                {
                    cmb_igrejas.SelectedItem = item;
                    break;
                }
            }

            if (missaSelecionada.Qnt_acolitos >= 0 && missaSelecionada.Qnt_acolitos < cmb_quant.Items.Count)
                cmb_quant.SelectedIndex = missaSelecionada.Qnt_acolitos;

            txt_desc.Text = missaSelecionada.Descricao;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (id_missa is null)
            {
                MessageBox.Show("Nenhuma missa selecionada.");
                return;
            }

            if (cmb_igrejas.SelectedItem is not Item selectedItem)
            {
                MessageBox.Show("Selecione uma igreja.");
                return;
            }

            if (!int.TryParse(txt_hora1.Text, out int horaNova) || horaNova < 0 || horaNova > 23)
            {
                MessageBox.Show("Hora inválida. Use um valor entre 00 e 23.");
                return;
            }

            if (!int.TryParse(txt_hora2.Text, out int minutoNovo) || minutoNovo < 0 || minutoNovo > 59)
            {
                MessageBox.Show("Minuto inválido. Use um valor entre 00 e 59.");
                return;
            }

            int quantidade = cmb_quant.SelectedIndex >= 0 ? cmb_quant.SelectedIndex : 0;
            var novaDataHora = dtp_missa.Value.Date.AddHours(horaNova).AddMinutes(minutoNovo);

            bool foiAlterado =
                igrejaAntiga != selectedItem.Display ||
                horaAntiga != novaDataHora.ToString("HH:mm") ||
                dataAntiga.Date != novaDataHora.Date ||
                descAntiga != txt_desc.Text ||
                qntAntiga != quantidade ||
                ativoAntigo != chkAtivo.Checked;

            if (!foiAlterado)
            {
                MessageBox.Show("Você não alterou nenhuma informação.");
                return;
            }

            MissaEntity dadosNovaMissaNova = new()
            {
                Id = id_missa.Value,
                Id_igreja = selectedItem.Value,
                Data = novaDataHora,
                Descricao = txt_desc.Text,
                Qnt_acolitos = quantidade,
                Ativo = chkAtivo.Checked
            };

            db.UpdateMissaNova(id_missa, dadosNovaMissaNova);

            MessageBox.Show("A missa foi editada");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ConfigurarAtivo()
        {
            chkAtivo.Text = "Missa ativa";
            chkAtivo.AutoSize = true;
            chkAtivo.Checked = true;
            chkAtivo.Location = new Point(103, 220);
            Controls.Add(chkAtivo);
        }
    }
}
