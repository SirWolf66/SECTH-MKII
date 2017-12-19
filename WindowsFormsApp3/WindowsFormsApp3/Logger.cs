using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    class Logger
    {
        string logpath = @"C:\Users\Public\";
        string filepath;
        public Logger(string path, string confrenceName, bool raw)
        {
            string addition = raw ? "_Raw" : "_English";
            string file = path + "_" + DateTime.Now.ToString("yyyy_MM_dd_") + "_" + confrenceName + addition + ".txt";

            if (!Directory.Exists(path))
                {
                Directory.CreateDirectory(path);
                File.CreateText(file);
            }
            else
            {
                if (!File.Exists(file))
                {
                    File.CreateText(file);
                }
            }
            logpath = path;
            filepath = file;
        }

        public void WriteLog(CommunicationFile communication)
        {
            using (StreamWriter logWriter = File.AppendText(filepath))
                if (communication.Language == "++" || communication.Language == "--")
                {
                    string temp = (communication.Language == "++") ? " has joined" : " has left";
                    logWriter.Write(communication.WriteTime + ", " + communication.Author + temp + Environment.NewLine);

                }
                else
                {
                    logWriter.Write(communication.WriteTime + ", " + communication.Language + ": " + communication.Author + ": " + communication.Message + Environment.NewLine);

                }
        }

    }
}
