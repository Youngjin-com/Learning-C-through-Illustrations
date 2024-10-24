using System;
using System.Windows.Forms;

class Sample13 : Form
{
    private Label lb;
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample13());
    }
    public Sample13()
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
       SampleForm sf = new SampleForm();
       sf.ShowDialog();
    }
}

class SampleForm : Form
{
    public SampleForm()
    {
        Label lb = new Label();
        Button bt = new Button();

        this.Text = "사례";
        this.Width = 250; this.Height = 200;

        lb.Text = "고맙습니다";
        lb.Dock = DockStyle.Top;
        
        bt.Text = "OK";
        bt.DialogResult = DialogResult.OK;
        bt.Dock = DockStyle.Bottom;

        lb.Parent = this;
        bt.Parent = this;
    }
}
