using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

class Sample : Form
{
    private MenuStrip ms;
    private ToolStripMenuItem[] mi = new ToolStripMenuItem[11];

    private List<Shape> shapeList;
    private int currentShape;
    private Color currentColor;

    static PrintDocument pd;

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample());
    }
    public Sample()
    {
        this.Text = "샘플";
        this.Width = 600; this.Height = 400;

        ms = new MenuStrip();
        mi[0] = new ToolStripMenuItem("파일");
        mi[1] = new ToolStripMenuItem("설정");
        mi[2] = new ToolStripMenuItem("도형");
        mi[3] = new ToolStripMenuItem("열기");
        mi[4] = new ToolStripMenuItem("저장");
        mi[5] = new ToolStripMenuItem("인쇄 미리보기");
        mi[6] = new ToolStripMenuItem("인쇄");
        mi[7] = new ToolStripMenuItem("사각형");
        mi[8] = new ToolStripMenuItem("타원형");
        mi[9] = new ToolStripMenuItem("직선");
        mi[10] = new ToolStripMenuItem("색");

        mi[0].DropDownItems.Add(mi[3]);
        mi[0].DropDownItems.Add(mi[4]);
        mi[0].DropDownItems.Add(new ToolStripSeparator());
        mi[0].DropDownItems.Add(mi[5]);
        mi[0].DropDownItems.Add(mi[6]);

        mi[1].DropDownItems.Add(mi[2]);
        mi[1].DropDownItems.Add(mi[10]);

        mi[2].DropDownItems.Add(mi[7]);
        mi[2].DropDownItems.Add(mi[8]);
        mi[2].DropDownItems.Add(mi[9]);

        ms.Items.Add(mi[0]);
        ms.Items.Add(mi[1]);

        this.MainMenuStrip = ms;
        ms.Parent = this;

        pd = new PrintDocument();
        
        shapeList = new List<Shape>();
        currentShape = Shape.RECT;
        currentColor = Color.Blue;

        for (int i = 0; i < mi.Length; i++)
        {
            mi[i].Click += new EventHandler(mi_Click);
        }

        this.MouseDown += new MouseEventHandler(fm_MouseDown);
        this.MouseUp += new MouseEventHandler(fm_MouseUp);
        this.Paint += new PaintEventHandler(fm_Paint);
        pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
    }
    public void mi_Click(Object sender, EventArgs e)
    {
        if (sender == mi[3])
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "그래픽 파일 |*.g";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                shapeList.Clear();
                shapeList = (List<Shape>)bf.Deserialize(fs);
                fs.Close();
                this.Invalidate();
            }
        }
        else if (sender == mi[4])
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "그래픽 파일 |*.g";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(fs, shapeList);
                fs.Close();
            }
        }
        else if (sender == mi[5])
        {
            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = pd;
            pp.ShowDialog();
        }
        else if (sender == mi[6])
        {
            pd.Print();
        }        
        else if (sender == mi[7])
        {
            currentShape = Shape.RECT;
        }
        else if (sender == mi[8])
        {
            currentShape = Shape.OVAL;
        }
        else if (sender == mi[9])
        {
            currentShape = Shape.LINE;
        }
        else if (sender == mi[10])
        {
            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                currentColor = cd.Color;
            }
        }
    }
    public void fm_MouseDown(Object sender, MouseEventArgs e)
    {
        // 도형 오브젝트를 작성한다
        Shape sh;
        if (currentShape == Shape.RECT)
        {
            sh = new Rect();
        }
        else if(currentShape == Shape.OVAL)
        {
          sh = new Oval();
        }
        else
        {
          sh = new Line();
        }
        // 도형 오브젝트의 색을 설정한다 
        sh.SetColor(currentColor);
        // 도형 오브젝트의 좌표를 설정한다 
        sh.SetStartPoint(e.X, e.Y);
        sh.SetEndPoint(e.X, e.Y);
        // 도형 오브젝트를 리스트 끝에 추가한다 
        shapeList.Add(sh);
    }
    public void fm_MouseUp(Object sender, MouseEventArgs e)
    {
        // 도형 오브젝트를 리스트 끝으로부터 꺼낸다
        Shape sh = (Shape)(shapeList[shapeList.Count-1] as Shape);
        sh.SetEndPoint(e.X, e.Y);
        // 폼을 다시 그린다
        this.Invalidate();
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        foreach (Shape sh in shapeList)
        {
            sh.Draw(g);
        }
    }
    public void pd_PrintPage(Object sender, PrintPageEventArgs e)
    {
        Graphics g = e.Graphics;

        foreach (Shape sh in shapeList)
        {
            sh.Draw(g);
        }
    }
}

[Serializable]
abstract class Shape
{
    public static int RECT = 0;
    public static int OVAL = 1;
    public static int LINE = 2;
    protected int x1, y1, x2, y2;
    protected Color c;

    abstract public void Draw(Graphics g);

    public void SetColor(Color c)
    {
        this.c = c;
    }
    public void SetStartPoint(int x, int y)
    {
        x1 = x; y1 = y;
    }
    public void SetEndPoint(int x, int y)
    {
        x2 = x; y2 = y;
    }
}
[Serializable]
class Rect : Shape
{
    override public void Draw(Graphics g)
    {
        SolidBrush sb = new SolidBrush(c);
        g.FillRectangle(sb, x1, y1, x2-x1, y2-y1);
    }
}
[Serializable]
class Oval : Shape
{
    override public void Draw(Graphics g)
    {
        SolidBrush sb = new SolidBrush(c);
        g.FillEllipse(sb, x1,y1, x2-x1, y2-y1);
    }
}
[Serializable]
class Line : Shape
{
    override public void Draw(Graphics g)
    {
        SolidBrush sb = new SolidBrush(c);
        Pen p = new Pen(sb);
        g.DrawLine(p,x1,y1,x2,y2);
    }
}
