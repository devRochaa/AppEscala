using AppEscala.Models.Entities;

using AppEscala.Helpers;

namespace AppEscala.Views
{
    public partial class form_editarAcolito : Form
    {
        private readonly Database db = new();
        private readonly Panel panelDisponibilidade = new();
        private readonly Panel panelSemana = new();
        private readonly Panel panelFimSemana = new();
        private readonly Panel panelDados = new();
        private readonly Panel panelIndisponibilidade = new();
        private readonly Button btnToggleSemana = new();
        private readonly Button btnToggleFimSemana = new();
        private readonly Button btnVoltar = new();
        private readonly Button btnExcluirAcolito = new();
        private readonly DataGridView dgvDiasIndisponiveis = new();
        private readonly TextBox txtMotivoAdd = new();
        private readonly ComboBox cmbPadrinho = new();
        private readonly NumericUpDown numMissasNecessarias = new();
        private readonly NumericUpDown numMissasServidas = new();
        private readonly Label lblMissasServidasValor = new();
        private readonly Dictionary<(int Dia, int Turno), CheckBox> disponibilidadeChecks = new();
        public int? id_acolito { get; set; }
        int id_dia = -1;
        public bool atualizou = false;
        private string nomeAntigo = string.Empty;
        public form_editarAcolito()
        {
            InitializeComponent();
            UiTheme.Apply(this);
            Text = "Editar acólito";
            cmb_dias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_turno1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_turno2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_turno3.DropDownStyle = ComboBoxStyle.DropDownList;
            db.Initialize();
            ConfigurarLayoutModerno();
        }


        private void form_editarAcolito_Load(object sender, EventArgs e)
        {
            ComboBoxDias();
            CarregarPadrinhos();
            carregar_acolito();
            carregarListView();

            dtp_add.Format = DateTimePickerFormat.Custom;
            dtp_add.CustomFormat = "dd/MM/yyyy";

            dtp_edit.Format = DateTimePickerFormat.Custom;
            dtp_edit.CustomFormat = "dd/MM/yyyy";
            CarregarDisponibilidades();
        }

        private void carregar_acolito()
        {
            var acolito = db.SelectAcolito(id_acolito);
            if (acolito is not null)
            {
                txt_nome.Text = acolito.Nome;
                nomeAntigo = acolito.Nome;
                SelecionarPadrinho(acolito.PadrinhoId);
                numMissasNecessarias.Value = Math.Min(numMissasNecessarias.Maximum, Math.Max(numMissasNecessarias.Minimum, acolito.MissasAcompanhadasNecessarias));
                numMissasServidas.Value = Math.Min(numMissasServidas.Maximum, Math.Max(numMissasServidas.Minimum, acolito.MissasServidas));
                lblMissasServidasValor.Text = acolito.MissasServidas.ToString();
            }

            cmb_turno1.SelectedIndex = -1;
            cmb_turno2.SelectedIndex = -1;
            cmb_turno3.SelectedIndex = -1;
            id_turnoAntigo1 = -1;
            id_turnoAntigo2 = -1;
            id_turnoAntigo3 = -1;
            id_turnoNovo1 = -1;
            id_turnoNovo2 = -1;
            id_turnoNovo3 = -1;

            if (cmb_dias.SelectedItem is not Item selectedItem)
                return;

            id_dia = selectedItem.Value;
            int i = 1;
            var listaAcolitos = db.Acolitos_Dias(id_acolito).ToList();
            foreach (var acolitoL in listaAcolitos)
            {
                if (acolitoL.IdDiaSemana != selectedItem.Value)
                    continue;

                if (i == 1)
                {
                    SetTurnoSelecionado(cmb_turno1, acolitoL.Id_Turno);
                    id_turnoAntigo1 = acolitoL.Id_Turno;
                }
                if (i == 2)
                {
                    SetTurnoSelecionado(cmb_turno2, acolitoL.Id_Turno);
                    id_turnoAntigo2 = acolitoL.Id_Turno;
                }
                if (i == 3)
                {
                    SetTurnoSelecionado(cmb_turno3, acolitoL.Id_Turno);
                    id_turnoAntigo3 = acolitoL.Id_Turno;
                }
                i++;
            }
        }

