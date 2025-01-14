﻿using System.Windows.Forms;
using System.Drawing;

class Sample4
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";
        fm.Width = 300; fm.Height = 200;

        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile("c:\\car.bmp");
        pb.Left = 100;

        Label lb = new Label();
        lb.Top = pb.Bottom;
		lb.Width = 170;
        lb.Text = "자동차입니다.";

        if (pb.Left >=0 && pb.Left <= fm.Width)
        {
            lb.Text = "자동차는 화면 안에 있습니다.";
        }
        else
        {
            lb.Text = "자동차는 화면 밖에 있습니다.";
        }

        pb.Parent = fm;
        lb.Parent = fm;

        Application.Run(fm);
    }
}
