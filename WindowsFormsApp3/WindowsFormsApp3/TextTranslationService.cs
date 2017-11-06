using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp3
{


    // key 1: 57594cf0272d428cbd945e4978c8e70e
    // key 2: 5becb65e0c0f42f79bd0f6347f4bcca6
    class TextTranslationService
    {
        public CummunicationFile[] Translate(CummunicationFile cummunicationFile)
        {
            CummunicationFile cummunicationFile2 = new CummunicationFile("NED",  cummunicationFile.WriteTime, cummunicationFile.Author, cummunicationFile.Message);
            CummunicationFile[] cummunicationFileList = { cummunicationFile, cummunicationFile2 };
            return cummunicationFileList;
        }
        
    }
}
