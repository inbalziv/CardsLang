using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CardsLang
{
    public class Card
    {
        [JsonProperty("_front")]
        public string _front { get;  set; }
        [JsonProperty("_back")]
        public string _back { get;  set; }
        
        public Card(string front, string back)
        {
            this._front = front;
            this._back = back;
        }
        public Card(Card card)
        {
            this._front = card._front;
            this._back = card._back;
        }
        
    }

}
