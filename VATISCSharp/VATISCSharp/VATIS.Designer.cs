namespace VATIS
{
    partial class VATIS
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
            this.saveButton = new System.Windows.Forms.Button();
            this.textToSpeech = new System.Windows.Forms.RichTextBox();
            this.ICAO_Textbox = new System.Windows.Forms.TextBox();
            this.ICAO_Search = new System.Windows.Forms.Button();
            this.ICAO_Label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToVATSIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutVATISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateBox = new System.Windows.Forms.CheckBox();
            this.listen = new System.Windows.Forms.Button();
            this.metarData = new System.Windows.Forms.TextBox();
            this.atisCodeBox = new System.Windows.Forms.ComboBox();
            this.atisCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dep_runways = new System.Windows.Forms.TextBox();
            this.dep_label = new System.Windows.Forms.Label();
            this.arr_runways = new System.Windows.Forms.TextBox();
            this.ilsApproachBox = new System.Windows.Forms.CheckBox();
            this.characterLabel = new System.Windows.Forms.Label();
            this.characterCount = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(289, 255);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(74, 21);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save ATIS";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // textToSpeech
            // 
            this.textToSpeech.Location = new System.Drawing.Point(218, 66);
            this.textToSpeech.Margin = new System.Windows.Forms.Padding(2);
            this.textToSpeech.Name = "textToSpeech";
            this.textToSpeech.Size = new System.Drawing.Size(264, 185);
            this.textToSpeech.TabIndex = 2;
            this.textToSpeech.Text = "";
            this.textToSpeech.TextChanged += new System.EventHandler(this.textToSpeech_TextChanged);
            // 
            // ICAO_Textbox
            // 
            this.ICAO_Textbox.Location = new System.Drawing.Point(11, 43);
            this.ICAO_Textbox.Margin = new System.Windows.Forms.Padding(2);
            this.ICAO_Textbox.Name = "ICAO_Textbox";
            this.ICAO_Textbox.Size = new System.Drawing.Size(76, 20);
            this.ICAO_Textbox.TabIndex = 3;
            this.ICAO_Textbox.TextChanged += new System.EventHandler(this.ICAO_Textbox_TextChanged);
            // 
            // ICAO_Search
            // 
            this.ICAO_Search.Location = new System.Drawing.Point(92, 42);
            this.ICAO_Search.Margin = new System.Windows.Forms.Padding(2);
            this.ICAO_Search.Name = "ICAO_Search";
            this.ICAO_Search.Size = new System.Drawing.Size(56, 19);
            this.ICAO_Search.TabIndex = 4;
            this.ICAO_Search.Text = "Search";
            this.ICAO_Search.UseVisualStyleBackColor = true;
            this.ICAO_Search.Click += new System.EventHandler(this.ICAO_Search_Click);
            // 
            // ICAO_Label
            // 
            this.ICAO_Label.AutoSize = true;
            this.ICAO_Label.Location = new System.Drawing.Point(9, 26);
            this.ICAO_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ICAO_Label.Name = "ICAO_Label";
            this.ICAO_Label.Size = new System.Drawing.Size(85, 13);
            this.ICAO_Label.TabIndex = 5;
            this.ICAO_Label.Text = "ICAO (Ex. OJAI):";
            this.ICAO_Label.Click += new System.EventHandler(this.ICAO_Label_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(487, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToVATSIMToolStripMenuItem,
            this.diconnectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToVATSIMToolStripMenuItem
            // 
            this.connectToVATSIMToolStripMenuItem.Name = "connectToVATSIMToolStripMenuItem";
            this.connectToVATSIMToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.connectToVATSIMToolStripMenuItem.Text = "Connect to VATSIM";
            this.connectToVATSIMToolStripMenuItem.Click += new System.EventHandler(this.connectToVATSIMToolStripMenuItem_Click);
            // 
            // diconnectToolStripMenuItem
            // 
            this.diconnectToolStripMenuItem.Name = "diconnectToolStripMenuItem";
            this.diconnectToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.diconnectToolStripMenuItem.Text = "Disconnect";
            this.diconnectToolStripMenuItem.Click += new System.EventHandler(this.diconnectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutVATISToolStripMenuItem,
            this.autoUpdateToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutVATISToolStripMenuItem
            // 
            this.aboutVATISToolStripMenuItem.Name = "aboutVATISToolStripMenuItem";
            this.aboutVATISToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.aboutVATISToolStripMenuItem.Text = "About VATIS";
            this.aboutVATISToolStripMenuItem.Click += new System.EventHandler(this.aboutVATISToolStripMenuItem_Click);
            // 
            // autoUpdateToolStripMenuItem
            // 
            this.autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            this.autoUpdateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.autoUpdateToolStripMenuItem.Text = "AutoUpdate";
            this.autoUpdateToolStripMenuItem.Click += new System.EventHandler(this.autoUpdateToolStripMenuItem_Click);
            // 
            // autoUpdateBox
            // 
            this.autoUpdateBox.AutoSize = true;
            this.autoUpdateBox.Enabled = false;
            this.autoUpdateBox.Location = new System.Drawing.Point(369, 261);
            this.autoUpdateBox.Margin = new System.Windows.Forms.Padding(2);
            this.autoUpdateBox.Name = "autoUpdateBox";
            this.autoUpdateBox.Size = new System.Drawing.Size(113, 17);
            this.autoUpdateBox.TabIndex = 9;
            this.autoUpdateBox.Text = "Auto Update ATIS";
            this.autoUpdateBox.UseVisualStyleBackColor = true;
            this.autoUpdateBox.CheckedChanged += new System.EventHandler(this.autoUpdateBox_CheckedChanged);
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(218, 255);
            this.listen.Margin = new System.Windows.Forms.Padding(2);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(56, 21);
            this.listen.TabIndex = 10;
            this.listen.Text = "Listen";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // metarData
            // 
            this.metarData.Enabled = false;
            this.metarData.Location = new System.Drawing.Point(11, 192);
            this.metarData.Margin = new System.Windows.Forms.Padding(2);
            this.metarData.Multiline = true;
            this.metarData.Name = "metarData";
            this.metarData.Size = new System.Drawing.Size(168, 84);
            this.metarData.TabIndex = 11;
            this.metarData.TextChanged += new System.EventHandler(this.metarData_TextChanged);
            // 
            // atisCodeBox
            // 
            this.atisCodeBox.AllowDrop = true;
            this.atisCodeBox.FormattingEnabled = true;
            this.atisCodeBox.Items.AddRange(new object[] {
            "ALPHA",
            "BRAVO",
            "CHARLIE",
            "DELTA",
            "ECHO",
            "FOXTROT",
            "GOLF",
            "HOTEL",
            "INDIA",
            "JULIET",
            "KILO",
            "LIMA",
            "MIKE",
            "NOVEMBER",
            "OSCAR",
            "PAPA",
            "QUEBEC",
            "ROMEO",
            "SIERRA",
            "TANGO",
            "UNIFORM",
            "VICTOR",
            "WHISKEY",
            "X-RAY",
            "YANKEE",
            "ZULU"});
            this.atisCodeBox.Location = new System.Drawing.Point(390, 41);
            this.atisCodeBox.Margin = new System.Windows.Forms.Padding(2);
            this.atisCodeBox.Name = "atisCodeBox";
            this.atisCodeBox.Size = new System.Drawing.Size(92, 21);
            this.atisCodeBox.TabIndex = 12;
            this.atisCodeBox.Text = "ALPHA";
            this.atisCodeBox.SelectedIndexChanged += new System.EventHandler(this.atisCodeBox_SelectedIndexChanged);
            // 
            // atisCode
            // 
            this.atisCode.AutoSize = true;
            this.atisCode.Location = new System.Drawing.Point(324, 48);
            this.atisCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.atisCode.Name = "atisCode";
            this.atisCode.Size = new System.Drawing.Size(62, 13);
            this.atisCode.TabIndex = 13;
            this.atisCode.Text = "ATIS Code:";
            this.atisCode.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Arrival Runways (seperate by spaces)\r\nEx: 26 Left 26 Right";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // dep_runways
            // 
            this.dep_runways.Location = new System.Drawing.Point(11, 147);
            this.dep_runways.Margin = new System.Windows.Forms.Padding(2);
            this.dep_runways.Multiline = true;
            this.dep_runways.Name = "dep_runways";
            this.dep_runways.Size = new System.Drawing.Size(168, 19);
            this.dep_runways.TabIndex = 18;
            this.dep_runways.TextChanged += new System.EventHandler(this.dep_runways_TextChanged);
            // 
            // dep_label
            // 
            this.dep_label.AutoSize = true;
            this.dep_label.Location = new System.Drawing.Point(9, 117);
            this.dep_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dep_label.Name = "dep_label";
            this.dep_label.Size = new System.Drawing.Size(101, 26);
            this.dep_label.TabIndex = 19;
            this.dep_label.Text = "Departure Runways\r\nEx: 8 Left 8 Right";
            // 
            // arr_runways
            // 
            this.arr_runways.BackColor = System.Drawing.SystemColors.Window;
            this.arr_runways.Location = new System.Drawing.Point(11, 97);
            this.arr_runways.Margin = new System.Windows.Forms.Padding(2);
            this.arr_runways.Name = "arr_runways";
            this.arr_runways.Size = new System.Drawing.Size(166, 20);
            this.arr_runways.TabIndex = 20;
            this.arr_runways.TextChanged += new System.EventHandler(this.arr_runways_TextChanged);
            // 
            // ilsApproachBox
            // 
            this.ilsApproachBox.AutoSize = true;
            this.ilsApproachBox.Location = new System.Drawing.Point(11, 171);
            this.ilsApproachBox.Margin = new System.Windows.Forms.Padding(2);
            this.ilsApproachBox.Name = "ilsApproachBox";
            this.ilsApproachBox.Size = new System.Drawing.Size(124, 17);
            this.ilsApproachBox.TabIndex = 21;
            this.ilsApproachBox.Text = "ILS Approach in Use";
            this.ilsApproachBox.UseVisualStyleBackColor = true;
            this.ilsApproachBox.CheckedChanged += new System.EventHandler(this.ilsApproachBox_CheckedChanged);
            // 
            // characterLabel
            // 
            this.characterLabel.AutoSize = true;
            this.characterLabel.Location = new System.Drawing.Point(218, 49);
            this.characterLabel.Name = "characterLabel";
            this.characterLabel.Size = new System.Drawing.Size(64, 13);
            this.characterLabel.TabIndex = 22;
            this.characterLabel.Text = "Characters: ";
            // 
            // characterCount
            // 
            this.characterCount.AutoSize = true;
            this.characterCount.Location = new System.Drawing.Point(276, 48);
            this.characterCount.Name = "characterCount";
            this.characterCount.Size = new System.Drawing.Size(0, 13);
            this.characterCount.TabIndex = 23;
            // 
            // VATIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 286);
            this.Controls.Add(this.characterCount);
            this.Controls.Add(this.characterLabel);
            this.Controls.Add(this.ilsApproachBox);
            this.Controls.Add(this.arr_runways);
            this.Controls.Add(this.dep_label);
            this.Controls.Add(this.dep_runways);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atisCode);
            this.Controls.Add(this.atisCodeBox);
            this.Controls.Add(this.metarData);
            this.Controls.Add(this.listen);
            this.Controls.Add(this.autoUpdateBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ICAO_Label);
            this.Controls.Add(this.ICAO_Search);
            this.Controls.Add(this.ICAO_Textbox);
            this.Controls.Add(this.textToSpeech);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "VATIS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VATIS: Vatsim ATIS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RichTextBox textToSpeech;
        private System.Windows.Forms.TextBox ICAO_Textbox;
        private System.Windows.Forms.Button ICAO_Search;
        private System.Windows.Forms.Label ICAO_Label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToVATSIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox autoUpdateBox;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.TextBox metarData;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutVATISToolStripMenuItem;
        private System.Windows.Forms.ComboBox atisCodeBox;
        private System.Windows.Forms.Label atisCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dep_runways;
        private System.Windows.Forms.Label dep_label;
        private System.Windows.Forms.TextBox arr_runways;
        private System.Windows.Forms.CheckBox ilsApproachBox;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateToolStripMenuItem;
        private System.Windows.Forms.Label characterLabel;
        private System.Windows.Forms.Label characterCount;
    }
}

