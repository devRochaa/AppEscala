namespace AppEscala
{
    partial class form_fimDsmn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            airButton1 = new ReaLTaiizor.Controls.AirButton();
            panel_dom = new Panel();
            Sunday_Night = new CheckBox();
            label2 = new Label();
            Sunday_Afternoon = new CheckBox();
            Sunday_Morning = new CheckBox();
            panel_sab = new Panel();
            Saturday_Night = new CheckBox();
            Saturday_Afternoon = new CheckBox();
            Saturday_Morning = new CheckBox();
            label1 = new Label();
            ou = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            check_tds = new CheckBox();
            panel_days = new Panel();
            panel_dom.SuspendLayout();
            panel_sab.SuspendLayout();
            panel3.SuspendLayout();
            panel_days.SuspendLayout();
            SuspendLayout();
            // 
            // airButton1
            // 
            airButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            airButton1.Font = new Font("Segoe UI", 9F);
            airButton1.Image = null;
            airButton1.Location = new Point(243, 204);
            airButton1.Name = "airButton1";
            airButton1.NoRounding = false;
            airButton1.Size = new Size(100, 45);
            airButton1.TabIndex = 11;
            airButton1.Text = "Enviar";
            airButton1.Transparent = false;
            airButton1.Click += airButton1_Click;
            // 
            // panel_dom
            // 
            panel_dom.BorderStyle = BorderStyle.FixedSingle;
            panel_dom.Controls.Add(Sunday_Night);
            panel_dom.Controls.Add(label2);
            panel_dom.Controls.Add(Sunday_Afternoon);
            panel_dom.Controls.Add(Sunday_Morning);
            panel_dom.Location = new Point(145, 12);
            panel_dom.Name = "panel_dom";
            panel_dom.Size = new Size(124, 157);
            panel_dom.TabIndex = 12;
            // 
            // Sunday_Night
            // 
            Sunday_Night.AutoSize = true;
            Sunday_Night.Location = new Point(32, 99);
            Sunday_Night.Name = "Sunday_Night";
            Sunday_Night.Size = new Size(55, 19);
            Sunday_Night.TabIndex = 19;
            Sunday_Night.Text = "Noite";
            Sunday_Night.UseVisualStyleBackColor = true;
            Sunday_Night.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 23);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 13;
            label2.Text = "Domingo";
            // 
            // Sunday_Afternoon
            // 
            Sunday_Afternoon.AutoSize = true;
            Sunday_Afternoon.Location = new Point(32, 82);
            Sunday_Afternoon.Name = "Sunday_Afternoon";
            Sunday_Afternoon.Size = new Size(55, 19);
            Sunday_Afternoon.TabIndex = 18;
            Sunday_Afternoon.Text = "Tarde";
            Sunday_Afternoon.UseVisualStyleBackColor = true;
            Sunday_Afternoon.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Sunday_Morning
            // 
            Sunday_Morning.AutoSize = true;
            Sunday_Morning.Location = new Point(32, 65);
            Sunday_Morning.Name = "Sunday_Morning";
            Sunday_Morning.Size = new Size(63, 19);
            Sunday_Morning.TabIndex = 17;
            Sunday_Morning.Text = "Manhã";
            Sunday_Morning.UseVisualStyleBackColor = true;
            Sunday_Morning.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // panel_sab
            // 
            panel_sab.BorderStyle = BorderStyle.FixedSingle;
            panel_sab.Controls.Add(Saturday_Night);
            panel_sab.Controls.Add(Saturday_Afternoon);
            panel_sab.Controls.Add(Saturday_Morning);
            panel_sab.Controls.Add(label1);
            panel_sab.Location = new Point(3, 12);
            panel_sab.Name = "panel_sab";
            panel_sab.Size = new Size(124, 157);
            panel_sab.TabIndex = 14;
            // 
            // Saturday_Night
            // 
            Saturday_Night.AutoSize = true;
            Saturday_Night.Location = new Point(34, 99);
            Saturday_Night.Name = "Saturday_Night";
            Saturday_Night.Size = new Size(55, 19);
            Saturday_Night.TabIndex = 16;
            Saturday_Night.Text = "Noite";
            Saturday_Night.UseVisualStyleBackColor = true;
            Saturday_Night.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Saturday_Afternoon
            // 
            Saturday_Afternoon.AutoSize = true;
            Saturday_Afternoon.Location = new Point(34, 82);
            Saturday_Afternoon.Name = "Saturday_Afternoon";
            Saturday_Afternoon.Size = new Size(55, 19);
            Saturday_Afternoon.TabIndex = 15;
            Saturday_Afternoon.Text = "Tarde";
            Saturday_Afternoon.UseVisualStyleBackColor = true;
            Saturday_Afternoon.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Saturday_Morning
            // 
            Saturday_Morning.AutoSize = true;
            Saturday_Morning.Location = new Point(34, 65);
            Saturday_Morning.Name = "Saturday_Morning";
            Saturday_Morning.Size = new Size(63, 19);
            Saturday_Morning.TabIndex = 14;
            Saturday_Morning.Text = "Manhã";
            Saturday_Morning.UseVisualStyleBackColor = true;
            Saturday_Morning.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 23);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 13;
            label1.Text = "Sábado";
            // 
            // ou
            // 
            ou.AutoSize = true;
            ou.Location = new Point(306, 92);
            ou.Name = "ou";
            ou.Size = new Size(21, 15);
            ou.TabIndex = 15;
            ou.Text = "ou";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 24);
            label3.Name = "label3";
            label3.Size = new Size(232, 17);
            label3.TabIndex = 16;
            label3.Text = "Marque caso o  acólitos possa servir";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(41, 41);
            label4.Name = "label4";
            label4.Size = new Size(163, 17);
            label4.TabIndex = 17;
            label4.Text = "o final de semana inteiro";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(50, 58);
            label5.Name = "label5";
            label5.Size = new Size(147, 17);
            label5.TabIndex = 18;
            label5.Text = "(manhã, tarde e noite)";
            // 
            // panel3
            // 
            panel3.Controls.Add(check_tds);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(343, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(245, 157);
            panel3.TabIndex = 19;
            // 
            // check_tds
            // 
            check_tds.AutoSize = true;
            check_tds.Location = new Point(95, 83);
            check_tds.Name = "check_tds";
            check_tds.Size = new Size(53, 19);
            check_tds.TabIndex = 20;
            check_tds.Text = "Pode";
            check_tds.UseVisualStyleBackColor = true;
            check_tds.CheckedChanged += check_tds_CheckedChanged;
            // 
            // panel_days
            // 
            panel_days.Controls.Add(panel_sab);
            panel_days.Controls.Add(panel_dom);
            panel_days.Location = new Point(12, 22);
            panel_days.Name = "panel_days";
            panel_days.Size = new Size(276, 176);
            panel_days.TabIndex = 20;
            // 
            // form_fimDsmn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 290);
            Controls.Add(panel_days);
            Controls.Add(panel3);
            Controls.Add(ou);
            Controls.Add(airButton1);
            Name = "form_fimDsmn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            panel_dom.ResumeLayout(false);
            panel_dom.PerformLayout();
            panel_sab.ResumeLayout(false);
            panel_sab.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel_days.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ReaLTaiizor.Controls.AirButton airButton1;
        private Panel panel_dom;
        private Label label2;
        private Panel panel_sab;
        private Label label1;
        private Label ou;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel3;
        private CheckBox Saturday_Night;
        private CheckBox Saturday_Afternoon;
        private CheckBox Saturday_Morning;
        private CheckBox Sunday_Night;
        private CheckBox Sunday_Afternoon;
        private CheckBox Sunday_Morning;
        private CheckBox check_tds;
        private Panel panel_days;
    }
}