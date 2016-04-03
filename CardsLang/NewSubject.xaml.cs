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
using System.Data;
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
       // private Dictionary<string, List<Card>> _cardsList;
        private List<Card> _cards;
     //   AddLists _lists = new AddLists();
        //   public List<Card> _cards = new List<Card>();
        int _selectedIndex = -1;
        private AddLists _listsBuild;

        public NewSubject(AddLists listsBuild)
        {
            InitializeComponent();
            _listsBuild = listsBuild;
            _cards = new List<Card>();
            
            updateDataGrid();
            
            hideListsControl();
            dataGridCards.HeadersVisibility = DataGridHeadersVisibility.All;
            dataGridCards.IsReadOnly = true;
            dataGridCards.AutoGenerateColumns = true;
            DataGridTextColumn colStar1 = new DataGridTextColumn();
            colStar1.Header = "Star 1";
            colStar1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
          //  colStar1.SetValue = _listsBuild.CardLists.Values.Where(out CardsLang .SelectMany(c => c).ToList();
            dataGridCards.Columns.Add(colStar1);

            buttonUpdateCard.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;

        }
        private void updateDataGrid()
        {
            dataGridCards.ItemsSource = _listsBuild.CardLists.Values.SelectMany(c => c).ToList();
            
        }
        

        private void buttonAddCard_Click(object sender, RoutedEventArgs e)
        {
            
            addNewCard(textBoxFront.Text.ToString(), textBoxBack.Text.ToString());
            
        }
        private void hideListsControl()
        {
            //ListsControl.VisibilityProperty = VisibilityProperty.hi
        }
      
    
        
        private void clearTextbox()
        {
            textBoxFront.Text = "";
            textBoxBack.Text = "";
        }

       
        private void addNewCard(string front, string back)
        {
            string _front;
            string _back;
            if (isCardValid(front, back))
            {
                _front = front.Trim();
                _back = back.Trim();
                _listsBuild.addCard(_front, _back, textBoxSubject.Text);
                updateDataGrid();
                clearTextbox();
            }
        }
         
        
        private void updateDataGrid(string front, string back, int index)
        {
            if ((dataGridCards.Items.Count >= index) && (dataGridCards.Items.Count >= index) && (index > 0))                
            {
                _selectedIndex = index;
                dataGridCards.Items[_selectedIndex] = front;
                dataGridCards.Items[_selectedIndex] = back;
            }
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

         
        private void buttonDone_Click(object sender, RoutedEventArgs e)
        {

            
        }
        
        private void buttonUpdateCard_Click(object sender, RoutedEventArgs e)
        {
            string _frontUpdate = textBoxFront.Text.ToString();
            string _backUpdate = textBoxBack.Text.ToString();
            int _indexUpdate = this.dataGridCards.SelectedIndex;
            if (isCardValid(_frontUpdate, _backUpdate))
            {
                int _indexDelete = dataGridCards.SelectedIndex;
                if (_listsBuild.updateCard(_indexDelete, textBoxSubject.Text.ToString(), _frontUpdate, _backUpdate))
                {
                    updateDataGrid();
                    clearTextbox();                   
                    buttonAddCard.Visibility = Visibility.Visible;
                    buttonUpdateCard.Visibility = Visibility.Hidden;
                    buttonDelete.Visibility = Visibility.Hidden;
                  
                }
            } 
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        { 
            int _indexDelete = dataGridCards.SelectedIndex;
            if (_listsBuild.deleteCard(_indexDelete, textBoxSubject.Text.ToString()))
            {
                updateDataGrid();
                clearTextbox();
                buttonDelete.Visibility = Visibility.Hidden;
                buttonAddCard.Visibility = Visibility.Visible;
                buttonUpdateCard.Visibility = Visibility.Hidden;
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int _index = this.dataGridCards.SelectedIndex;
            if (_index > -1)
            {
                Card selectedCard = (Card)dataGridCards.SelectedItem;
                textBoxFront.Text = selectedCard._front.ToString();
                textBoxBack.Text = selectedCard._back.ToString();
                buttonAddCard.Visibility = Visibility.Hidden;
                buttonUpdateCard.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
            }
        }
    }
    
}
