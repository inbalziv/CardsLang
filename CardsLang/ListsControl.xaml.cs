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
using System.Data;


namespace CardsLang
{
    /// <summary>
    /// Interaction logic for ListsControl.xaml
    /// </summary> 
    /// 
    public delegate void CloseEventHandler(object sender, EventArgs e);

    public partial class ListsControl : Page
    {
        private FileImplementaion _cardsFile;
        public Window host = new Window();            
        private AddLists _listsControl;
        public ListsControl()
        {
            InitializeComponent();
            _listsControl = new AddLists();
            _cardsFile = new FileImplementaion();
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonAddList.Visibility = Visibility.Visible;
            buttonEdit.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;
            
        }
        public ListsControl(AddLists listsControl)
        {
            InitializeComponent();
            _cardsFile = new FileImplementaion();
            _listsControl = listsControl;           
            listBoxLists.ItemsSource = _listsControl.CardLists.Keys.ToList();
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
            if (listCreated == 1)
            {
                createNewSubject(_textBoxListName);
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
        }
        private void createNewSubject(string listName)
        {
          //  CloseAllWindows();
            NewSubject _newSubjectWin = new NewSubject(_listsControl, listName);            
            host.Content = _newSubjectWin;            
            host.Width = 430;
            host.Height = 420;
            host.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            host.Show();
            loadNewSubjectWin(_newSubjectWin);            
            listBoxLists.ItemsSource = _listsControl.CardLists.Keys.ToList();
            textBoxListName.Clear();
            
        }
        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }
        private void loadNewSubjectWin(NewSubject _newSubjectWin)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window.Content == _newSubjectWin)
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.Show();
                }
                else window.Hide();
            }
        }
      /*  public event CloseEventHandler Closed;
        {

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
                _cardsFile.saveDictToFile(_listsControl.CardLists);
                buttonUpdate.Visibility = Visibility.Hidden;
                buttonAddList.Visibility = Visibility.Visible;
                buttonEdit.Visibility = Visibility.Hidden;
                buttonDelete.Visibility = Visibility.Hidden;
            }
            else MessageBox.Show("Name is not valid or already exist");
        }

       
        private void updateBoxList(string updatedName, int index)
        {
            if ((listBoxLists.Items.Count >= index) && (index >= 0))
            {               
               
                listBoxLists.ItemsSource = _listsControl.CardLists.Keys.ToList();
                textBoxListName.Clear();              

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
                    listBoxLists.ItemsSource = _listsControl.CardLists.Keys.ToList();                   
                    _cardsFile.saveDictToFile(_listsControl.CardLists);
                    clearTextbox();
                }
            }
        }

        private void textBoxListName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {

            createNewSubject(textBoxListName.Text.ToString().Trim());
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(_listsControl);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            
            
        }
    }
}
