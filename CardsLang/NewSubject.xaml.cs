using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;



namespace CardsLang
{
    /// <summary>
    /// Interaction logic for NewSubject.xaml
    /// </summary>
    public partial class NewSubject : Page
    {
        private int _cardsNum = 0;
        List<Card> _cards = new List<Card>();
        
        public NewSubject()
        {
            InitializeComponent();            
            _cardsNum = 0;
            listBoxBack.SelectionMode = SelectionMode.Single;
            labelCount.Content = _cardsNum.ToString();
            buttonUpdateCard.Visibility = Visibility.Hidden;

        }

        public bool Visible { get; private set; }

        private void buttonAddCard_Click(object sender, RoutedEventArgs e)
        {
            
            handleCard(textBoxFront.Text.ToString(), textBoxBack.Text.ToString(),true);            
            _cardsNum++;
            labelCount.Content = _cardsNum.ToString();
            listBoxBack.DataContext = _cards;


        }

        
        private void addCard(string front, string back)
        {
            //add card to list in subject
            
            _cards.Add(new Card(front, back ));
        }
        private void updateCard(string frontUpdate, string backUpdate)
        {
            int _indexUpdate;
            //search the card in subject
            Card _card = new Card(frontUpdate, backUpdate);
            _indexUpdate = _cards.BinarySearch(_card);
            if (_indexUpdate > 0)
            {
                
                _cards[_indexUpdate]._front = frontUpdate;
                _cards[_indexUpdate]._back = backUpdate;
                //update card value, 
               // _cards.RemoveAt(_indexUpdate);
                //maybe update values ??
              //  _cards.Insert(_indexUpdate, _card);
               
            }
        }
        private void clearTextbox()
        {
            textBoxFront.Text = "";
            textBoxBack.Text = "";
        }

        
        private void handleCard(string front, string back, bool isNew)
        {
            string _front;
            string _back;
            if (isCardValid(front, back))
            {
                _front = front.Trim();
                _back = back.Trim();
                if (isNew)
                {
                    addCard(_front, _back);
                    addCardToBoxList(_front, _back);
                }
                else
                {
                    updateCard(_front, _back);
                    updateBoxList(_front, _back);

                }
                clearTextbox();
            }
        }
        private void addCardToBoxList(string front, string back)
        {
            
            this.listBoxFront.Items.Add(front);
            this.listBoxBack.Items.Add(back);

        }
        private void updateBoxList(string front, string back)
        {

        }
        private bool isCardValid(string front, string back)
        {
            if ((front.Trim() != "") && (back.Trim() != ""))
                return true;
            else return false;
        }
        private void textBoxFront_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Back_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBoxFront_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int _index;
            _index = this.listBoxFront.SelectedIndex;            
            this.textBoxFront.Text = listBoxFront.SelectedValue.ToString();
            this.textBoxBack.Text = listBoxBack.Items[_index].ToString();
            listBoxBack.SelectedIndex = _index;


        }
        //listbox back
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int _index;
            
            _index = this.listBoxBack.SelectedIndex;
            this.textBoxBack.Text = listBoxBack.SelectedValue.ToString();
            this.textBoxFront.Text = listBoxFront.Items[_index].ToString();
            listBoxFront.SelectedIndex = _index;
            buttonAddCard.Visibility = Visibility.Hidden;
            buttonUpdateCard.Visibility = Visibility.Visible;



        }
        
        private void buttonDone_Click(object sender, RoutedEventArgs e)
        {

            
        }

        private void buttonUpdateCard_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
