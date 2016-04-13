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
        private List<Card> _cards;         
        private AddLists _listsBuild;
        public Window host = new Window();
        public NewSubject(AddLists listsBuild)
        {
            
            InitializeComponent();
            _listsBuild = listsBuild;
            _cards = new List<Card>();
            
            updateDataGrid();            
            hideListsControl();
         /*   dataGridCards.HeadersVisibility = DataGridHeadersVisibility.All;
            dataGridCards.IsReadOnly = true;
            dataGridCards.AutoGenerateColumns = true; */

          //  dataGridCards.Columns.Count = 1;
         //   DataGridTextColumn colStar1 = new DataGridTextColumn();
          // colStar1.Header = "Star 1";
         //   List<Card> listTemp = _listsBuild.CardLists.Values.SelectMany(c => c).ToList();
            //  
            // colStar1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
          //  colStar1.SetValue = listTemp[0]._front;
           // dataGridCards.Columns.Add(colStar1);

            buttonUpdateCard.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;

        }
        private void updateDataGrid()
        {
            //  List<Card> listTemp = _listsBuild.CardLists.Values.SelectMany(c => c).ToList();
            DataGridTextColumn frontColumn = new DataGridTextColumn();
            DataGridTextColumn backColumn = new DataGridTextColumn();
            frontColumn.Header = "Front";
            backColumn.Header = "Back";
            // colStar1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            //   colStar1.SetValue = _listsBuild.CardLists.Values.Where(out CardsLang.SelectMany(c => c).ToList();
            //   dataGridCards.Columns.Add(colStar1);
            if (textBoxSubject.Text != "")
            {
                List<Card> _currentValues;
                string key = textBoxSubject.Text;                
                
                if (_listsBuild.CardLists.TryGetValue(key, out _currentValues))
                {
                    int count = 0;
                    List<string> _frontValues = new List<string>();
                    List<string> _backValues = new List<string>();
                    
                 //   foreach (var value in _currentValues)
                    for (int i = 0; i < _currentValues.Count(); i++)
                    {
                        _frontValues.Add(_currentValues[i]._front);
                        _backValues.Add(_currentValues[i]._back);
                      //  if (i > 0)
                       // if ((dataGridCards.Items.Count >= i) && (i > 0))
                     //   {
                            
                            //    dataGridCards.Items[i] = _frontValues[i];
                            // dataGridCards.Items[i] = value._back;
                       // }
                       // count++;
                    }
                   // dataGridCards.Items.Add(_frontValues);
                    //   dataGridCards.so
                    dataGridCards.ItemsSource = _currentValues.ToList();
                    dataGridCards.Columns[0].Header = "Front";
                    dataGridCards.Columns[1].Header = "Back";
                    dataGridCards.Columns[0].Width = dataGridCards.Width / 2;
                    dataGridCards.Columns[1].Width = dataGridCards.Width / 2;
                    dataGridCards.UnselectAll();
                    // dataGridCardsBack.ItemsSource = _backValues.ToList();
                }
                    
            }
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
            loadListsControlWin();

        }
        private void loadListsControlWin()
        {
            ListsControl _listControlWin = new ListsControl(_listsBuild);
            host.Content = _listControlWin;
            host.Show();
            foreach (Window window in App.Current.Windows)

            {
                if (window.Content == _listControlWin)
                {
                    window.Show();
                }
                else window.Hide();
            }
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
