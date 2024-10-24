using System;
using System.Windows.Forms;

class Sample1 : Form
{
    private Label lb;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "샘플";
        this.Width = 250; this.Height = 200;
     
        lb = new Label();
        lb.Text = "어서 오세요";
        
        lb.Parent = this;
       
        this.Click += new EventHandler(fm_Click);
    }
    public void fm_Click(Object sender, EventArgs e)
    {
        lb.Text = "안녕하세요";
    }
}
