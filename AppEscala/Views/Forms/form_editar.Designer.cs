namespace AppEscala
{
    partial class form_editar
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
            label1 = new Label();
            cmb_igrejas = new ComboBox();
            dtp_missa = new DateTimePicker();
            btn_salvar = new Button();
            txt_hora1 = new TextBox();
            txt_hora2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txt_desc = new RichTextBox();
            cmb_quant = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 59);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 9;
            label1.Text = "Igreja:";
            // 
            // cmb_igrejas
            // 
            cmb_igrejas.FormattingEnabled = true;
            cmb_igrejas.Location = new Point(103, 77);
            cmb_igrejas.Name = "cmb_igrejas";
            cmb_igrejas.Size = new Size(222, 23);
            cmb_igrejas.TabIndex = 8;
            // 
            // dtp_missa
            // 
            dtp_missa.Format = DateTimePickerFormat.Short;
            dtp_missa.Location = new Point(103, 255);
            dtp_missa.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtp_missa.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtp_missa.Name = "dtp_missa";
            dtp_missa.Size = new Size(222, 23);
            dtp_missa.TabIndex = 10;
            // 
            // btn_salvar
            // 
            btn_salvar.Location = new Point(103, 343);
            btn_salvar.Name = "btn_salvar";
            btn_salvar.Size = new Size(222, 23);
            btn_salvar.TabIndex = 12;
            btn_salvar.Text = "Salvar";
            btn_salvar.UseVisualStyleBackColor = true;
            btn_salvar.Click += btn_salvar_Click;
            // 
            // txt_hora1
            // 
            txt_hora1.Location = new Point(103, 305);
            txt_hora1.MaxLength = 5;
            txt_hora1.Name = "txt_hora1";
            txt_hora1.Size = new Size(91, 23);
            txt_hora1.TabIndex = 13;
            txt_hora1.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_hora2
            // 
            txt_hora2.Location = new Point(234, 305);
            txt_hora2.MaxLength = 5;
            txt_hora2.Name = "txt_hora2";
            txt_hora2.Size = new Size(91, 23);
            txt_hora2.TabIndex = 14;
            txt_hora2.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(209, 305);
            label2.Name = "label2";
            label2.Size = new Size(13, 20);
            label2.TabIndex = 15;
            label2.Text = ":";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(106, 287);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 16;
            label3.Text = "Hora:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(105, 237);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 17;
            label4.Text = "Data:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(168, 35);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 18;
            label5.Text = "Editar Missa";
            // 
            // txt_desc
            // 
            txt_desc.Location = new Point(103, 118);
            txt_desc.Name = "txt_desc";
            txt_desc.Size = new Size(172, 96);
            txt_desc.TabIndex = 19;
            txt_desc.Text = "";
            // 
            // cmb_quant
            // 
            cmb_quant.FormattingEnabled = true;
            cmb_quant.Location = new Point(281, 118);
            cmb_quant.Name = "cmb_quant";
            cmb_quant.Size = new Size(44, 23);
            cmb_quant.TabIndex = 20;
            // 
            // form_editar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 385);
            Controls.Add(cmb_quant);
            Controls.Add(txt_desc);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_hora2);
            Controls.Add(txt_hora1);
            Controls.Add(btn_salvar);
            Controls.Add(dtp_missa);
            Controls.Add(label1);
            Controls.Add(cmb_igrejas);
            Name = "form_editar";
            Text = "form_editar";
            Load += form_editar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmb_igrejas;
        private DateTimePicker dtp_missa;
        private Button btn_salvar;
        private TextBox txt_hora1;
        private TextBox txt_hora2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox txt_desc;
        private ComboBox cmb_quant;
    }
}