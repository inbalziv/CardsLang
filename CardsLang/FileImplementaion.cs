using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows;

namespace CardsLang
{
    class FileImplementaion
    {
        public FileImplementaion() { }

        private string GetOrCreateFile()
        {
            var filePath = GetFilePath();                       
            if (!File.Exists(filePath))
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            return File.ReadAllText(filePath); 
            
        }
        public Dictionary<string, List<Card>> getDictFromFile()
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<Dictionary<string, List<Card>>>(GetOrCreateFile());
            

        }
        public bool saveDictToFile(Dictionary<string, List<Card>> dict)
        {
            string fileData;
            var filePath = GetFilePath();
            if (filePath != null)
            {
                fileData = convertToJson(dict);
                File.WriteAllText(filePath, fileData);
                return true;
            }
            
            return false;
        }
        private string convertToJson(Dictionary<string, List<Card>> dict)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize((object)dict);
        }
        private static string GetFilePath()
        {
            var cardsFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "CardsList",
                "CardsList.txt");
            return cardsFilePath;
        }
                
    }
}
