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

        var product = new[] {
            new{name= "연필", price = 80},
            new{name= "지우개", price = 50},
            new{name= "자", price = 200},
            new{name= "컴퍼스", price = 300},
            new{name= "볼펜", price = 100},
        };

        IEnumerable qry = from p in product
                          where p.price >= 200
                          select new { p.name, p.price };

        foreach (var tmp in qry)
        {
            lbx.Items.Add(tmp);
        }
        lbx.Parent = this;
    }
}
