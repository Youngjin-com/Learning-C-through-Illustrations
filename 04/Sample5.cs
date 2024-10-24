using System.Windows.Forms;

class Sample5
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";
        fm.Width = 300; fm.Height = 150;

        Label lb = new Label();
        lb.Width = fm.Width; lb.Height = fm.Height;

        for (int i = 0; i < 5; i++)
        {
            lb.Text += i + "호 자동차를 표시합니다.\n"; 
        }

        lb.Parent = fm;

        Application.Run(fm);
    }
}
