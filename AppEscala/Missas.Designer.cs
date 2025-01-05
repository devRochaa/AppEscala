namespace AppEscala
{
    partial class Missas
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
            btnAdd = new Button();
            listBox1 = new ListBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            label1 = new Label();
            btn_AddIgreja = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(370, 387);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(108, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(61, 151);
            listBox1.MultiColumn = true;
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(222, 276);
            listBox1.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(61, 103);
            dateTimePicker1.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(222, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(61, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(222, 23);
            comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 39);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 7;
            label1.Text = "Igreja:";
            // 
            // btn_AddIgreja
            // 
            btn_AddIgreja.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddIgreja.Location = new Point(289, 56);
            btn_AddIgreja.Name = "btn_AddIgreja";
            btn_AddIgreja.Padding = new Padding(2, 0, 0, 0);
            btn_AddIgreja.Size = new Size(23, 23);
            btn_AddIgreja.TabIndex = 8;
            btn_AddIgreja.Text = "+";
            btn_AddIgreja.UseVisualStyleBackColor = true;
            btn_AddIgreja.Click += btn_AddIgreja_Click;
            // 
            // Missas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_AddIgreja);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(listBox1);
            Controls.Add(btnAdd);
            Name = "Missas";
            RightToLeft = RightToLeft.No;
            Size = new Size(746, 472);
            Load += Missas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private ListBox listBox1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private Label label1;
        private Button btn_AddIgreja;
    }
}
