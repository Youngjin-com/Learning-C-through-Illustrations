using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

class Sample4S
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
            StreamWriter sw = new StreamWriter(tc.GetStream());
            sw.WriteLine("이쪽은 서버입니다.");

            sw.Flush();
            sw.Close();
            tc.Close();
            break;
        }
    }
}
