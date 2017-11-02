using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

using RedCorona.Net;


namespace WindowsFormsApp3
{
    class ServerCode
    {
        // https://codeabout.wordpress.com/2011/03/06/building-a-simple-server-client-application-using-c/

        IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
        List<TcpListener> list = new List<TcpListener>();

        public void CreateTCPListener()
        {
            TcpListener tcpListener = new TcpListener(ipAdress, 8000);
            list.Add(tcpListener);
        }

        public void Test(string clientIpAdress)
        {
            IPAddress ipAdress = IPAddress.Parse(clientIpAdress);
            
            TcpListener tcpListener = new TcpListener(ipAdress, 8000);
            list.Add(tcpListener);
            tcpListener.Start();

            Socket s = tcpListener.AcceptSocket();

            // When accepted
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
            byte[] b = new byte[100];
            int k = s.Receive(b);
            Console.WriteLine("Recieved...");
            

            // convert moet per groep bytes voor elke string / item om het object weer op te bouwen
            for (int i = 0; i < k; i++)
            {
                Console.Write(Convert.ToChar(b[i]));
            }

            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("Automatic message: String received by server!"));
            Console.WriteLine("\n Automatic message sent!");

            s.Close();
            tcpListener.Stop();

        }

}
}
