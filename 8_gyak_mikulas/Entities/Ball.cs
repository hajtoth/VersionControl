using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using _8_gyak_mikulas.Abstractions;

namespace _8_gyak_mikulas.Entities
{
    public class Ball : Toy
    {
        public Ball()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Ball_Paint;
        }
        private void Ball_Paint(object sender, PaintEventArgs e)
        {

            DrawImage(e.Graphics);
        
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

        public void MoveBall()
        {
            Left += 1;
        }

      
    }
}
