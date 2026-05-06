namespace AppEscala
{
    partial class form_smn
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
            panel3 = new Panel();
            check_tds = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            ou = new Label();
            panel_ter = new Panel();
            Tuesday_Night = new CheckBox();
            label1 = new Label();
            Tuesday_Afternoon = new CheckBox();
            Tuesday_Morning = new CheckBox();
            panel_qua = new Panel();
            Wednesday_Night = new CheckBox();
            label2 = new Label();
            Wednesday_Afternoon = new CheckBox();
            Wednesday_Morning = new CheckBox();
            airButton1 = new ReaLTaiizor.Controls.AirButton();
            panel_sex = new Panel();
            Friday_Night = new CheckBox();
            Friday_Afternoon = new CheckBox();
            label7 = new Label();
            Friday_Morning = new CheckBox();
            panel_seg = new Panel();
            Monday_Night = new CheckBox();
            label8 = new Label();
            Monday_Afternoon = new CheckBox();
            Monday_Morning = new CheckBox();
            Thursday_Morning = new CheckBox();
            Thursday_Afternoon = new CheckBox();
            label6 = new Label();
            Thursday_Night = new CheckBox();
            panel_qui = new Panel();
            panel_days = new Panel();
            panel3.SuspendLayout();
            panel_ter.SuspendLayout();
            panel_qua.SuspendLayout();
            panel_sex.SuspendLayout();
            panel_seg.SuspendLayout();
            panel_qui.SuspendLayout();
            panel_days.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(check_tds);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(240, 219);
            panel3.Name = "panel3";
            panel3.Size = new Size(245, 119);
            panel3.TabIndex = 24;
            // 
            // check_tds
            // 
            check_tds.AutoSize = true;
            check_tds.Location = new Point(89, 87);
            check_tds.Name = "check_tds";
            check_tds.Size = new Size(53, 19);
            check_tds.TabIndex = 34;
            check_tds.Text = "Pode";
            check_tds.UseVisualStyleBackColor = true;
            check_tds.CheckedChanged += check_tds_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(68, 41);
            label4.Name = "label4";
            label4.Size = new Size(111, 17);
            label4.TabIndex = 17;
            label4.Text = "a semana inteiro";
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
            // ou
            // 
            ou.AutoSize = true;
            ou.Location = new Point(350, 188);
            ou.Name = "ou";
            ou.Size = new Size(21, 15);
            ou.TabIndex = 23;
            ou.Text = "ou";
            // 
            // panel_ter
            // 
            panel_ter.BorderStyle = BorderStyle.FixedSingle;
            panel_ter.Controls.Add(Tuesday_Night);
            panel_ter.Controls.Add(label1);
            panel_ter.Controls.Add(Tuesday_Afternoon);
            panel_ter.Controls.Add(Tuesday_Morning);
            panel_ter.Location = new Point(143, 37);
            panel_ter.Name = "panel_ter";
            panel_ter.Size = new Size(124, 157);
            panel_ter.TabIndex = 22;
            // 
            // Tuesday_Night
            // 
            Tuesday_Night.AutoSize = true;
            Tuesday_Night.Location = new Point(35, 101);
            Tuesday_Night.Name = "Tuesday_Night";
            Tuesday_Night.Size = new Size(55, 19);
            Tuesday_Night.TabIndex = 30;
            Tuesday_Night.Text = "Noite";
            Tuesday_Night.UseVisualStyleBackColor = true;
            Tuesday_Night.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 23);
            label1.Name = "label1";
            label1.Size = new Size(50, 21);
            label1.TabIndex = 13;
            label1.Text = "Terça";
            // 
            // Tuesday_Afternoon
            // 
            Tuesday_Afternoon.AutoSize = true;
            Tuesday_Afternoon.Location = new Point(35, 84);
            Tuesday_Afternoon.Name = "Tuesday_Afternoon";
            Tuesday_Afternoon.Size = new Size(55, 19);
            Tuesday_Afternoon.TabIndex = 29;
            Tuesday_Afternoon.Text = "Tarde";
            Tuesday_Afternoon.UseVisualStyleBackColor = true;
            Tuesday_Afternoon.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Tuesday_Morning
            // 
            Tuesday_Morning.AutoSize = true;
            Tuesday_Morning.Location = new Point(35, 67);
            Tuesday_Morning.Name = "Tuesday_Morning";
            Tuesday_Morning.Size = new Size(63, 19);
            Tuesday_Morning.TabIndex = 28;
            Tuesday_Morning.Text = "Manhã";
            Tuesday_Morning.UseVisualStyleBackColor = true;
            Tuesday_Morning.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // panel_qua
            // 
            panel_qua.BorderStyle = BorderStyle.FixedSingle;
            panel_qua.Controls.Add(Wednesday_Night);
            panel_qua.Controls.Add(label2);
            panel_qua.Controls.Add(Wednesday_Afternoon);
            panel_qua.Controls.Add(Wednesday_Morning);
            panel_qua.Location = new Point(285, 37);
            panel_qua.Name = "panel_qua";
            panel_qua.Size = new Size(124, 157);
            panel_qua.TabIndex = 21;
            // 
            // Wednesday_Night
            // 
            Wednesday_Night.AutoSize = true;
            Wednesday_Night.Location = new Point(34, 101);
            Wednesday_Night.Name = "Wednesday_Night";
            Wednesday_Night.Size = new Size(55, 19);
            Wednesday_Night.TabIndex = 33;
            Wednesday_Night.Text = "Noite";
            Wednesday_Night.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 23);
            label2.Name = "label2";
            label2.Size = new Size(62, 21);
            label2.TabIndex = 13;
            label2.Text = "Quarta";
            // 
            // Wednesday_Afternoon
            // 
            Wednesday_Afternoon.AutoSize = true;
            Wednesday_Afternoon.Location = new Point(34, 84);
            Wednesday_Afternoon.Name = "Wednesday_Afternoon";
            Wednesday_Afternoon.Size = new Size(55, 19);
            Wednesday_Afternoon.TabIndex = 32;
            Wednesday_Afternoon.Text = "Tarde";
            Wednesday_Afternoon.UseVisualStyleBackColor = true;
            Wednesday_Afternoon.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Wednesday_Morning
            // 
            Wednesday_Morning.AutoSize = true;
            Wednesday_Morning.Location = new Point(34, 67);
            Wednesday_Morning.Name = "Wednesday_Morning";
            Wednesday_Morning.Size = new Size(63, 19);
            Wednesday_Morning.TabIndex = 31;
            Wednesday_Morning.Text = "Manhã";
            Wednesday_Morning.UseVisualStyleBackColor = true;
            Wednesday_Morning.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // airButton1
            // 
            airButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            airButton1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            airButton1.Image = null;
            airButton1.Location = new Point(308, 354);
            airButton1.Name = "airButton1";
            airButton1.NoRounding = false;
            airButton1.Size = new Size(100, 45);
            airButton1.TabIndex = 20;
            airButton1.Text = "Enviar";
            airButton1.Transparent = false;
            airButton1.Click += airButton1_Click;
            // 
            // panel_sex
            // 
            panel_sex.BorderStyle = BorderStyle.FixedSingle;
            panel_sex.Controls.Add(Friday_Night);
            panel_sex.Controls.Add(Friday_Afternoon);
            panel_sex.Controls.Add(label7);
            panel_sex.Controls.Add(Friday_Morning);
            panel_sex.Location = new Point(573, 37);
            panel_sex.Name = "panel_sex";
            panel_sex.Size = new Size(124, 157);
            panel_sex.TabIndex = 23;
            // 
            // Friday_Night
            // 
            Friday_Night.AutoSize = true;
            Friday_Night.Location = new Point(33, 101);
            Friday_Night.Name = "Friday_Night";
            Friday_Night.Size = new Size(55, 19);
            Friday_Night.TabIndex = 30;
            Friday_Night.Text = "Noite";
            Friday_Night.UseVisualStyleBackColor = true;
            Friday_Night.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Friday_Afternoon
            // 
            Friday_Afternoon.AutoSize = true;
            Friday_Afternoon.Location = new Point(33, 84);
            Friday_Afternoon.Name = "Friday_Afternoon";
            Friday_Afternoon.Size = new Size(55, 19);
            Friday_Afternoon.TabIndex = 29;
            Friday_Afternoon.Text = "Tarde";
            Friday_Afternoon.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(35, 23);
            label7.Name = "label7";
            label7.Size = new Size(52, 21);
            label7.TabIndex = 13;
            label7.Text = "Sexta";
            // 
            // Friday_Morning
            // 
            Friday_Morning.AutoSize = true;
            Friday_Morning.Location = new Point(33, 67);
            Friday_Morning.Name = "Friday_Morning";
            Friday_Morning.Size = new Size(63, 19);
            Friday_Morning.TabIndex = 28;
            Friday_Morning.Text = "Manhã";
            Friday_Morning.UseVisualStyleBackColor = true;
            Friday_Morning.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // panel_seg
            // 
            panel_seg.BorderStyle = BorderStyle.FixedSingle;
            panel_seg.Controls.Add(Monday_Night);
            panel_seg.Controls.Add(label8);
            panel_seg.Controls.Add(Monday_Afternoon);
            panel_seg.Controls.Add(Monday_Morning);
            panel_seg.Location = new Point(3, 37);
            panel_seg.Name = "panel_seg";
            panel_seg.Size = new Size(124, 157);
            panel_seg.TabIndex = 23;
            // 
            // Monday_Night
            // 
            Monday_Night.AutoSize = true;
            Monday_Night.Location = new Point(30, 101);
            Monday_Night.Name = "Monday_Night";
            Monday_Night.Size = new Size(55, 19);
            Monday_Night.TabIndex = 27;
            Monday_Night.Text = "Noite";
            Monday_Night.UseVisualStyleBackColor = true;
            Monday_Night.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(27, 23);
            label8.Name = "label8";
            label8.Size = new Size(77, 21);
            label8.TabIndex = 13;
            label8.Text = "Segunda";
            // 
            // Monday_Afternoon
            // 
            Monday_Afternoon.AutoSize = true;
            Monday_Afternoon.Location = new Point(30, 84);
            Monday_Afternoon.Name = "Monday_Afternoon";
            Monday_Afternoon.Size = new Size(55, 19);
            Monday_Afternoon.TabIndex = 26;
            Monday_Afternoon.Text = "Tarde";
            Monday_Afternoon.UseVisualStyleBackColor = true;
            Monday_Afternoon.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Monday_Morning
            // 
            Monday_Morning.AutoSize = true;
            Monday_Morning.Location = new Point(30, 67);
            Monday_Morning.Name = "Monday_Morning";
            Monday_Morning.Size = new Size(63, 19);
            Monday_Morning.TabIndex = 25;
            Monday_Morning.Text = "Manhã";
            Monday_Morning.UseVisualStyleBackColor = true;
            Monday_Morning.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Thursday_Morning
            // 
            Thursday_Morning.AutoSize = true;
            Thursday_Morning.Location = new Point(27, 67);
            Thursday_Morning.Name = "Thursday_Morning";
            Thursday_Morning.Size = new Size(63, 19);
            Thursday_Morning.TabIndex = 34;
            Thursday_Morning.Text = "Manhã";
            Thursday_Morning.UseVisualStyleBackColor = true;
            Thursday_Morning.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // Thursday_Afternoon
            // 
            Thursday_Afternoon.AutoSize = true;
            Thursday_Afternoon.Location = new Point(27, 84);
            Thursday_Afternoon.Name = "Thursday_Afternoon";
            Thursday_Afternoon.Size = new Size(55, 19);
            Thursday_Afternoon.TabIndex = 35;
            Thursday_Afternoon.Text = "Tarde";
            Thursday_Afternoon.UseVisualStyleBackColor = true;
            Thursday_Afternoon.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(27, 23);
            label6.Name = "label6";
            label6.Size = new Size(62, 21);
            label6.TabIndex = 13;
            label6.Text = "Quinta";
            // 
            // Thursday_Night
            // 
            Thursday_Night.AutoSize = true;
            Thursday_Night.Location = new Point(27, 101);
            Thursday_Night.Name = "Thursday_Night";
            Thursday_Night.Size = new Size(55, 19);
            Thursday_Night.TabIndex = 36;
            Thursday_Night.Text = "Noite";
            Thursday_Night.UseVisualStyleBackColor = true;
            Thursday_Night.CheckedChanged += CheckTurno_CheckedChanged;
            // 
            // panel_qui
            // 
            panel_qui.BorderStyle = BorderStyle.FixedSingle;
            panel_qui.Controls.Add(Thursday_Night);
            panel_qui.Controls.Add(label6);
            panel_qui.Controls.Add(Thursday_Afternoon);
            panel_qui.Controls.Add(Thursday_Morning);
            panel_qui.Location = new Point(431, 37);
            panel_qui.Name = "panel_qui";
            panel_qui.Size = new Size(124, 157);
            panel_qui.TabIndex = 24;
            // 
            // panel_days
            // 
            panel_days.Controls.Add(panel_seg);
            panel_days.Controls.Add(panel_qui);
            panel_days.Controls.Add(panel_qua);
            panel_days.Controls.Add(panel_sex);
            panel_days.Controls.Add(panel_ter);
            panel_days.Location = new Point(5, 12);
            panel_days.Name = "panel_days";
            panel_days.Size = new Size(710, 201);
            panel_days.TabIndex = 25;
            // 
            // form_smn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 450);
            Controls.Add(panel_days);
            Controls.Add(panel3);
            Controls.Add(ou);
            Controls.Add(airButton1);
            Name = "form_smn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "form_smn";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel_ter.ResumeLayout(false);
            panel_ter.PerformLayout();
            panel_qua.ResumeLayout(false);
            panel_qua.PerformLayout();
            panel_sex.ResumeLayout(false);
            panel_sex.PerformLayout();
            panel_seg.ResumeLayout(false);
            panel_seg.PerformLayout();
            panel_qui.ResumeLayout(false);
            panel_qui.PerformLayout();
            panel_days.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label ou;
        private Panel panel_ter;
        private Label label1;
        private Panel panel_qua;
        private Label label2;
        private ReaLTaiizor.Controls.AirButton airButton1;
        private Panel panel_sex;
        private Label label7;
        private Panel panel_seg;
        private Label label8;
        private CheckBox Monday_Night;
        private CheckBox Monday_Afternoon;
        private CheckBox Monday_Morning;
        private CheckBox Tuesday_Night;
        private CheckBox Tuesday_Afternoon;
        private CheckBox Tuesday_Morning;
        private CheckBox Wednesday_Night;
        private CheckBox Wednesday_Afternoon;
        private CheckBox Wednesday_Morning;
        private CheckBox Friday_Night;
        private CheckBox Friday_Afternoon;
        private CheckBox Friday_Morning;
        private CheckBox check_tds;
        private CheckBox Thursday_Morning;
        private CheckBox Thursday_Afternoon;
        private Label label6;
        private CheckBox Thursday_Night;
        private Panel panel_qui;
        private Panel panel_days;
    }
}