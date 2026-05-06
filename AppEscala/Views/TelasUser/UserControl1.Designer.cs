namespace AppEscala
{
    partial class UserControl1
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
            skyLabel1 = new ReaLTaiizor.Controls.SkyLabel();
            button1 = new ReaLTaiizor.Controls.HopeRoundButton();
            cmb_diasSemana = new ComboBox();
            dgvEscala = new DataGridView();
            btnGerarPdf = new ReaLTaiizor.Controls.HopeRoundButton();
            btnAdicionarLinha = new Button();
            btnRemoverLinha = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEscala).BeginInit();
            SuspendLayout();
            // 
            // skyLabel1
            // 
            skyLabel1.AutoSize = true;
            skyLabel1.Font = new Font("Verdana", 6.75F, FontStyle.Bold);
            skyLabel1.ForeColor = Color.FromArgb(27, 94, 137);
            skyLabel1.Location = new Point(297, 66);
            skyLabel1.Name = "skyLabel1";
            skyLabel1.Size = new Size(41, 12);
            skyLabel1.TabIndex = 0;
            skyLabel1.Text = "teste 1";
            // 
            // button1
            // 
            button1.BorderColor = Color.FromArgb(220, 223, 230);
            button1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            button1.DangerColor = Color.FromArgb(245, 108, 108);
            button1.DefaultColor = Color.FromArgb(255, 255, 255);
            button1.Font = new Font("Segoe UI", 12F);
            button1.HoverTextColor = Color.FromArgb(48, 49, 51);
            button1.InfoColor = Color.FromArgb(144, 147, 153);
            button1.Location = new Point(222, 273);
            button1.Name = "button1";
            button1.PrimaryColor = Color.FromArgb(64, 158, 255);
            button1.Size = new Size(190, 40);
            button1.SuccessColor = Color.FromArgb(103, 194, 58);
            button1.TabIndex = 1;
            button1.Text = "Gerar Escala";
            button1.TextColor = Color.White;
            button1.WarningColor = Color.FromArgb(230, 162, 60);
            button1.Click += button1_Click;
            // 
            // btnGerarPdf
            // 
            btnGerarPdf.BorderColor = Color.FromArgb(220, 223, 230);
            btnGerarPdf.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnGerarPdf.DangerColor = Color.FromArgb(245, 108, 108);
            btnGerarPdf.DefaultColor = Color.FromArgb(255, 255, 255);
            btnGerarPdf.Font = new Font("Segoe UI", 12F);
            btnGerarPdf.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnGerarPdf.InfoColor = Color.FromArgb(144, 147, 153);
            btnGerarPdf.Location = new Point(418, 273);
            btnGerarPdf.Name = "btnGerarPdf";
            btnGerarPdf.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnGerarPdf.Size = new Size(190, 40);
            btnGerarPdf.SuccessColor = Color.FromArgb(103, 194, 58);
            btnGerarPdf.TabIndex = 3;
            btnGerarPdf.Text = "Gerar PDF";
            btnGerarPdf.TextColor = Color.White;
            btnGerarPdf.WarningColor = Color.FromArgb(230, 162, 60);
            btnGerarPdf.Click += btnGerarPdf_Click;
            // 
            // cmb_diasSemana
            // 
            cmb_diasSemana.FormattingEnabled = true;
            cmb_diasSemana.Location = new Point(253, 126);
            cmb_diasSemana.Name = "cmb_diasSemana";
            cmb_diasSemana.Size = new Size(121, 23);
            cmb_diasSemana.TabIndex = 2;
            // 
            // dgvEscala
            // 
            dgvEscala.AllowUserToAddRows = true;
            dgvEscala.AllowUserToDeleteRows = true;
            dgvEscala.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEscala.Location = new Point(32, 210);
            dgvEscala.Name = "dgvEscala";
            dgvEscala.Size = new Size(577, 140);
            dgvEscala.TabIndex = 4;
            dgvEscala.CellDoubleClick += dgvEscala_CellDoubleClick;
            // 
            // btnAdicionarLinha
            // 
            btnAdicionarLinha.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdicionarLinha.Location = new Point(32, 180);
            btnAdicionarLinha.Name = "btnAdicionarLinha";
            btnAdicionarLinha.Size = new Size(36, 30);
            btnAdicionarLinha.TabIndex = 5;
            btnAdicionarLinha.Text = "+";
            btnAdicionarLinha.UseVisualStyleBackColor = true;
            btnAdicionarLinha.Click += btnAdicionarLinha_Click;
            // 
            // btnRemoverLinha
            // 
            btnRemoverLinha.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRemoverLinha.Location = new Point(74, 180);
            btnRemoverLinha.Name = "btnRemoverLinha";
            btnRemoverLinha.Size = new Size(36, 30);
            btnRemoverLinha.TabIndex = 6;
            btnRemoverLinha.Text = "-";
            btnRemoverLinha.UseVisualStyleBackColor = true;
            btnRemoverLinha.Click += btnRemoverLinha_Click;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRemoverLinha);
            Controls.Add(btnAdicionarLinha);
            Controls.Add(dgvEscala);
            Controls.Add(btnGerarPdf);
            Controls.Add(cmb_diasSemana);
            Controls.Add(button1);
            Controls.Add(skyLabel1);
            Name = "UserControl1";
            Size = new Size(641, 383);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEscala).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.SkyLabel skyLabel1;
        private ReaLTaiizor.Controls.HopeRoundButton button1;
        private ComboBox cmb_diasSemana;
        private DataGridView dgvEscala;
        private ReaLTaiizor.Controls.HopeRoundButton btnGerarPdf;
        private Button btnAdicionarLinha;
        private Button btnRemoverLinha;
    }
}
