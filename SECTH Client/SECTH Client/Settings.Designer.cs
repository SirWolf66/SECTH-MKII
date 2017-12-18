namespace SECTH_Cliënt
{
    partial class Settings
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
            this.button1 = new System.Windows.Forms.Button();
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.autorBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(34, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // languageBox
            // 
            this.languageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Items.AddRange(new object[] {
            "en",
            "de",
            "nl",
            "ja",
            "es",
            "hi",
            "ar",
            "zh"});
            this.languageBox.Location = new System.Drawing.Point(84, 13);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(121, 21);
            this.languageBox.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Language";
            // 
            // autorBox
            // 
            this.autorBox.Location = new System.Drawing.Point(84, 40);
            this.autorBox.Name = "autorBox";
            this.autorBox.Size = new System.Drawing.Size(121, 20);
            this.autorBox.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(7, 39);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(71, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Avatar name";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(7, 64);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(71, 20);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Server IP";
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(84, 65);
            this.ipBox.MaxLength = 16;
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(121, 20);
            this.ipBox.TabIndex = 5;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 272);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.autorBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.button1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox languageBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox autorBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox ipBox;
    }
}