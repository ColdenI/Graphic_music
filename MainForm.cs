using System;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Graphic_music
{
    public partial class MainForm : Form
    {
        private Analyzer analyzer;
        public DrawLine DLvolume, DLvolumeR, DLvolumeL, DLch1, DLch2, DLch3, DLch4, DLch5, DLch6, DLch7, DLch8, DLch9, DLch10, DLch11, DLch12, DLch13, DLch14, DLch15, DLch16;
        private PieСhart pieСhart;
        /*
        Graphics gs;
        float oldValSph = 0;
        Color nowColorSphere = Color.Black;
        int sphereColorJumpAndGradientIndex = 0;
        float WidhtSpherePen = 2;//толщина пера

        float StandartWidhtSpherePen = 2;//стандартная толщина пера
        float MaxWidthSpherePen = 6;//максимальная толщина пера
        float SpherePosCorrect = 0f;//на сколько увеличивать круг
        bool isClearSphere = true;//очищать график за цикл?
        bool isSetSizeFoVolume = true;//изменять толщину круга в скочках
        int sphereColorJumpVal = 50;//на сколько цветов прыгать в скачках
        float SeparatorSetColor = 40; //порог скачка
        Color BackGColorSphere = Color.White;//цвет заднего фона
        Color staticColorSphere = Color.Black;//статично настроенный и сохранённый цвет
        */

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll")]
        static extern IntPtr SetFocus(IntPtr hWnd);


        private void numericUpDown_MaxWidthSpherePen_ValueChanged(object sender, EventArgs e)
        {
            pieСhart.MaxWidthPen = (float)numericUpDown_MaxWidthSpherePen.Value;
            Properties.Settings.Default.MaxWidthSpherePen = pieСhart.MaxWidthPen;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown_SpherePosCorrect_ValueChanged(object sender, EventArgs e)
        {
            pieСhart.PosCorrect = (float)numericUpDown_SpherePosCorrect.Value;
            Properties.Settings.Default.SpherePosCorrect = pieСhart.PosCorrect;
            Properties.Settings.Default.Save();
        }

        private void checkBox_isClearSphere_CheckedChanged(object sender, EventArgs e)
        {
            pieСhart.isClear = checkBox_isClearSphere.Checked;
            Properties.Settings.Default.isClearSphere = pieСhart.isClear;
            Properties.Settings.Default.Save();
        }

        private void checkBox_isSetSizeFoVolume_CheckedChanged(object sender, EventArgs e)
        {
            pieСhart.isSetSizeFoVolume = checkBox_isSetSizeFoVolume.Checked;
            Properties.Settings.Default.isSetSizeFoVolume = pieСhart.isSetSizeFoVolume;
            Properties.Settings.Default.Save();
            if (!pieСhart.isSetSizeFoVolume) pieСhart.WidthPen = pieСhart.StandartWidthPen;
        }

        private void numericUpDown_sphereColorJumpVal_ValueChanged(object sender, EventArgs e)
        {
            pieСhart.ColorJumpVal = (int)numericUpDown_sphereColorJumpVal.Value;
            Properties.Settings.Default.sphereColorJumpVal = pieСhart.ColorJumpVal;
            Properties.Settings.Default.Save();
        }

        private void button_openSettingsLines_Click(object sender, EventArgs e)
        {
            new Lines().ShowDialog();
            LoadLinesGrSerrings();
        }

        private void numericUpDown_SeparatorSetColor_ValueChanged(object sender, EventArgs e)
        {
            pieСhart.SeparatorSetColor = (float)numericUpDown_SeparatorSetColor.Value;
            Properties.Settings.Default.SeparatorSetColor = pieСhart.SeparatorSetColor;
            Properties.Settings.Default.Save();
        }

        private void button_BackGColorSphere_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            pieСhart.BackGColor = cd.Color;
            Properties.Settings.Default.BackGColorSphere = cd.Color;
            Properties.Settings.Default.Save();
        }

        private void button_staticColorSphere_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            pieСhart.StaticColor = cd.Color;
            pieСhart.NowColor = pieСhart.StaticColor;
            //comboBox_modeSphere.SelectedIndex = 18;
            Properties.Settings.Default.staticColorSphere = pieСhart.StaticColor;
            Properties.Settings.Default.Save();
        }

        private void toolStripButton_serialEnable_Click(object sender, EventArgs e)
        {

            if (!serialPort1.IsOpen)
            {
                if (toolStripComboBox_serialPort.Text == "") { MessageBox.Show("Specify the serial connection port!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (toolStripComboBox_serialSpeed.Text == "") { MessageBox.Show("Specify the speed of the Serial port!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                serialPort1.PortName = toolStripComboBox_serialPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(toolStripComboBox_serialSpeed.Text);
                serialPort1.Open();
                toolStripButton_serialEnable.Text = "Stop";
                toolStripComboBox_serialSpeed.Enabled = false;
                toolStripComboBox_serialPort.Enabled = false;

                Properties.Settings.Default.oldSerialPort = serialPort1.PortName;
                Properties.Settings.Default.Save();
            }
            else
            {
                toolStripButton_serialEnable.Text = "Start";
                toolStripComboBox_serialSpeed.Enabled = true;
                toolStripComboBox_serialPort.Enabled = true;
                serialPort1.Close();
            }
        }

        private void toolStripButton_openSettingsProtocol_Click(object sender, EventArgs e)
        {
            new SettingsProtocolForm().ShowDialog();
        }

        private void button_engine_BassEnable_Click(object sender, EventArgs e)
        {
            analyzer.Enable = !analyzer.Enable;
            //comboBox1.Enabled = !analyzer.Enable;
            if (analyzer.Enable) button_engine_BassEnable.Text = "Stop";
            else button_engine_BassEnable.Text = "Start";
            DrawLine.Clear();
            pieСhart.Clear();
        }

        private void comboBox_modeSphere_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startGrModeIndex = comboBox_modeSphere.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void comboBox_sphereColorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startGrColorModeIndex = comboBox_sphereColorMode.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void button_bigGraph_Click(object sender, EventArgs e)
        {
            BigForm bf = new BigForm();
            bf.FormClosed += Bf_FormClosed;
            bf.SizeChanged += Bf_SizeChanged;
            bf.TopMost = true;
            button_bigGraph.Enabled = false;
            pieСhart.Clear();
            pieСhart.PictureBox = bf.pictureBox;
            bf.Show();
        }

        private void Bf_SizeChanged(object sender, EventArgs e)
        {
            (sender as Form).Size = new Size((sender as Form).Size.Width, (sender as Form).Size.Width);
            pieСhart.Init();
        }

        private void Bf_FormClosed(object sender, FormClosedEventArgs e)
        {
            pieСhart.PictureBox = pictureBox2;
            button_bigGraph.Enabled = true;
        }

        private void button_takeOutHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Control the removed window.\r\nArrows/mouse - position\r\n- / + - size\r\nSpace - on/off always in front\r\nEscape - close");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.startDeviceName = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            //Console.WriteLine(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            Properties.Settings.Default.Save();
        }

        private void toolStripButton_openSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();

            timer_autoUpdateSerialPortsList.Enabled = Properties.Settings.Default.isAutoUpdateSerialPortsList;
            timer_autoUpdateSerialPortsList.Interval = Properties.Settings.Default.AutoUpdateSerialPortsList_Interval;
        }

        private void toolStripButton_openAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void timer_autoUpdateSerialPortsList_Tick(object sender, EventArgs e)
        {
            toolStripComboBox_serialPort.Items.Clear();
            toolStripComboBox_serialPort.Items.AddRange(SerialPort.GetPortNames());
        }

        private void button_BGColorgrLine_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.Cancel) return;
            DrawLine.BackGColor = cd.Color;
            DrawLine.Clear();
            Properties.Settings.Default.BackGColorLines = cd.Color;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown_speed_grLine_ValueChanged(object sender, EventArgs e)
        {
            DrawLine.Speed = (float)numericUpDown_speed_grLine.Value;
            Properties.Settings.Default.SpeedLines = DrawLine.Speed;
            Properties.Settings.Default.Save();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Label[] labels = { label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18 };
            foreach (System.Windows.Forms.Label i in labels)
                i.Font = new Font(i.Font, FontStyle.Bold);

            DLch1.Visible = true;
            DLch2.Visible = true;
            DLch3.Visible = true;
            DLch4.Visible = true;
            DLch5.Visible = true;
            DLch6.Visible = true;
            DLch7.Visible = true;
            DLch8.Visible = true;
            DLch9.Visible = true;
            DLch10.Visible = true;
            DLch11.Visible = true;
            DLch12.Visible = true;
            DLch13.Visible = true;
            DLch14.Visible = true;
            DLch15.Visible = true;
            DLch16.Visible = true;
            DLvolume.Visible = true;
            DLvolumeR.Visible = true;
            DLvolumeL.Visible = true;

            if (!checkedListBox1.CheckedItems.Contains("Volume")) DLvolume.Visible = false;
            if (!checkedListBox1.CheckedItems.Contains("Volume R")) DLvolumeR.Visible = false;
            if (!checkedListBox1.CheckedItems.Contains("Volume L")) DLvolumeL.Visible = false;

            if (!checkedListBox1.CheckedItems.Contains("1 Hz")) { DLch1.Visible = false; labels[0].Font = new Font(labels[0].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("30 Hz")) { DLch2.Visible = false; labels[1].Font = new Font(labels[1].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("40 Hz")) { DLch3.Visible = false; labels[2].Font = new Font(labels[2].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("60 Hz")) { DLch4.Visible = false; labels[3].Font = new Font(labels[3].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("100 Hz")) { DLch5.Visible = false; labels[4].Font = new Font(labels[4].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("200 Hz")) { DLch6.Visible = false; labels[5].Font = new Font(labels[5].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("300 Hz")) { DLch7.Visible = false; labels[6].Font = new Font(labels[6].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("500 Hz")) { DLch8.Visible = false; labels[7].Font = new Font(labels[7].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("900 Hz")) { DLch9.Visible = false; labels[8].Font = new Font(labels[8].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("1,5k Hz")) { DLch10.Visible = false; labels[9].Font = new Font(labels[9].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("2,4k Hz")) { DLch11.Visible = false; labels[10].Font = new Font(labels[10].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("3,8k Hz")) { DLch12.Visible = false; labels[11].Font = new Font(labels[11].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("5,9k Hz")) { DLch13.Visible = false; labels[12].Font = new Font(labels[12].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("9,5k Hz")) { DLch14.Visible = false; labels[13].Font = new Font(labels[13].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("15k Hz")) { DLch15.Visible = false; labels[14].Font = new Font(labels[14].Font, FontStyle.Regular); }
            if (!checkedListBox1.CheckedItems.Contains("20k Hz")) { DLch16.Visible = false; labels[15].Font = new Font(labels[15].Font, FontStyle.Regular); }

        }

        private void numericUpDown_StandartWidhtSpherePen_ValueChanged(object sender, EventArgs e)
        {
            pieСhart.StandartWidthPen = (float)numericUpDown_StandartWidhtSpherePen.Value;
            Properties.Settings.Default.StandartWidhtSpherePen = pieСhart.StandartWidthPen;
            Properties.Settings.Default.Save();
        }

        public MainForm()
        {
            Console.WriteLine("Create MainForm");
            InitializeComponent();
            analyzer = new Analyzer(progressBar_l, progressBar_r, comboBox1, this);
            DrawLine.pictureBox = pictureBox1;
            PieСhart.mainForm = this;
            pieСhart = new PieСhart(pictureBox2);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loading Form...");
            this.Hide();
            Thread.Sleep(3000);
            this.Show();
            //SwitchDatabase(this.Text);
            this.TopMost = true;
            this.TopMost = false;

            if (analyzer.Enable) button_engine_BassEnable.Text = "Stop";
            else button_engine_BassEnable.Text = "Start";

            if (Properties.Settings.Default.isTestModes)
            {
                comboBox_modeSphere.Items.Add("Test mode 1");
            }

            comboBox_sphereColorMode.SelectedIndex = Properties.Settings.Default.startGrColorModeIndex;
            if (Properties.Settings.Default.startGrModeIndex >= comboBox_modeSphere.Items.Count) comboBox_modeSphere.SelectedIndex = 0;
            else comboBox_modeSphere.SelectedIndex = Properties.Settings.Default.startGrModeIndex;

            DrawLine.BackGColor = Properties.Settings.Default.BackGColorLines;
            DrawLine.Speed = Properties.Settings.Default.SpeedLines;
            numericUpDown_speed_grLine.Value = (decimal)DrawLine.Speed;

            pieСhart.StandartWidthPen = Properties.Settings.Default.StandartWidhtSpherePen;
            numericUpDown_StandartWidhtSpherePen.Value = (decimal)pieСhart.StandartWidthPen;
            pieСhart.MaxWidthPen = Properties.Settings.Default.MaxWidthSpherePen;
            numericUpDown_MaxWidthSpherePen.Value = (decimal)pieСhart.MaxWidthPen;
            pieСhart.PosCorrect = Properties.Settings.Default.SpherePosCorrect;
            numericUpDown_SpherePosCorrect.Value = (decimal)pieСhart.PosCorrect;
            pieСhart.isClear = Properties.Settings.Default.isClearSphere;
            checkBox_isClearSphere.Checked = pieСhart.isClear;
            pieСhart.isSetSizeFoVolume = Properties.Settings.Default.isSetSizeFoVolume;
            checkBox_isSetSizeFoVolume.Checked = pieСhart.isSetSizeFoVolume;
            pieСhart.ColorJumpVal = Properties.Settings.Default.sphereColorJumpVal;
            numericUpDown_sphereColorJumpVal.Value = (decimal)pieСhart.ColorJumpVal;
            pieСhart.SeparatorSetColor = Properties.Settings.Default.SeparatorSetColor;
            numericUpDown_SeparatorSetColor.Value = (decimal)pieСhart.SeparatorSetColor;
            pieСhart.BackGColor = Properties.Settings.Default.BackGColorSphere;
            pieСhart.StaticColor = Properties.Settings.Default.staticColorSphere;

            DrawLine.Init();
            checkedListBox1.SetItemChecked(0, true);

            #region Load Lines Settings
            DLvolume = new DrawLine(Properties.Settings.Default.DLColor_volume, Properties.Settings.Default.DLWidth_volume, true);
            DLvolumeL = new DrawLine(Properties.Settings.Default.DLColor_volumeL, Properties.Settings.Default.DLWidth_volumeL);
            DLvolumeR = new DrawLine(Properties.Settings.Default.DLColor_volumeR, Properties.Settings.Default.DLWidth_volumeR);

            DLch1 = new DrawLine(Properties.Settings.Default.DLColor_ch1, Properties.Settings.Default.DLWidth_ch1);
            DLch2 = new DrawLine(Properties.Settings.Default.DLColor_ch2, Properties.Settings.Default.DLWidth_ch2);
            DLch3 = new DrawLine(Properties.Settings.Default.DLColor_ch3, Properties.Settings.Default.DLWidth_ch3);
            DLch4 = new DrawLine(Properties.Settings.Default.DLColor_ch4, Properties.Settings.Default.DLWidth_ch4);
            DLch5 = new DrawLine(Properties.Settings.Default.DLColor_ch5, Properties.Settings.Default.DLWidth_ch5);
            DLch6 = new DrawLine(Properties.Settings.Default.DLColor_ch6, Properties.Settings.Default.DLWidth_ch6);
            DLch7 = new DrawLine(Properties.Settings.Default.DLColor_ch7, Properties.Settings.Default.DLWidth_ch7);
            DLch8 = new DrawLine(Properties.Settings.Default.DLColor_ch8, Properties.Settings.Default.DLWidth_ch8);
            DLch9 = new DrawLine(Properties.Settings.Default.DLColor_ch9, Properties.Settings.Default.DLWidth_ch9);
            DLch10 = new DrawLine(Properties.Settings.Default.DLColor_ch10, Properties.Settings.Default.DLWidth_ch10);
            DLch11 = new DrawLine(Properties.Settings.Default.DLColor_ch11, Properties.Settings.Default.DLWidth_ch11);
            DLch12 = new DrawLine(Properties.Settings.Default.DLColor_ch12, Properties.Settings.Default.DLWidth_ch12);
            DLch13 = new DrawLine(Properties.Settings.Default.DLColor_ch13, Properties.Settings.Default.DLWidth_ch13);
            DLch14 = new DrawLine(Properties.Settings.Default.DLColor_ch14, Properties.Settings.Default.DLWidth_ch14);
            DLch15 = new DrawLine(Properties.Settings.Default.DLColor_ch15, Properties.Settings.Default.DLWidth_ch15);
            DLch16 = new DrawLine(Properties.Settings.Default.DLColor_ch16, Properties.Settings.Default.DLWidth_ch16);

            LoadLinesGrSerrings();
            #endregion

            // load auto update serial port list
            timer_autoUpdateSerialPortsList.Enabled = Properties.Settings.Default.isAutoUpdateSerialPortsList;
            timer_autoUpdateSerialPortsList.Interval = Properties.Settings.Default.AutoUpdateSerialPortsList_Interval;

            // load and Auto start
            //string _loadDeviceName = Properties.Settings.Default.startDeviceName.Split(new[] { " - " }, StringSplitOptions.None)[1];
            string _loadDeviceName = Properties.Settings.Default.startDeviceName;
            //Console.WriteLine(_loadDeviceName);
            if (comboBox1.Items.Contains(_loadDeviceName))
            {
                /*
                List<string> list = new List<string>();
                list.AddRange((IEnumerable<string>)comboBox1.Items);
                for (int i = 0; i < list.Count; i++) list[i] = list[i].Split(new[] { " - " }, StringSplitOptions.None)[1];
                comboBox1.SelectedIndex = list.IndexOf(_loadDeviceName);
                */
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(_loadDeviceName);
            }
            if (Properties.Settings.Default.isAutoStart) button_engine_BassEnable_Click(this, new EventArgs());

            // load Serial Port Settings
            toolStripComboBox_serialSpeed.SelectedIndex = toolStripComboBox_serialSpeed.Items.IndexOf(Properties.Settings.Default.SerialSpeed.ToString());
            toolStripComboBox_serialPort.Items.AddRange(SerialPort.GetPortNames());
            string _loadSerialPort = Properties.Settings.Default.oldSerialPort;
            if (_loadSerialPort != "" && toolStripComboBox_serialPort.Items.Contains(_loadSerialPort)) toolStripComboBox_serialPort.Text = _loadSerialPort;
            if (Properties.Settings.Default.isAutoStartSerial) toolStripButton_serialEnable_Click(sender, e);
        }

        public void LoadLinesGrSerrings()
        {
            DLvolume.Color = Properties.Settings.Default.DLColor_volume; DLvolume.Width = Properties.Settings.Default.DLWidth_volume;
            DLvolumeL.Color = Properties.Settings.Default.DLColor_volumeL; DLvolumeL.Width = Properties.Settings.Default.DLWidth_volumeL;
            DLvolumeR.Color = Properties.Settings.Default.DLColor_volumeR; DLvolumeR.Width = Properties.Settings.Default.DLWidth_volumeR;

            DLch1.Color = Properties.Settings.Default.DLColor_ch1; DLch1.Width = Properties.Settings.Default.DLWidth_ch1;
            DLch2.Color = Properties.Settings.Default.DLColor_ch2; DLch2.Width = Properties.Settings.Default.DLWidth_ch2;
            DLch3.Color = Properties.Settings.Default.DLColor_ch3; DLch3.Width = Properties.Settings.Default.DLWidth_ch3;
            DLch4.Color = Properties.Settings.Default.DLColor_ch4; DLch4.Width = Properties.Settings.Default.DLWidth_ch4;
            DLch5.Color = Properties.Settings.Default.DLColor_ch5; DLch5.Width = Properties.Settings.Default.DLWidth_ch5;
            DLch6.Color = Properties.Settings.Default.DLColor_ch6; DLch6.Width = Properties.Settings.Default.DLWidth_ch6;
            DLch7.Color = Properties.Settings.Default.DLColor_ch7; DLch7.Width = Properties.Settings.Default.DLWidth_ch7;
            DLch8.Color = Properties.Settings.Default.DLColor_ch8; DLch8.Width = Properties.Settings.Default.DLWidth_ch8;
            DLch9.Color = Properties.Settings.Default.DLColor_ch9; DLch9.Width = Properties.Settings.Default.DLWidth_ch9;
            DLch10.Color = Properties.Settings.Default.DLColor_ch10; DLch10.Width = Properties.Settings.Default.DLWidth_ch10;
            DLch11.Color = Properties.Settings.Default.DLColor_ch11; DLch11.Width = Properties.Settings.Default.DLWidth_ch11;
            DLch12.Color = Properties.Settings.Default.DLColor_ch12; DLch12.Width = Properties.Settings.Default.DLWidth_ch12;
            DLch13.Color = Properties.Settings.Default.DLColor_ch13; DLch13.Width = Properties.Settings.Default.DLWidth_ch13;
            DLch14.Color = Properties.Settings.Default.DLColor_ch14; DLch14.Width = Properties.Settings.Default.DLWidth_ch14;
            DLch15.Color = Properties.Settings.Default.DLColor_ch15; DLch15.Width = Properties.Settings.Default.DLWidth_ch15;
            DLch16.Color = Properties.Settings.Default.DLColor_ch16; DLch16.Width = Properties.Settings.Default.DLWidth_ch16;

            label3.ForeColor = DLch1.Color;
            label4.ForeColor = DLch2.Color;
            label5.ForeColor = DLch3.Color;
            label6.ForeColor = DLch4.Color;
            label7.ForeColor = DLch5.Color;
            label8.ForeColor = DLch6.Color;
            label9.ForeColor = DLch7.Color;
            label10.ForeColor = DLch8.Color;
            label11.ForeColor = DLch9.Color;
            label12.ForeColor = DLch10.Color;
            label13.ForeColor = DLch11.Color;
            label14.ForeColor = DLch12.Color;
            label15.ForeColor = DLch13.Color;
            label16.ForeColor = DLch14.Color;
            label17.ForeColor = DLch15.Color;
            label18.ForeColor = DLch16.Color;


        }

        public void Draw(float volume, byte[] ch)
        {
            DLvolume.Value = volume;
            DrawLine.Draw();
            pieСhart.Update(volume);
            switch (comboBox_modeSphere.SelectedIndex)
            {
                case 0: pieСhart.DrawSphere(volume, 0, 100); break;
                case 1: pieСhart.DrawSphere(ch[1 - 1], 0, 256); break;
                case 2: pieСhart.DrawSphere(ch[2 - 1], 0, 256); break;
                case 3: pieСhart.DrawSphere(ch[3 - 1], 0, 256); break;
                case 4: pieСhart.DrawSphere(ch[4 - 1], 0, 256); break;
                case 5: pieСhart.DrawSphere(ch[5 - 1], 0, 256); break;
                case 6: pieСhart.DrawSphere(ch[6 - 1], 0, 256); break;
                case 7: pieСhart.DrawSphere(ch[7 - 1], 0, 256); break;
                case 8: pieСhart.DrawSphere(ch[8 - 1], 0, 256); break;
                case 9: pieСhart.DrawSphere(ch[9 - 1], 0, 256); break;
                case 10: pieСhart.DrawSphere(ch[10 - 1], 0, 256); break;
                case 11: pieСhart.DrawSphere(ch[11 - 1], 0, 256); break;
                case 12: pieСhart.DrawSphere(ch[12 - 1], 0, 256); break;
                case 13: pieСhart.DrawSphere(ch[13 - 1], 0, 256); break;
                case 14: pieСhart.DrawSphere(ch[14 - 1], 0, 256); break;
                case 15: pieСhart.DrawSphere(ch[15 - 1], 0, 256); break;
                case 16: pieСhart.DrawSphere(ch[16 - 1], 0, 256); break;
                case 17: pieСhart.ChLinesDraw(volume, ch); break;
                case 18: pieСhart.CurveDraw(volume, ch); break;
                case 19: pieСhart.CurveLinesDraw(volume, ch); break;

            }
            if (comboBox_modeSphere.SelectedIndex == comboBox_modeSphere.Items.IndexOf("Test mode 1")) pieСhart.TestCurveDraw(volume, ch);

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(EncodeProtocol(Properties.Settings.Default.protocolSerial, volume, ch));
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            analyzer.Enable = false;
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DrawLine.Clear();
        }

        public static long map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public static string EncodeProtocol(string protocol, float volume, byte[] ch)
        {
            string res = protocol;
            if (protocol.Contains("<volume>")) res = res.Replace("<volume>", volume.ToString());
            for (int i = 1; i <= 16; i++)
            {
                if (protocol.Contains($"<freq{i}>")) res = res.Replace($"<freq{i}>", ch[i - 1].ToString());
            }
            return res;
        }

        public static Color colorWheel(int color)
        {
            // включает цвет по цветовому колесу, принимает 0-1530
            int _r = 0, _g = 0, _b = 0;
            if (color <= 255)
            {                       // красный макс, зелёный растёт
                _r = 255;
                _g = color;
                _b = 0;
            }
            else if (color > 255 && color <= 510)
            {   // зелёный макс, падает красный
                _r = 510 - color;
                _g = 255;
                _b = 0;
            }
            else if (color > 510 && color <= 765)
            {   // зелёный макс, растёт синий
                _r = 0;
                _g = 255;
                _b = color - 510;
            }
            else if (color > 765 && color <= 1020)
            {  // синий макс, падает зелёный
                _r = 0;
                _g = 1020 - color;
                _b = 255;
            }
            else if (color > 1020 && color <= 1275)
            {   // синий макс, растёт красный
                _r = color - 1020;
                _g = 0;
                _b = 255;
            }
            else if (color > 1275 && color <= 1530)
            { // красный макс, падает синий
                _r = 255;
                _g = 0;
                _b = 1530 - color;
            }

            return Color.FromArgb(255 - _r, 255 - _g, 255 - _b);
        }

        public static void SwitchDatabase(string mainWindowTitle)
        {
            try
            {
                bool launched = false;

                Process[] processList = Process.GetProcesses();

                foreach (Process theProcess in processList)
                {
                    ShowWindow(theProcess.MainWindowHandle, 2);
                }

                foreach (Process theProcess in processList)
                {
                    if (theProcess.MainWindowTitle.ToUpper().Contains(mainWindowTitle.ToUpper()))
                    {
                        ShowWindow(theProcess.MainWindowHandle, 9);
                        launched = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //ThrowStandardException(ex);
                MessageBox.Show(ex.Message);
            }
        }

    }
}
