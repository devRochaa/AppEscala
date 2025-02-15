namespace AppEscala.Views
{
    partial class form_editarAcolito
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
            txt_nome = new TextBox();
            label1 = new Label();
            btn_salvar = new Button();
            lbl_dia = new Label();
            label3 = new Label();
            listView1 = new ListView();
            textBox1 = new TextBox();
            cmb_dias = new ComboBox();
            label2 = new Label();
            cmb_turno1 = new ComboBox();
            cmb_turno2 = new ComboBox();
            cmb_turno3 = new ComboBox();
            SuspendLayout();
            // 
            // txt_nome
            // 
            txt_nome.Location = new Point(183, 50);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(290, 23);
            txt_nome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(298, 32);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome:";
            // 
            // btn_salvar
            // 
            btn_salvar.Location = new Point(320, 278);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(78, 24);
            btn_salvar.TabIndex = 70;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            // 
            // lbl_dia
            // 
            lbl_dia.AutoSize = true;
            lbl_dia.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_dia.Location = new Point(307, 115);
            lbl_dia.Name = "lbl_dia";
            lbl_dia.Size = new Size(30, 17);
            lbl_dia.TabIndex = 63;
            lbl_dia.Text = "Dia:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.75F, FontStyle.Bold);
            label3.Location = new Point(266, 9);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 40;
            label3.Text = "Editar Acólito:";
            // 
            // listView1
            // 
            listView1.Location = new Point(47, 183);
            listView1.Name = "listView1";
            listView1.Size = new Size(267, 168);
            listView1.TabIndex = 72;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(320, 249);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 23);
            textBox1.TabIndex = 73;
            // 
            // cmb_dias
            // 
            cmb_dias.FormattingEnabled = true;
            cmb_dias.Location = new Point(260, 89);
            cmb_dias.Name = "cmb_dias";
            cmb_dias.Size = new Size(131, 23);
            cmb_dias.TabIndex = 80;
            cmb_dias.SelectedIndexChanged += cmb_dias_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(155, 91);
            label2.Name = "label2";
            label2.Size = new Size(101, 17);
            label2.TabIndex = 81;
            label2.Text = "Selecione o dia:";
            // 
            // cmb_turno1
            // 
            cmb_turno1.FormattingEnabled = true;
            cmb_turno1.Location = new Point(209, 140);
            cmb_turno1.Name = "cmb_turno1";
            cmb_turno1.Size = new Size(76, 23);
            cmb_turno1.TabIndex = 82;
            cmb_turno1.TextUpdate += cmb_turno1_TextUpdate;
            // 
            // cmb_turno2
            // 
            cmb_turno2.FormattingEnabled = true;
            cmb_turno2.Location = new Point(288, 140);
            cmb_turno2.Name = "cmb_turno2";
            cmb_turno2.Size = new Size(76, 23);
            cmb_turno2.TabIndex = 83;
            // 
            // cmb_turno3
            // 
            cmb_turno3.FormattingEnabled = true;
            cmb_turno3.Location = new Point(367, 140);
            cmb_turno3.Name = "cmb_turno3";
            cmb_turno3.Size = new Size(76, 23);
            cmb_turno3.TabIndex = 84;
            // 
            // form_editarAcolito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 363);
            Controls.Add(cmb_turno3);
            Controls.Add(cmb_turno2);
            Controls.Add(cmb_turno1);
            Controls.Add(label2);
            Controls.Add(cmb_dias);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Controls.Add(btn_salvar);
            Controls.Add(lbl_dia);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txt_nome);
            Name = "form_editarAcolito";
            Text = "Editar Acólito";
            Load += form_editarAcolito_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btn_salvar;
        private Label lbl_dia;
        private TextBox txt_nome;
        private Label label3;
        private ListView listView1;
        private TextBox textBox1;
        private ComboBox cmb_dias;
        private Label label2;
        private ComboBox cmb_turno1;
        private ComboBox cmb_turno2;
        private ComboBox cmb_turno3;
    }
}