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
        CommunicationFile systemMessage;
        string clientLanguage = "nl";
        string joincode = "++";
        string leavecode = "--";
        TcpClient tcpClient = new TcpClient();
        Stream stream;

        public bool Connected { get => tcpClient.Connected; }

        public ClientCode(string serverIpAdress, string language, string autor)
        {
            if (language != string.Empty)
            {
                clientLanguage = language;
            }
            tcpClient.Connect(serverIpAdress, 2345);
            stream = tcpClient.GetStream();
            systemMessage = new CommunicationFile(joincode, DateTime.Now, autor, Environment.NewLine);
            SendMessage(systemMessage.ConvertToByteArray());
        }

        private void ClientCode__show(object sender, EventArgs e)
        {
            RecieveMessage();
        }

        public CommunicationFile RecieveMessage()
        {
            byte[] bb = new byte[10000];
            int k = stream.Read(bb, 0, 10000);

            string language = Encoding.UTF8.GetString(bb, 0, 2);
            if (language == clientLanguage || language == joincode)
            {
                string[] convertedStringArray = Encoding.UTF8.GetString(bb, 2, bb.Length - 2).Split(new string[] { ";;;" }, StringSplitOptions.None);
                convertedStringArray[3] = convertedStringArray[3].Replace("\0", "");
                CommunicationFile incomingMessage = new CommunicationFile(language, Convert.ToDateTime(convertedStringArray[1]), convertedStringArray[2], convertedStringArray[3]);
                return incomingMessage;
            }
            return new CommunicationFile("ERROR", DateTime.Now, "ERROR", "");            
        }
               

        
        public void SendMessage(byte[] message)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            
            byte[] ba = message;           

            stream.Write(ba, 0, ba.Length);     
        }

        public void CloseConncetion(string autor)
        {
            systemMessage = new CommunicationFile(leavecode, DateTime.Now, autor, "");
            SendMessage(systemMessage.ConvertToByteArray());
            tcpClient.Close();
        }

    }
}
