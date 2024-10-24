﻿using System;
using System.Windows.Forms;
using System.Drawing;

class Sample1 : Form
{
    private int t;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "샘플";
        this.ClientSize = new Size(200, 300);
        this.DoubleBuffered = true;

        t = 0;

        Timer tm = new Timer();
        tm.Interval = 100;
        tm.Start();

        this.Paint += new PaintEventHandler(fm_Paint);
        tm.Tick += new EventHandler(tm_Tick);
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        int w = this.ClientSize.Width;
        int h = this.ClientSize.Height;

        g.FillRectangle(new SolidBrush(Color.DarkOrchid), 0, 0, w, h);
        g.FillRectangle(new SolidBrush(Color.DeepPink), 0, 0, w, h - (float)0.5 * t);

        string time = t / 10 + ":" + "0" + t % 10;

        Font f = new Font("Courier", 20);
        SizeF ts = g.MeasureString(time, f);

        float tx = (w - ts.Width) / 2;
        float ty = (h - ts.Height) / 2;

        g.DrawString(time, f, new SolidBrush(Color.Black), tx, ty);
    }
    public void tm_Tick(Object sender, EventArgs e)
    {
        t = t + 1;
        if (t > 600)
            t = 0;

        this.Invalidate();
    }
}