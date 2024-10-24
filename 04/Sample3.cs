using System.Windows.Forms;
using System.Drawing;

class Sample3
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";
        fm.Width = 300; fm.Height = 200;

        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile("c:\\car.bmp");
        pb.Left = 150;

        Label lb = new Label();
        lb.Top = pb.Bottom;
		lb.Width = 170;
        lb.Text = "자동차입니다.";

        switch (pb.Left)
        {
            case 20:
                lb.Text = "서쪽의 주유소입니다.";
                break;
            case 150:
                lb.Text = "동쪽의 주유소입니다.";
                break;
            default:
                lb.Text = "주행 중입니다.";
                break;
        }

        pb.Parent = fm;
        lb.Parent = fm;

        Application.Run(fm);
    }
}
