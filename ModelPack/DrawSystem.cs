using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.Props;

namespace VectorGraphicsEditor
{
    internal class DrawSystem
    {
        Pen FramePen = new Pen(Color.FromArgb(0, 0, 0));
        Pen SelectPen = new Pen(Color.Black);

        Graphics Graphics;
        public Pen Pen;
        Brush Brush;
        public DrawSystem(Graphics graphics)
        {
            FramePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Graphics = graphics;
            Pen = new Pen(Color.Black);
            Brush = new SolidBrush(Color.Empty);
        }
        public void DrawLine(PropList propList, Frame frame)
        {
            Point start = new Point(frame.x1, frame.y1);
            Point end = new Point(frame.x2, frame.y2);

            Graphics.DrawLine(Pen, start, end);

        }
        public void DrawRectangle(PropList propList, Frame frame)
        {
            /*Point start = new Point(frame.x1, frame.y1);
            Size size = new Size(frame.width, frame.length);

            Rectangle rect = new Rectangle(start, size);*/

            Rectangle rect = frame.GetFrame();

            Graphics.FillRectangle(Brush, rect);
            Graphics.DrawRectangle(Pen, rect);
        }
        public void DrawEllipse(PropList propList, Frame frame)
        {
            Rectangle rect = frame.GetFrame();

            Graphics.FillEllipse(Brush, rect);
            Graphics.DrawEllipse(Pen, rect);
        }
        public void DrawSelect(List<Rectangle> points)
        {
            foreach(var p in points)
            {
                Graphics.DrawRectangle(SelectPen, p);
            }
        }
        public void DrawFrame(Frame frame)
        {
            Rectangle rectangle = frame.GetFrame();
            Graphics.DrawRectangle(FramePen, rectangle);
        }
        public void Clear()
        {
            Graphics.Clear(Color.White);
        }
        public void ApplyLineWidth(int width)
        {
            Pen.Width = width;
        }
        public void ApplyLineColor(Color color)
        {
            Pen.Color = color;
        }
        public void ApplyFillColor(Color color)
        {
            ((SolidBrush)Brush).Color = color;
        }
    }
}
