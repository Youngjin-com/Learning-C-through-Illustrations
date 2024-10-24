using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Sample5S
{
    public static string HOST = "localhost";
    public static int PORT = 10000;

    public static void Main()
    {
        IPHostEntry ih = Dns.GetHostEntry(HOST);

        TcpListener tl = new TcpListener(ih.AddressList[0], PORT);
        tl.Start();

        Console.WriteLine("대기합니다.");
        while (true)
        {
            TcpClient tc = tl.AcceptTcpClient();
            Console.WriteLine("어서 오세요.");

            Client c = new Client(tc);
            Thread th = new Thread(c.run);
            th.Start();
        }
    }
}
class Client
{
    TcpClient tc;

    public Client(TcpClient c)
    {
        tc = c;
    }
    public void run()
    {
        StreamWriter sw = new StreamWriter(tc.GetStream());
        StreamReader sr = new StreamReader(tc.GetStream());

        while(true)
        {
            try
            {
                String str = sr.ReadLine();
                sw.WriteLine("서버:「" + str + "」입니다.");
                sw.Flush();
            }
            catch
            {
                sr.Close();
                sw.Close();
                tc.Close();
                break;
            }
        }
    }
}
