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
            check_domN = new CheckBox();
            label2 = new Label();
            check_domT = new CheckBox();
            check_domM = new CheckBox();
            panel_sab = new Panel();
            check_sabN = new CheckBox();
            check_sabT = new CheckBox();
            check_sabM = new CheckBox();
            label1 = new Label();
            ou = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            check_tds = new CheckBox();
            panel_dom.SuspendLayout();
            panel_sab.SuspendLayout();
            panel3.SuspendLayout();
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
            panel_dom.Controls.Add(check_domN);
            panel_dom.Controls.Add(label2);
            panel_dom.Controls.Add(check_domT);
            panel_dom.Controls.Add(check_domM);
            panel_dom.Location = new Point(153, 22);
            panel_dom.Name = "panel_dom";
            panel_dom.Size = new Size(124, 157);
            panel_dom.TabIndex = 12;
            // 
            // check_domN
            // 
            check_domN.AutoSize = true;
            check_domN.Location = new Point(32, 99);
            check_domN.Name = "check_domN";
            check_domN.Size = new Size(55, 19);
            check_domN.TabIndex = 19;
            check_domN.Text = "Noite";
            check_domN.UseVisualStyleBackColor = true;
            check_domN.CheckedChanged += check_domN_CheckedChanged;
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
            label2.Click += label2_Click;
            // 
            // check_domT
            // 
            check_domT.AutoSize = true;
            check_domT.Location = new Point(32, 82);
            check_domT.Name = "check_domT";
            check_domT.Size = new Size(54, 19);
            check_domT.TabIndex = 18;
            check_domT.Text = "Tarde";
            check_domT.UseVisualStyleBackColor = true;
            check_domT.CheckedChanged += check_domT_CheckedChanged;
            // 
            // check_domM
            // 
            check_domM.AutoSize = true;
            check_domM.Location = new Point(32, 65);
            check_domM.Name = "check_domM";
            check_domM.Size = new Size(63, 19);
            check_domM.TabIndex = 17;
            check_domM.Text = "Manhã";
            check_domM.UseVisualStyleBackColor = true;
            check_domM.CheckedChanged += check_domM_CheckedChanged;
            // 
            // panel_sab
            // 
            panel_sab.BorderStyle = BorderStyle.FixedSingle;
            panel_sab.Controls.Add(check_sabN);
            panel_sab.Controls.Add(check_sabT);
            panel_sab.Controls.Add(check_sabM);
            panel_sab.Controls.Add(label1);
            panel_sab.Location = new Point(11, 22);
            panel_sab.Name = "panel_sab";
            panel_sab.Size = new Size(124, 157);
            panel_sab.TabIndex = 14;
            // 
            // check_sabN
            // 
            check_sabN.AutoSize = true;
            check_sabN.Location = new Point(34, 99);
            check_sabN.Name = "check_sabN";
            check_sabN.Size = new Size(55, 19);
            check_sabN.TabIndex = 16;
            check_sabN.Text = "Noite";
            check_sabN.UseVisualStyleBackColor = true;
            check_sabN.CheckedChanged += check_sabN_CheckedChanged;
            // 
            // check_sabT
            // 
            check_sabT.AutoSize = true;
            check_sabT.Location = new Point(34, 82);
            check_sabT.Name = "check_sabT";
            check_sabT.Size = new Size(54, 19);
            check_sabT.TabIndex = 15;
            check_sabT.Text = "Tarde";
            check_sabT.UseVisualStyleBackColor = true;
            check_sabT.CheckedChanged += check_sabT_CheckedChanged;
            // 
            // check_sabM
            // 
            check_sabM.AutoSize = true;
            check_sabM.Location = new Point(34, 65);
            check_sabM.Name = "check_sabM";
            check_sabM.Size = new Size(63, 19);
            check_sabM.TabIndex = 14;
            check_sabM.Text = "Manhã";
            check_sabM.UseVisualStyleBackColor = true;
            check_sabM.CheckedChanged += check_sabM_CheckedChanged;
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
            // form_fimDsmn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 290);
            Controls.Add(panel3);
            Controls.Add(ou);
            Controls.Add(panel_sab);
            Controls.Add(panel_dom);
            Controls.Add(airButton1);
            Name = "form_fimDsmn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            panel_dom.ResumeLayout(false);
            panel_dom.PerformLayout();
            panel_sab.ResumeLayout(false);
            panel_sab.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private CheckBox check_sabN;
        private CheckBox check_sabT;
        private CheckBox check_sabM;
        private CheckBox check_domN;
        private CheckBox check_domT;
        private CheckBox check_domM;
        private CheckBox check_tds;
    }
}