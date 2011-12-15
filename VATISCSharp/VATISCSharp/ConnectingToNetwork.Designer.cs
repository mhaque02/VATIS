namespace VATIS
{
    partial class ConnectingToNetwork
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
            this.idLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.vatsimID = new System.Windows.Forms.TextBox();
            this.connectingPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(10, 9);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(64, 13);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "VATSIM ID:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(156, 8);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(98, 55);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // vatsimID
            // 
            this.vatsimID.Location = new System.Drawing.Point(13, 25);
            this.vatsimID.MaxLength = 20;
            this.vatsimID.Name = "vatsimID";
            this.vatsimID.Size = new System.Drawing.Size(100, 20);
            this.vatsimID.TabIndex = 5;
            this.vatsimID.TextChanged += new System.EventHandler(this.vatsimID_TextChanged);
            // 
            // connectingPass
            // 
            this.connectingPass.Location = new System.Drawing.Point(159, 25);
            this.connectingPass.MaxLength = 20;
            this.connectingPass.Name = "connectingPass";
            this.connectingPass.PasswordChar = '*';
            this.connectingPass.Size = new System.Drawing.Size(100, 20);
            this.connectingPass.TabIndex = 6;
            this.connectingPass.TextChanged += new System.EventHandler(this.connectingPass_TextChanged);
            // 
            // ConnectingToNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 90);
            this.Controls.Add(this.connectingPass);
            this.Controls.Add(this.vatsimID);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.idLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectingToNetwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to VATSIM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox vatsimID;
        private System.Windows.Forms.TextBox connectingPass;
    }
}