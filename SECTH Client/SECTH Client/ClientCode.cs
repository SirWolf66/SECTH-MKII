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
        string clientLanguage = "ENG";


        IPAddress ipAdress = IPAddress.Parse("127.0.0.1");
        public void Test(string serverIpAdress, byte[] message)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(serverIpAdress, 2345);



            String str = Console.ReadLine();
            Stream stm = tcpClient.GetStream();
            

            //CummunicationFile communicationFile = new CummunicationFile();
            //Convert.ToByte(communicationFile);

            ASCIIEncoding asen = new ASCIIEncoding();
            //byte[] ba = asen.GetBytes(message);
            byte[] ba = message;
            Console.WriteLine("Sending...");

            stm.Write(ba, 0, ba.Length);
            

            byte[] bb = new byte[10000];
            int k = stm.Read(bb, 0, 100);

            
            string language = Encoding.UTF8.GetString(bb, 0, 3);
            if (language == clientLanguage)
            {
                string[] convertedStringArray = Encoding.UTF8.GetString(bb, 3, bb.Length - 3).Split(new string[] { ";;;" }, StringSplitOptions.None);
                //messages.Split(new string[] { ";;;" }, StringSplitOptions.None);
                CummunicationFile incomingMessage = new CummunicationFile(language, Convert.ToDateTime(convertedStringArray[0]), convertedStringArray[1], convertedStringArray[2]);
            }


            tcpClient.Close();
        }

    }
}
