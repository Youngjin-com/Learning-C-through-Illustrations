using System.Windows.Forms;
using System.Drawing;

class Sample1
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";
        fm.Width = 300; fm.Height = 200;

        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile("c:\\car.bmp");
        pb.Left = 200;

        Label lb = new Label();
        lb.Top = pb.Bottom;
		lb.Width = 170;
        lb.Text = "자동차입니다";

        if (pb.Left >= 150)
        {
            lb.Text = "자동차는 동쪽에 있습니다.";
        }

        pb.Parent = fm;
        lb.Parent = fm;

        Application.Run(fm);
    }
}
