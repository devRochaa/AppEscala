
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
            menuTransition = new System.Windows.Forms.Timer(components);
            sidebar = new FlowLayoutPanel();
            MenuContainer = new FlowLayoutPanel();
            panel3 = new Panel();
            menu = new Button();
            panel2 = new Panel();
            button4 = new Button();
            panel4 = new Panel();
            button5 = new Button();
            panel6 = new Panel();
            button7 = new Button();
            panel8 = new Panel();
            button2 = new Button();
            button9 = new Button();
            panel7 = new Panel();
            button8 = new Button();
            timerSideBarTransition = new System.Windows.Forms.Timer(components);
            btnHam = new PictureBox();
            label1 = new Label();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            panel1 = new Panel();
            sidebar.SuspendLayout();
            MenuContainer.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(736, 29);
            button1.Name = "button1";
            button1.Size = new Size(143, 56);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuTransition
            // 
            menuTransition.Interval = 10;
            menuTransition.Tick += menuTransition_Tick;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.Black;
            sidebar.Controls.Add(MenuContainer);
            sidebar.Controls.Add(panel6);
            sidebar.Controls.Add(panel8);
            sidebar.Controls.Add(panel7);
            sidebar.ForeColor = Color.Coral;
            sidebar.Location = new Point(0, 42);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(187, 400);
            sidebar.TabIndex = 3;
            // 
            // MenuContainer
            // 
            MenuContainer.BackColor = SystemColors.ActiveCaptionText;
            MenuContainer.Controls.Add(panel3);
            MenuContainer.Controls.Add(panel2);
            MenuContainer.Controls.Add(panel4);
            MenuContainer.Location = new Point(0, 0);
            MenuContainer.Margin = new Padding(0);
            MenuContainer.Name = "MenuContainer";
            MenuContainer.Padding = new Padding(2, 0, 0, 0);
            MenuContainer.Size = new Size(186, 60);
            MenuContainer.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Controls.Add(menu);
            panel3.Location = new Point(5, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(189, 40);
            panel3.TabIndex = 9;
            // 
            // menu
            // 
            menu.BackColor = Color.Black;
            menu.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menu.ForeColor = SystemColors.Control;
            menu.Image = (Image)resources.GetObject("menu.Image");
            menu.ImageAlign = ContentAlignment.MiddleLeft;
            menu.Location = new Point(-10, -13);
            menu.Name = "menu";
            menu.Padding = new Padding(13, 5, 0, 0);
            menu.Size = new Size(202, 73);
            menu.TabIndex = 1;
            menu.Text = "      Menu";
            menu.TextAlign = ContentAlignment.MiddleLeft;
            menu.UseVisualStyleBackColor = false;
            menu.Click += btnMenu_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button4);
            panel2.Location = new Point(5, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 40);
            panel2.TabIndex = 8;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.Control;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(-10, -12);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Padding = new Padding(8, 5, 5, 5);
            button4.Size = new Size(202, 71);
            button4.TabIndex = 1;
            button4.Text = "    Sub Menu 1";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(button5);
            panel4.Location = new Point(5, 95);
            panel4.Name = "panel4";
            panel4.Size = new Size(186, 40);
            panel4.TabIndex = 9;
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.Control;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(-10, -12);
            button5.Margin = new Padding(0);
            button5.Name = "button5";
            button5.Padding = new Padding(8, 5, 5, 5);
            button5.Size = new Size(202, 73);
            button5.TabIndex = 1;
            button5.Text = "    Sub Menu 2";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(button7);
            panel6.Location = new Point(3, 63);
            panel6.Name = "panel6";
            panel6.Size = new Size(183, 55);
            panel6.TabIndex = 9;
            // 
            // button7
            // 
            button7.BackColor = Color.Black;
            button7.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.Control;
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(-10, -11);
            button7.Margin = new Padding(0);
            button7.Name = "button7";
            button7.Padding = new Padding(18, 5, 5, 5);
            button7.Size = new Size(201, 70);
            button7.TabIndex = 1;
            button7.Text = "     Escalas";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(button2);
            panel8.Controls.Add(button9);
            panel8.Location = new Point(3, 124);
            panel8.Name = "panel8";
            panel8.Size = new Size(183, 55);
            panel8.TabIndex = 12;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Control;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(-10, -8);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Padding = new Padding(14, 5, 5, 5);
            button2.Size = new Size(202, 71);
            button2.TabIndex = 2;
            button2.Text = "      Configurações";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.Black;
            button9.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = SystemColors.Control;
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(-10, -12);
            button9.Margin = new Padding(0);
            button9.Name = "button9";
            button9.Padding = new Padding(14, 5, 5, 5);
            button9.Size = new Size(202, 71);
            button9.TabIndex = 1;
            button9.Text = "      Configurações";
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.Controls.Add(button8);
            panel7.Location = new Point(3, 185);
            panel7.Name = "panel7";
            panel7.Size = new Size(183, 55);
            panel7.TabIndex = 8;
            // 
            // button8
            // 
            button8.BackColor = Color.Black;
            button8.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = SystemColors.Control;
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(-10, -12);
            button8.Margin = new Padding(0);
            button8.Name = "button8";
            button8.Padding = new Padding(18, 5, 5, 5);
            button8.Size = new Size(202, 71);
            button8.TabIndex = 1;
            button8.Text = "     Logout";
            button8.TextAlign = ContentAlignment.MiddleLeft;
            button8.UseVisualStyleBackColor = false;
            // 
            // timerSideBarTransition
            // 
            timerSideBarTransition.Interval = 10;
            timerSideBarTransition.Tick += timerSideBarTransition_Tick;
            // 
            // btnHam
            // 
            btnHam.Image = (Image)resources.GetObject("btnHam.Image");
            btnHam.Location = new Point(5, 7);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(34, 29);
            btnHam.SizeMode = PictureBoxSizeMode.StretchImage;
            btnHam.TabIndex = 3;
            btnHam.TabStop = false;
            btnHam.Click += btnHam_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(54, 9);
            label1.Name = "label1";
            label1.Size = new Size(198, 19);
            label1.TabIndex = 4;
            label1.Text = "CRIAR ESCALAS | TELA INICIAL";
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
            nightControlBox1.Location = new Point(637, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(nightControlBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnHam);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 39);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(776, 519);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = " ";
            Load += Form1_Load;
            sidebar.ResumeLayout(false);
            MenuContainer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHam).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private System.Windows.Forms.Timer menuTransition;
        private FlowLayoutPanel sidebar;
        private FlowLayoutPanel MenuContainer;
        private Panel panel3;
        private Button menu;
        private Panel panel2;
        private Button button4;
        private Panel panel4;
        private Button button5;
        private Panel panel7;
        private Button button8;
        private Panel panel6;
        private Button button7;
        private Panel panel8;
        private Button button9;
        private System.Windows.Forms.Timer timerSideBarTransition;
        private PictureBox btnHam;
        private Label label1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Panel panel1;
        private Button button2;
    }
}
