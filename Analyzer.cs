using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Windows.Threading;
using Un4seen.Bass;
using Un4seen.BassWasapi;

namespace Graphic_music
{

    internal class Analyzer
    {
        MainForm mainForm;
        private bool _enable;               //enabled status
        private DispatcherTimer _t;         //timer that refreshes the display
        private float[] _fft;               //buffer for fft data
        private ProgressBar _l, _r;         //progressbars for left and right channel intensity
        private WASAPIPROC _process;        //callback function to obtain data
        private int _lastlevel;             //last output level
        private int _hanctr;                //last output level counter
        public List<byte> _spectrumdata;   //spectrum data buffer
        //private Spectrum _spectrum;         //spectrum dispay control
        private ComboBox _devicelist;       //device list
        private bool _initialized;          //initialized flag
        private int devindex;               //used device index

        private int _lines = 16;            // number of spectrum lines

        //ctor
        public Analyzer(ProgressBar left, ProgressBar right, ComboBox devicelist, MainForm mainForm)
        {
            _fft = new float[1024];
            _lastlevel = 0;
            _hanctr = 0;
            _t = new DispatcherTimer();
            _t.Tick += _t_Tick;
            _t.Interval = TimeSpan.FromMilliseconds(25); //40hz refresh rate
            _t.IsEnabled = false;
            _l = left;
            _r = right;
            _l.Minimum = 0;
            _r.Minimum = 0;
            _r.Maximum = ushort.MaxValue;
            _l.Maximum = ushort.MaxValue;
            _process = new WASAPIPROC(Process);
            _spectrumdata = new List<byte>();
            //_spectrum = spectrum;
            _devicelist = devicelist;
            _initialized = false;
            Init();
            this.mainForm = mainForm as MainForm;
        }

        // Serial port for arduino output
        public SerialPort Serial { get; set; }

        // flag for display enable
        public bool DisplayEnable { get; set; }

        //flag for enabling and disabling program functionality
        public bool Enable
        {
            get { return _enable; }
            set
            {
                _enable = value;
                if (value)
                {
                    if (!_initialized)
                    {
                        var array = (_devicelist.Items[_devicelist.SelectedIndex] as string).Split(' ');
                        devindex = Convert.ToInt32(array[0]);
                        bool result = BassWasapi.BASS_WASAPI_Init(devindex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, _process, IntPtr.Zero);
                        if (!result)
                        {
                            var error = Bass.BASS_ErrorGetCode();
                            MessageBox.Show(error.ToString());
                        }
                        else
                        {
                            _initialized = true;
                            _devicelist.Enabled = false;
                        }
                    }
                    BassWasapi.BASS_WASAPI_Start();
                }
                else
                {
                    BassWasapi.BASS_WASAPI_Stop(true);
                }
                System.Threading.Thread.Sleep(500);
                _t.IsEnabled = value;
            }
        }

