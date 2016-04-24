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
        private FileImplementaion _cardsFile;
        public Window host = new Window();
        
        public NewSubject(AddLists listsBuild, string listName)
        {
            
            InitializeComponent();
            _listsBuild = listsBuild;
            _cardsFile = new FileImplementaion();
            _cards = new List<Card>();
            textBoxSubject.Text = listName;            
            textBoxSubject.IsReadOnly = true;
            updateDataGrid();            
            hideListsControl();            

            buttonUpdateCard.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;

        }
        private void updateDataGrid()
        {          
          
            if (textBoxSubject.Text != "")
            {
                List<Card> _currentValues;
                string key = textBoxSubject.Text;             
                
                if (_listsBuild.CardLists.TryGetValue(key, out _currentValues))
                {                    
                    dataGridCards.ItemsSource = _currentValues.ToList();                    
                    dataGridCards.UnselectAll();                      
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
            
            _cardsFile.saveDictToFile(_listsBuild.CardLists);              
            loadListsControlWin();

          }
          
          private void loadListsControlWin()
          {
              ListsControl _listControlWin = new ListsControl(_listsBuild);
              
              host.Content = _listControlWin;
              host.WindowStartupLocation = WindowStartupLocation.CenterScreen;
              host.Show();
              foreach (Window window in App.Current.Windows)
              {
                  if (window.Content == _listControlWin)
                  {
                    host.SizeToContent = SizeToContent.Width;
                    host.Height = 330;
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
