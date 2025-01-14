﻿using System;
using System.Windows.Forms;

class Sample4 : Form
{
    private Label lb1, lb2;

    public static void Main()
    {
        Application.Run(new Sample4());
    }
    public Sample4()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 100;

        lb1 = new Label();
        lb1.Text = "방향키로 선택하세요.";
        lb1.Width = this.Width;

        lb2 = new Label();
        lb2.Top = lb1.Bottom;

        lb1.Parent = this;
        lb2.Parent = this;

        this.KeyDown += new KeyEventHandler(fm_KeyDown);

    }
    public void fm_KeyDown(Object sender, KeyEventArgs e)
    {
        String str;
        if(e.KeyCode == Keys.Up)
        {
           str = "위쪽";
        }
        else if(e.KeyCode == Keys.Down)
        {
           str = "아래쪽";
        }
        else if(e.KeyCode == Keys.Right)
        {
           str = "오른쪽";
        }
        else if(e.KeyCode == Keys.Left)
        {
           str = "왼쪽";
        }
        else
        {
           str = "다른 키";
        }
        lb2.Text = str + "입니다.";
    }
}
