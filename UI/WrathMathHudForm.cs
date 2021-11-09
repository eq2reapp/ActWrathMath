using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace ACT_Plugin
{
    public partial class WrathMathHudForm : Form
    {
        private class DetCombo
        {
            public WrathMathDet First;
            public WrathMathDet Second;
        }

        private WrathMathSettings _settings = null;
        private List<WrathMathDet> _playerDets = new List<WrathMathDet>();
        private WrathMathDet _mobDet = null;
        private bool _started = false;
        private bool _matched = false;
        private System.Timers.Timer _timerProgress = null;

        public WrathMathHudForm(WrathMathSettings settings)
        {
            InitializeComponent();

            _settings = settings;
        }

        private void WrathMathHud_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = $"ACT Wrath Math v{version.Major}.{version.Minor}.{version.Build}{(WrathMathMain.DEBUG ? " - [DEBUG]" : "")}";

            lblNext.Visible = false;
            progressRound.Visible = false;
        }

        private void WrathMathHudForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopProgressTimer();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            var frmHelp = new WrathMathHelpForm();
            frmHelp.ShowDialog(this);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            _settings.EditSettings();
        }

        private void StartProgressTimer()
        {
            if (_timerProgress == null)
            {
                _timerProgress = new System.Timers.Timer(1000);
                _timerProgress.AutoReset = true;
                _timerProgress.Elapsed += timerProgress_Elapsed;
                _timerProgress.Start();
            }
        }

        private void StopProgressTimer()
        {
            if (_timerProgress != null)
            {
                _timerProgress.Elapsed -= timerProgress_Elapsed;
                _timerProgress.Stop();
                _timerProgress.Dispose();
                _timerProgress = null;
            }
        }

        private void timerProgress_Elapsed(object sender, ElapsedEventArgs e)
        {
            AdvanceProgress();
        }

        private void AdvanceProgress()
        {
            if (this.InvokeRequired)
            {
                Action safeUpdate = delegate { AdvanceProgress(); };
                this.Invoke(safeUpdate);
            }
            else
            {
                progressRound.PerformStep();
                if (progressRound.Value == progressRound.Maximum)
                {
                    lblNext.Text = $"Next due anytime";
                }
                else
                {
                    lblNext.Text = $"Next in about { Math.Max(0, progressRound.Maximum - progressRound.Value) }s";
                }
                progressRound.Visible = true;
                lblNext.Visible = true;
            }
        }

        public void Reset()
        {
            StopProgressTimer();
            progressRound.Value = 0;

            _playerDets.Clear();
            _started = false;
            _mobDet = null;
            _matched = false;
            RefreshCombos();

            // Clear the old macro file so that someone cannot prematurely execute from the last round
            if (_settings.CreateMacro && !string.IsNullOrEmpty(_settings.MacroFile))
            {
                File.WriteAllText(_settings.MacroFile, "");
            }
        }

        public void StartRound()
        {
            Reset();
            _started = true;
        }

        public void EndRound()
        {
            progressRound.Value = 0;
            StartProgressTimer();
        }

        public void AddDet(WrathMathDet mathDet)
        {
            if (_started)
            {
                if (mathDet.IsLabomination)
                {
                    _mobDet = mathDet;
                    if (_settings.ConfirmMob)
                    {
                        ActGlobals.oFormActMain.TTS("Mob");
                    }
                }
                else
                {
                    _playerDets.Add(mathDet);
                    if (mathDet.Player.Equals(ActGlobals.charName) && _settings.ConfirmYou)
                    {
                        ActGlobals.oFormActMain.TTS("You");
                    }
                }
                RefreshCombos();
            }
        }

        public void RefreshCombos()
        {
            StringBuilder sb = new StringBuilder();
            if (_playerDets.Count > 1)
            {
                var combos = new List<DetCombo>();
                CollectCombos(_playerDets.ToArray(), combos);
                combos.Sort((x, y) => -(x.First.Number + x.Second.Number).CompareTo(y.First.Number + y.Second.Number));
                foreach (var combo in combos)
                {
                    var total = combo.First.Number + combo.Second.Number;
                    if (_mobDet != null && _mobDet.Number == total)
                    {
                        sb.AppendLine("------------------------------------------------------------------------");
                        sb.AppendLine($"  {total}:   {combo.First.Player}  +  {combo.Second.Player}");
                        sb.AppendLine("------------------------------------------------------------------------");
                        if (!_matched)
                        {
                            _matched = true;

                            if (_settings.AnnouncePlayers)
                            {
                                ActGlobals.oFormActMain.TTS($"Cure {combo.First.Player} and {combo.Second.Player}");
                            }
                            if (_settings.CreateMacro && !string.IsNullOrEmpty(_settings.MacroFile))
                            {
                                var macroText = _settings.MacroCommands
                                                    .Replace("PLAYER1", combo.First.Player)
                                                    .Replace("PLAYER2", combo.Second.Player);
                                File.WriteAllText(_settings.MacroFile, macroText);
                                SystemSounds.Beep.Play();
                            }
                        }
                    }
                    else
                    {
                        sb.AppendLine($"  {total}:   {combo.First.Player}  +  {combo.Second.Player}");
                    }
                }
            }
            txtResults.Text = sb.ToString();

            if (_playerDets.Count == 6 || _matched)
            {
                txtResults.BackColor = Color.FromArgb(220, 255, 220);
            }
            else
            {
                txtResults.BackColor = SystemColors.Window;
            }
        }

        private void CollectCombos(WrathMathDet[] dets, List<DetCombo> combos)
        {
            for (int i = 1; i < dets.Length; i++)
            {
                combos.Add(new DetCombo() { First = dets[0], Second = dets[i] });
            }
            if (dets.Length > 2)
            {
                CollectCombos(dets.Skip(1).Take(99999).ToArray(), combos);
            }
        }
    }
}
