using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace ACT_Plugin
{
    public partial class WrathMathSettingsForm : Form
    {
        private WrathMathSettings _settings = null;

        public WrathMathSettingsForm(WrathMathSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            chkYou.Checked = _settings.ConfirmYou;
            txtMobChannel.Text = _settings.MobDetChannel;
            chkMob.Checked = _settings.ConfirmMob;
            chkAnnounceCures.Checked = _settings.AnnouncePlayers;
            chkCreateMacro.Checked = _settings.CreateMacro;
            txtMacroFile.Text = _settings.MacroFile;
            txtMacroCommands.Text = _settings.MacroCommands;
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.ConfirmYou = chkYou.Checked;
            _settings.MobDetChannel = txtMobChannel.Text.Trim();
            _settings.ConfirmMob = chkMob.Checked;
            _settings.AnnouncePlayers = chkAnnounceCures.Checked;
            _settings.CreateMacro = chkCreateMacro.Checked;
            _settings.MacroFile = txtMacroFile.Text.Trim();
            _settings.MacroCommands = txtMacroCommands.Text.Trim();
            _settings.SaveSettings();
        }

        private void btnBrowseMacroFile_Click(object sender, EventArgs e)
        {
            var selectedFile = new FileInfo(txtMacroFile.Text.Trim());
            if (selectedFile.Exists)
            {
                dlgMacroFile.FileName = selectedFile.Name;
                dlgMacroFile.InitialDirectory = selectedFile.DirectoryName;
            }

            if (dlgMacroFile.ShowDialog(this) == DialogResult.OK)
            {
                txtMacroFile.Text = dlgMacroFile.FileName;
            }
        }

        private void chkCreateMacro_CheckedChanged(object sender, EventArgs e)
        {
            grpMacro.Enabled = chkCreateMacro.Checked;
        }

        private void lnkMacroHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://eq2.fandom.com/wiki/Slash_Commands#File_commands");
        }
    }
}
