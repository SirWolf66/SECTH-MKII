using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace SECTH_Cliënt
{
    class ClientCode
    {
        //https://codeabout.wordpress.com/2011/03/06/building-a-simple-server-client-application-using-c/

        IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
        public void Test(string serverIpAdress, string message)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(serverIpAdress, 2345);

            String str = Console.ReadLine();
            Stream stm = tcpClient.GetStream();

            //CummunicationFile communicationFile = new CummunicationFile();
            //Convert.ToByte(communicationFile);

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(message);
            Console.WriteLine("Sending...");

            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
            {
                Console.Write(Convert.ToChar(bb[i]));
            }

            tcpClient.Close();
        }

    }
}
