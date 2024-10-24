using System;
using System.Windows.Forms;

class Sample8 : Form
{
    private Label lb;
    private TextBox tb;

    public static void Main()
    {
        Application.Run(new Sample8());
    }
    public Sample8()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "어서 오세요";
        lb.Dock = DockStyle.Top;

        tb = new TextBox();
        tb.Dock = DockStyle.Bottom;

        lb.Parent = this;
        tb.Parent = this;

        tb.KeyDown += new KeyEventHandler(tb_KeyDown);
    }
    public void tb_KeyDown(Object sender, KeyEventArgs e)
    {
        TextBox tmp = (TextBox)sender;
        if (e.KeyCode == Keys.Enter)
        {
            lb.Text = tmp.Text + "을(를) 선택했습니다";
        }
    }
}
