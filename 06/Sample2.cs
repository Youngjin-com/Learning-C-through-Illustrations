using System;
using System.Windows.Forms;

class Sample2 : Form
{
    private Label lb;
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 100;

        lb = new Label();
        lb.Text = "어서 오세요";
        lb.Width = 150;
        bt = new Button();
        bt.Text = "구입";
        bt.Top = this.Top + lb.Height;
        bt.Width = lb.Width;

        bt.Parent = this;
        lb.Parent = this;  
        
        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        lb.Text = "고맙습니다.";
    }
}
