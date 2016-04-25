using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CardsLang
{
    class FileImplementaion
    {
        private AddLists _cardsList;
        public FileImplementaion()
        {
            _cardsList = new AddLists();
        }

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
            Dictionary<string, List<Card>> dict = new Dictionary<string, List<Card>>();            
            string tempList;
            Dictionary<string, object> dictTemp = JsonConvert.DeserializeObject<Dictionary<string, object>>(GetOrCreateFile());
            foreach (var obj in dictTemp)
            {              
                dict.Add(obj.Key, new List<Card>());
                tempList = obj.Value.ToString();               
                List<object> jsonObject = JsonConvert.DeserializeObject<List<object>>(tempList);                
                foreach (var row in jsonObject)
                {                   
                    var _cards = JsonConvert.DeserializeObject<dynamic>(row.ToString());                    
                    dict[obj.Key].Add(new Card(_cards._front.Value, _cards._back.Value));
                }

            }
            return dict;

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
