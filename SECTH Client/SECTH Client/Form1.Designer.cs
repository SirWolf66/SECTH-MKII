namespace SECTH_Cliënt
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuChatMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChatSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChatQuitMain = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChatExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChatFont = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Location = new System.Drawing.Point(12, 348);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(469, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox4.Location = new System.Drawing.Point(487, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(133, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "search";
            this.textBox4.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 50);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(468, 292);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Gebruikers in Vergadering:",
            "Marie",
            "Yakuza",
            "Sakura",
            "Miu",
            "Gilbert",
            "Kevin",
            "Klaas",
            "Jan",
            "Jeane"});
            this.listBox1.Location = new System.Drawing.Point(487, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(133, 290);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChatMenu,
            this.menuChatFont});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuChatMenu
            // 
            this.menuChatMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChatSettings,
            this.menuChatQuitMain,
            this.menuChatExit});
            this.menuChatMenu.Name = "menuChatMenu";
            this.menuChatMenu.Size = new System.Drawing.Size(50, 20);
            this.menuChatMenu.Text = "Menu";
            // 
            // menuChatSettings
            // 
            this.menuChatSettings.Name = "menuChatSettings";
            this.menuChatSettings.Size = new System.Drawing.Size(175, 22);
            this.menuChatSettings.Text = "Settings";
            this.menuChatSettings.Click += new System.EventHandler(this.MenuChatSettings_Click);
            // 
            // menuChatQuitMain
            // 
            this.menuChatQuitMain.Name = "menuChatQuitMain";
            this.menuChatQuitMain.Size = new System.Drawing.Size(175, 22);
            this.menuChatQuitMain.Text = "Quit to main menu";
            this.menuChatQuitMain.Click += new System.EventHandler(this.MenuChatQuitMain_Click);
            // 
            // menuChatExit
            // 
            this.menuChatExit.Name = "menuChatExit";
            this.menuChatExit.Size = new System.Drawing.Size(175, 22);
            this.menuChatExit.Text = "Exit the application";
            this.menuChatExit.Click += new System.EventHandler(this.MenuChatExit_Click);
            // 
            // menuChatFont
            // 
            this.menuChatFont.Name = "menuChatFont";
            this.menuChatFont.Size = new System.Drawing.Size(43, 20);
            this.menuChatFont.Text = "Font";
            this.menuChatFont.Click += new System.EventHandler(this.MenuChatFont_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 405);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuChatMenu;
        private System.Windows.Forms.ToolStripMenuItem menuChatSettings;
        private System.Windows.Forms.ToolStripMenuItem menuChatQuitMain;
        private System.Windows.Forms.ToolStripMenuItem menuChatExit;
        private System.Windows.Forms.ToolStripMenuItem menuChatFont;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}

