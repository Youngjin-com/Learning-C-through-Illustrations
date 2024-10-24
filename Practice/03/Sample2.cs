using System.Windows.Forms;

class Sample2
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";

        fm.Width = 300;
        fm.Height = 200;

        Label lb1 = new Label();
        Label lb2 = new Label();

        lb1.Text = "안녕하세요";
        lb2.Text = "안녕히 가세요";

        lb2.Left = lb1.Left + 100;
        
        lb1.Parent = fm;
        lb2.Parent = fm;

        Application.Run(fm);
    }
}
