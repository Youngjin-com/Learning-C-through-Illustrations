using System;
using System.Windows.Forms;
using System.IO;

class Sample1 : Form
{
    private Button bt;
    private Label[] lb = new Label[3];

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "샘플";
        this.Width = 300; this.Height = 200;

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i] = new Label();
            lb[i].Top = i * lb[0].Height;
            lb[i].Width = 300;
        }

        bt = new Button();
        bt.Text = "표시";
        bt.Dock = DockStyle.Bottom;

        bt.Parent = this;

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i].Parent = this;
        }

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            FileInfo fi = new FileInfo(ofd.FileName);
            lb[0].Text = "파일명은 " + ofd.FileName + "입니다.";
            lb[1].Text = "절대 경로는 " + Path.GetFullPath(ofd.FileName) + "입니다.";
            lb[2].Text = "크기는 " + Convert.ToString(fi.Length) + "입니다.";
        }
    }
}
