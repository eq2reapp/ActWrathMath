using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT_Plugin
{
    public partial class WrathMathHelpControl : UserControl
    {
        public WrathMathHelpControl()
        {
            InitializeComponent();
        }

        private void WrathMathHelpControl_Load(object sender, EventArgs e)
        {
            webHelp.DocumentText = WrathMathMain.HELP_TEXT;
        }

        private void webHelp_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Scheme.StartsWith("http"))
            {
                System.Diagnostics.Process.Start(e.Url.ToString());
                e.Cancel = true;
            }
        }
    }
}
