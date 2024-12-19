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
            SuspendLayout();
            // 
            // skyLabel1
            // 
            skyLabel1.AutoSize = true;
            skyLabel1.Font = new Font("Verdana", 6.75F, FontStyle.Bold);
            skyLabel1.ForeColor = Color.FromArgb(27, 94, 137);
            skyLabel1.Location = new Point(210, 92);
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
            button1.Location = new Point(142, 172);
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
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(skyLabel1);
            Name = "UserControl1";
            Size = new Size(459, 280);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.SkyLabel skyLabel1;
        private ReaLTaiizor.Controls.HopeRoundButton button1;
    }
}
