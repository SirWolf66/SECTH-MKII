using System;
using System.IO;

namespace WindowsFormsApp3
{
    class Logger
    {
        string logpath;

        public Logger(string path)
        {
            if (File.Exists(path))
            {
                logpath = path;
            }
            else
            {
                try
                {
                    File.Create(path);
                    logpath = path;
                }
                catch (Exception)
                {
                    throw;
                }                
            }            
        }

        public void WriteLog(CommunicationFile communication)
        {
            StreamWriter logWriter =  File.AppendText(logpath);
            logWriter.Write(communication.WriteTime + ", " + communication.Language + ": "  + communication.Author + ": " + communication.Message + Environment.NewLine);
        }

    }
}
