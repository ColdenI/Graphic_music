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
    public partial class Lines : Form
    {
        public Lines()
        {
            InitializeComponent();
        }

        private void SettinfsLinesForm_Load(object sender, EventArgs e)
        {
            button1.BackColor = Properties.Settings.Default.DLColor_volume;
            button2.BackColor = Properties.Settings.Default.DLColor_volumeR;
            button3.BackColor = Properties.Settings.Default.DLColor_volumeL;

            button4.BackColor = Properties.Settings.Default.DLColor_ch1;
            button5.BackColor = Properties.Settings.Default.DLColor_ch2;
            button6.BackColor = Properties.Settings.Default.DLColor_ch3;
            button7.BackColor = Properties.Settings.Default.DLColor_ch4;
            button8.BackColor = Properties.Settings.Default.DLColor_ch5;
            button9.BackColor = Properties.Settings.Default.DLColor_ch6;
            button10.BackColor = Properties.Settings.Default.DLColor_ch7;
            button11.BackColor = Properties.Settings.Default.DLColor_ch8;
            button12.BackColor = Properties.Settings.Default.DLColor_ch9;
            button13.BackColor = Properties.Settings.Default.DLColor_ch10;
            button14.BackColor = Properties.Settings.Default.DLColor_ch11;
            button15.BackColor = Properties.Settings.Default.DLColor_ch12;
            button16.BackColor = Properties.Settings.Default.DLColor_ch13;
            button17.BackColor = Properties.Settings.Default.DLColor_ch14;
            button18.BackColor = Properties.Settings.Default.DLColor_ch15;
            button19.BackColor = Properties.Settings.Default.DLColor_ch16;


            numericUpDown0.Value = (decimal)Properties.Settings.Default.DLWidth_volume;
            numericUpDown1.Value = (decimal)Properties.Settings.Default.DLWidth_volumeR;
            numericUpDown2.Value = (decimal)Properties.Settings.Default.DLWidth_volumeL;

            numericUpDown3.Value = (decimal)Properties.Settings.Default.DLWidth_ch1;
            numericUpDown4.Value = (decimal)Properties.Settings.Default.DLWidth_ch2;
            numericUpDown5.Value = (decimal)Properties.Settings.Default.DLWidth_ch3;
            numericUpDown6.Value = (decimal)Properties.Settings.Default.DLWidth_ch4;
            numericUpDown7.Value = (decimal)Properties.Settings.Default.DLWidth_ch5;
            numericUpDown8.Value = (decimal)Properties.Settings.Default.DLWidth_ch6;
            numericUpDown9.Value = (decimal)Properties.Settings.Default.DLWidth_ch7;
            numericUpDown10.Value = (decimal)Properties.Settings.Default.DLWidth_ch8;
            numericUpDown11.Value = (decimal)Properties.Settings.Default.DLWidth_ch9;
            numericUpDown12.Value = (decimal)Properties.Settings.Default.DLWidth_ch10;
            numericUpDown13.Value = (decimal)Properties.Settings.Default.DLWidth_ch11;
            numericUpDown14.Value = (decimal)Properties.Settings.Default.DLWidth_ch12;
            numericUpDown15.Value = (decimal)Properties.Settings.Default.DLWidth_ch13;
            numericUpDown16.Value = (decimal)Properties.Settings.Default.DLWidth_ch14;
            numericUpDown17.Value = (decimal)Properties.Settings.Default.DLWidth_ch15;
            numericUpDown18.Value = (decimal)Properties.Settings.Default.DLWidth_ch16;

        }

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            (sender as Button).BackColor = cd.Color;
        }

        private void SettinfsLinesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DLColor_volume = button1.BackColor;
            Properties.Settings.Default.DLColor_volumeR = button2.BackColor;
            Properties.Settings.Default.DLColor_volumeL = button3.BackColor;
            Properties.Settings.Default.DLColor_ch1 = button4.BackColor;
            Properties.Settings.Default.DLColor_ch2 = button5.BackColor;
            Properties.Settings.Default.DLColor_ch3 = button6.BackColor;
            Properties.Settings.Default.DLColor_ch4 = button7.BackColor;
            Properties.Settings.Default.DLColor_ch5 = button8.BackColor;
            Properties.Settings.Default.DLColor_ch6 = button9.BackColor;
            Properties.Settings.Default.DLColor_ch7 = button10.BackColor;
            Properties.Settings.Default.DLColor_ch8 = button11.BackColor;
            Properties.Settings.Default.DLColor_ch9 = button12.BackColor;
            Properties.Settings.Default.DLColor_ch10 = button13.BackColor;
            Properties.Settings.Default.DLColor_ch11 = button14.BackColor;
            Properties.Settings.Default.DLColor_ch12 = button15.BackColor;
            Properties.Settings.Default.DLColor_ch13 = button16.BackColor;
            Properties.Settings.Default.DLColor_ch14 = button17.BackColor;
            Properties.Settings.Default.DLColor_ch15 = button18.BackColor;
            Properties.Settings.Default.DLColor_ch16 = button19.BackColor;

            Properties.Settings.Default.DLWidth_volume = (float)numericUpDown0.Value;
            Properties.Settings.Default.DLWidth_volumeR = (float)numericUpDown1.Value;
            Properties.Settings.Default.DLWidth_volumeL = (float)numericUpDown2.Value;
            Properties.Settings.Default.DLWidth_ch1 = (float)numericUpDown3.Value;
            Properties.Settings.Default.DLWidth_ch2 = (float)numericUpDown4.Value;
            Properties.Settings.Default.DLWidth_ch3 = (float)numericUpDown5.Value;
            Properties.Settings.Default.DLWidth_ch4 = (float)numericUpDown6.Value;
            Properties.Settings.Default.DLWidth_ch5 = (float)numericUpDown7.Value;
            Properties.Settings.Default.DLWidth_ch6 = (float)numericUpDown8.Value;
            Properties.Settings.Default.DLWidth_ch7 = (float)numericUpDown9.Value;
            Properties.Settings.Default.DLWidth_ch8 = (float)numericUpDown10.Value;
            Properties.Settings.Default.DLWidth_ch9 = (float)numericUpDown11.Value;
            Properties.Settings.Default.DLWidth_ch10 = (float)numericUpDown12.Value;
            Properties.Settings.Default.DLWidth_ch11 = (float)numericUpDown13.Value;
            Properties.Settings.Default.DLWidth_ch12 = (float)numericUpDown14.Value;
            Properties.Settings.Default.DLWidth_ch13 = (float)numericUpDown15.Value;
            Properties.Settings.Default.DLWidth_ch14 = (float)numericUpDown16.Value;
            Properties.Settings.Default.DLWidth_ch15 = (float)numericUpDown17.Value;
            Properties.Settings.Default.DLWidth_ch16 = (float)numericUpDown18.Value;

            Properties.Settings.Default.Save();
        }
    }
}
