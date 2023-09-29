using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_music
{
    public class DrawLine
    {
        public static PictureBox pictureBox;
        private static Graphics g;
        private static float oldPos = 0;
        public static float OldPos { get { return oldPos; } }
        public static List<DrawLine> drawLines = new List<DrawLine>();
        //static settings 
        public static Color BackGColor = Color.White;
        public static float Speed = 1;

        public static void Init()
        {
            g = pictureBox.CreateGraphics();
            Clear();
        }

        public static void Clear()
        {
            g.Clear(BackGColor);
            oldPos = 0;
        }

        public static void Save()
        {
            Image image = pictureBox.Image;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName);
            }
            image.Dispose();
            image = null;
        }

        public static void Draw()
        {
            foreach (var line in drawLines)
            {
                if (line.Visible)
                {
                    PointF _startPoint = new PointF(oldPos, -line.oldVal + line.Y_Correct);
                    PointF _endPoint = new PointF(oldPos + Speed, -line.Value + line.Y_Correct);
                    Pen _pen = new Pen(line.Color, line.Width);
                    g.DrawLine(_pen, _startPoint, _endPoint);
                    //g.DrawCurve(_pen, new PointF[] { _startPoint, _endPoint});
                }
            }
            oldPos += Speed;
            if (oldPos > pictureBox.Width) Clear();
        }

        public Color Color = Color.Black;
        private float oldVal = 0;
        public float Width = 1;
        private float _value = 0;
        public float Value { get { return _value; } set { oldVal = _value; _value = value; } }
        public bool Visible;
        public float Y_Correct = 260;

        public DrawLine(Color color, float width = 1, bool visi = false)
        {
            Color = color;
            Visible = visi;
            Value = 0;
            oldVal = 0;
            Width = width;
            drawLines.Add(this);
        }

    }
}
