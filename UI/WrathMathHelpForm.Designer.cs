
namespace ACT_Plugin
{
    partial class WrathMathHelpForm
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
            this.ctlHelp = new ACT_Plugin.WrathMathHelpControl();
            this.SuspendLayout();
            // 
            // ctlHelp
            // 
            this.ctlHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlHelp.Location = new System.Drawing.Point(0, 0);
            this.ctlHelp.Name = "ctlHelp";
            this.ctlHelp.Size = new System.Drawing.Size(881, 800);
            this.ctlHelp.TabIndex = 0;
            // 
            // WrathMathHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 800);
            this.Controls.Add(this.ctlHelp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WrathMathHelpForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ACT Wrath Math - Help";
            this.ResumeLayout(false);

        }

        #endregion

        private WrathMathHelpControl ctlHelp;
    }
}