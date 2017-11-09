using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using RedCorona.Net;


using System.IO;
using System.Net;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Security.Cryptography;



namespace WindowsFormsApp3
{
    class SimpleServer
    {
        TextTranslationService textTranslationService = new TextTranslationService();
        Logger Logger = new Logger(@"C:\Users\Public\Log");
        Server server;
        ClientInfo client;
        public void Start()
        {
            server = new Server(2345, new ClientEvent(ClientConnect));
        }

        bool ClientConnect(Server serv, ClientInfo new_client)
        {
            new_client.Delimiter = "\n";
            new_client.OnRead += new ConnectionRead(ReadData);
            return true; // allow this connection
            
        }

        public void ReadData(ClientInfo ci, String text)
        {
            string [] textList = text.Split(new string[] { ";;;" }, StringSplitOptions.RemoveEmptyEntries);
            CommunicationFile commnunicationFile = new CommunicationFile(textList[0], Convert.ToDateTime(textList[1]), textList[2], textList[3]);

            //hereunder shalt be forged the translation component
            //Logger.WriteLog(commnunicationFile);
            List<CommunicationFile> communicationFileList = textTranslationService.Translate(commnunicationFile);


            foreach (CommunicationFile item in communicationFileList) /* translate the inhoud van het bericht en veranderen taal naar vertaalde taal hierboven doen 
                                                                          communicationfile is een list van allen communicationfiles die overeenkomen met elke taal*/
            {
                if (item.Language == "en")
                {
                    // logger second path
                 //   Logger.WriteLog(item);
                }
                server.Broadcast(item.ConvertToByteArray());
            }
            MessageBox.Show("WORKING?");
            Console.WriteLine("Received from " + ci.ID + ": " + text);
            if (text[0] == '!')
                server.Broadcast(commnunicationFile.ConvertToByteArray());
            else
            {
                ci.Send(commnunicationFile.ConvertToByteArray());
                //ci.Send(text)
                    }
        } 
    }
}
