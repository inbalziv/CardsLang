using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLang
{
    class AddLists
    {
        //  public Dictionary<string, List<Card>> _cardsList { get; set; }
        private Dictionary<string, List<Card>> _cardsList;
        public List<Card> _cards { get; set; }
        public AddLists()
        {
            (App.Current as App)._dictList = new Dictionary<string, List<Card>>();
            _cardsList = (App.Current as App)._dictList;
            _cards = new List<Card>();
        }
        /**********************************************************************
          addList check if subject is valid
            if valid: creates a new CardsList with the subject --> returns 1 
            if subject already exist --> returns 0 
            if subject is null/empty --> returns -1 
        ***********************************************************************/
        public int addList(string subject)
        {
            NewSubject _newSubjectWin = new NewSubject();
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
            int _indexUpdate;
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
            if (_cardsList.ContainsKey(_removeSubject))
            { 
                _cardsList.Remove(_removeSubject);                
                return true;
            }
            else return false;
        }
        private bool isValidSubject(string subject)
        {
            if (subject.Trim() != "")
                return true;
            else return false;
        }

        public void addCard(string front, string back)
        {
            _cards.Add(new Card(front, back));
        }
        public bool updateCard(string frontUpdate, string backUpdate, int _index)
        {            
            string _frontUpdate = frontUpdate.Trim();
            string _backUpdate = backUpdate.Trim();
            Card _card = new Card(_frontUpdate, _backUpdate);

            if (_index > -1)
            {
                if ((_cards[_index]._front != _frontUpdate) && (_cards[_index]._back != _backUpdate))
                {
                    _cards[_index]._front = _frontUpdate;
                    _cards[_index]._back = _backUpdate;
                    //update card value, 
                    // _cards.RemoveAt(_index);
                    //maybe update values ??
                    //  _cards.Insert(_index, _card);

                }
                return true;
            }
            else return false;
        }
        
        public bool deleteCard(int indexDelete)
        {

            if (indexDelete > -1)
            {
                _cards.RemoveAt(indexDelete);                
                return true;
            }
            else return false;
        }
    }
}
