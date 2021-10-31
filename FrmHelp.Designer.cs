
namespace ACT_Plugin
{
    partial class FrmHelp
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
            this.webHelp = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webHelp
            // 
            this.webHelp.AllowWebBrowserDrop = false;
            this.webHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webHelp.IsWebBrowserContextMenuEnabled = false;
            this.webHelp.Location = new System.Drawing.Point(0, 0);
            this.webHelp.MinimumSize = new System.Drawing.Size(20, 20);
            this.webHelp.Name = "webHelp";
            this.webHelp.Size = new System.Drawing.Size(747, 794);
            this.webHelp.TabIndex = 1;
            this.webHelp.TabStop = false;
            this.webHelp.WebBrowserShortcutsEnabled = false;
            // 
            // FrmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 794);
            this.Controls.Add(this.webHelp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHelp";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ACT Wrath Math - Help";
            this.Load += new System.EventHandler(this.FrmHelp_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.WebBrowser webHelp;
    }
}