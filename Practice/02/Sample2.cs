using System.Windows.Forms;

class Sample2
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";

        Label lb = new Label();
        lb.Text = "또 만납시다!";

        lb.Parent = fm;

        Application.Run(fm);
    }
}
