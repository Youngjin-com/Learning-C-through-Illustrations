using System;
using System.Windows.Forms;

class Sample11 : Form
{
    private Label lb;
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample11());
    }
    public Sample11()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "어서 오세요";
        lb.Dock = DockStyle.Top;

        bt = new Button();
        bt.Text = "구입";
        bt.Dock = DockStyle.Bottom;

        lb.Parent = this;
        bt.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        MessageBox.Show("구입해 주셔서 고맙습니다", "구입");
    }
}
