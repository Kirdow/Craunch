namespace Craunch
{
    partial class SetupForm
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tboxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxCmd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxPW = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(331, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 20);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BrowseClick);
            // 
            // tboxPath
            // 
            this.tboxPath.Location = new System.Drawing.Point(126, 12);
            this.tboxPath.Name = "tboxPath";
            this.tboxPath.Size = new System.Drawing.Size(199, 20);
            this.tboxPath.TabIndex = 1;
            this.tboxPath.TextChanged += new System.EventHandler(this.OnTextChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Executable: ";
            // 
            // tboxCmd
            // 
            this.tboxCmd.Location = new System.Drawing.Point(126, 38);
            this.tboxCmd.Name = "tboxCmd";
            this.tboxCmd.Size = new System.Drawing.Size(280, 20);
            this.tboxCmd.TabIndex = 3;
            this.tboxCmd.TextChanged += new System.EventHandler(this.OnTextChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cmd Line Args: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password: ";
            // 
            // tboxPW
            // 
            this.tboxPW.Location = new System.Drawing.Point(126, 64);
            this.tboxPW.Name = "tboxPW";
            this.tboxPW.PasswordChar = '*';
            this.tboxPW.Size = new System.Drawing.Size(199, 20);
            this.tboxPW.TabIndex = 6;
            this.tboxPW.TextChanged += new System.EventHandler(this.OnTextChange);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(331, 64);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 20);
            this.btnEncrypt.TabIndex = 7;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.EncryptClick);
            // 
            // btnMode
            // 
            this.btnMode.Location = new System.Drawing.Point(12, 12);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(36, 20);
            this.btnMode.TabIndex = 8;
            this.btnMode.Text = "x86";
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.ModeClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 96);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.tboxPW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxCmd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxPath);
            this.Controls.Add(this.btnBrowse);
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.Text = "Setup Craunch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tboxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxCmd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxPW;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnMode;
    }
}