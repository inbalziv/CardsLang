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


namespace CardsLang
{
    /// <summary>
    /// Interaction logic for NewSubject.xaml
    /// </summary>
    public partial class NewSubject : Page
    {
        private int _cardsNum = 0;
        
        public NewSubject()
        {
            InitializeComponent();            
            _cardsNum = 0;
            labelCount.Content = _cardsNum.ToString();

        }

        public bool Visible { get; private set; }

        private void buttonAddCard_Click(object sender, RoutedEventArgs e)
        {
            
            handleCard(textBoxFront.Text.ToString(), textBoxBack.Text.ToString(),true);            
            _cardsNum++;
            labelCount.Content = _cardsNum.ToString();                
            
        }

        
        private void addCard(string front, string back)
        {
            //add card to list insubject
           // List<Card> _card = new List<Card>();
           // _card.Add(new Card { Age = 25, FirstName = "Alex", LastName = "Johnson" });
        }
        private void updateCard(string front, string back)
        {
            //search the card in subject
            //update card value
        }
        private void clearTextbox()
        {
            textBoxFront.Text = "";
            textBoxBack.Text = "";
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        }
    }
    
}
