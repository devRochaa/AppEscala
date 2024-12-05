
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
            subMenu1 = new Button();
            panel4 = new Panel();
            subMenu2 = new Button();
            pnEscala = new Panel();
            button7 = new Button();
            pnInfo = new Panel();
            button3 = new Button();
            pnConfig = new Panel();
            button2 = new Button();
            button9 = new Button();
            pnLogout = new Panel();
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
            pnEscala.SuspendLayout();
            pnInfo.SuspendLayout();
            pnConfig.SuspendLayout();
            pnLogout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHam).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(633, 42);
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
            sidebar.Controls.Add(pnEscala);
            sidebar.Controls.Add(pnInfo);
            sidebar.Controls.Add(pnConfig);
            sidebar.Controls.Add(pnLogout);
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.ForeColor = Color.Coral;
            sidebar.Location = new Point(0, 42);
            sidebar.Name = "sidebar";
            sidebar.Padding = new Padding(0, 30, 0, 0);
            sidebar.Size = new Size(186, 467);
            sidebar.TabIndex = 3;
            // 
            // MenuContainer
            // 
            MenuContainer.BackColor = SystemColors.ActiveCaptionText;
            MenuContainer.Controls.Add(panel3);
            MenuContainer.Controls.Add(panel2);
            MenuContainer.Controls.Add(panel4);
            MenuContainer.Location = new Point(0, 30);
            MenuContainer.Margin = new Padding(0);
            MenuContainer.Name = "MenuContainer";
            MenuContainer.Padding = new Padding(2, 0, 0, 0);
            MenuContainer.Size = new Size(186, 173);
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
            panel2.Controls.Add(subMenu1);
            panel2.Location = new Point(5, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 40);
            panel2.TabIndex = 8;
            // 
            // subMenu1
            // 
            subMenu1.BackColor = Color.Black;
            subMenu1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            subMenu1.ForeColor = SystemColors.Control;
            subMenu1.Image = (Image)resources.GetObject("subMenu1.Image");
            subMenu1.ImageAlign = ContentAlignment.MiddleLeft;
            subMenu1.Location = new Point(-10, -12);
            subMenu1.Margin = new Padding(0);
            subMenu1.Name = "subMenu1";
            subMenu1.Padding = new Padding(8, 5, 5, 5);
            subMenu1.Size = new Size(202, 71);
            subMenu1.TabIndex = 1;
            subMenu1.Text = "    Sub Menu 1";
            subMenu1.TextAlign = ContentAlignment.MiddleLeft;
            subMenu1.UseVisualStyleBackColor = false;
            subMenu1.Click += subMenu1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(subMenu2);
            panel4.Location = new Point(5, 95);
            panel4.Name = "panel4";
            panel4.Size = new Size(186, 40);
            panel4.TabIndex = 9;
            // 
            // subMenu2
            // 
            subMenu2.BackColor = Color.Black;
            subMenu2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            subMenu2.ForeColor = SystemColors.Control;
            subMenu2.Image = (Image)resources.GetObject("subMenu2.Image");
            subMenu2.ImageAlign = ContentAlignment.MiddleLeft;
            subMenu2.Location = new Point(-10, -12);
            subMenu2.Margin = new Padding(0);
            subMenu2.Name = "subMenu2";
            subMenu2.Padding = new Padding(8, 5, 5, 5);
            subMenu2.Size = new Size(202, 73);
            subMenu2.TabIndex = 1;
            subMenu2.Text = "    Sub Menu 2";
            subMenu2.TextAlign = ContentAlignment.MiddleLeft;
            subMenu2.UseVisualStyleBackColor = false;
            // 
            // pnEscala
            // 
            pnEscala.Controls.Add(button7);
            pnEscala.Location = new Point(3, 206);
            pnEscala.Name = "pnEscala";
            pnEscala.Size = new Size(183, 55);
            pnEscala.TabIndex = 9;
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
            // pnInfo
            // 
            pnInfo.Controls.Add(button3);
            pnInfo.Location = new Point(3, 267);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(183, 55);
            pnInfo.TabIndex = 10;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.Control;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(-10, -11);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Padding = new Padding(18, 5, 5, 5);
            button3.Size = new Size(201, 70);
            button3.TabIndex = 1;
            button3.Text = "     Informações";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            // 
            // pnConfig
            // 
            pnConfig.Controls.Add(button2);
            pnConfig.Controls.Add(button9);
            pnConfig.Location = new Point(3, 328);
            pnConfig.Name = "pnConfig";
            pnConfig.Size = new Size(183, 55);
            pnConfig.TabIndex = 12;
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
            // pnLogout
            // 
            pnLogout.Controls.Add(button8);
            pnLogout.Location = new Point(3, 389);
            pnLogout.Name = "pnLogout";
            pnLogout.Size = new Size(183, 55);
            pnLogout.TabIndex = 8;
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
            button8.Text = "     Sair";
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
            btnHam.Location = new Point(9, 2);
            btnHam.Name = "btnHam";
            btnHam.Size = new Size(39, 29);
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
            IsMdiContainer = true;
            Name = "Form1";
            Text = " ";
            FormClosed += sub1_FormClosed;
            Load += Form1_Load;
            sidebar.ResumeLayout(false);
            MenuContainer.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            pnEscala.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            pnConfig.ResumeLayout(false);
            pnLogout.ResumeLayout(false);
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
        private Button subMenu1;
        private Panel panel4;
        private Button subMenu2;
        private Panel pnLogout;
        private Button button8;
        private Panel pnEscala;
        private Button button7;
        private Panel pnConfig;
        private Button button9;
        private System.Windows.Forms.Timer timerSideBarTransition;
        private PictureBox btnHam;
        private Label label1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private Panel panel1;
        private Button button2;
        private Panel pnInfo;
        private Button button3;

    }
}
