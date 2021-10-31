using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ACT_Plugin
{
    /*
     * This class follows the pattern from the ACT plugin examples. It adds a UI to show/edit the settings.
     */
    public class WrathMathSettings
    {
        private string _settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\WrathMath.config.xml");
        private SettingsSerializer _xmlSettings;

        private FrmSettings _frmSettings = null;

        public int WindowLocationX = 0;
        public int WindowLocationY = 0;
        public int WindowWidth = 0;
        public int WindowHeight = 0;
        public string MobDetChannel = "";
        public bool AnnouncePlayers = false;
        public bool ConfirmYou = false;
        public bool ConfirmMob = false;
        public bool CreateMacro = false;
        public string MacroFile = "";
        public string MacroCommands = "";

        public WrathMathSettings()
        {
            _xmlSettings = new SettingsSerializer(this);
            _xmlSettings.AddIntSetting("WindowLocationX");
            _xmlSettings.AddIntSetting("WindowLocationY");
            _xmlSettings.AddIntSetting("WindowWidth");
            _xmlSettings.AddIntSetting("WindowHeight");
            _xmlSettings.AddStringSetting("MobDetChannel");
            _xmlSettings.AddBooleanSetting("AnnouncePlayers");
            _xmlSettings.AddBooleanSetting("ConfirmYou");
            _xmlSettings.AddBooleanSetting("ConfirmMob");
            _xmlSettings.AddBooleanSetting("CreateMacro");
            _xmlSettings.AddStringSetting("MacroFile");
            _xmlSettings.AddStringSetting("MacroCommands");

            _frmSettings = new FrmSettings(this);
        }

        public void EditSettings()
        {
            _frmSettings.ShowDialog();
        }

        public void LoadSettings()
        {
            if (File.Exists(_settingsFile))
            {
                var fs = new FileStream(_settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                _xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch { }
                xReader.Close();
            }
        }

        public void SaveSettings()
        {
            try
            {
                FileStream fs = new FileStream(_settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
                xWriter.Formatting = Formatting.Indented;
                xWriter.Indentation = 1;
                xWriter.IndentChar = '\t';
                xWriter.WriteStartDocument(true);
                xWriter.WriteStartElement("Config");    // <Config>
                xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
                _xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
                xWriter.WriteEndElement();  // </SettingsSerializer>
                xWriter.WriteEndElement();  // </Config>
                xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
                xWriter.Flush();    // Flush the file buffer to disk
                xWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
