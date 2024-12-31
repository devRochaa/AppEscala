namespace AppEscala
{
    partial class UserControl2
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
            label1 = new Label();
            txtNome = new TextBox();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            check_semana = new CheckBox();
            check_fimDsmn = new CheckBox();
            listView1 = new ListView();
            button1 = new Button();
            label3 = new Label();
            button2 = new Button();
            ribbonButtonCenter1 = new ReaLTaiizor.Controls.RibbonButtonCenter();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(269, 11);
            label1.Name = "label1";
            label1.Size = new Size(154, 21);
            label1.TabIndex = 0;
            label1.Text = "Adicionar Acólitos:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(208, 53);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(345, 23);
            txtNome.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 56);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Nome:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(353, 104);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2024, 12, 21, 19, 29, 52, 0);
            // 
            // check_semana
            // 
            check_semana.AutoSize = true;
            check_semana.Location = new Point(148, 98);
            check_semana.Name = "check_semana";
            check_semana.Size = new Size(184, 19);
            check_semana.TabIndex = 8;
            check_semana.Text = "Pode servir durante a semana.";
            check_semana.UseVisualStyleBackColor = true;
            check_semana.CheckedChanged += check_semana_CheckedChanged;
            // 
            // check_fimDsmn
            // 
            check_fimDsmn.AutoSize = true;
            check_fimDsmn.Location = new Point(148, 123);
            check_fimDsmn.Name = "check_fimDsmn";
            check_fimDsmn.Size = new Size(190, 19);
            check_fimDsmn.TabIndex = 9;
            check_fimDsmn.Text = "Pode servir no final de semana.";
            check_fimDsmn.UseVisualStyleBackColor = true;
            check_fimDsmn.CheckedChanged += check_fimDsmn_CheckedChanged;
            // 
            // listView1
            // 
            listView1.Location = new Point(353, 133);
            listView1.Name = "listView1";
            listView1.Size = new Size(200, 97);
            listView1.TabIndex = 10;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(478, 236);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(354, 84);
            label3.Name = "label3";
            label3.Size = new Size(199, 17);
            label3.TabIndex = 12;
            label3.Text = "Dias específicos que não pode:";
            // 
            // button2
            // 
            button2.Location = new Point(286, 266);
            button2.Name = "button2";
            button2.Size = new Size(137, 41);
            button2.TabIndex = 13;
            button2.Text = "Adicionar Acólito";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ribbonButtonCenter1
            // 
            ribbonButtonCenter1.BackColor = Color.Transparent;
            ribbonButtonCenter1.BaseColorA = Color.FromArgb(214, 162, 68);
            ribbonButtonCenter1.BaseColorB = Color.FromArgb(199, 147, 53);
            ribbonButtonCenter1.BorderColorA = Color.FromArgb(142, 107, 46);
            ribbonButtonCenter1.BorderColorB = Color.FromArgb(75, 255, 255, 255);
            ribbonButtonCenter1.DownBaseColorA = Color.FromArgb(214, 162, 68);
            ribbonButtonCenter1.DownBaseColorB = Color.FromArgb(199, 147, 53);
            ribbonButtonCenter1.DownBorderColorA = Color.FromArgb(142, 107, 46);
            ribbonButtonCenter1.DownBorderColorB = Color.FromArgb(75, 255, 255, 255);
            ribbonButtonCenter1.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            ribbonButtonCenter1.ForeColor = Color.Black;
            ribbonButtonCenter1.HoverBaseColorA = Color.FromArgb(204, 152, 58);
            ribbonButtonCenter1.HoverBaseColorB = Color.FromArgb(205, 153, 59);
            ribbonButtonCenter1.HoverBorderColorA = Color.FromArgb(142, 107, 46);
            ribbonButtonCenter1.HoverBorderColorB = Color.FromArgb(75, 255, 255, 255);
            ribbonButtonCenter1.Location = new Point(531, 321);
            ribbonButtonCenter1.Name = "ribbonButtonCenter1";
            ribbonButtonCenter1.Size = new Size(140, 40);
            ribbonButtonCenter1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ribbonButtonCenter1.TabIndex = 14;
            ribbonButtonCenter1.Text = "ribbonButtonCenter1";
            ribbonButtonCenter1.Click += ribbonButtonCenter1_Click;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ribbonButtonCenter1);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(check_fimDsmn);
            Controls.Add(check_semana);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Name = "UserControl2";
            Size = new Size(746, 472);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private CheckBox check_semana;
        private CheckBox check_fimDsmn;
        private ListView listView1;
        private Button button1;
        private Label label3;
        private Button button2;
        private ReaLTaiizor.Controls.RibbonButtonCenter ribbonButtonCenter1;
    }
}
