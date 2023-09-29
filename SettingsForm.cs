using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_music
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBox_isAutoStartApp.Checked = Properties.Settings.Default.isAutoStartApp;
            checkBox_isAutoStartEngine.Checked = Properties.Settings.Default.isAutoStart;
            checkBox_isAutoStartSerial.Checked = Properties.Settings.Default.isAutoStartSerial;
            checkBox_isAutoUpdateSerialList.Checked = Properties.Settings.Default.isAutoUpdateSerialPortsList;
            numericUpDown_AutoUpdateSerialListInterval.Value = Properties.Settings.Default.AutoUpdateSerialPortsList_Interval;
            comboBox_getVolumeIndex.SelectedIndex = Properties.Settings.Default.GetVolumeIndex;
            checkBox_isAddTestModes.Checked = Properties.Settings.Default.isTestModes;
        }

        private void checkBox_isAutoStartSerial_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoStartSerial = checkBox_isAutoStartSerial.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_isAutoUpdateSerialList_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoUpdateSerialPortsList = checkBox_isAutoUpdateSerialList.Checked;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown_AutoUpdateSerialListInterval_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpdateSerialPortsList_Interval = (int)numericUpDown_AutoUpdateSerialListInterval.Value;
            Properties.Settings.Default.Save();
        }

        private void checkBox_isAutoStartEngine_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isAutoStart = checkBox_isAutoStartEngine.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox_isAddTestModes_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.isTestModes = checkBox_isAddTestModes.Checked;
            Properties.Settings.Default.Save();
        }

        private void comboBox_getVolumeIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GetVolumeIndex = comboBox_getVolumeIndex.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
