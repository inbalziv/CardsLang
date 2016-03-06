using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLang
{
    
    class WriteToFile
    {
        private static string _fileName = "cardsDB.json";        
        private string _path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), _fileName);
                
        private void createFile()
        {

        }
        public void updateFile() { }
    }
    
}
