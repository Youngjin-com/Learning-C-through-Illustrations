using System;
using System.Windows.Forms;
using System.Drawing;

class Sample2 : Form
{
    private Label lb;
    private RadioButton rb1, rb2, rb3;
    private GroupBox gb;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "샘플";
        this.Width = 300; this.Height = 200;

        lb = new Label();
        lb.Text = "Hello!";
        lb.Dock = DockStyle.Top;

        rb1 = new RadioButton();
        rb2 = new RadioButton();
        rb3 = new RadioButton();

        rb1.Text = "보통";
        rb2.Text = "볼드체";
        rb3.Text = "이탤릭체";

        rb1.Dock = DockStyle.Bottom;
        rb2.Dock = DockStyle.Bottom;
        rb3.Dock = DockStyle.Bottom;
        rb1.Checked = true;

        gb = new GroupBox();
        gb.Text = "종류";
        gb.Dock = DockStyle.Bottom;

        rb1.Parent = gb;
        rb2.Parent = gb;
        rb3.Parent = gb;

        lb.Parent = this;
        gb.Parent = this;

        rb1.Click += new EventHandler(rb_Click);
        rb2.Click += new EventHandler(rb_Click);
        rb3.Click += new EventHandler(rb_Click);
    }
    public void rb_Click(Object sender, EventArgs e)
    {
        RadioButton tmp = (RadioButton)sender;
        if (tmp == rb1)
        {
            lb.Font = new Font("Arial", 16, FontStyle.Regular);
        }
        else if (tmp == rb2)
        {
            lb.Font = new Font("Arial", 16, FontStyle.Bold);
        }
        else if (tmp == rb3)
        {
            lb.Font = new Font("Arial", 16, FontStyle.Italic);
        }
    }
}
