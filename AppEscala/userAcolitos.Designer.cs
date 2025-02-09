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
            oculto = new DataGridViewTextBoxColumn();
            label3 = new Label();
            txt_nome = new TextBox();
            txt_seg1 = new TextBox();
            txt_ter1 = new TextBox();
            txt_qua1 = new TextBox();
            txt_qui1 = new TextBox();
            txt_sex1 = new TextBox();
            txt_sab1 = new TextBox();
            txt_dom1 = new TextBox();
            txt_dom2 = new TextBox();
            txt_sab2 = new TextBox();
            txt_sex2 = new TextBox();
            txt_qui2 = new TextBox();
            txt_qua2 = new TextBox();
            txt_ter2 = new TextBox();
            txt_seg2 = new TextBox();
            txt_dom3 = new TextBox();
            txt_sab3 = new TextBox();
            txt_sex3 = new TextBox();
            txt_qui3 = new TextBox();
            txt_qua3 = new TextBox();
            txt_ter3 = new TextBox();
            txt_seg3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            btn_salvar = new Button();
            txt_id = new TextBox();
            txt_aviso = new Label();
            btn_edit = new Button();
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
            dgv_acolitos.Columns.AddRange(new DataGridViewColumn[] { nome, segunda, terca, quarta, quinta, sexta, sabado, domingo, oculto });
            dgv_acolitos.Location = new Point(48, 101);
            dgv_acolitos.MultiSelect = false;
            dgv_acolitos.Name = "dgv_acolitos";
            dgv_acolitos.ReadOnly = true;
            dgv_acolitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_acolitos.Size = new Size(646, 203);
            dgv_acolitos.TabIndex = 5;
            dgv_acolitos.CellClick += dgv_acolitos_CellClick;
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
            // oculto
            // 
            oculto.HeaderText = "id";
            oculto.Name = "oculto";
            oculto.ReadOnly = true;
            oculto.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(51, 313);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 6;
            label3.Text = "Editar Acólito:";
            // 
            // txt_nome
            // 
            txt_nome.Location = new Point(51, 335);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(135, 23);
            txt_nome.TabIndex = 7;
            // 
            // txt_seg1
            // 
            txt_seg1.Location = new Point(196, 333);
            txt_seg1.Name = "txt_seg1";
            txt_seg1.Size = new Size(66, 23);
            txt_seg1.TabIndex = 8;
            // 
            // txt_ter1
            // 
            txt_ter1.Location = new Point(268, 333);
            txt_ter1.Name = "txt_ter1";
            txt_ter1.Size = new Size(66, 23);
            txt_ter1.TabIndex = 9;
            // 
            // txt_qua1
            // 
            txt_qua1.Location = new Point(340, 333);
            txt_qua1.Name = "txt_qua1";
            txt_qua1.Size = new Size(66, 23);
            txt_qua1.TabIndex = 10;
            // 
            // txt_qui1
            // 
            txt_qui1.Location = new Point(412, 333);
            txt_qui1.Name = "txt_qui1";
            txt_qui1.Size = new Size(66, 23);
            txt_qui1.TabIndex = 11;
            // 
            // txt_sex1
            // 
            txt_sex1.Location = new Point(484, 333);
            txt_sex1.Name = "txt_sex1";
            txt_sex1.Size = new Size(66, 23);
            txt_sex1.TabIndex = 12;
            // 
            // txt_sab1
            // 
            txt_sab1.Location = new Point(556, 333);
            txt_sab1.Name = "txt_sab1";
            txt_sab1.Size = new Size(66, 23);
            txt_sab1.TabIndex = 13;
            // 
            // txt_dom1
            // 
            txt_dom1.Location = new Point(628, 333);
            txt_dom1.Name = "txt_dom1";
            txt_dom1.Size = new Size(66, 23);
            txt_dom1.TabIndex = 14;
            // 
            // txt_dom2
            // 
            txt_dom2.Location = new Point(628, 362);
            txt_dom2.Name = "txt_dom2";
            txt_dom2.Size = new Size(66, 23);
            txt_dom2.TabIndex = 21;
            // 
            // txt_sab2
            // 
            txt_sab2.Location = new Point(556, 362);
            txt_sab2.Name = "txt_sab2";
            txt_sab2.Size = new Size(66, 23);
            txt_sab2.TabIndex = 20;
            // 
            // txt_sex2
            // 
            txt_sex2.Location = new Point(484, 362);
            txt_sex2.Name = "txt_sex2";
            txt_sex2.Size = new Size(66, 23);
            txt_sex2.TabIndex = 19;
            // 
            // txt_qui2
            // 
            txt_qui2.Location = new Point(412, 362);
            txt_qui2.Name = "txt_qui2";
            txt_qui2.Size = new Size(66, 23);
            txt_qui2.TabIndex = 18;
            // 
            // txt_qua2
            // 
            txt_qua2.Location = new Point(340, 362);
            txt_qua2.Name = "txt_qua2";
            txt_qua2.Size = new Size(66, 23);
            txt_qua2.TabIndex = 17;
            // 
            // txt_ter2
            // 
            txt_ter2.Location = new Point(268, 362);
            txt_ter2.Name = "txt_ter2";
            txt_ter2.Size = new Size(66, 23);
            txt_ter2.TabIndex = 16;
            // 
            // txt_seg2
            // 
            txt_seg2.Location = new Point(196, 362);
            txt_seg2.Name = "txt_seg2";
            txt_seg2.Size = new Size(66, 23);
            txt_seg2.TabIndex = 15;
            // 
            // txt_dom3
            // 
            txt_dom3.Location = new Point(628, 391);
            txt_dom3.Name = "txt_dom3";
            txt_dom3.Size = new Size(66, 23);
            txt_dom3.TabIndex = 28;
            // 
            // txt_sab3
            // 
            txt_sab3.Location = new Point(556, 391);
            txt_sab3.Name = "txt_sab3";
            txt_sab3.Size = new Size(66, 23);
            txt_sab3.TabIndex = 27;
            // 
            // txt_sex3
            // 
            txt_sex3.Location = new Point(484, 391);
            txt_sex3.Name = "txt_sex3";
            txt_sex3.Size = new Size(66, 23);
            txt_sex3.TabIndex = 26;
            // 
            // txt_qui3
            // 
            txt_qui3.Location = new Point(412, 391);
            txt_qui3.Name = "txt_qui3";
            txt_qui3.Size = new Size(66, 23);
            txt_qui3.TabIndex = 25;
            // 
            // txt_qua3
            // 
            txt_qua3.Location = new Point(340, 391);
            txt_qua3.Name = "txt_qua3";
            txt_qua3.Size = new Size(66, 23);
            txt_qua3.TabIndex = 24;
            // 
            // txt_ter3
            // 
            txt_ter3.Location = new Point(268, 391);
            txt_ter3.Name = "txt_ter3";
            txt_ter3.Size = new Size(66, 23);
            txt_ter3.TabIndex = 23;
            // 
            // txt_seg3
            // 
            txt_seg3.Location = new Point(196, 391);
            txt_seg3.Name = "txt_seg3";
            txt_seg3.Size = new Size(66, 23);
            txt_seg3.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(196, 313);
            label4.Name = "label4";
            label4.Size = new Size(64, 17);
            label4.TabIndex = 29;
            label4.Text = "Segunda:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(281, 313);
            label5.Name = "label5";
            label5.Size = new Size(42, 17);
            label5.TabIndex = 30;
            label5.Text = "Terça:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(349, 313);
            label6.Name = "label6";
            label6.Size = new Size(50, 17);
            label6.TabIndex = 31;
            label6.Text = "Quarta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(421, 313);
            label7.Name = "label7";
            label7.Size = new Size(49, 17);
            label7.TabIndex = 32;
            label7.Text = "Quinta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(496, 313);
            label8.Name = "label8";
            label8.Size = new Size(44, 17);
            label8.TabIndex = 33;
            label8.Text = "Sexta:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(560, 313);
            label9.Name = "label9";
            label9.Size = new Size(56, 17);
            label9.TabIndex = 34;
            label9.Text = "Sábado:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(630, 313);
            label10.Name = "label10";
            label10.Size = new Size(67, 17);
            label10.TabIndex = 35;
            label10.Text = "Domingo:";
            // 
            // btn_salvar
            // 
            btn_salvar.Location = new Point(619, 420);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(78, 24);
            btn_salvar.TabIndex = 36;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            // 
            // txt_id
            // 
            txt_id.Location = new Point(628, 22);
            txt_id.Name = "txt_id";
            txt_id.Size = new Size(66, 23);
            txt_id.TabIndex = 37;
            // 
            // txt_aviso
            // 
            txt_aviso.AutoSize = true;
            txt_aviso.Location = new Point(278, 199);
            txt_aviso.Name = "txt_aviso";
            txt_aviso.Size = new Size(204, 15);
            txt_aviso.TabIndex = 38;
            txt_aviso.Text = "Não foi encontrado nenhum registro.";
            txt_aviso.Visible = false;
            // 
            // btn_edit
            // 
            btn_edit.Location = new Point(79, 388);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(75, 23);
            btn_edit.TabIndex = 39;
            btn_edit.Text = "Editar Acólito";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += btn_edit_Click;
            // 
            // userAcolitos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_edit);
            Controls.Add(txt_aviso);
            Controls.Add(txt_id);
            Controls.Add(btn_salvar);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txt_dom3);
            Controls.Add(txt_sab3);
            Controls.Add(txt_sex3);
            Controls.Add(txt_qui3);
            Controls.Add(txt_qua3);
            Controls.Add(txt_ter3);
            Controls.Add(txt_seg3);
            Controls.Add(txt_dom2);
            Controls.Add(txt_sab2);
            Controls.Add(txt_sex2);
            Controls.Add(txt_qui2);
            Controls.Add(txt_qua2);
            Controls.Add(txt_ter2);
            Controls.Add(txt_seg2);
            Controls.Add(txt_dom1);
            Controls.Add(txt_sab1);
            Controls.Add(txt_sex1);
            Controls.Add(txt_qui1);
            Controls.Add(txt_qua1);
            Controls.Add(txt_ter1);
            Controls.Add(txt_seg1);
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
            VisibleChanged += userAcolitos_VisibleChanged;
            Enter += userAcolitos_Enter;
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
        private TextBox txt_seg1;
        private TextBox txt_ter1;
        private TextBox txt_qua1;
        private TextBox txt_qui1;
        private TextBox txt_sex1;
        private TextBox txt_sab1;
        private TextBox txt_dom1;
        private TextBox txt_dom2;
        private TextBox txt_sab2;
        private TextBox txt_sex2;
        private TextBox txt_qui2;
        private TextBox txt_qua2;
        private TextBox txt_ter2;
        private TextBox txt_seg2;
        private TextBox txt_dom3;
        private TextBox txt_sab3;
        private TextBox txt_sex3;
        private TextBox txt_qui3;
        private TextBox txt_qua3;
        private TextBox txt_ter3;
        private TextBox txt_seg3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btn_salvar;
        private DataGridViewTextBoxColumn oculto;
        private TextBox txt_id;
        private Label txt_aviso;
        private Button btn_edit;
    }
}
