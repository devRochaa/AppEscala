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
            btn_recarregarIgrejas = new Button();
            btn_editar = new Button();
            btn_excluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_missas).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(61, 414);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(222, 40);
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
            listBox1.Location = new Point(61, 132);
            listBox1.MultiColumn = true;
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(222, 276);
            listBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(61, 103);
            dateTimePicker1.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(222, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // cmb_igrejas
            // 
            cmb_igrejas.FormattingEnabled = true;
            cmb_igrejas.Location = new Point(61, 57);
            cmb_igrejas.Name = "cmb_igrejas";
            cmb_igrejas.Size = new Size(222, 23);
            cmb_igrejas.TabIndex = 6;
            cmb_igrejas.SelectedIndexChanged += cmb_igrejas_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 39);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Igreja:";
            // 
            // btn_AddIgreja
            // 
            btn_AddIgreja.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddIgreja.Location = new Point(289, 56);
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
            dgv_missas.Columns.AddRange(new DataGridViewColumn[] { coluna1, coluna2, coluna3, coluna4 });
            dgv_missas.Location = new Point(402, 56);
            dgv_missas.Name = "dgv_missas";
            dgv_missas.ReadOnly = true;
            dgv_missas.Size = new Size(288, 397);
            dgv_missas.TabIndex = 9;
            dgv_missas.CellClick += dgv_missas_CellClick;
            dgv_missas.CellContentClick += dgv_missas_CellContentClick;
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
            // btn_recarregarIgrejas
            // 
            btn_recarregarIgrejas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_recarregarIgrejas.Location = new Point(318, 56);
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
            btn_editar.Location = new Point(615, 24);
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
            btn_excluir.Location = new Point(534, 24);
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Size = new Size(75, 26);
            btn_excluir.TabIndex = 12;
            btn_excluir.Text = "Excluir";
            btn_excluir.UseVisualStyleBackColor = true;
            btn_excluir.Click += btn_excluir_Click;
            // 
            // Missas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
        private DataGridViewTextBoxColumn coluna1;
        private DataGridViewTextBoxColumn coluna2;
        private DataGridViewTextBoxColumn coluna3;
        private DataGridViewTextBoxColumn coluna4;
    }
}
