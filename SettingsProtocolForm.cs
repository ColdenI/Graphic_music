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
    public partial class SettingsProtocolForm : Form
    {
        public SettingsProtocolForm()
        {
            InitializeComponent();
        }

        private void SettingsProtocolForm_Load(object sender, EventArgs e)
        {
            textBox_protocol.Text = Properties.Settings.Default.protocolSerial;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.protocolSerial = textBox_protocol.Text;
            Properties.Settings.Default.Save();
        }

        private void timer_update_Tick(object sender, EventArgs e)
        {
            byte[] _arr = new byte[16];
            for (int i = 0; i < 16;i++) 
                _arr[i] = (byte)new Random().Next(0, 255);
            textBox_result.Text = MainForm.EncodeProtocol(textBox_protocol.Text, new Random().Next(0, 100), _arr);
        }

        private void checkBox_isUpdate_CheckedChanged(object sender, EventArgs e)
        {
            timer_update.Enabled = checkBox_isUpdate.Checked;
        }

        private void textBox_protocol_TextChanged(object sender, EventArgs e)
        {
            timer_update_Tick(sender, e);
        }
    }
}
