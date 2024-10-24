using System;
using System.Windows.Forms;

class Sample10 : Form
{
    private Label lb;
    private MenuStrip ms;
    private ToolStripMenuItem[] mi = new ToolStripMenuItem[10];

    public static void Main()
    {
        Application.Run(new Sample10());
    }
    public Sample10()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "어서 오세요";
        lb.Dock = DockStyle.Bottom;
        
        ms = new MenuStrip();
        mi[0] = new ToolStripMenuItem("메인1");
        mi[1] = new ToolStripMenuItem("메인2");
        mi[2] = new ToolStripMenuItem("서브1");
        mi[3] = new ToolStripMenuItem("서브2");
        mi[4] = new ToolStripMenuItem("승용차");
        mi[5] = new ToolStripMenuItem("트럭");
        mi[6] = new ToolStripMenuItem("오픈카");
        mi[7] = new ToolStripMenuItem("택시");
        mi[8] = new ToolStripMenuItem("스포츠카");
        mi[9] = new ToolStripMenuItem("미니카");

        mi[0].DropDownItems.Add(mi[4]);
        mi[0].DropDownItems.Add(mi[5]);

        mi[1].DropDownItems.Add(mi[2]);
        mi[1].DropDownItems.Add(new ToolStripSeparator());
        mi[1].DropDownItems.Add(mi[3]);
        mi[2].DropDownItems.Add(mi[6]);
        mi[2].DropDownItems.Add(mi[7]);
        mi[3].DropDownItems.Add(mi[8]);
        mi[3].DropDownItems.Add(mi[9]);

        ms.Items.Add(mi[0]);
        ms.Items.Add(mi[1]);

        this.MainMenuStrip = ms;

        ms.Parent = this;
        lb.Parent = this;

        for (int i = 4; i < mi.Length; i++)
        {
            mi[i].Click += new EventHandler(mi_Click);
        }
    }
    public void mi_Click(Object sender, EventArgs e)
    {
        ToolStripMenuItem mi = (ToolStripMenuItem)sender;
        lb.Text = mi.Text + "입니다";
    }
}
