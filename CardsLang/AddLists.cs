using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLang
{
    public class AddLists
    {
        //  public Dictionary<string, List<Card>> _cardsList { get; set; }
        private Dictionary<string, List<Card>> _cardsList;
        // private List<Card> _cards;
        public AddLists()
        {
            _cardsList = new Dictionary<string, List<Card>>();
            //  _cards = new List<Card>();
        }

        public Dictionary<string, List<Card>> CardLists
        {
            get
            {
                if (_cardsList != null)
                    return _cardsList;
                else return new Dictionary<string, List<Card>>();
            }
            set
            {
                _cardsList = value;                 
                
            }
        }
        /**********************************************************************
          addList check if subject is valid
            if valid: creates a new CardsList with the subject --> returns 1 
            if subject already exist --> returns 0 
            if subject is null/empty --> returns -1 
        ***********************************************************************/
        public int addList(string subject)
        {          
            string _textBoxListName = subject;
            if (isValidSubject(_textBoxListName))
            {
                //create new CardsList                   
                if (!_cardsList.ContainsKey(_textBoxListName))
                {
                    _cardsList.Add(_textBoxListName, new List<Card>());
                    return 1;
                }
                else return 0;   //if name already exist
            }
            return -1;  //if name is empty
        }
        public bool updateListName(string updatedName, string oldName)
        {
            List<Card> _cards;
            
            string _updatedSubject = updatedName.Trim();
            if (isValidSubject(_updatedSubject))
            {
                if (!_cardsList.ContainsKey(_updatedSubject))
                    return false;
                else
                {
                    _cards = new List<Card>(_cardsList[_updatedSubject]);
                    _cardsList.Remove(oldName);  // do not change order
                    _cardsList[_updatedSubject] = _cards;  // or dict.Add(newKey, value) depending on ur comfort
                    return true;
                }             
            }
            return false;
            
        }
        public bool deleteCardsList(string _removeSubject)
        {
            try
            {
                _cardsList.Remove(_removeSubject);
                    return true;              
                
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
        private bool isValidSubject(string subject)
        {
            if (subject.Trim() != "")
                return true;
            else return false;
        }
        
        public void addCard(string front, string back, string key)
        {
            
            if (_cardsList.ContainsKey(key))
            {
                try
                {
                    _cardsList[key].Add(new Card(front, back));
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Key = \"tif\" is not found.");
                }
            }
            else
            {
                _cardsList.Add(key, new List<Card>());
                _cardsList[key].Add(new Card(front, back));
            }
        }
        /*
        public bool updateCard(string frontUpdate, string backUpdate, string subject)
        {            
            string _frontUpdate = frontUpdate.Trim();
            string _backUpdate = backUpdate.Trim();
            Card _card = new Card(_frontUpdate, _backUpdate);
            Card _originalCard;
            _cardsList.TryGetValue(subject, out (_card[8]._front));
            
            if (_cardsList.TryGetValue(subject))
            {

                // update card value, 
                _cardsList.Remove(_index);
                //maybe update values ??
                _cardsList.Insert(_index, _card);

                }
                return true;
            }
            else return false; 
    }*/
        public bool deleteCard(int indexDelete, string key)
        {            
            List<Card> tempList;
            if (indexDelete > -1)
            {
                if (_cardsList.TryGetValue(key, out tempList))
                {
                    tempList.RemoveAt(indexDelete);
                    _cardsList[key] = tempList;
                    return true;
                }
                return false;
            }
            else return false;
        } 
        public bool updateCard(int indexUpdate, string key, string updatedFront, string updatedBack)
        {
            List<Card> tempList;
            if (indexUpdate > -1)
            {
                if (_cardsList.TryGetValue(key, out tempList))
                {
                    tempList[indexUpdate]._front = updatedFront;
                    tempList[indexUpdate]._back = updatedBack;
                    _cardsList[key] = tempList;
                    return true;
                }
                return false;
            }
            else return false;
        }
    }
}
