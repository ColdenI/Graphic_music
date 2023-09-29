using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graphic_music
{
    public partial class BigForm : Form
    {
        public BigForm()
        {
            InitializeComponent();
        }

        private void BigForm_Move(object sender, EventArgs e)
        {
            Console.WriteLine(1);
        }

        private void BigForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(e.X + Location.X - Size.Width / 2, e.Y + Location.Y - Size.Height / 2);
            }
        }

        private void BigForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus && Size.Height > 100) Size = new Size(Size.Width - 10, Size.Height - 10);
            if (e.KeyCode == Keys.Oemplus) Size = new Size(Size.Width + 10, Size.Height + 10);

            if (e.KeyCode == Keys.Escape)
            {
                if(MessageBox.Show("Close this window?", "?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) Close();
            }
            if (e.KeyCode == Keys.Space) TopMost = !TopMost;
            if (e.KeyCode == Keys.Left) Location = new Point(Location.X - 10, Location.Y);
            if (e.KeyCode == Keys.Right) Location = new Point(Location.X + 10, Location.Y);
            if (e.KeyCode == Keys.Up) Location = new Point(Location.X, Location.Y - 10);
            if (e.KeyCode == Keys.Down) Location = new Point(Location.X, Location.Y + 10);
            
        }
    }
}
