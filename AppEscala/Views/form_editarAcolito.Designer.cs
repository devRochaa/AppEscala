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
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txt_qua = new TextBox();
            txt_ter = new TextBox();
            txt_seg = new TextBox();
            label3 = new Label();
            listView1 = new ListView();
            textBox1 = new TextBox();
            txt_qui = new TextBox();
            txt_sex = new TextBox();
            txt_sab = new TextBox();
            txt_dom = new TextBox();
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(322, 183);
            label10.Name = "label10";
            label10.Size = new Size(67, 17);
            label10.TabIndex = 69;
            label10.Text = "Domingo:";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(333, 154);
            label9.Name = "label9";
            label9.Size = new Size(56, 17);
            label9.TabIndex = 68;
            label9.Text = "Sábado:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(338, 126);
            label8.Name = "label8";
            label8.Size = new Size(44, 17);
            label8.TabIndex = 67;
            label8.Text = "Sexta:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(333, 98);
            label7.Name = "label7";
            label7.Size = new Size(49, 17);
            label7.TabIndex = 66;
            label7.Text = "Quinta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(60, 155);
            label6.Name = "label6";
            label6.Size = new Size(50, 17);
            label6.TabIndex = 65;
            label6.Text = "Quarta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(64, 125);
            label5.Name = "label5";
            label5.Size = new Size(42, 17);
            label5.TabIndex = 64;
            label5.Text = "Terça:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(47, 93);
            label4.Name = "label4";
            label4.Size = new Size(64, 17);
            label4.TabIndex = 63;
            label4.Text = "Segunda:";
            // 
            // txt_qua
            // 
            txt_qua.Location = new Point(112, 152);
            txt_qua.Name = "txt_qua";
            txt_qua.Size = new Size(202, 23);
            txt_qua.TabIndex = 56;
            // 
            // txt_ter
            // 
            txt_ter.Location = new Point(112, 123);
            txt_ter.Name = "txt_ter";
            txt_ter.Size = new Size(202, 23);
            txt_ter.TabIndex = 49;
            // 
            // txt_seg
            // 
            txt_seg.Location = new Point(112, 94);
            txt_seg.Name = "txt_seg";
            txt_seg.Size = new Size(202, 23);
            txt_seg.TabIndex = 42;
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
            // txt_qui
            // 
            txt_qui.Location = new Point(388, 98);
            txt_qui.Name = "txt_qui";
            txt_qui.Size = new Size(202, 23);
            txt_qui.TabIndex = 74;
            // 
            // txt_sex
            // 
            txt_sex.Location = new Point(388, 125);
            txt_sex.Name = "txt_sex";
            txt_sex.Size = new Size(202, 23);
            txt_sex.TabIndex = 75;
            // 
            // txt_sab
            // 
            txt_sab.Location = new Point(388, 153);
            txt_sab.Name = "txt_sab";
            txt_sab.Size = new Size(202, 23);
            txt_sab.TabIndex = 76;
            // 
            // txt_dom
            // 
            txt_dom.Location = new Point(388, 182);
            txt_dom.Name = "txt_dom";
            txt_dom.Size = new Size(202, 23);
            txt_dom.TabIndex = 77;
            // 
            // form_editarAcolito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 363);
            Controls.Add(txt_dom);
            Controls.Add(txt_sab);
            Controls.Add(txt_sex);
            Controls.Add(txt_qui);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Controls.Add(btn_salvar);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txt_qua);
            Controls.Add(txt_ter);
            Controls.Add(txt_seg);
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
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txt_qua;
        private TextBox txt_ter;
        private TextBox txt_seg;
        private TextBox txt_nome;
        private Label label3;
        private ListView listView1;
        private TextBox textBox1;
        private TextBox txt_qui;
        private TextBox txt_sex;
        private TextBox txt_sab;
        private TextBox txt_dom;
    }
}