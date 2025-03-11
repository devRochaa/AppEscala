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
            cmb_dias = new ComboBox();
            label2 = new Label();
            cmb_turno1 = new ComboBox();
            cmb_turno2 = new ComboBox();
            cmb_turno3 = new ComboBox();
            teste = new Label();
            dtp_add = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            btn_excluirDia = new Button();
            dtp_edit = new DateTimePicker();
            lst_dias = new ListBox();
            btn_addDia = new Button();
            SuspendLayout();
            // 
            // txt_nome
            // 
            txt_nome.Location = new Point(21, 50);
            txt_nome.Name = "txt_nome";
            txt_nome.Size = new Size(318, 23);
            txt_nome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 32);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome:";
            // 
            // btn_salvar
            // 
            btn_salvar.Location = new Point(213, 317);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(126, 34);
            btn_salvar.TabIndex = 70;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            // 
            // lbl_dia
            // 
            lbl_dia.AutoSize = true;
            lbl_dia.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_dia.Location = new Point(177, 120);
            lbl_dia.Name = "lbl_dia";
            lbl_dia.Size = new Size(30, 17);
            lbl_dia.TabIndex = 63;
            lbl_dia.Text = "Dia:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.75F, FontStyle.Bold);
            label3.Location = new Point(132, 9);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 40;
            label3.Text = "Editar Acólito:";
            // 
            // cmb_dias
            // 
            cmb_dias.FormattingEnabled = true;
            cmb_dias.Location = new Point(126, 89);
            cmb_dias.Name = "cmb_dias";
            cmb_dias.Size = new Size(131, 23);
            cmb_dias.TabIndex = 80;
            cmb_dias.SelectedIndexChanged += cmb_dias_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 91);
            label2.Name = "label2";
            label2.Size = new Size(101, 17);
            label2.TabIndex = 81;
            label2.Text = "Selecione o dia:";
            // 
            // cmb_turno1
            // 
            cmb_turno1.FormattingEnabled = true;
            cmb_turno1.Location = new Point(75, 140);
            cmb_turno1.Name = "cmb_turno1";
            cmb_turno1.Size = new Size(76, 23);
            cmb_turno1.TabIndex = 82;
            cmb_turno1.SelectionChangeCommitted += cmb_turno1_SelectionChangeCommitted;
            cmb_turno1.TextUpdate += cmb_turno1_TextUpdate;
            // 
            // cmb_turno2
            // 
            cmb_turno2.FormattingEnabled = true;
            cmb_turno2.Location = new Point(154, 140);
            cmb_turno2.Name = "cmb_turno2";
            cmb_turno2.Size = new Size(76, 23);
            cmb_turno2.TabIndex = 83;
            cmb_turno2.SelectionChangeCommitted += cmb_turno2_SelectionChangeCommitted;
            // 
            // cmb_turno3
            // 
            cmb_turno3.FormattingEnabled = true;
            cmb_turno3.Location = new Point(233, 140);
            cmb_turno3.Name = "cmb_turno3";
            cmb_turno3.Size = new Size(76, 23);
            cmb_turno3.TabIndex = 84;
            cmb_turno3.SelectionChangeCommitted += cmb_turno3_SelectionChangeCommitted;
            // 
            // teste
            // 
            teste.AutoSize = true;
            teste.Location = new Point(572, 157);
            teste.Name = "teste";
            teste.Size = new Size(10, 15);
            teste.TabIndex = 85;
            teste.Text = "l";
            // 
            // dtp_add
            // 
            dtp_add.CustomFormat = "hh:mm";
            dtp_add.Format = DateTimePickerFormat.Short;
            dtp_add.Location = new Point(213, 201);
            dtp_add.Name = "dtp_add";
            dtp_add.Size = new Size(96, 23);
            dtp_add.TabIndex = 86;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(213, 183);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 87;
            label4.Text = "Adicionar:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(213, 235);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 88;
            label5.Text = "Editar:";
            // 
            // btn_excluirDia
            // 
            btn_excluirDia.Location = new Point(213, 287);
            btn_excluirDia.Name = "btn_excluirDia";
            btn_excluirDia.Size = new Size(30, 23);
            btn_excluirDia.TabIndex = 89;
            btn_excluirDia.Text = "🗑";
            btn_excluirDia.UseVisualStyleBackColor = true;
            btn_excluirDia.Click += btn_excluirDia_Click;
            // 
            // dtp_edit
            // 
            dtp_edit.CustomFormat = "hh:mm";
            dtp_edit.Format = DateTimePickerFormat.Short;
            dtp_edit.Location = new Point(213, 253);
            dtp_edit.Name = "dtp_edit";
            dtp_edit.Size = new Size(96, 23);
            dtp_edit.TabIndex = 90;
            // 
            // lst_dias
            // 
            lst_dias.FormattingEnabled = true;
            lst_dias.ItemHeight = 15;
            lst_dias.Location = new Point(21, 183);
            lst_dias.Name = "lst_dias";
            lst_dias.Size = new Size(186, 169);
            lst_dias.TabIndex = 91;
            lst_dias.SelectedIndexChanged += lst_dias_SelectedIndexChanged_1;
            // 
            // btn_addDia
            // 
            btn_addDia.Location = new Point(315, 201);
            btn_addDia.Name = "btn_addDia";
            btn_addDia.Size = new Size(24, 23);
            btn_addDia.TabIndex = 92;
            btn_addDia.Text = "+";
            btn_addDia.TextAlign = ContentAlignment.MiddleRight;
            btn_addDia.UseVisualStyleBackColor = true;
            btn_addDia.Click += btn_addDia_Click;
            // 
            // form_editarAcolito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 363);
            Controls.Add(btn_addDia);
            Controls.Add(lst_dias);
            Controls.Add(dtp_edit);
            Controls.Add(btn_excluirDia);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtp_add);
            Controls.Add(teste);
            Controls.Add(cmb_turno3);
            Controls.Add(cmb_turno2);
            Controls.Add(cmb_turno1);
            Controls.Add(label2);
            Controls.Add(cmb_dias);
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
        private ComboBox cmb_dias;
        private Label label2;
        private ComboBox cmb_turno1;
        private ComboBox cmb_turno2;
        private ComboBox cmb_turno3;
        private Label teste;
        private DateTimePicker dtp_add;
        private Label label4;
        private Label label5;
        private Button btn_excluirDia;
        private DateTimePicker dtp_edit;
        private ListBox lst_dias;
        private Button btn_addDia;
    }
}