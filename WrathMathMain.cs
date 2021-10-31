using System;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace ACT_Plugin
{
    /*
     * See https://github.com/EQAditu/AdvancedCombatTracker/wiki/Plugin-Creation-Tips
     */
    public class WrathMathMain : IActPluginV1
    {
#if DEBUG
        public static bool DEBUG = true;
#else
        public static bool DEBUG = false;
#endif

        public static string HELP_TEXT = @"
<html>
<head>
    <style>
        html {
            font-size: 16px;
            font-family: verdana;
        }
        h1, h2 {
            font-size: 1.5em;
            font-weight: bold;
            color: #3e4444;
        }
        h2 {
            font-size: 1.2em;
        }
        a, a:visited {
            color: cornflowerblue;
        }
        p {
            font-size: 0.9em;
            padding: 0.15em;
        }
        strong {
            font-style: normal;
            color: #3e4444;
        }
        em {
            font-style: normal;
            font-weight: 600;
            color: #405d27;
        }
    </style>
</head>
<body>
    <h1>ACT Wrath Math - Labomination Domination</h1>
    <p>This plugin aims to help out with the Labomination encounter in Vasty Deep: Toil and Trouble [Heroic II].</p>
    <h2>Instructions</h2>
    <p>
        During the encounter, each group member will be afflicted with a curse with an associated number.
        When this lands, have every person in the group type their number into the group chat.
    </p>
    <p>
        This plugin will parse the numbers for each group member and display all possible sums for two curses,
        in descending order. This should allow you to determine which two players add up to equal the detriment value 
        in the Labomination's detrimentals - have the healer(s) in the group cure those two people, and only those people!
    </p>
    <h2>Advanced usage</h2>
    <p>
        This plugin has a couple tricks up its sleeve. If you enter a text channel in the 
        <strong>Mob Detriment</strong> - <strong>Channel</strong> textbox, the plugin will attempt to parse the mob's
        detriment number from that channel. If that number matches one of the combinations provided by the group members,
        then the correct combination will be highlighted in the list.
    </p>
    <p>
        Additionally, if you've checked the <strong>Announce players needing cures (TTS)</strong> checkbox, the plugin 
        will announce the players as text-to-speech (like other triggers). You can also enable the other TTS checkboxes
        to hear confirmation as you enter your own detriment and/or the mob's detriment. This can be helpful as an auditory
        hint letting you know the plugin has parsed them correctly.
    </p>
    <p>
        Finally, you can take advantage of <em>/do_file_commands</em> in-game to execute a macro file after
        the plugin has detected the afflicted players. Just indicate where you want the file saved, and what you want in it
        (you'll probably want to use the available text substitutions) - which can include multiple lines. Make sure the
        commands are not preceded with a slash (/). For example, <em>gsay Cure curse on PLAYER1 and PLAYER2</em>. Then create
        a macro in the game that executes the macro file. For example, if you used <em>C:\EQ2\WrathMathCommands.txt</em> for the 
        <strong>Macro file</strong>, you'd want to create a macro with a step running the command
        <em>/do_file_commands C:\EQ2\WrathMathCommands.txt</em>. Now, whenever the plugin has determined who needs cures
        during each round, it will beep to indicate that the macro file has been updated so you can hit the macro in-game
        to take the appropriate actions.
    </p>
    <h2>Help!</h2>
    <p>Send an in-game tell to Skyfire.Reapp, or on Discord (samo#7395) and I'll try to help out if I can!</p>
    <p>
        If you find a bug or have a suggestion to improve the plugin, creat an issue on 
        <a href=""https://github.com/eq2reapp/ActWrathMath/issues"">Github</a>.
    </p>
</body>
</html>";

        private Label _lblPluginPage = null;
        private TabPage _tabPluginPage = null;
        private WrathMathHudForm _hud = null;
        private WrathMathSettings _settings = new WrathMathSettings();
        private bool _zoneDetected = false;

        void IActPluginV1.DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= OFormActMain_OnLogLineRead;
            ActGlobals.oFormActMain.OnCombatStart -= OFormActMain_OnCombatStart;
            _hud.FormClosing -= hud_FormClosing;

            _hud.Close();
            _lblPluginPage.Text = "Plugin Stopped";
        }

        void IActPluginV1.InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _lblPluginPage = pluginStatusText;
            _lblPluginPage.Text = "Plugin Started";
            var webHelp = new WrathMathHelpControl()
            {
                Dock = DockStyle.Fill
            };
            _tabPluginPage = pluginScreenSpace;
            _tabPluginPage.Controls.Clear();
            _tabPluginPage.Controls.Add(webHelp);

            _settings.LoadSettings();

            _hud = new WrathMathHudForm(_settings);
            _hud.FormClosing += hud_FormClosing;
            _hud.Show(ActGlobals.oFormActMain);
            _hud.SetDesktopLocation(_settings.WindowLocationX, _settings.WindowLocationY);
            _hud.Width = _settings.WindowWidth > 0 ? _settings.WindowWidth : 200;
            _hud.Height = _settings.WindowHeight > 0 ? _settings.WindowHeight : 200;

            ActGlobals.oFormActMain.OnLogLineRead += OFormActMain_OnLogLineRead;
            ActGlobals.oFormActMain.OnCombatStart += OFormActMain_OnCombatStart;
        }

        private void hud_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the settings automatically
            _settings.WindowLocationX = _hud.Location.X;
            _settings.WindowLocationY = _hud.Location.Y;
            _settings.WindowWidth = _hud.Width;
            _settings.WindowHeight = _hud.Height;
            _settings.SaveSettings();
        }

        private void OFormActMain_OnCombatStart(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            // On any new encounter, clear the detected state. This allows us to at least shorten the
            // parse time during the intended zone.
            _zoneDetected = false;
        }

        private void OFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            // Try to parse only when necessary
            if (DEBUG || (!isImport && logInfo.inCombat))
            {
                if (!_zoneDetected)
                {
                    _zoneDetected = (logInfo.detectedZone == "Vasty Deep: Toil and Trouble [Heroic II]");
                }
                if (DEBUG || _zoneDetected)
                {
                    // Check for beginning of a round - this will let us clear the list for easy scanning
                    if (logInfo.logLine.Contains("The combined increments of the first two removals"))
                    {
                        _hud.StartRound();
                    }
                    else
                    {
                        // Check for player dets, and add them collectively. The HUD will handle any extra logic.
                        var det = GetDetFromChatMessage(logInfo.logLine);
                        if (det != null)
                        {
                            _hud.AddDet(det);
                        }
                    }
                }
            }
        }

        private WrathMathDet GetDetFromChatMessage(string logLine)
        {
            /* Examples:
                (1632880424)[Tue Sep 28 21:53:44 2021] \aPC 78873 Reapp:Reapp\/a says to the group, "30"
                (1632880425)[Tue Sep 28 21:53:45 2021] You say to the group, "73"
                (1632945948)[Wed Sep 29 16:05:48 2021] You tell customchannel (6), "88"
            */
            WrathMathDet det = null;
            var str = logLine;
            var idx = str.IndexOf(']');
            if (idx >= 0)
            {
                str = str.Substring(idx + 2);
                if (str.StartsWith("You say to the group"))
                {
                    int number = GetDetNumberFromChatMessage(str);
                    if (number > 0)
                    {
                        det = new WrathMathDet() { Player = ActGlobals.charName, Number = number };
                    }
                }
                else if (str.StartsWith("\\aPC") && str.Contains("says to the group"))
                {
                    int number = GetDetNumberFromChatMessage(str);
                    if (number > 0)
                    {
                        var name = GetPlayerFromChatMessage(str);
                        if (name != null)
                        {
                            det = new WrathMathDet() { Player = name, Number = number };
                        }
                    }
                }
                else if (str.StartsWith($"You tell {_settings.MobDetChannel} "))
                {
                    int number = GetDetNumberFromChatMessage(str);
                    if (number > 0)
                    {
                        det = new WrathMathDet() { Player = ActGlobals.charName, Number = number, IsLabomination = true};
                    }
                }
            }
            return det;
        }

        private int GetDetNumberFromChatMessage(string message)
        {
            int number = -1;
            int idx = message.IndexOf('"');
            if (idx >= 0)
            {
                message = message.Substring(idx + 1);
                message = message.Substring(0, message.Length - 1);
                var firstWord = message.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                var strNum = new string(firstWord.Where(c => char.IsDigit(c)).ToArray());
                int.TryParse(strNum, out number);
            }
            return number;
        }

        private string GetPlayerFromChatMessage(string message)
        {
            var str = message;
            int idx = str.IndexOf(':');
            if (idx >= 0)
            {
                str = str.Substring(idx + 1);
                idx = str.IndexOf('\\');
                if (idx >= 0)
                {
                    return str.Substring(0, idx);
                }
            }
            return null;
        }
    }
}
