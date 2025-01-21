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
            label1 = new Label();
            txtPesquisa = new TextBox();
            label2 = new Label();
            btn_buscar = new Button();
            dgv_acolitos = new DataGridView();
            nome = new DataGridViewTextBoxColumn();
            segunda = new DataGridViewTextBoxColumn();
            terca = new DataGridViewTextBoxColumn();
            quarta = new DataGridViewTextBoxColumn();
            quinta = new DataGridViewTextBoxColumn();
            sexta = new DataGridViewTextBoxColumn();
            sabado = new DataGridViewTextBoxColumn();
            domingo = new DataGridViewTextBoxColumn();
            label3 = new Label();
            txt_nome = new TextBox();
            txt_seg = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            txt_seg2 = new TextBox();
            textBox16 = new TextBox();
            textBox17 = new TextBox();
            textBox18 = new TextBox();
            textBox19 = new TextBox();
            textBox20 = new TextBox();
            textBox21 = new TextBox();
            txt_seg3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_acolitos).BeginInit();
            SuspendLayout();
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
            // dgv_acolitos
            // 
            dgv_acolitos.AllowUserToAddRows = false;
            dgv_acolitos.AllowUserToDeleteRows = false;
            dgv_acolitos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_acolitos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_acolitos.Columns.AddRange(new DataGridViewColumn[] { nome, segunda, terca, quarta, quinta, sexta, sabado, domingo });
            dgv_acolitos.Location = new Point(48, 101);
            dgv_acolitos.MultiSelect = false;
            dgv_acolitos.Name = "dgv_acolitos";
            dgv_acolitos.ReadOnly = true;
            dgv_acolitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_acolitos.Size = new Size(646, 203);
            dgv_acolitos.TabIndex = 5;
            dgv_acolitos.CellContentClick += dgv_acolitos_CellContentClick;
            dgv_acolitos.SelectionChanged += dgv_acolitos_SelectionChanged;
            // 
            // nome
            // 
            nome.HeaderText = "Nome";
            nome.Name = "nome";
            nome.ReadOnly = true;
            nome.Width = 155;
            // 
            // segunda
            // 
            segunda.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            segunda.HeaderText = "Segunda";
            segunda.Name = "segunda";
            segunda.ReadOnly = true;
            // 
            // terca
            // 
            terca.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            terca.HeaderText = "Terça";
            terca.Name = "terca";
            terca.ReadOnly = true;
            // 
            // quarta
            // 
            quarta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quarta.HeaderText = "Quarta";
            quarta.Name = "quarta";
            quarta.ReadOnly = true;
            // 
            // quinta
            // 
            quinta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quinta.HeaderText = "Quinta";
            quinta.Name = "quinta";
            quinta.ReadOnly = true;
            // 
            // sexta
            // 
            sexta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sexta.HeaderText = "Sexta";
            sexta.Name = "sexta";
            sexta.ReadOnly = true;
            // 
            // sabado
            // 
            sabado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sabado.HeaderText = "Sábado";
            sabado.Name = "sabado";
            sabado.ReadOnly = true;
            // 
            // domingo
            // 
            domingo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            domingo.HeaderText = "Domingo";
            domingo.Name = "domingo";
            domingo.ReadOnly = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(48, 322);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 6;
            label3.Text = "Editar Acólito:";
            // 
            // txt_nome
            // 
            txt_nome.Location = new Point(48, 354);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(135, 23);
            txt_nome.TabIndex = 7;
            // 
            // txt_seg
            // 
            txt_seg.Location = new Point(196, 355);
            txt_seg.Name = "txt_seg";
            txt_seg.Size = new Size(66, 23);
            txt_seg.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(268, 355);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 23);
            textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(340, 355);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(66, 23);
            textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(412, 355);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(66, 23);
            textBox5.TabIndex = 11;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(484, 355);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(66, 23);
            textBox6.TabIndex = 12;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(556, 355);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(66, 23);
            textBox7.TabIndex = 13;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(628, 355);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(66, 23);
            textBox8.TabIndex = 14;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(628, 384);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(66, 23);
            textBox9.TabIndex = 21;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(556, 384);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(66, 23);
            textBox10.TabIndex = 20;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(484, 384);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(66, 23);
            textBox11.TabIndex = 19;
            // 
            // textBox12
            // 
            textBox12.Location = new Point(412, 384);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(66, 23);
            textBox12.TabIndex = 18;
            // 
            // textBox13
            // 
            textBox13.Location = new Point(340, 384);
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(66, 23);
            textBox13.TabIndex = 17;
            // 
            // textBox14
            // 
            textBox14.Location = new Point(268, 384);
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(66, 23);
            textBox14.TabIndex = 16;
            // 
            // txt_seg2
            // 
            txt_seg2.Location = new Point(196, 384);
            txt_seg2.Name = "txt_seg2";
            txt_seg2.Size = new Size(66, 23);
            txt_seg2.TabIndex = 15;
            // 
            // textBox16
            // 
            textBox16.Location = new Point(628, 413);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(66, 23);
            textBox16.TabIndex = 28;
            // 
            // textBox17
            // 
            textBox17.Location = new Point(556, 413);
            textBox17.Name = "textBox17";
            textBox17.Size = new Size(66, 23);
            textBox17.TabIndex = 27;
            // 
            // textBox18
            // 
            textBox18.Location = new Point(484, 413);
            textBox18.Name = "textBox18";
            textBox18.Size = new Size(66, 23);
            textBox18.TabIndex = 26;
            // 
            // textBox19
            // 
            textBox19.Location = new Point(412, 413);
            textBox19.Name = "textBox19";
            textBox19.Size = new Size(66, 23);
            textBox19.TabIndex = 25;
            // 
            // textBox20
            // 
            textBox20.Location = new Point(340, 413);
            textBox20.Name = "textBox20";
            textBox20.Size = new Size(66, 23);
            textBox20.TabIndex = 24;
            // 
            // textBox21
            // 
            textBox21.Location = new Point(268, 413);
            textBox21.Name = "textBox21";
            textBox21.Size = new Size(66, 23);
            textBox21.TabIndex = 23;
            // 
            // txt_seg3
            // 
            txt_seg3.Location = new Point(196, 413);
            txt_seg3.Name = "txt_seg3";
            txt_seg3.Size = new Size(66, 23);
            txt_seg3.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(196, 335);
            label4.Name = "label4";
            label4.Size = new Size(64, 17);
            label4.TabIndex = 29;
            label4.Text = "Segunda:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(281, 335);
            label5.Name = "label5";
            label5.Size = new Size(42, 17);
            label5.TabIndex = 30;
            label5.Text = "Terça:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(349, 335);
            label6.Name = "label6";
            label6.Size = new Size(50, 17);
            label6.TabIndex = 31;
            label6.Text = "Quarta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(421, 335);
            label7.Name = "label7";
            label7.Size = new Size(49, 17);
            label7.TabIndex = 32;
            label7.Text = "Quinta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(496, 335);
            label8.Name = "label8";
            label8.Size = new Size(44, 17);
            label8.TabIndex = 33;
            label8.Text = "Sexta:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(560, 335);
            label9.Name = "label9";
            label9.Size = new Size(56, 17);
            label9.TabIndex = 34;
            label9.Text = "Sábado:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(630, 335);
            label10.Name = "label10";
            label10.Size = new Size(67, 17);
            label10.TabIndex = 35;
            label10.Text = "Domingo:";
            // 
            // userAcolitos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox16);
            Controls.Add(textBox17);
            Controls.Add(textBox18);
            Controls.Add(textBox19);
            Controls.Add(textBox20);
            Controls.Add(textBox21);
            Controls.Add(txt_seg3);
            Controls.Add(textBox9);
            Controls.Add(textBox10);
            Controls.Add(textBox11);
            Controls.Add(textBox12);
            Controls.Add(textBox13);
            Controls.Add(textBox14);
            Controls.Add(txt_seg2);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(txt_seg);
            Controls.Add(txt_nome);
            Controls.Add(label3);
            Controls.Add(dgv_acolitos);
            Controls.Add(btn_buscar);
            Controls.Add(label2);
            Controls.Add(txtPesquisa);
            Controls.Add(label1);
            ImeMode = ImeMode.KatakanaHalf;
            Name = "userAcolitos";
            Size = new Size(746, 472);
            Load += acolitos_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_acolitos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtPesquisa;
        private Label label2;
        private Button btn_buscar;
        private DataGridView dgv_acolitos;
        private DataGridViewTextBoxColumn nome;
        private DataGridViewTextBoxColumn segunda;
        private DataGridViewTextBoxColumn terca;
        private DataGridViewTextBoxColumn quarta;
        private DataGridViewTextBoxColumn quinta;
        private DataGridViewTextBoxColumn sexta;
        private DataGridViewTextBoxColumn sabado;
        private DataGridViewTextBoxColumn domingo;
        private Label label3;
        private TextBox txt_nome;
        private TextBox txt_seg;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox txt_seg2;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox txt_seg3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}
