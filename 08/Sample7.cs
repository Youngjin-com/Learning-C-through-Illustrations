using System;
using System.Windows.Forms;
using System.Drawing;

class Sample7 : Form
{
    private Ball bl;
    private int dx, dy;

    public static void Main()
    {
        Application.Run(new Sample7());
    }
    public Sample7()
    {
        this.Text = "샘플";
        this.ClientSize = new Size(250, 100);
        
        bl = new Ball();

        Point p = new Point(0, 0);
        Color c = Color.Blue;

        bl.Point = p;
        bl.Color = c;

        dx = 2;
        dy = 2;

        Timer tm = new Timer();
        tm.Interval = 100;
        tm.Start();
        
        this.Paint += new PaintEventHandler(fm_Paint);
        tm.Tick += new EventHandler(tm_Tick);
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        Point p = bl.Point;
        Color c = bl.Color;
        SolidBrush br = new SolidBrush(c);

        g.FillEllipse(br, p.X, p.Y, 10, 10);
    }
    public void tm_Tick(Object sender,EventArgs e)
    {
        Point p = bl.Point;

        if (p.X < 0 || p.X > this.ClientSize.Width-10) dx = -dx;
        if (p.Y < 0 || p.Y > this.ClientSize.Height-10) dy = -dy; 
   
        p.X = p.X + dx;
        p.Y = p.Y + dy;

        bl.Point = p;
        this.Invalidate();
     }
}
class Ball
{
    public Color Color;
    public Point Point;
}
