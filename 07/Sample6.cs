using System;
using System.Windows.Forms;

class Sample6 : Form
{
    private Label lb;
    private CheckBox cb1, cb2;
    private FlowLayoutPanel flp;
 
    public static void Main()
    {
        Application.Run(new Sample6());
    }
    public Sample6()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "어서 오세요";
        lb.Dock = DockStyle.Top;

        cb1 = new CheckBox();
        cb2 = new CheckBox();

        cb1.Text = "자동차";
        cb2.Text = "트럭";

        flp = new FlowLayoutPanel();
        flp.Dock = DockStyle.Bottom;
        
        cb1.Parent = flp;
        cb2.Parent = flp;

        lb.Parent = this; 
        flp.Parent = this;

        cb1.CheckedChanged += new EventHandler(cb_CheckedChanged);
        cb2.CheckedChanged += new EventHandler(cb_CheckedChanged);
    }
    public void cb_CheckedChanged(Object sender, EventArgs e)
    {
        CheckBox tmp = (CheckBox)sender;
        if(tmp.Checked == true)
        {
            lb.Text =  tmp.Text + "을(를) 선택했습니다";
        }
        else if (tmp.Checked == false)
        {
            lb.Text = tmp.Text + "을(를) 해제했습니다";
        }
    }
}
