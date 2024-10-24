using System.Windows.Forms;

class Sample8
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "샘플";
        fm.Width = 250; fm.Height = 100;

        string[,] str = new string[4, 3]{
            {"서울", "Seoul", "徐菀"},
            {"대전", "Daejeon", "大田"}, 
            {"대구", "Daegu", "大邱"},
            {"부산", "Busan", "釜山"}
        };


        Label lb = new Label();
        lb.Width = fm.Width;
        lb.Height = fm.Height;

        string tmp = "";

        for (int i = 0; i < 4; i++)
        {
            tmp += "(" ;
            for (int j = 0; j < 3; j++)
            {
                tmp += str[i,j];
                tmp += ",";
            }
            tmp += ")\n";
        }

        lb.Text = tmp;
        lb.Parent = fm;

        Application.Run(fm);
    }
}
