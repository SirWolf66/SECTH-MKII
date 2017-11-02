namespace SECTH_Cliënt
{
    partial class Dashboard
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
            this.btnJoinConference = new System.Windows.Forms.Button();
            this.btnCreateConference = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnMarkTemp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJoinConference
            // 
            this.btnJoinConference.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinConference.Location = new System.Drawing.Point(332, 146);
            this.btnJoinConference.Name = "btnJoinConference";
            this.btnJoinConference.Size = new System.Drawing.Size(171, 69);
            this.btnJoinConference.TabIndex = 0;
            this.btnJoinConference.Text = "Deelnemen aan vergadering";
            this.btnJoinConference.UseVisualStyleBackColor = true;
            // 
            // btnCreateConference
            // 
            this.btnCreateConference.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateConference.Location = new System.Drawing.Point(332, 249);
            this.btnCreateConference.Name = "btnCreateConference";
            this.btnCreateConference.Size = new System.Drawing.Size(171, 69);
            this.btnCreateConference.TabIndex = 1;
            this.btnCreateConference.Text = "Vergadering aanmaken";
            this.btnCreateConference.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(332, 351);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(171, 69);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Instellingen";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnMarkTemp
            // 
            this.btnMarkTemp.Location = new System.Drawing.Point(616, 191);
            this.btnMarkTemp.Name = "btnMarkTemp";
            this.btnMarkTemp.Size = new System.Drawing.Size(135, 69);
            this.btnMarkTemp.TabIndex = 3;
            this.btnMarkTemp.Text = "Mark\'s chatvenster (temp)";
            this.btnMarkTemp.UseVisualStyleBackColor = true;
            this.btnMarkTemp.Click += new System.EventHandler(this.btnMarkTemp_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 601);
            this.Controls.Add(this.btnMarkTemp);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnCreateConference);
            this.Controls.Add(this.btnJoinConference);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJoinConference;
        private System.Windows.Forms.Button btnCreateConference;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnMarkTemp;
    }
}