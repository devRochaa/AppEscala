
namespace AppEscala
{
    partial class Form1 
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            btn_add = new Button();
            panel1 = new Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            button2 = new Button();
            menuTransition = new System.Windows.Forms.Timer(components);
            panel3 = new Panel();
            button3 = new Button();
            panel4 = new Panel();
            button4 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel5 = new Panel();
            button5 = new Button();
            panel6 = new Panel();
            button6 = new Button();
            panel7 = new Panel();
            button7 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(528, 42);
            button1.Name = "button1";
            button1.Size = new Size(143, 56);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btn_add
            // 
            btn_add.BackColor = Color.FromArgb(37, 37, 41);
            btn_add.ForeColor = SystemColors.Control;
            btn_add.Image = (Image)resources.GetObject("btn_add.Image");
            btn_add.ImageAlign = ContentAlignment.MiddleLeft;
            btn_add.Location = new Point(-10, -11);
            btn_add.Name = "btn_add";
            btn_add.Padding = new Padding(10, 0, 0, 0);
            btn_add.Size = new Size(218, 77);
            btn_add.TabIndex = 1;
            btn_add.Text = "Gerar Escalas";
            btn_add.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(nightControlBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 36);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(661, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(40, 9);
            label1.Name = "label1";
            label1.Size = new Size(198, 19);
            label1.TabIndex = 4;
            label1.Text = "CRIAR ESCALAS | TELA INICIAL";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(31, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(37, 37, 41);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.ForeColor = Color.Coral;
            flowLayoutPanel1.Location = new Point(0, 36);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(189, 434);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_add);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(203, 57);
            panel2.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(596, 324);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // menuTransition
            // 
            menuTransition.Tick += menuTransition_Tick;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Location = new Point(250, 81);
            panel3.Name = "panel3";
            panel3.Size = new Size(203, 57);
            panel3.TabIndex = 5;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(44, 45, 52);
            button3.ForeColor = SystemColors.Control;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(-10, -11);
            button3.Name = "button3";
            button3.Padding = new Padding(10, 0, 0, 0);
            button3.Size = new Size(218, 77);
            button3.TabIndex = 1;
            button3.Text = "Adicionar Acólitos";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(button4);
            panel4.Location = new Point(250, 144);
            panel4.Name = "panel4";
            panel4.Size = new Size(203, 57);
            panel4.TabIndex = 6;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(44, 45, 52);
            button4.ForeColor = SystemColors.Control;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(-10, -11);
            button4.Name = "button4";
            button4.Padding = new Padding(10, 0, 0, 0);
            button4.Size = new Size(218, 77);
            button4.TabIndex = 1;
            button4.Text = "Editar Acólitos";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.FromArgb(37, 37, 41);
            flowLayoutPanel2.Controls.Add(panel6);
            flowLayoutPanel2.Controls.Add(panel7);
            flowLayoutPanel2.Controls.Add(panel5);
            flowLayoutPanel2.Location = new Point(250, 276);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(203, 174);
            flowLayoutPanel2.TabIndex = 7;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // panel5
            // 
            panel5.Controls.Add(button5);
            panel5.Location = new Point(0, 114);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(203, 57);
            panel5.TabIndex = 7;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(44, 45, 52);
            button5.ForeColor = SystemColors.Control;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(-10, -11);
            button5.Name = "button5";
            button5.Padding = new Padding(10, 0, 0, 0);
            button5.Size = new Size(218, 77);
            button5.TabIndex = 1;
            button5.Text = "Editar Datas";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(button6);
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(203, 57);
            panel6.TabIndex = 6;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(37, 37, 41);
            button6.ForeColor = SystemColors.Control;
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(-10, -11);
            button6.Margin = new Padding(0);
            button6.Name = "button6";
            button6.Padding = new Padding(10, 0, 0, 0);
            button6.Size = new Size(218, 77);
            button6.TabIndex = 1;
            button6.Text = "Adicionar Acólitos";
            button6.TextImageRelation = TextImageRelation.ImageBeforeText;
            button6.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(button7);
            panel7.Location = new Point(0, 57);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(203, 57);
            panel7.TabIndex = 8;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(44, 45, 52);
            button7.ForeColor = SystemColors.Control;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(-10, -11);
            button7.Name = "button7";
            button7.Padding = new Padding(10, 0, 0, 0);
            button7.Size = new Size(218, 77);
            button7.TabIndex = 1;
            button7.Text = "Editar Acólitos";
            button7.TextImageRelation = TextImageRelation.ImageBeforeText;
            button7.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 470);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(button2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btn_add;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Button button2;
        private System.Windows.Forms.Timer menuTransition;
        private Panel panel3;
        private Button button3;
        private Panel panel4;
        private Button button4;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel6;
        private Button button6;
        private Panel panel5;
        private Button button5;
        private Panel panel7;
        private Button button7;
    }
}
