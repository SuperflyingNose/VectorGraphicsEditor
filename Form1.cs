using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorGraphicsEditor.Controller;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.Primitives;
using VectorGraphicsEditor.Props;

namespace VectorGraphicsEditor
{
    public partial class Form1 : Form
    {
        public Graphics g;
        internal IController controller;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void DrawLine(object sender, EventArgs e)
        {
            controller.SetItemCreationRegime(ItemType.itLine);
            controller.eventHandler.ActivateState(StateType.CreateState);
        }

        private void DrawRect(object sender, EventArgs e)
        {
            controller.SetItemCreationRegime(ItemType.itRectangle);
            controller.eventHandler.ActivateState(StateType.CreateState);
        }

        private void DrawEllipse(object sender, EventArgs e)
        {
            controller.SetItemCreationRegime(ItemType.itEllipse);
            controller.eventHandler.ActivateState(StateType.CreateState);
        }

        private void ChangeLineColor(object sender, EventArgs e)
        {
            controller.model.GrParams.lineProps.Color = GetColor();
            ((GrParams)controller.model.GrParams).ApplyChanges();
        }

        private void ChangeLineWidth(object sender, EventArgs e)
        {
            var check = textBox1.Text;
            controller.model.GrParams.lineProps.Width = Convert.ToInt32(textBox1.Text);
            ((GrParams)controller.model.GrParams).ApplyChanges();
        }

        private void ChangeFillColor(object sender, EventArgs e)
        {
            controller.model.GrParams.fillProps.Color = GetColor();
            ((GrParams)controller.model.GrParams).ApplyChanges();
        }


        private void panel1_Click(object sender, EventArgs e)
        {
            //if (true) { return; }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            
            if (controller != null)
            {
                g = panel1.CreateGraphics();
                controller.model.SetGrPort(g,1,1);
                controller.model.Repaint();
            }
        }
        private Color GetColor()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    return colorDialog.Color;
                }
            }
            return Color.Black;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            MouseEventArgs cursor = (MouseEventArgs)e;
            if(Control.ModifierKeys == Keys.Control)
            {
                controller.eventHandler.CtrlMouseUp(cursor.X, cursor.Y);
                return;
            }
            controller.eventHandler.LeftMouseDown(cursor.X, cursor.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            MouseEventArgs cursor = (MouseEventArgs)e;
            controller.eventHandler.LeftMouseUp(cursor.X, cursor.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs cursor = (MouseEventArgs)e;
            controller.eventHandler.LeftMouseMove(cursor.X, cursor.Y);
        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    controller.eventHandler.Escape();
                    break;
                case Keys.Delete:
                    controller.eventHandler.Delete();
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            controller.eventHandler.Group();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            controller.eventHandler.UnGroup();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    controller.eventHandler.Escape();
                    break;
                case Keys.Delete:
                    controller.eventHandler.Delete();
                    break;
            }
        }
    }
}
