using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

class Sample1 : Form
{
    private TextBox tb;
    private Label[] lb = new Label[5];
    private Button bt;
    private TableLayoutPanel tlp;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "샘플";
        this.Width = 300; this.Height = 200;

        tb = new TextBox();
        tb.Dock = DockStyle.Fill;

        bt = new Button();
        bt.Width = this.Width;
        bt.Text = "검색";
        bt.Dock = DockStyle.Bottom;        
        
        tlp = new TableLayoutPanel();
        tlp.Dock = DockStyle.Fill;

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i] = new Label();
            lb[i].Dock = DockStyle.Fill;
        }

        tlp.ColumnCount = 2;
        tlp.RowCount = 3;

        lb[0].Text = "입력하세요.";
        lb[1].Text = "호스트명: ";
        lb[3].Text = "IP 주소: ";

        lb[0].Parent = tlp;
        tb.Parent = tlp;

        for (int i = 1; i < lb.Length; i++)
        {
            lb[i].Parent = tlp;
        }

        bt.Parent = this;
        tlp.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        try
        {
            IPHostEntry ih = Dns.GetHostEntry(tb.Text);
            IPAddress ia = ih.AddressList[0];

            lb[2].Text = ih.HostName;
            lb[4].Text = ia.ToString();
        }
        catch(SocketException se)
        {
            MessageBox.Show("호스트를 찾을 수 없었습니다.");
        }
        catch
        {
            MessageBox.Show("오류가 발생했습니다.");
        }
    }
}
