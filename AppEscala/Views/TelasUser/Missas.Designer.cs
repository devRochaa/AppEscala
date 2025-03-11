namespace AppEscala
{
    partial class Missas
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            listBox1 = new ListBox();
            dateTimePicker1 = new DateTimePicker();
            cmb_igrejas = new ComboBox();
            label1 = new Label();
            btn_AddIgreja = new Button();
            dgv_missas = new DataGridView();
            coluna1 = new DataGridViewTextBoxColumn();
            coluna2 = new DataGridViewTextBoxColumn();
            coluna3 = new DataGridViewTextBoxColumn();
            coluna4 = new DataGridViewTextBoxColumn();
            Descricao = new DataGridViewTextBoxColumn();
            Qnt_Acolitos = new DataGridViewTextBoxColumn();
            btn_recarregarIgrejas = new Button();
            btn_editar = new Button();
            btn_excluir = new Button();
            txt_desc = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmb_quant = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgv_missas).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(25, 400);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(358, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(25, 118);
            listBox1.MultiColumn = true;
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(222, 276);
            listBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(25, 89);
            dateTimePicker1.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(222, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // cmb_igrejas
            // 
            cmb_igrejas.FormattingEnabled = true;
            cmb_igrejas.Location = new Point(25, 43);
            cmb_igrejas.Name = "cmb_igrejas";
            cmb_igrejas.Size = new Size(222, 23);
            cmb_igrejas.TabIndex = 6;
            cmb_igrejas.SelectedIndexChanged += cmb_igrejas_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Igreja:";
            // 
            // btn_AddIgreja
            // 
            btn_AddIgreja.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddIgreja.Location = new Point(253, 42);
            btn_AddIgreja.Name = "btn_AddIgreja";
            btn_AddIgreja.Padding = new Padding(2, 0, 0, 0);
            btn_AddIgreja.Size = new Size(23, 23);
            btn_AddIgreja.TabIndex = 8;
            btn_AddIgreja.Text = "+";
            btn_AddIgreja.UseVisualStyleBackColor = true;
            btn_AddIgreja.Click += btn_AddIgreja_Click;
            // 
            // dgv_missas
            // 
            dgv_missas.AllowUserToAddRows = false;
            dgv_missas.AllowUserToDeleteRows = false;
            dgv_missas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_missas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_missas.Columns.AddRange(new DataGridViewColumn[] { coluna1, coluna2, coluna3, coluna4, Descricao, Qnt_Acolitos });
            dgv_missas.Location = new Point(431, 52);
            dgv_missas.Name = "dgv_missas";
            dgv_missas.ReadOnly = true;
            dgv_missas.Size = new Size(288, 397);
            dgv_missas.TabIndex = 9;
            dgv_missas.CellClick += dgv_missas_CellClick;
            dgv_missas.CellContentClick += dgv_missas_CellContentClick;
            dgv_missas.CellMouseDoubleClick += dgv_missas_CellMouseDoubleClick;
            // 
            // coluna1
            // 
            coluna1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            coluna1.HeaderText = "Data";
            coluna1.Name = "coluna1";
            coluna1.ReadOnly = true;
            coluna1.Width = 56;
            // 
            // coluna2
            // 
            coluna2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            coluna2.HeaderText = "Horário";
            coluna2.Name = "coluna2";
            coluna2.ReadOnly = true;
            coluna2.Width = 72;
            // 
            // coluna3
            // 
            coluna3.HeaderText = "Local";
            coluna3.MinimumWidth = 128;
            coluna3.Name = "coluna3";
            coluna3.ReadOnly = true;
            // 
            // coluna4
            // 
            coluna4.HeaderText = "id";
            coluna4.Name = "coluna4";
            coluna4.ReadOnly = true;
            coluna4.Visible = false;
            // 
            // Descricao
            // 
            Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            Descricao.Width = 83;
            // 
            // Qnt_Acolitos
            // 
            Qnt_Acolitos.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Qnt_Acolitos.HeaderText = "Qnt";
            Qnt_Acolitos.Name = "Qnt_Acolitos";
            Qnt_Acolitos.ReadOnly = true;
            Qnt_Acolitos.Width = 52;
            // 
            // btn_recarregarIgrejas
            // 
            btn_recarregarIgrejas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_recarregarIgrejas.Location = new Point(282, 42);
            btn_recarregarIgrejas.Name = "btn_recarregarIgrejas";
            btn_recarregarIgrejas.Padding = new Padding(2, 0, 0, 0);
            btn_recarregarIgrejas.Size = new Size(23, 23);
            btn_recarregarIgrejas.TabIndex = 10;
            btn_recarregarIgrejas.Text = "↺";
            btn_recarregarIgrejas.UseVisualStyleBackColor = true;
            btn_recarregarIgrejas.Click += btn_recarregarIgrejas_Click;
            // 
            // btn_editar
            // 
            btn_editar.Location = new Point(644, 20);
            btn_editar.Name = "btn_editar";
            btn_editar.Size = new Size(75, 26);
            btn_editar.TabIndex = 11;
            btn_editar.Text = "Editar";
            btn_editar.UseVisualStyleBackColor = true;
            btn_editar.Click += btn_editar_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_excluir.ForeColor = Color.Red;
            btn_excluir.Location = new Point(563, 20);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 26);
            btn_excluir.TabIndex = 12;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // txt_desc
            // 
            txt_desc.Location = new Point(253, 142);
            txt_desc.Name = "txt_desc";
            txt_desc.Size = new Size(130, 68);
            txt_desc.TabIndex = 13;
            txt_desc.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(253, 124);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 14;
            label2.Text = "Descrição:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 71);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 15;
            label3.Text = "Data:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(253, 228);
            label4.Name = "label4";
            label4.Size = new Size(134, 15);
            label4.TabIndex = 16;
            label4.Text = "Quantidade de Acolitos:";
            // 
            // cmb_quant
            // 
            cmb_quant.FormattingEnabled = true;
            cmb_quant.Location = new Point(253, 255);
            cmb_quant.Name = "cmb_quant";
            cmb_quant.Size = new Size(130, 23);
            cmb_quant.TabIndex = 18;
            // 
            // Missas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmb_quant);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_desc);
            Controls.Add(btn_excluir);
            Controls.Add(btn_editar);
            Controls.Add(btn_recarregarIgrejas);
            Controls.Add(dgv_missas);
            Controls.Add(btn_AddIgreja);
            Controls.Add(label1);
            Controls.Add(cmb_igrejas);
            Controls.Add(dateTimePicker1);
            Controls.Add(listBox1);
            Controls.Add(btnAdd);
            Name = "Missas";
            RightToLeft = RightToLeft.No;
            Size = new Size(746, 472);
            Load += Missas_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_missas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private ListBox listBox1;
        private DateTimePicker dateTimePicker1;
        private ComboBox cmb_igrejas;
        private Label label1;
        private Button btn_AddIgreja;
        private DataGridView dgv_missas;
        private Button btn_recarregarIgrejas;
        private Button btn_editar;
        private Button btn_excluir;
        private RichTextBox txt_desc;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_;
        private ComboBox cmb_quant;
        private DataGridViewTextBoxColumn coluna1;
        private DataGridViewTextBoxColumn coluna2;
        private DataGridViewTextBoxColumn coluna3;
        private DataGridViewTextBoxColumn coluna4;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Qnt_Acolitos;
    }
}
