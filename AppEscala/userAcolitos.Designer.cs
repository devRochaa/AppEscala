namespace AppEscala
{
    partial class userAcolitos
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
            lst_acolitos = new ListView();
            label1 = new Label();
            txtPesquisa = new TextBox();
            label2 = new Label();
            btn_buscar = new Button();
            SuspendLayout();
            // 
            // lst_acolitos
            // 
            lst_acolitos.Location = new Point(48, 84);
            lst_acolitos.Name = "lst_acolitos";
            lst_acolitos.Size = new Size(646, 197);
            lst_acolitos.TabIndex = 0;
            lst_acolitos.UseCompatibleStateImageBehavior = false;
            lst_acolitos.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 17);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 1;
            label1.Text = "Acólitos:";
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(166, 54);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(385, 23);
            txtPesquisa.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 57);
            label2.Name = "label2";
            label2.Size = new Size(115, 17);
            label2.TabIndex = 3;
            label2.Text = "Pesquisar Acólito:";
            // 
            // btn_buscar
            // 
            btn_buscar.Location = new Point(557, 54);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(78, 24);
            btn_buscar.TabIndex = 4;
            btn_buscar.Text = "Buscar";
            btn_buscar.UseVisualStyleBackColor = true;
            btn_buscar.Click += btn_buscar_Click;
            // 
            // acolitos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_buscar);
            Controls.Add(label2);
            Controls.Add(txtPesquisa);
            Controls.Add(label1);
            Controls.Add(lst_acolitos);
            Name = "acolitos";
            Size = new Size(746, 472);
            Load += acolitos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lst_acolitos;
        private Label label1;
        private TextBox txtPesquisa;
        private Label label2;
        private Button btn_buscar;
    }
}
