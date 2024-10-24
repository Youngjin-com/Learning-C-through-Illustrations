using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

class Sample4C : Form
{
    public static string HOST = "localhost";
    public static int PORT = 10000;

    private TextBox tb;
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample4C());

    }
    public Sample4C()
    {
        this.Text = "샘플";
        this.Width = 300; this.Height = 300;

        tb = new TextBox();

        tb.Multiline = true;
        tb.ScrollBars = ScrollBars.Vertical;
        tb.Height = 150;
        tb.Dock = DockStyle.Top;

        bt = new Button();
        bt.Text = "접속";
        bt.Dock = DockStyle.Bottom;

        tb.Parent = this;
        bt.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        TcpClient tc = new TcpClient(HOST, PORT);

        StreamReader sr = new StreamReader(tc.GetStream());
        String str = sr.ReadLine();
        tb.Text = str;

        sr.Close();
        tc.Close();
    }
}
