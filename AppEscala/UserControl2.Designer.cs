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
            textBox1 = new TextBox();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            radioButton1 = new RadioButton();
            radio_finalSmn = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(147, 16);
            label1.Name = "label1";
            label1.Size = new Size(154, 21);
            label1.TabIndex = 0;
            label1.Text = "Adicionar Acólitos:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(86, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(345, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 61);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Nome:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(243, 99);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(26, 99);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(183, 19);
            radioButton1.TabIndex = 6;
            radioButton1.TabStop = true;
            radioButton1.Text = "Pode servir durante a semana.";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radio_finalSmn
            // 
            radio_finalSmn.AutoSize = true;
            radio_finalSmn.Location = new Point(26, 124);
            radio_finalSmn.Name = "radio_finalSmn";
            radio_finalSmn.Size = new Size(189, 19);
            radio_finalSmn.TabIndex = 7;
            radio_finalSmn.TabStop = true;
            radio_finalSmn.Text = "Pode servir no final de semana.";
            radio_finalSmn.UseVisualStyleBackColor = true;
            radio_finalSmn.CheckedChanged += radio_finalSmn_CheckedChanged_1;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(radio_finalSmn);
            Controls.Add(radioButton1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "UserControl2";
            Size = new Size(468, 276);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private RadioButton radioButton1;
        private RadioButton radio_finalSmn;
    }
}
