using System;
using System.Windows.Forms;

class Sample9 : Form
{
    private Label lb;
    private ListBox lbx;

    public static void Main()
    {
        Application.Run(new Sample9());
    }
    public Sample9()
    {
        string[] str = {"승용차", "트럭", "오픈카",
                      "택시", "스포츠카", "미니카",
                      "자동차", "이륜차", "바이크",
                      "비행기", "헬리콥터", "로켓"};

        this.Text = "샘플";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "어서 오세요";
        lb.Dock = DockStyle.Top;

        lbx = new ListBox();

        for (int i = 0; i < str.Length; i++)
        {
            lbx.Items.Add(str[i]);
        }
        lbx.Top = lb.Bottom;

        lb.Parent = this;
        lbx.Parent = this;

        lbx.SelectedIndexChanged += new EventHandler(lbx_SelectedIndexChanged);
    }
    public void lbx_SelectedIndexChanged(Object sender, EventArgs e)
    {
        ListBox tmp = (ListBox)sender;

        lb.Text = tmp.Text + "을(를) 선택했습니다";
     }
}
