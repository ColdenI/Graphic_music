using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Graphic_music
{
    class PieСhart
    {
        public static MainForm mainForm;

        private Graphics g;
        private PictureBox pictureBox;
        private float oldVal = 0;
        private Color nowColor = Color.Black;
        private int colorJumpAndGradientIndex = 0;
        private float widthPen = 2;//толщина пера
        private bool isLockedJump = false;

        public float StandartWidthPen = 2;//стандартная толщина пера
        public float MaxWidthPen = 6;//максимальная толщина пера
        public float PosCorrect = 0f;//на сколько увеличивать круг
        public bool isClear = true;//очищать график за цикл?
        public bool isSetSizeFoVolume = true;//изменять толщину круга в скочках
        public int ColorJumpVal = 50;//на сколько цветов прыгать в скачках
        public float SeparatorSetColor = 40; //порог скачка
        public Color BackGColor = Color.White;//цвет заднего фона
        public Color StaticColor = Color.Black;//статично настроенный и сохранённый цвет

        public float WidthPen { set => widthPen = value; }
        public Color NowColor { set => nowColor = value; }
        public PictureBox PictureBox { set{ pictureBox = value; Init(); } }

        public PieСhart(PictureBox pictureBox) 
        {
            this.pictureBox = pictureBox;
            Init();
        }

        public void Init()
        {
            g = pictureBox.CreateGraphics();
            g.Clear(BackGColor);
        }

        public void Clear()
        {
            g.Clear(BackGColor);
        }

        private void TickVolumeJump(float val)
        {
            if (val >= SeparatorSetColor)
            {
                if (mainForm.comboBox_sphereColorMode.SelectedIndex == 1) colorJumpAndGradientIndex += ColorJumpVal;
                if (isSetSizeFoVolume && widthPen < MaxWidthPen) widthPen += 1.1f;
            }
            else if (widthPen > StandartWidthPen) if (isSetSizeFoVolume) widthPen -= 3.1f;
        }

        public void Update(float volume)
        {
            SetNowColor();
            if (isClear) Clear();
            if (!isLockedJump) TickVolumeJump(volume);
            isLockedJump = false;
        }

        public void SetNowColor()
        {
            switch (mainForm.comboBox_sphereColorMode.SelectedIndex)
            {
                case 0: nowColor = StaticColor; break;
                case 1: nowColor = MainForm.colorWheel(colorJumpAndGradientIndex); break;
                case 2: nowColor = MainForm.colorWheel(colorJumpAndGradientIndex); colorJumpAndGradientIndex += 10; break;
            }
            if (colorJumpAndGradientIndex >= 1530) colorJumpAndGradientIndex -= 1530;
        }

        private PointF[] GetChPoints(float volume, byte[] ch, int count = 16)
        {
            PointF center = new PointF(pictureBox.Width / 2, pictureBox.Height / 2);
            PointF[] pointFs = new PointF[count];
            for (int i = 0; i < ch.Length; i++)
            {
                float l = (float)MainForm.map((long)(ch[i] + volume), 0, 356, 0, (long)(center.X * .95f)) + PosCorrect;
                pointFs[i] = new PointF(
                    center.X + (float)Math.Cos(i * 69.5) * l,
                    center.Y + (float)Math.Sin(i * 69.5) * l
                    );
            }
            return pointFs;
        }

        public void ChLinesDraw(float volume, byte[] ch)
        {
            isLockedJump = true;
            PointF center = new PointF(pictureBox.Width / 2, pictureBox.Height / 2);

            PointF[] pointFs = GetChPoints(volume, ch);
            for(int i = 0; i < 16; i++)
            {
                if (ch[i] >= SeparatorSetColor)
                    if (mainForm.comboBox_sphereColorMode.SelectedIndex == 1) colorJumpAndGradientIndex += ColorJumpVal;

                if (colorJumpAndGradientIndex >= 1530) colorJumpAndGradientIndex -= 1530;
                Pen pen = new Pen(nowColor, (float)mainForm.numericUpDown_StandartWidhtSpherePen.Value);
                g.DrawLine(pen, center, pointFs[i]);
            }

        }

        public void CurveDraw(float volume, byte[] ch)
        {
            Pen pen = new Pen(nowColor, widthPen);

            PointF[] pointFs = GetChPoints(volume, ch, 18);
            pointFs[16] = pointFs[0];
            pointFs[17] = pointFs[1];
            g.DrawCurve(pen, pointFs);
        }

        public void TestCurveDraw(float volume, byte[] ch)
        {
            CurveDraw(volume, ch);
            ChLinesDraw(volume, ch);
            DrawSphere(volume, 0, 356);
        }

        public void CurveLinesDraw(float volume, byte[] ch)
        {
            Pen pen = new Pen(nowColor, widthPen);

            PointF[] pointFs = GetChPoints(volume, ch, 17);           
            pointFs[16] = pointFs[0];
            g.DrawLines(pen, pointFs);
        }

        public void DrawSphere(float val, long inMin, long inMax)
        {
            val = MainForm.map((long)val, inMin, inMax, 0, 100);
            oldVal = val;
        
            Pen pen = new Pen(nowColor, widthPen);
            float gs_s = (pictureBox.Width / 2) - ((oldVal) / 2 * (pictureBox.Height / 100) + PosCorrect / 2) * .9f;
            g.DrawEllipse(pen, gs_s, gs_s, 
                (oldVal * (pictureBox.Width / 100)) * .9f + PosCorrect, 
                (oldVal * (pictureBox.Height / 100)) * .9f + PosCorrect);
 
        }


    }
}
