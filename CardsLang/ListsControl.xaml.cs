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
    /// Interaction logic for ListsControl.xaml
    /// </summary>
    public partial class ListsControl : Page
    {
        // List<CardsList> _cardsList = new List<CardsList>();   
        ///   public Dictionary<string, List<Card>> _cardsList { get; set; }

        private AddLists _listsControl = new AddLists();

        private int _selectedIndex = -1;
        public ListsControl()
        {
            InitializeComponent();
            
         ///   _cardsList = new Dictionary<string, List<Card>>();
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonAddList.Visibility = Visibility.Visible;
            buttonEdit.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;
        }

        private void buttonAddList_Click(object sender, RoutedEventArgs e)
        {
            string _message;
            string _textBoxListName = textBoxListName.Text.ToString().Trim();
            int listCreated = _listsControl.addList(_textBoxListName);

            NewSubject _newSubjectWin;
            if (listCreated == 1)
            {
                _newSubjectWin = new NewSubject();
                var host = new Window();
                host.Content = _newSubjectWin;
                host.Show();

                _newSubjectWin.textBoxSubject.Text = _textBoxListName;

                // add list name to list box 
                listBoxLists.Items.Add(_textBoxListName);
                textBoxListName.Clear();
            }
            else
            {
                if (listCreated == 0)
                    _message = "List name already exist, please choose a different name";
                else
                {
                    _message = "Please fill list name";
                    textBoxListName.Clear();
                }
                MessageBox.Show(_message, "Error");
                
            }
            
            /*can be deleted
            NewSubject _newSubjectWin = new NewSubject();
            string _textBoxListName = textBoxListName.Text.ToString();
            if (isValidSubject(_textBoxListName))
            {
                //create new CardsList                   
                if (!_cardsList.ContainsKey(_textBoxListName))
                { 
                    _cardsList.Add(_textBoxListName, new List<Card>());
                    //open NewSubject window to start adding Cards
                    var host = new Window();
                    host.Content = _newSubjectWin;
                    host.Show();          
                    
                    _newSubjectWin.textBoxSubject.Text = _textBoxListName;

                    // add list name to list box 
                    listBoxLists.Items.Add(_textBoxListName);                    
                    textBoxListName.Clear();
                }
                else
                    MessageBox.Show("List name already exist, please choose a different name","Error Message");

            }
            else
            {
                //error message incase list name is null or space only
                textBoxListName.Clear();
                MessageBox.Show("Please fill list name","Error Message");
            }

    */
        }

        
        /*can be deleted
        private bool isValidSubject(string subject)
        {
            if (subject.Trim() != "")
                return true;
            else return false;
        } */
        

        private void listBoxLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int _index = this.listBoxLists.SelectedIndex;
            if (_index > -1)
            {
                this.textBoxListName.Text = listBoxLists.SelectedValue.ToString();  
                buttonUpdate.Visibility = Visibility.Visible;
                buttonAddList.Visibility = Visibility.Hidden;
                buttonEdit.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            string _updatedName = textBoxListName.Text.ToString();
            
            if (_listsControl.updateListName(_updatedName, listBoxLists.SelectedValue.ToString()))
            {
                updateBoxList(_updatedName, listBoxLists.SelectedIndex);
                clearTextbox();
                // listBoxLists.DataContext = _cards;
                buttonUpdate.Visibility = Visibility.Hidden;
                buttonAddList.Visibility = Visibility.Visible;
                buttonEdit.Visibility = Visibility.Hidden;
                buttonDelete.Visibility = Visibility.Hidden;

            }
            else MessageBox.Show("Name is not valid or already exist");
        }

       /*  can be deleted
       private bool updateListName(string updatedName, string oldName)
        {
            List<Card> _cards;
            int _indexUpdate;
            string _updatedName = updatedName.Trim();
            if (isValidSubject(_updatedName))
            {
                if (!_cardsList.ContainsKey(_updatedName))
                    return false;
                _indexUpdate = listBoxLists.SelectedIndex;
                if (_indexUpdate > -1)
                {
                    _cards = new List<Card>(_cardsList[_updatedName]);
                    _cardsList.Remove(oldName);  // do not change order
                    _cardsList[_updatedName] = _cards;  // or dict.Add(newKey, value) depending on ur comfort
                    updateBoxList(_updatedName, _indexUpdate);
                    clearTextbox();
                    return true;
                }
                return false;
            }
            else
            {
                MessageBox.Show("Name is not valid");
                return false;
            }
        } */

        private void updateBoxList(string updatedName, int index)
        {
            if ((listBoxLists.Items.Count >= index) && (index > 0))
            {
                _selectedIndex = index;
                listBoxLists.Items[_selectedIndex] = updatedName;
                
            }
        }
        private void clearTextbox()
        {
            textBoxListName.Text = "";            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete " + textBoxListName.Text.ToString() + " list? //n All cards will be delted" ,
    "Important Question", MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (result.ToString() == "Yes")
            {

                deleteList();
                // listBoxLists.DataContext = _cardsList;
                buttonUpdate.Visibility = Visibility.Hidden;
                buttonAddList.Visibility = Visibility.Visible;
                buttonEdit.Visibility = Visibility.Hidden;
                buttonDelete.Visibility = Visibility.Hidden;
            }
        }
        private void deleteList()
        {
            string _removeSubject = listBoxLists.SelectedValue.ToString();
            int _indexDelete = listBoxLists.SelectedIndex;

            if (_indexDelete > -1)
            {
                if (_listsControl.deleteCardsList(_removeSubject))
                {
                    listBoxLists.Items.RemoveAt(_indexDelete);
                    clearTextbox();
                }
            }
        }

        private void textBoxListName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