        private void carregarListView()
        {
            lst_dias.Items.Clear();
            dgvDiasIndisponiveis.Rows.Clear();
            var listaDias = db.SelectDiasAcolito(id_acolito);

            foreach (AcolitoCompromissosEntity item in listaDias)
            {
                lst_dias.Items.Add(item.dia);
                dgvDiasIndisponiveis.Rows.Add(item.dia, ObterNomeDiaSemana(item.Dia), item.Motivo, "Editar", "Excluir");
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
            public string Display { get; set; } = string.Empty; // O texto visível
            public int Value { get; set; } // O valor oculto

            public override string ToString()
            {
                return Display; // Exibe apenas o texto no ComboBox
            }
        }
        private void ComboBoxDias()
        {
            var listaDias = db.SelectDiasSemana().ToList();
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

        private static void SetTurnoSelecionado(ComboBox comboBox, int turnoId)
        {
            int index = turnoId - 1;
            comboBox.SelectedIndex = index >= 0 && index < comboBox.Items.Count ? index : -1;
        }


        private void cmb_dias_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregar_acolito();
            lbl_dia.Text = cmb_dias.SelectedItem is null ? "Dia:" : cmb_dias.SelectedItem.ToString() + ":";
        }

        private void cmb_turno1_TextUpdate(object sender, EventArgs e)
        {
            //confirmar que o texto foi alterado
            teste.Text = "vish";
        }

        int id_turnoNovo1 = -1;
        int id_turnoNovo2 = -1;
        int id_turnoNovo3 = -1;
        int id_turnoAntigo1 = -1;
        int id_turnoAntigo2 = -1;
        int id_turnoAntigo3 = -1;

        private void cmb_turno1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_turno1.SelectedItem is Item selectedItem)
            {
                id_turnoNovo1 = selectedItem.Value;
            }
        }
        private void cmb_turno2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_turno2.SelectedItem is Item selectedItem)
            {
                id_turnoNovo2 = selectedItem.Value;
            }
        }
        private void cmb_turno3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmb_turno3.SelectedItem is Item selectedItem)
            {
                id_turnoNovo3 = selectedItem.Value;
            }
        }

        private void salvarTurno()
        {
            if (id_dia == -1)
                return;

            if (id_turnoNovo1 != -1 && id_turnoNovo1 != id_turnoAntigo1)
            {
                atualizou |= db.SalvarTurnoAcolito(id_acolito, id_dia, id_turnoAntigo1, id_turnoNovo1);
            }
            if (id_turnoNovo2 != -1 && id_turnoNovo2 != id_turnoAntigo2)
            {
                atualizou |= db.SalvarTurnoAcolito(id_acolito, id_dia, id_turnoAntigo2, id_turnoNovo2);
            }
            if (id_turnoNovo3 != -1 && id_turnoNovo3 != id_turnoAntigo3)
            {
                atualizou |= db.SalvarTurnoAcolito(id_acolito, id_dia, id_turnoAntigo3, id_turnoNovo3);
            }

        }

        private bool editarData()
        {
            string? dataSelecionada = ObterDataSelecionadaGrid();
            if (dataSelecionada is null)
                return false;

            db.UpdateDias(id_acolito, dataSelecionada, dtp_edit.Text);
            return true;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            bool houveAlteracao = diasEditado;
            string nomeNovo = txt_nome.Text.Trim();
            if (string.IsNullOrWhiteSpace(nomeNovo))
            {
                MessageBox.Show("O nome do acólito não pode ficar vazio.");
                return;
            }

            try
            {
                db.UpdateAcolito(id_acolito, nomeNovo, ObterPadrinhoSelecionadoId(), (int)numMissasNecessarias.Value, (int)numMissasServidas.Value);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            atualizou = true;
            houveAlteracao = true;

            db.SetDisponibilidadesAcolito(id_acolito, ObterDisponibilidadesSelecionadas());
            atualizou = true;
            houveAlteracao = true;

            if (diaSelecionado && lst_dias.SelectedItem != null && dtp_edit.Text != lst_dias.SelectedItem.ToString())
            {
                houveAlteracao |= editarData();
                atualizou = true;
            }

            if (!houveAlteracao)
            {
                MessageBox.Show("Você tem que editar ao menos 1 coisa para poder salvar.");
                return;
            }

            MessageBox.Show("Suas alterações foram salvas!");
            DialogResult = DialogResult.OK;
            Close();
        }

        bool diaSelecionado = false;

        private void lst_dias_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string horaTexto = lst_dias.Text;
            diaSelecionado = true;

            if (DateTime.TryParse(horaTexto, out DateTime hora))
            {
                dtp_edit.Value = hora;
            }
            else
            {
                MessageBox.Show("Formato de data/hora inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool diasEditado = false;
        private void btn_excluirDia_Click(object sender, EventArgs e)
        {
            string? dataSelecionada = ObterDataSelecionadaGrid();
            if (dataSelecionada is null)
            {
                MessageBox.Show("Para apagar, selecione um dia primeiro!");
                return;
            }
            if (id_acolito is null)
                return;

            db.DeleteDias(id_acolito.Value, dataSelecionada);
            
            carregarListView();
            diasEditado = true;
            atualizou = true;
        }

        private void btn_addDia_Click(object sender, EventArgs e)
        {
            string dataDia = dtp_add.Value.ToString().Substring(0, 10);
            if (DataJaExiste(dataDia))
            {
                MessageBox.Show("Essa data já foi adicionada!");
                return;
            }

            if (id_acolito is null)
                return;

            AcolitoCompromissosEntity novoDia = new()
            {
                Id_acolitos = id_acolito.Value,
                dia = dataDia,
                Motivo = txtMotivoAdd.Text.Trim()
            };
            db.InsertDias(novoDia);
            carregarListView();
            txtMotivoAdd.Clear();
            diasEditado = true;
            atualizou = true;
        }

        private bool DataJaExiste(string data)
            => db.SelectDiasAcolito(id_acolito).Any(d => d.dia == data);

        private string? ObterDataSelecionadaGrid()
        {
            if (dgvDiasIndisponiveis.CurrentRow is null || dgvDiasIndisponiveis.CurrentRow.IsNewRow)
                return null;

            return dgvDiasIndisponiveis.CurrentRow.Cells["data"].Value?.ToString();
        }

        private void ConfigurarLayoutModerno()
        {
            AutoScroll = true;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(1160, 820);
            MinimumSize = new Size(1120, 760);

            label3.Text = "Editar acólito";
            UiTheme.StyleTitle(label3);
            label3.Location = new Point(128, 22);

            btnVoltar.Text = "Voltar";
            btnVoltar.Size = new Size(84, 36);
            btnVoltar.Location = new Point(28, 24);
            btnVoltar.Click += (_, _) => Close();
            Controls.Add(btnVoltar);

            ConfigurarPainelDados();

            label2.Visible = false;
            lbl_dia.Visible = false;
            cmb_dias.Visible = false;
            cmb_turno1.Visible = false;
            cmb_turno2.Visible = false;
            cmb_turno3.Visible = false;
            teste.Visible = false;

            ConfigurarPainelDisponibilidade();
            ConfigurarPainelDiasIndisponiveis();

            btn_salvar.Text = "Salvar alterações";
            btn_salvar.Size = new Size(160, 40);
            btn_salvar.Location = new Point(ClientSize.Width - 196, ClientSize.Height - 58);
            btn_salvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            btnExcluirAcolito.Text = "🗑";
            btnExcluirAcolito.Size = new Size(44, 40);
            btnExcluirAcolito.Location = new Point(28, ClientSize.Height - 58);
            btnExcluirAcolito.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExcluirAcolito.BackColor = UiTheme.Danger;
            btnExcluirAcolito.ForeColor = Color.White;
            btnExcluirAcolito.Click += btnExcluirAcolito_Click;
            Controls.Add(btnExcluirAcolito);
        }

        private void btnExcluirAcolito_Click(object? sender, EventArgs e)
        {
            string nome = string.IsNullOrWhiteSpace(txt_nome.Text) ? "este acólito" : txt_nome.Text.Trim();
            DialogResult result = MessageBox.Show(
                $"Tem certeza que deseja apagar {nome}? Esta ação não pode ser desfeita.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            db.DeleteAcolito(id_acolito);
            atualizou = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ConfigurarPainelDisponibilidade()
        {
            panelDisponibilidade.Controls.Clear();
            panelSemana.Controls.Clear();
            panelFimSemana.Controls.Clear();
            panelDisponibilidade.BackColor = UiTheme.Surface;
            panelDisponibilidade.BorderStyle = BorderStyle.FixedSingle;

            Label titulo = new()
            {
                AutoSize = true,
                Text = "Dias em que pode servir",
                Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
                ForeColor = UiTheme.Text,
                Location = new Point(20, 30)
            };

            Label descricao = new()
            {
                AutoSize = true,
                Text = "Marque os períodos em que o acólito costuma estar disponível.",
                ForeColor = UiTheme.MutedText,
                Location = new Point(20, 60)
            };

            btnToggleSemana.Text = "Pode servir durante a semana";
            btnToggleSemana.Text = "Marcar semana";
            btnToggleSemana.Size = new Size(140, 34);
            btnToggleSemana.Location = new Point(20, 428);
            btnToggleSemana.Click += (_, _) => AlternarPainel(panelSemana);

            btnToggleFimSemana.Text = "Marcar final de semana";
            btnToggleFimSemana.Size = new Size(170, 34);
            btnToggleFimSemana.Location = new Point(172, 428);
            btnToggleFimSemana.Click += (_, _) => AlternarPainel(panelFimSemana);

            panelDisponibilidade.Location = new Point(35, 276);
            panelDisponibilidade.Size = new Size(500, 482);
            panelDisponibilidade.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelDisponibilidade.Controls.AddRange(new Control[] { titulo, descricao, btnToggleSemana, btnToggleFimSemana, panelSemana, panelFimSemana });

            panelSemana.Location = new Point(20, 96);
            panelSemana.Size = new Size(456, 216);
            panelSemana.Visible = true;
            CriarGrupoDias(panelSemana, new[]
            {
                (1, "Segunda"),
                (2, "Terça"),
                (3, "Quarta"),
                (4, "Quinta"),
                (5, "Sexta")
            });

            panelFimSemana.Location = new Point(20, 312);
            panelFimSemana.Size = new Size(456, 112);
            panelFimSemana.Visible = true;
            CriarGrupoDias(panelFimSemana, new[]
            {
                (6, "Sábado"),
                (7, "Domingo")
            });

            Controls.Add(panelDisponibilidade);
        }

        private void ConfigurarPainelDados()
        {
            panelDados.Controls.Clear();
            panelDados.BackColor = UiTheme.Surface;
            panelDados.BorderStyle = BorderStyle.FixedSingle;
            panelDados.Location = new Point(35, 108);
            panelDados.Size = new Size(500, 132);

            Label titulo = new()
            {
                AutoSize = true,
                Text = "Dados do acólito",
                Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
                ForeColor = UiTheme.Text,
                Location = new Point(20, 18)
            };

            label1.Location = new Point(20, 54);
            txt_nome.Location = new Point(20, 76);
            txt_nome.Size = new Size(300, 32);

            Label lblPadrinho = new()
            {
                AutoSize = true,
                Text = "Padrinho",
                ForeColor = UiTheme.Text,
                Location = new Point(20, 120)
            };

            cmbPadrinho.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPadrinho.Location = new Point(20, 142);
            cmbPadrinho.Size = new Size(190, 32);

            Label lblMissasNecessarias = new()
            {
                AutoSize = true,
                Text = "Missas Acomp.",
                ForeColor = UiTheme.Text,
                Location = new Point(236, 120)
            };

            numMissasNecessarias.Minimum = 0;
            numMissasNecessarias.Maximum = 1000;
            numMissasNecessarias.Location = new Point(236, 142);
            numMissasNecessarias.Size = new Size(96, 32);

            numMissasServidas.Minimum = 0;
            numMissasServidas.Maximum = 1000;
            numMissasServidas.Visible = false;

            Label lblMissasServidas = new()
            {
                AutoSize = true,
                Text = "Missas servidas",
                ForeColor = UiTheme.Text,
                Location = new Point(378, 120)
            };

            lblMissasServidasValor.AutoSize = false;
            lblMissasServidasValor.Text = "0";
            lblMissasServidasValor.TextAlign = ContentAlignment.MiddleCenter;
            lblMissasServidasValor.BorderStyle = BorderStyle.FixedSingle;
            lblMissasServidasValor.BackColor = Color.White;
            lblMissasServidasValor.ForeColor = UiTheme.Text;
            lblMissasServidasValor.Location = new Point(378, 142);
            lblMissasServidasValor.Size = new Size(80, 32);

            panelDados.Size = new Size(500, 190);
            panelDados.Controls.AddRange(new Control[] { titulo, label1, txt_nome, lblPadrinho, cmbPadrinho, lblMissasNecessarias, numMissasNecessarias, lblMissasServidas, lblMissasServidasValor });
            Controls.Add(panelDados);
        }

        private void CriarGrupoDias(Panel parent, (int Id, string Nome)[] dias)
        {
            parent.Controls.Clear();
            Label manha = new() { AutoSize = true, Text = "Manhã", ForeColor = UiTheme.MutedText, Location = new Point(170, 0) };
            Label tarde = new() { AutoSize = true, Text = "Tarde", ForeColor = UiTheme.MutedText, Location = new Point(260, 0) };
            Label noite = new() { AutoSize = true, Text = "Noite", ForeColor = UiTheme.MutedText, Location = new Point(350, 0) };
            parent.Controls.AddRange(new Control[] { manha, tarde, noite });

            int y = 28;
            int index = 0;
            foreach (var dia in dias)
            {
                Panel row = new()
                {
                    Location = new Point(0, y),
                    Size = new Size(442, 28),
                    BackColor = index % 2 == 0 ? Color.FromArgb(248, 250, 252) : Color.White
                };

                Label titulo = new()
                {
                    AutoSize = true,
                    Text = dia.Nome,
                    ForeColor = UiTheme.Text,
                    Location = new Point(12, 6)
                };

                row.Controls.Add(titulo);
                CriarCheckTurno(row, dia.Id, 1, "", 168, 5);
                CriarCheckTurno(row, dia.Id, 2, "", 258, 5);
                CriarCheckTurno(row, dia.Id, 3, "", 348, 5);

                parent.Controls.Add(row);
                y += 38;
                index++;
            }
        }

        private void CriarCheckTurno(Control parent, int dia, int turno, string texto, int x, int y)
        {
            CheckBox checkBox = new()
            {
                AutoSize = true,
                Text = texto,
                Location = new Point(x, y)
            };

            disponibilidadeChecks[(dia, turno)] = checkBox;
            parent.Controls.Add(checkBox);
        }

        private void ConfigurarPainelDiasIndisponiveis()
        {
            panelIndisponibilidade.Controls.Clear();
            panelIndisponibilidade.BackColor = UiTheme.Surface;
            panelIndisponibilidade.BorderStyle = BorderStyle.FixedSingle;
            panelIndisponibilidade.Location = new Point(568, 108);
            panelIndisponibilidade.Size = new Size(560, 626);

            Label titulo = new()
            {
                AutoSize = true,
                Text = "Datas em que não pode servir",
                Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
                ForeColor = UiTheme.Text,
                Location = new Point(20, 18)
            };

            Label descricao = new()
            {
                AutoSize = true,
                Text = "Use para viagem, trabalho, escola ou outros compromissos pontuais.",
                ForeColor = UiTheme.MutedText,
                Location = new Point(20, 48)
            };

            ConfigurarGridDiasIndisponiveis();
            dgvDiasIndisponiveis.Location = new Point(20, 166);
            dgvDiasIndisponiveis.Size = new Size(520, 254);

            lst_dias.Visible = false;
            dtp_edit.Visible = false;
            label5.Visible = false;

            label4.Location = new Point(20, 78);
            label4.Text = "Adicionar data";
            dtp_add.Location = new Point(20, 98);
            dtp_add.Size = new Size(150, 32);
            txtMotivoAdd.PlaceholderText = "Motivo opcional";
            txtMotivoAdd.Location = new Point(188, 98);
            txtMotivoAdd.Size = new Size(210, 32);
            btn_addDia.Location = new Point(420, 98);
            btn_addDia.Size = new Size(112, 38);
            btn_addDia.Text = "+ Adicionar";
            btn_addDia.TextAlign = ContentAlignment.MiddleCenter;

            btn_excluirDia.Visible = false;

            panelIndisponibilidade.Controls.AddRange(new Control[]
            {
                titulo,
                descricao,
                label4,
                dtp_add,
                txtMotivoAdd,
                btn_addDia,
                dgvDiasIndisponiveis
            });
            Controls.Add(panelIndisponibilidade);
        }

        private void ConfigurarGridDiasIndisponiveis()
        {
            dgvDiasIndisponiveis.AllowUserToAddRows = false;
            dgvDiasIndisponiveis.AllowUserToDeleteRows = false;
            dgvDiasIndisponiveis.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDiasIndisponiveis.BackgroundColor = UiTheme.Surface;
            dgvDiasIndisponiveis.BorderStyle = BorderStyle.None;
            dgvDiasIndisponiveis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiasIndisponiveis.Columns.Clear();
            dgvDiasIndisponiveis.MultiSelect = false;
            dgvDiasIndisponiveis.ReadOnly = true;
            dgvDiasIndisponiveis.RowHeadersVisible = false;
            dgvDiasIndisponiveis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiasIndisponiveis.CellContentClick += dgvDiasIndisponiveis_CellContentClick;
            dgvDiasIndisponiveis.CellDoubleClick += dgvDiasIndisponiveis_CellDoubleClick;

            dgvDiasIndisponiveis.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "data",
                HeaderText = "Data",
                Width = 105
            });
            dgvDiasIndisponiveis.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dia",
                HeaderText = "Dia",
                Width = 95
            });
            dgvDiasIndisponiveis.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "motivo",
                HeaderText = "Motivo",
                Width = 190
            });
            dgvDiasIndisponiveis.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "editar",
                HeaderText = "",
                Width = 58,
                Text = "Editar",
                UseColumnTextForButtonValue = true
            });
            dgvDiasIndisponiveis.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "excluir",
                HeaderText = "",
                Width = 58,
                Text = "Excluir",
                UseColumnTextForButtonValue = true
            });
        }

        private void dgvDiasIndisponiveis_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                EditarDataIndisponivel(e.RowIndex);
        }

        private void dgvDiasIndisponiveis_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string coluna = dgvDiasIndisponiveis.Columns[e.ColumnIndex].Name;
            if (coluna == "editar")
                EditarDataIndisponivel(e.RowIndex);
            else if (coluna == "excluir")
                ExcluirDataIndisponivel(e.RowIndex);
        }

        private void EditarDataIndisponivel(int rowIndex)
        {
            string? dataAtual = dgvDiasIndisponiveis.Rows[rowIndex].Cells["data"].Value?.ToString();
            string motivoAtual = dgvDiasIndisponiveis.Rows[rowIndex].Cells["motivo"].Value?.ToString() ?? string.Empty;
            if (dataAtual is null || id_acolito is null)
                return;

            using Form seletor = CriarSeletorData(dataAtual, motivoAtual, out DateTimePicker picker, out TextBox motivo);
            if (seletor.ShowDialog(this) != DialogResult.OK)
                return;

            string novaData = picker.Value.ToString("dd/MM/yyyy");
            if (novaData != dataAtual && DataJaExiste(novaData))
            {
                MessageBox.Show("Essa data já foi adicionada!");
                return;
            }

            db.UpdateDias(id_acolito, dataAtual, novaData, motivo.Text.Trim());
            carregarListView();
            diasEditado = true;
            atualizou = true;
        }

        private void ExcluirDataIndisponivel(int rowIndex)
        {
            string? data = dgvDiasIndisponiveis.Rows[rowIndex].Cells["data"].Value?.ToString();
            if (data is null || id_acolito is null)
                return;

            db.DeleteDias(id_acolito.Value, data);
            carregarListView();
            diasEditado = true;
            atualizou = true;
        }

        private static Form CriarSeletorData(string dataAtual, string motivoAtual, out DateTimePicker picker, out TextBox motivo)
        {
            Form seletor = new()
            {
                Text = "Selecionar data",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(320, 168)
            };

            picker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Width = 260,
                Location = new Point(30, 18)
            };

            if (DateTime.TryParse(dataAtual, out var data))
                picker.Value = data;

            motivo = new TextBox
            {
                PlaceholderText = "Motivo opcional",
                Text = motivoAtual,
                Width = 260,
                Location = new Point(30, 58)
            };

            Button btnConfirmar = new()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(116, 108),
                Size = new Size(86, 32)
            };

            seletor.Controls.Add(picker);
            seletor.Controls.Add(motivo);
            seletor.Controls.Add(btnConfirmar);
            seletor.AcceptButton = btnConfirmar;
            return seletor;
        }

        private static string ObterNomeDiaSemana(DateOnly data)
        {
            string[] dias = ["Domingo", "2ª.feira", "3ª.feira", "4ª.feira", "5ª.feira", "6ª.feira", "Sábado"];
            return dias[(int)data.DayOfWeek];
        }

        private void CarregarDisponibilidades()
        {
            foreach (var checkBox in disponibilidadeChecks.Values)
                checkBox.Checked = false;

            foreach (var item in db.Acolitos_Dias(id_acolito))
            {
                if (disponibilidadeChecks.TryGetValue((item.IdDiaSemana, item.Id_Turno), out var checkBox))
                    checkBox.Checked = true;
            }
        }

        private IEnumerable<(int Dia, int Turno)> ObterDisponibilidadesSelecionadas()
        {
            foreach (var item in disponibilidadeChecks)
            {
                if (item.Value.Checked)
                    yield return item.Key;
            }
        }

        private void CarregarPadrinhos()
        {
            cmbPadrinho.Items.Clear();
            cmbPadrinho.Items.Add(new PadrinhoItem("Sem padrinho", null));

            foreach (var acolito in db.SelectAllAcolitos().Where(a => a.Id != id_acolito))
                cmbPadrinho.Items.Add(new PadrinhoItem(acolito.Nome, acolito.Id));

            cmbPadrinho.SelectedIndex = 0;
        }

        private void SelecionarPadrinho(int? padrinhoId)
        {
            for (int i = 0; i < cmbPadrinho.Items.Count; i++)
            {
                if (cmbPadrinho.Items[i] is PadrinhoItem item && item.Id == padrinhoId)
                {
                    cmbPadrinho.SelectedIndex = i;
                    return;
                }
            }

            cmbPadrinho.SelectedIndex = 0;
        }

        private int? ObterPadrinhoSelecionadoId()
            => cmbPadrinho.SelectedItem is PadrinhoItem item ? item.Id : null;

        private sealed record PadrinhoItem(string Nome, int? Id)
        {
            public override string ToString() => Nome;
        }

        private static void AlternarPainel(Panel panel)
        {
            var checks = EnumerarCheckBoxes(panel).ToList();
            bool marcar = checks.Any(checkBox => !checkBox.Checked);

            foreach (var checkBox in EnumerarCheckBoxes(panel))
                checkBox.Checked = marcar;
        }

        private static IEnumerable<CheckBox> EnumerarCheckBoxes(Control root)
        {
            foreach (Control control in root.Controls)
            {
                if (control is CheckBox checkBox)
                    yield return checkBox;

                if (control.HasChildren)
                {
                    foreach (var child in EnumerarCheckBoxes(control))
                        yield return child;
                }
            }
        }
    }
}
