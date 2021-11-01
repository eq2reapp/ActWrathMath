
namespace ACT_Plugin.UI
{
    partial class WrathMathPluginTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlControls = new System.Windows.Forms.Panel();
            this.cmbDisplay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wrathMathHelpControl1 = new ACT_Plugin.WrathMathHelpControl();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.cmbDisplay);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(812, 45);
            this.pnlControls.TabIndex = 0;
            // 
            // cmbDisplay
            // 
            this.cmbDisplay.DisplayMember = "Name";
            this.cmbDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisplay.FormattingEnabled = true;
            this.cmbDisplay.Location = new System.Drawing.Point(105, 13);
            this.cmbDisplay.Name = "cmbDisplay";
            this.cmbDisplay.Size = new System.Drawing.Size(117, 21);
            this.cmbDisplay.TabIndex = 1;
            this.cmbDisplay.SelectedIndexChanged += new System.EventHandler(this.cmbDisplay_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show on display:";
            // 
            // wrathMathHelpControl1
            // 
            this.wrathMathHelpControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wrathMathHelpControl1.Location = new System.Drawing.Point(0, 45);
            this.wrathMathHelpControl1.Name = "wrathMathHelpControl1";
            this.wrathMathHelpControl1.Size = new System.Drawing.Size(812, 694);
            this.wrathMathHelpControl1.TabIndex = 1;
            // 
            // WrathMathPluginTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wrathMathHelpControl1);
            this.Controls.Add(this.pnlControls);
            this.Name = "WrathMathPluginTab";
            this.Size = new System.Drawing.Size(812, 739);
            this.Load += new System.EventHandler(this.WrathMathPluginTab_Load);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private WrathMathHelpControl wrathMathHelpControl1;
        private System.Windows.Forms.ComboBox cmbDisplay;
        private System.Windows.Forms.Label label1;
    }
}
