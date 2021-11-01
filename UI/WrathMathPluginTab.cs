using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT_Plugin.UI
{
    public partial class WrathMathPluginTab : UserControl
    {
        private WrathMathMain _main = null;

        public WrathMathPluginTab(WrathMathMain main)
        {
            InitializeComponent();

            _main = main;
        }

        private void WrathMathPluginTab_Load(object sender, EventArgs e)
        {
            var num = 1;
            foreach (var screen in System.Windows.Forms.Screen.AllScreens)
            {
                cmbDisplay.Items.Add(new Screen()
                {
                    Name = $"Screen {num++}",
                    Bounds = screen.Bounds
                });
            }
        }

        private void cmbDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Screen screen = cmbDisplay.SelectedItem as Screen;
            if (screen != null)
            {
                _main.MoveHudTo(screen.Bounds);
            }
        }

        private class Screen
        {
            public string Name;
            public Rectangle Bounds;
            public override string ToString()
            {
                return Name;
            }
        }
    }
}
