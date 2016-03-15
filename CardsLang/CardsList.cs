using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsLang
{
    class CardsList
    {
        public List<Card> _cards { get; set; }
        public string _subject { get; set; }


        public CardsList(string subject)
        {
            this._subject = subject;
            this._cards = new List<Card>();

        }
        public void addCard(Card card)
        {
            _cards.Add(card);
        }
        public string getSubject()
        {
            return this._subject;
        }

        

        //find the card index and update it and returns true if updated
        //TBD: add exceptions
        public bool updateCard(Card card)
        {
            int _cardIndex;
            _cardIndex = _cards.IndexOf(card);
            if (_cardIndex != -1)
            {
                _cards.Insert(_cardIndex, card);
                _cards.RemoveAt(_cardIndex + 1);
                return true;
            }
            else return false;
        }


    }
}
