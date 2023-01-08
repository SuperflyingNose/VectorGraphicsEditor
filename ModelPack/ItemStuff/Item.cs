using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.Model;
using VectorGraphicsEditor.Primitives;

namespace VectorGraphicsEditor.ItemStuff
{
    internal abstract class Item
    {
        public Frame Frame;
        public RelativeFrame RelativeFrame;
        public Item(Frame frame)
        {
            if(Frame == null)
            {
                Frame = frame;
            }
            else
            {
                Frame.Add(frame);
            }
        }
        abstract public Item Copy();
        abstract public void Draw(DrawSystem drawSystem);
        abstract public VectorGraphicsEditor.Model.Selection CreateSelection();
        public void SetRelativeFrame(Frame frame)
        {
            RelativeFrame = new RelativeFrame((double)(Frame.x1 - frame.x1) / frame.width, (double)(Frame.y1 - frame.y1) / frame.length, (double)Frame.width / frame.width, (double)Frame.length / frame.length);
        }
        virtual public void ChangeFrameToRelative(Frame relFrame)
        {
            
            Frame = new Frame((int)(relFrame.x1 + (RelativeFrame.x1*relFrame.width)), (int)(relFrame.y1 + (RelativeFrame.y1*relFrame.length)), (int)(relFrame.width * RelativeFrame.widthRelate), (int)(relFrame.length * RelativeFrame.lengthRelate));
        }
        abstract public bool TryGrab(int x, int y);
        
    }
    public class RelativeFrame
    {
        public double x1;
        public double y1;
        public double widthRelate;
        public double lengthRelate;
        public RelativeFrame(double x1, double y1, double widthRelate, double lengthRelate)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.widthRelate = widthRelate;
            this.lengthRelate = lengthRelate;
        }
    }
}
