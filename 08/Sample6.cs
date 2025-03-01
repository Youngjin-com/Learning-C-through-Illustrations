﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

class Sample6 : Form
{
    private List<Ball> ls;
    
    public static void Main()
    {
        Application.Run(new Sample6());
    }
    public Sample6()
    {
        this.Text = "샘플";
        this.Paint += new PaintEventHandler(fm_Paint);

        ls = new List<Ball>();

        Random rn = new Random();

        for (int i = 0; i < 30; i++)
        {
            Ball bl = new Ball();

            int x = rn.Next(this.Width);
            int y = rn.Next(this.Height);

            int r = rn.Next(256);
            int g = rn.Next(256);
            int b = rn.Next(256);

            Point p = new Point(x, y);
            Color c = Color.FromArgb(r, g, b);

            bl.Point = p;
            bl.Color = c;

            ls.Add(bl);
        }
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        foreach (Ball bl in ls)
        {
            Point p = bl.Point;
            Color c = bl.Color;
            SolidBrush br = new SolidBrush(c);

            g.FillEllipse(br, p.X, p.Y, 10, 10);
        }
    }
}
class Ball
{
    public Color Color;
    public Point Point;
}
