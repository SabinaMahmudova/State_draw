using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                p = f.PointToClient(Cursor.Position);

                //p = new Point(CursorX, CursorY);
                //return p;
                Graphics gr = Graphics.FromImage(bitmap);
                //gr.DrawLine(Pens.Red, p, new Point(p.X - 50, p.Y - 50));
                Console.WriteLine(p.X);
                Console.WriteLine(p.Y);
            }
            
            public void HandleMouseMove()
            {
                p1 = f.PointToClient(Control.MousePosition);
                //p1 = new Point(CursorX1, CursorY1);
                //return p1;
                Console.WriteLine(p1.X);
                Console.WriteLine(p1.Y);
                Pen pen = new Pen(Color.Black);
                Graphics gr = Graphics.FromImage(bitmap);
                gr.DrawLine(Pens.Red, p, p1);
                //gr.DrawLine(Pens.Red, /*p, new Point(p.X+50,p.Y+50)*/ 10,10,50,50);
            }

            public void HandlePaint()
            {
                //Graphics gr = Graphics.FromImage(bitmap);
                
                Pen pen = new Pen(Color.Black);
                Graphics gr = Graphics.FromImage(bitmap);
                gr.DrawLine(Pens.Red, p, p1);
                //gr.DrawLine(Pens.Red, p, p1);
                //gr.DrawLine(Pens.Red, 10, 10, 50, 50);
            }
            
        }
        //public class RectangleState : IToolState
        //{
        //    private Bitmap bitmap;

        //    public RectangleState(Bitmap map)
        //    {
        //        this.bitmap = map;
        //    }

        //    public void HandleMouseDown()
        //    {
        //        Graphics gr = Graphics.FromImage(bitmap);
        //        gr.DrawRectangle(Pens.Red, 10, 10, 50, 50);
        //    }
        //}
        //public class CircleState : IToolState
        //{
        //    private Bitmap bitmap;
        //    public CircleState(Bitmap map)
        //    {
        //        this.bitmap = map;
        //    }
        //    public void HandleMouseDown()
        //    {
        //        Graphics gr = Graphics.FromImage(bitmap);
        //        gr.DrawEllipse(Pens.Red, 10, 10, 50, 50);
        //    }
        //}
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
        //private void button2_Click_1(object sender, EventArgs e)
        //{
        //    tool = new RectangleState(bitmap);
        //    drawer.SetState(tool);
        //}
        //private void button3_Click_1(object sender, EventArgs e)
        //{
        //    tool = new CircleState(bitmap);
        //    drawer.SetState(tool);
        //}
        //Point nach;
        //Point kon;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            tool.HandleMouseDown();
            pictureBox1.Image = bitmap;
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

        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            //tool.HandlePaint();
            //pictureBox1.Image = bitmap;    
        }
    }
}

/*        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                X1 = e.X;
                Y1 = e.Y;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            twoPoint.Add(new twoPoint(new Point(X, Y), new Point(X1, Y1)));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            e.Graphics.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
            foreach (var p in twoPoint)
            {
                e.Graphics.DrawLine(pen, p.X, p.Y);
            }
        }
*/

