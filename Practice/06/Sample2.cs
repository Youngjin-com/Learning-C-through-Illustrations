using System;
using System.Windows.Forms;

class Sample2 : Form
{
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 100;

        bt = new Button();
        bt.Text = "어서 오세요";
        bt.Width = 100;

        bt.Parent = this;

        bt.MouseEnter += new EventHandler(bt_MouseEnter);
        bt.MouseLeave += new EventHandler(bt_MouseLeave);
    }
    public void bt_MouseEnter(Object sender, EventArgs e)
    {
        bt.Text = "안녕하세요";
    }
    public void bt_MouseLeave(Object sender, EventArgs e)
    {
        bt.Text = "안녕히 가세요";
    }
}
