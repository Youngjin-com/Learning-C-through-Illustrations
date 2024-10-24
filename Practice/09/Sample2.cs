using System;
using System.Windows.Forms;
using System.Drawing;

class Sample2 : Form
{
    private Ball bl;
    private Image im;
    private int dx, dy;
    private int t;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "샘플";
        this.ClientSize = new Size(600, 300);
        this.DoubleBuffered = true;

        im = Image.FromFile("c:\\sky.bmp");
        bl = new Ball();

        Point p = new Point(0, 300);
        Color c = Color.White;
        dx = 0;
        dy = 0;
        t = 0;

        bl.Point = p;
        bl.Color = c;

        Timer tm = new Timer();
        tm.Interval = 100;
        tm.Start();

        this.Paint += new PaintEventHandler(fm_Paint);
        tm.Tick += new EventHandler(tm_Tick);
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.DrawImage(im, 0, 0, im.Width, im.Height);

        Point p = bl.Point;
        Color c = bl.Color;
        SolidBrush br = new SolidBrush(c);

        g.FillEllipse(br, p.X, p.Y, 10, 10);
    }
    public void tm_Tick(Object sender, EventArgs e)
    {
        Point p = bl.Point;

        t++;

        if (p.X > this.ClientSize.Width)
        {
            dx = 0;
            dy = 0;
            t = 0;
            p.X = 0;
            p.Y = 300;
        }
        dx = (int)(90 * Math.Cos(Math.PI / 4));
        dy = (int)(90 * Math.Sin(Math.PI / 4) - 9.8 * t);

        p.X = p.X + dx;
        p.Y = p.Y - dy;

        bl.Point = p;
        this.Invalidate();
    }
}
class Ball
{
    public Color Color;
    public Point Point;
}
