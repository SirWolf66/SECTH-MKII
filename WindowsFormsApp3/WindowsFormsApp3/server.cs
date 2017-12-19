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
        Logger Logger = new Logger(@"C:\Users\Public\", "TestConfrence" , false);
        Logger LoggerRaw = new Logger(@"C:\Users\Public\", "TestConfrence", true);
        Server server;
        ClientInfo client;
        List<CommunicationFile> userList = new List<CommunicationFile>();

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

        public void CloseServer()
        {
            server.Close();
        }

        public void ReadData(ClientInfo ci, String text)
        {
            string [] textList = text.Split(new string[] { ";;;" }, StringSplitOptions.RemoveEmptyEntries);
            CommunicationFile commnunicationFile = new CommunicationFile(textList[0], Convert.ToDateTime(textList[1]), textList[2], textList[3]);

            if (commnunicationFile.Language == "++" || commnunicationFile.Language == "--")
            {
                LoggerRaw.WriteLog(commnunicationFile);
                Logger.WriteLog(commnunicationFile);
                userList.Add(commnunicationFile);
                foreach (CommunicationFile item in userList)
                {
                    server.Broadcast(item.ConvertToByteArray());
                }
            }
            else
            {
                LoggerRaw.WriteLog(commnunicationFile);
                List<CommunicationFile> communicationFileList = textTranslationService.Translate(commnunicationFile);
                foreach (CommunicationFile item in communicationFileList) /* translate the inhoud van het bericht en veranderen taal naar vertaalde taal hierboven doen 
                                                                          communicationfile is een list van allen communicationfiles die overeenkomen met elke taal*/
                {
                    if (item.Language == "en")
                    {
                        Logger.WriteLog(item);
                    }
                    server.Broadcast(item.ConvertToByteArray());
                }
            }
            //hereunder shalt be forged the translation component          

        } 
    }
}
