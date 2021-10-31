
namespace ACT_Plugin
{
    partial class FrmSettings
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
            this.grpMob = new System.Windows.Forms.GroupBox();
            this.lnkMacroHelp = new System.Windows.Forms.LinkLabel();
            this.grpMacro = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMacroCommands = new System.Windows.Forms.TextBox();
            this.btnBrowseMacroFile = new System.Windows.Forms.Button();
            this.txtMacroFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCreateMacro = new System.Windows.Forms.CheckBox();
            this.chkMob = new System.Windows.Forms.CheckBox();
            this.chkAnnounceCures = new System.Windows.Forms.CheckBox();
            this.txtMobChannel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkYou = new System.Windows.Forms.CheckBox();
            this.grpPlayers = new System.Windows.Forms.GroupBox();
            this.dlgMacroFile = new System.Windows.Forms.SaveFileDialog();
            this.grpMob.SuspendLayout();
            this.grpMacro.SuspendLayout();
            this.grpPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMob
            // 
            this.grpMob.Controls.Add(this.lnkMacroHelp);
            this.grpMob.Controls.Add(this.grpMacro);
            this.grpMob.Controls.Add(this.chkCreateMacro);
            this.grpMob.Controls.Add(this.chkMob);
            this.grpMob.Controls.Add(this.chkAnnounceCures);
            this.grpMob.Controls.Add(this.txtMobChannel);
            this.grpMob.Controls.Add(this.label1);
            this.grpMob.Location = new System.Drawing.Point(12, 80);
            this.grpMob.Name = "grpMob";
            this.grpMob.Size = new System.Drawing.Size(547, 351);
            this.grpMob.TabIndex = 1;
            this.grpMob.TabStop = false;
            this.grpMob.Text = "Mob Detriment";
            // 
            // lnkMacroHelp
            // 
            this.lnkMacroHelp.AutoSize = true;
            this.lnkMacroHelp.Location = new System.Drawing.Point(159, 105);
            this.lnkMacroHelp.Name = "lnkMacroHelp";
            this.lnkMacroHelp.Size = new System.Drawing.Size(100, 13);
            this.lnkMacroHelp.TabIndex = 5;
            this.lnkMacroHelp.TabStop = true;
            this.lnkMacroHelp.Text = "/do_file_commands";
            this.lnkMacroHelp.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkMacroHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMacroHelp_LinkClicked);
            // 
            // grpMacro
            // 
            this.grpMacro.Controls.Add(this.label6);
            this.grpMacro.Controls.Add(this.label5);
            this.grpMacro.Controls.Add(this.label4);
            this.grpMacro.Controls.Add(this.label3);
            this.grpMacro.Controls.Add(this.txtMacroCommands);
            this.grpMacro.Controls.Add(this.btnBrowseMacroFile);
            this.grpMacro.Controls.Add(this.txtMacroFile);
            this.grpMacro.Controls.Add(this.label2);
            this.grpMacro.Location = new System.Drawing.Point(42, 118);
            this.grpMacro.Name = "grpMacro";
            this.grpMacro.Size = new System.Drawing.Size(484, 219);
            this.grpMacro.TabIndex = 4;
            this.grpMacro.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "PLAYER2 - the second player to cure";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(98, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "PLAYER1 - the first player to cure";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "The following tokens will be substituted:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Commands";
            // 
            // txtMacroCommands
            // 
            this.txtMacroCommands.Location = new System.Drawing.Point(82, 48);
            this.txtMacroCommands.Multiline = true;
            this.txtMacroCommands.Name = "txtMacroCommands";
            this.txtMacroCommands.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMacroCommands.Size = new System.Drawing.Size(394, 105);
            this.txtMacroCommands.TabIndex = 2;
            // 
            // btnBrowseMacroFile
            // 
            this.btnBrowseMacroFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMacroFile.Location = new System.Drawing.Point(447, 19);
            this.btnBrowseMacroFile.Name = "btnBrowseMacroFile";
            this.btnBrowseMacroFile.Size = new System.Drawing.Size(31, 22);
            this.btnBrowseMacroFile.TabIndex = 1;
            this.btnBrowseMacroFile.Text = "...";
            this.btnBrowseMacroFile.UseVisualStyleBackColor = true;
            this.btnBrowseMacroFile.Click += new System.EventHandler(this.btnBrowseMacroFile_Click);
            // 
            // txtMacroFile
            // 
            this.txtMacroFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMacroFile.Location = new System.Drawing.Point(82, 20);
            this.txtMacroFile.Name = "txtMacroFile";
            this.txtMacroFile.Size = new System.Drawing.Size(359, 20);
            this.txtMacroFile.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Macro file";
            // 
            // chkCreateMacro
            // 
            this.chkCreateMacro.AutoSize = true;
            this.chkCreateMacro.Location = new System.Drawing.Point(24, 104);
            this.chkCreateMacro.Name = "chkCreateMacro";
            this.chkCreateMacro.Size = new System.Drawing.Size(131, 17);
            this.chkCreateMacro.TabIndex = 3;
            this.chkCreateMacro.Text = "Create macro file - see";
            this.chkCreateMacro.UseVisualStyleBackColor = true;
            this.chkCreateMacro.CheckedChanged += new System.EventHandler(this.chkCreateMacro_CheckedChanged);
            // 
            // chkMob
            // 
            this.chkMob.AutoSize = true;
            this.chkMob.Location = new System.Drawing.Point(24, 58);
            this.chkMob.Name = "chkMob";
            this.chkMob.Size = new System.Drawing.Size(248, 17);
            this.chkMob.TabIndex = 1;
            this.chkMob.Text = "Announce when mob detriment is parsed (TTS)";
            this.chkMob.UseVisualStyleBackColor = true;
            // 
            // chkAnnounceCures
            // 
            this.chkAnnounceCures.AutoSize = true;
            this.chkAnnounceCures.Location = new System.Drawing.Point(24, 81);
            this.chkAnnounceCures.Name = "chkAnnounceCures";
            this.chkAnnounceCures.Size = new System.Drawing.Size(211, 17);
            this.chkAnnounceCures.TabIndex = 2;
            this.chkAnnounceCures.Text = "Announce players needing cures (TTS)";
            this.chkAnnounceCures.UseVisualStyleBackColor = true;
            // 
            // txtMobChannel
            // 
            this.txtMobChannel.Location = new System.Drawing.Point(80, 27);
            this.txtMobChannel.Name = "txtMobChannel";
            this.txtMobChannel.Size = new System.Drawing.Size(112, 20);
            this.txtMobChannel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Channel";
            // 
            // chkYou
            // 
            this.chkYou.AutoSize = true;
            this.chkYou.Location = new System.Drawing.Point(24, 25);
            this.chkYou.Name = "chkYou";
            this.chkYou.Size = new System.Drawing.Size(248, 17);
            this.chkYou.TabIndex = 0;
            this.chkYou.Text = "Announce when your detriment is parsed (TTS)";
            this.chkYou.UseVisualStyleBackColor = true;
            // 
            // grpPlayers
            // 
            this.grpPlayers.Controls.Add(this.chkYou);
            this.grpPlayers.Location = new System.Drawing.Point(12, 12);
            this.grpPlayers.Name = "grpPlayers";
            this.grpPlayers.Size = new System.Drawing.Size(547, 62);
            this.grpPlayers.TabIndex = 0;
            this.grpPlayers.TabStop = false;
            this.grpPlayers.Text = "Player Detriments";
            // 
            // dlgMacroFile
            // 
            this.dlgMacroFile.DefaultExt = "txt";
            this.dlgMacroFile.FileName = "WrathMathCommands";
            this.dlgMacroFile.Filter = "Text files|*.txt";
            this.dlgMacroFile.InitialDirectory = "C:\\";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 443);
            this.Controls.Add(this.grpPlayers);
            this.Controls.Add(this.grpMob);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ACT Wrath Math - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSettings_FormClosing);
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.grpMob.ResumeLayout(false);
            this.grpMob.PerformLayout();
            this.grpMacro.ResumeLayout(false);
            this.grpMacro.PerformLayout();
            this.grpPlayers.ResumeLayout(false);
            this.grpPlayers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMob;
        private System.Windows.Forms.GroupBox grpMacro;
        private System.Windows.Forms.Button btnBrowseMacroFile;
        private System.Windows.Forms.TextBox txtMacroFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCreateMacro;
        private System.Windows.Forms.CheckBox chkMob;
        private System.Windows.Forms.CheckBox chkAnnounceCures;
        private System.Windows.Forms.TextBox txtMobChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkYou;
        private System.Windows.Forms.GroupBox grpPlayers;
        private System.Windows.Forms.SaveFileDialog dlgMacroFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMacroCommands;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lnkMacroHelp;
    }
}