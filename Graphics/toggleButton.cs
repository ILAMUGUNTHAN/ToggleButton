using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Graphics
{
    public class toggleButton:CheckBox
    {
        private Timer timer;
        private int TogX = 0;
        private int TogY = 0;
        
        public toggleButton()
        {
            //InitializeComponent();
            this.MinimumSize = new Size(250, 100);
        }

        //Methods
        //private GraphicsPath GetFigurePath()
        //{
        //    int arcSize = this.Height - 1;
        //    Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
        //    Rectangle rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

        //    GraphicsPath path = new GraphicsPath();
        //    path.StartFigure();
        //    path.AddArc(rightArc, 270, 180);
        //    path.AddArc(leftArc, 90, 180);

        //    //path.AddRectangle(rightArc);
        //    //path.AddRectangle(leftArc);
        //    path.CloseFigure();
         
        //    return path;
        //}

        


        protected override void OnPaint(PaintEventArgs pevent)
        {
            //int toggleSize = this.Height - 5;
            //pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //pevent.Graphics.Clear(this.Parent.BackColor);

            //if (this.Checked) //ON
            //{
            //    //Draw the control surface
            //    if (solidStyle)
            //        pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
            //    else pevent.Graphics.DrawPath(new Pen(onBackColor, 2), GetFigurePath());
            //    //Draw the toggle
            //    pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
            //      new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            //}
            //else //OFF
            //{
            //    //Draw the control surface
            //    if (solidStyle)
            //        pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
            //    else pevent.Graphics.DrawPath(new Pen(offBackColor, 2), GetFigurePath());
            //    //Draw the toggle
            //    pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
            //      new Rectangle(2, 2, toggleSize, toggleSize));
            //}


            System.Drawing.Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(this.Parent.BackColor);
            GraphicsPath gPath = new GraphicsPath();


            Rectangle leftArc = new Rectangle(0, 0, this.Height, this.Height);
            Rectangle rightArc = new Rectangle(this.Width - this.Height, 0, this.Height, this.Height);
            gPath.StartFigure();

            gPath.AddArc(rightArc, 270, 180);
            gPath.AddArc(leftArc, 90, 180);

            g.FillPath(new SolidBrush(Color.Gray), gPath);
            gPath.CloseFigure();

            if (timer == null || !timer.Enabled)
            {
                timer = new Timer();
                timer.Interval = 10;
                timer.Tick += TimerTick;
                
            }

            if (this.Checked)
            {
                timer.Start();
                g.FillPath(new SolidBrush(Color.Green), gPath);
                
                
                g.FillEllipse(new SolidBrush(Color.White),TogX+2.5f,TogY+2.5f,this.Height-5,this.Height-5);
                
            }
            else
            {
                g.FillEllipse(new SolidBrush(Color.White), TogX+2.5f,TogY+2.5f,this.Height-5,this.Height-5);
            }

            

        }
        private void TimerTick(object sender, EventArgs e)
        {
            
            if(this.Checked)
            {
                if (TogX == this.Width - this.Height)
                {
                    timer.Stop();
                    return;
                }
                else
                {
                    TogX += 25;
                    Invalidate();
                }
            }
            else
            {
                if (TogX == 0)
                {
                    timer.Stop();
                    return;
                }
                else
                {
                    TogX -= 25;
                    Invalidate();
                }
            }


        }
    }
}
