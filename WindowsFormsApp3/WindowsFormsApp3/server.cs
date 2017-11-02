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
            MessageBox.Show(text);
            Console.WriteLine("Received from " + ci.ID + ": " + text);
            if (text[0] == '!')
                server.Broadcast(Encoding.UTF8.GetBytes(text));
            else ci.Send(text);
        }
        /*
         string language = Encoding.UTF8.GetString(bb, 0, 3);
            string[] convertedStringArray = Encoding.UTF8.GetString(bb, 3, bb.Length-3).Split(new string[] { ";;;" }, StringSplitOptions.None);
            //messages.Split(new string[] { ";;;" }, StringSplitOptions.None);
            CummunicationFile incomingMessage = new CummunicationFile(language, Convert.ToDateTime(convertedStringArray[0]), convertedStringArray[1], convertedStringArray[2]);
        */
        
    }
}