        // initialization
        private void Init()
        {
            bool result = false;
            for (int i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
            {
                var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                if (device.IsEnabled && device.IsLoopback)
                {
                    _devicelist.Items.Add(string.Format("{0} - {1}", i, device.name));
                }
            }
            _devicelist.SelectedIndex = 0;
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
            result = Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            if (!result) throw new Exception("Init Error");
        }

        //timer 
        private void _t_Tick(object sender, EventArgs e)
        {
            int ret = BassWasapi.BASS_WASAPI_GetData(_fft, (int)BASSData.BASS_DATA_FFT2048); //get channel fft data
            if (ret < -1) return;
            int x, y;
            int b0 = 0;

            //computes the spectrum data, the code is taken from a bass_wasapi sample.
            for (x=0; x<_lines; x++)
            {
                float peak = 0;
                int b1 = (int)Math.Pow(2, x * 10.0 / (_lines - 1));
                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;
                for (;b0<b1;b0++)
                {
                    if (peak < _fft[1 + b0]) peak = _fft[1 + b0];
                }
                y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                if (y > 255) y = 255;
                if (y < 0) y = 0;
                _spectrumdata.Add((byte)y);
                //Console.Write("{0, 3} ", y);
            }

            int level = BassWasapi.BASS_WASAPI_GetLevel();
            _l.Value = Utils.LowWord32(level);
            _r.Value = Utils.HighWord32(level);
            if (level == _lastlevel && level != 0) _hanctr++;
            _lastlevel = level;

            mainForm.DLvolumeL.Value = (float)MainForm.map((long)_l.Value, 0, 65555, 0, 100);
            mainForm.DLvolumeR.Value = (float)MainForm.map((long)_r.Value, 0, 65555, 0, 100);

            //if (DisplayEnable) _spectrum.Set(_spectrumdata);
            mainForm.trackBar1.Value = _spectrumdata[0];
            mainForm.trackBar2.Value = _spectrumdata[1];
            mainForm.trackBar3.Value = _spectrumdata[2];
            mainForm.trackBar4.Value = _spectrumdata[3];
            mainForm.trackBar5.Value = _spectrumdata[4];
            mainForm.trackBar6.Value = _spectrumdata[5];
            mainForm.trackBar7.Value = _spectrumdata[6];
            mainForm.trackBar8.Value = _spectrumdata[7];
            mainForm.trackBar9.Value = _spectrumdata[8];
            mainForm.trackBar10.Value = _spectrumdata[9];
            mainForm.trackBar11.Value = _spectrumdata[10];
            mainForm.trackBar12.Value = _spectrumdata[11];
            mainForm.trackBar13.Value = _spectrumdata[12];
            mainForm.trackBar14.Value = _spectrumdata[13];
            mainForm.trackBar15.Value = _spectrumdata[14];
            mainForm.trackBar16.Value = _spectrumdata[15];

            mainForm.DLch1.Value = _spectrumdata[0];
            mainForm.DLch2.Value = _spectrumdata[1];
            mainForm.DLch3.Value = _spectrumdata[2];
            mainForm.DLch4.Value = _spectrumdata[3];
            mainForm.DLch5.Value = _spectrumdata[4];
            mainForm.DLch6.Value = _spectrumdata[5];
            mainForm.DLch7.Value = _spectrumdata[6];
            mainForm.DLch8.Value = _spectrumdata[7];
            mainForm.DLch9.Value = _spectrumdata[8];
            mainForm.DLch10.Value = _spectrumdata[9];
            mainForm.DLch11.Value = _spectrumdata[10];
            mainForm.DLch12.Value = _spectrumdata[11];
            mainForm.DLch13.Value = _spectrumdata[12];
            mainForm.DLch14.Value = _spectrumdata[13];
            mainForm.DLch15.Value = _spectrumdata[14];
            mainForm.DLch16.Value = _spectrumdata[15];

            float volume = 0;
            // 0 - среднее между R L
            // 1 - максимальное между R L
            // 2 - минимальное между R L
            switch (Properties.Settings.Default.GetVolumeIndex)
            {
                case 0: volume = (float)MainForm.map((long)((_l.Value + _r.Value) / 2), 0, 65555, 0, 100);break;
                case 1: volume = (float)MainForm.map((long)Math.Max(_l.Value, _r.Value), 0, 65555, 0, 100); break;
                case 2: volume = (float)MainForm.map((long)Math.Min(_l.Value, _r.Value), 0, 65555, 0, 100); break;
            }
            mainForm.Draw(volume, _spectrumdata.ToArray());


            if (Serial != null)
            {
                Serial.Write(_spectrumdata.ToArray(), 0, _spectrumdata.Count);
            }
            _spectrumdata.Clear();


            //Required, because some programs hang the output. If the output hangs for a 75ms
            //this piece of code re initializes the output so it doesn't make a gliched sound for long.
            if (_hanctr > 3)
            {
                _hanctr = 0;
                _l.Value = 0;
                _r.Value = 0;
                Free();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                _initialized = false;
                Enable = true;
            }
        }

        // WASAPI callback, required for continuous recording
        private int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        //cleanup
        public void Free()
        {
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();
        }
    }
}
