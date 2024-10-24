using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections;

class Sample2 : Form
{
    private ListBox lbx;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "샘플";
        this.Width = 300; this.Height = 200;

        lbx = new ListBox();
        lbx.Dock = DockStyle.Fill;

        var 차량표 = new[] {
            new{ 번호 = 2, 이름 = "승용차"},
            new{ 번호 = 3, 이름 = "오픈카"},
            new{ 번호 = 4, 이름 = "트럭"},
        };

        IEnumerable qry = from K in 차량표
                          where K.번호 <= 3
                          select new { K.이름, K.번호 };

        foreach (var tmp in qry)
        {
            lbx.Items.Add(tmp);
        }
        lbx.Parent = this;
    }
}
