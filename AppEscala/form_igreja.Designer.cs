namespace AppEscala
{
    partial class form_igreja
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
            txt_igreja = new TextBox();
            btn_add = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txt_igreja
            // 
            txt_igreja.Location = new Point(65, 100);
            txt_igreja.Name = "txt_igreja";
            txt_igreja.Size = new Size(215, 23);
            txt_igreja.TabIndex = 0;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(104, 181);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(137, 45);
            btn_add.TabIndex = 1;
            btn_add.Text = "Adicionar";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(122, 70);
            label1.Name = "label1";
            label1.Size = new Size(103, 17);
            label1.TabIndex = 2;
            label1.Text = "Nome da Igreja:";
            // 
            // form_igreja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 315);
            Controls.Add(label1);
            Controls.Add(btn_add);
            Controls.Add(txt_igreja);
            Name = "form_igreja";
            Text = "form_igreja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_igreja;
        private Button btn_add;
        private Label label1;
    }
}