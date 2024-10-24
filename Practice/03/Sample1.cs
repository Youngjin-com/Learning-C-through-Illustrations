using System.Windows.Forms;

class Sample1
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";

        fm.Width = 300;
        fm.Height = 200;

        Label lb = new Label();

        lb.Text = "안녕하세요";

        lb.Top = (fm.Height - lb.Height) / 2;
        lb.Left = (fm.Width - lb.Width) / 2;

        lb.Parent = fm;

        Application.Run(fm);
    }
}
