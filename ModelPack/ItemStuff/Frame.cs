using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor.ItemStuff
{
    internal class Frame
    {
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public int width;
        public int length;
        public int margin = 4;
        public bool valid = true;

        public Frame(int x1, int y1, int width, int length)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.width = width;
            this.length = length;
            x2 = x1 + width;
            y2 = y1 + length;
        }
        public Frame(Rectangle r)
        {
            this.x1 = r.X;
            this.y1 = r.Y;
            this.width = r.Width;
            this.length = r.Height;
            x2 = x1 + width;
            y2 = y1 + length;
        }
        public Frame()
        {
            valid = false;
        }
        public void Add(Frame otherFrame)
        {
            Rectangle r = otherFrame.GetFrame();
            x1 = Math.Min(x1, r.X);
            y1 = Math.Min(y1, r.Y);
            x2 = Math.Max(x2, r.X + r.Width);
            y2 = Math.Max(y2, r.Y + r.Height);

            width = x2 - x1;
            length = y2 - y1;
        }
        public Rectangle GetFrame()
        {
            return new Rectangle(Math.Min(x1, x2), Math.Min(y1, y2), Math.Abs(width), Math.Abs(length));
        }
        public void SetToNormal()
        {
            int minx = Math.Min(x1, x2);
            int miny = Math.Min(y1, y2);
            this.x1 = minx;
            this.y1 = miny;
            this.width = Math.Abs(width);
            this.length = Math.Abs(length);
            x2 = x1 + width;
            y2 = y1 + length;
        }
    }
}
