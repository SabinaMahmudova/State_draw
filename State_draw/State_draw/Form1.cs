using System;
using System.Drawing;
using System.Windows.Forms;

namespace State_draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public interface IToolState
        {
            void HandleMouseDown();
            void HandleMouseMove();
            void HandlePaint();
        }

        public class LineState : IToolState
        {
            private Bitmap bitmap;

            public LineState(Bitmap map)
            {
                this.bitmap = map;
            }
            public Form1 f = new Form1();
            Point p;
            Point p1;
            public void HandleMouseDown()
            {
                p.X = Form1.MousePosition.X - 276;
                p.Y = Form1.MousePosition.Y - 12;
            }
            
            public void HandleMouseMove()
            {
                p1.X = Form1.MousePosition.X - 276;
                p1.Y = Form1.MousePosition.Y - 12;
              }

            public void HandlePaint()
            {
                Graphics gr = Graphics.FromImage(bitmap);
                gr.DrawLine(Pens.Red, p, p1);
            }            
        }
        public class RectangleState : IToolState
        {
            public Form1 f = new Form1();
            Point p;
            Point p1;
            private Bitmap bitmap;
            
            public RectangleState(Bitmap map)
            {
                this.bitmap = map;
            }

            public void HandleMouseDown()
            {
                p.X = Form1.MousePosition.X - 276;
                p.Y = Form1.MousePosition.Y - 12;
          }

            public void HandleMouseMove()
            {
                p1.X = Form1.MousePosition.X - 276;
                p1.Y = Form1.MousePosition.Y - 12;
              }

            public void HandlePaint()
            {
                Graphics gr = Graphics.FromImage(bitmap);
                if (p.X > p1.X)
                {
                    gr.DrawRectangle(Pens.Red, p1.X, p1.Y, Math.Abs(p1.X - p.X), Math.Abs(p1.Y - p.Y));
                }
                else
                {
                    gr.DrawRectangle(Pens.Red, p.X, p.Y, Math.Abs(p1.X - p.X), Math.Abs(p1.Y - p.Y));
                }
            }
        }
        public class CircleState : IToolState
        {
            public Form1 f = new Form1();
            Point p;
            Point p1;
            private Bitmap bitmap;
            public CircleState(Bitmap map)
            {
                this.bitmap = map;
            }
            public void HandleMouseDown()
            {
                p.X = Form1.MousePosition.X - 276;
                p.Y = Form1.MousePosition.Y - 12;
            }

            public void HandleMouseMove()
            {
                p1.X = Form1.MousePosition.X - 276;
                p1.Y = Form1.MousePosition.Y - 12;
                Pen pen = new Pen(Color.Black);
         }
            public void HandlePaint()
            {
                Graphics gr = Graphics.FromImage(bitmap);
                if (p.X > p1.X)
                {
                    gr.DrawEllipse(Pens.Red, p1.X, p1.Y, Math.Abs(p1.X - p.X), Math.Abs(p1.Y - p.Y));
                }
                else
                {
                    gr.DrawEllipse(Pens.Red, p.X, p.Y, Math.Abs(p1.X - p.X), Math.Abs(p1.Y - p.Y));
                }
                //gr.DrawEllipse(Pens.Red, p.X, p.Y, Math.Abs(p1.X - p.X), Math.Abs(p1.Y - p.Y));
            }
        }
        public class DrawingController
            {
                IToolState ToolState;
                public void SetState(IToolState state)
                {
                    ToolState = state;
                }
            }
        static Bitmap bitmap= new Bitmap(328, 336);
        IToolState tool;
        DrawingController drawer = new DrawingController();
        private void button1_Click(object sender, EventArgs e)
            {
                tool = new LineState(bitmap);
                drawer.SetState(tool);
            
            }
        private void button2_Click(object sender, EventArgs e)
        {
            tool = new RectangleState(bitmap);
            drawer.SetState(tool);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tool = new CircleState(bitmap);
            drawer.SetState(tool);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            tool.HandleMouseDown();
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tool.HandleMouseMove();
            }
            pictureBox1.Image = bitmap;
            pictureBox1.Invalidate();       
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            tool.HandlePaint();
            pictureBox1.Image = bitmap;
        }
    }
}


