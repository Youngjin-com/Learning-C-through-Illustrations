using System;
using System.Windows.Forms;

class Sample5 : Form
{
    private Label lb;
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample5());
    }
    public Sample5()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 100;

        lb = new Label();
        lb.Text = "어서 오세요";
        lb.Dock = DockStyle.Top;

        bt = new Button();
        bt.Text = "구입";
        bt.Dock = DockStyle.Bottom;

        bt.Click += new EventHandler(bt_Click);

        lb.Parent = this;
        bt.Parent = this;
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        lb.Text = "구입해 주셔서 고맙습니다.";
        bt.Enabled = false;
    }
}
