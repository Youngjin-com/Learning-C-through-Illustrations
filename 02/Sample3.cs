using System.Windows.Forms;

class Sample3
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "어서 오세요 C#으로!";

        Label lb = new Label();
		lb.Width = 150;
        lb.Text = "C#을 시작합시다!";
        lb.Parent = fm;

        Application.Run(fm);
    }
}
