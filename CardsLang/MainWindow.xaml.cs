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
    /// Interaction logic for MainWindow.xaml

    public partial class MainWindow : Window
    {
        private AddLists _lists;
        private FileImplementaion _cardsFile;
        public MainWindow()
        {
            InitializeComponent();            
            _cardsFile = new FileImplementaion();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            hideOtherWin();
        }
        public MainWindow(AddLists lists)
        {
            InitializeComponent();
            _cardsFile = new FileImplementaion();
            _lists = lists;
            hideOtherWin();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ListsControl _listControlWin;
            var host = new Window();
            if (_lists == null)
            {
                if (_cardsFile.getDictFromFile() == null)
                    _listControlWin = new ListsControl();
                else
                {
                    _lists = new AddLists();
                    _lists.CardLists = _cardsFile.getDictFromFile();
                    _listControlWin = new ListsControl(_lists);
                }
            }
            else
            {
                _listControlWin = new ListsControl(_lists);
            }
            host.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            host.Content = _listControlWin;
            host.SizeToContent = SizeToContent.Width;
            host.Height = 330;
            host.Show();
            this.Close();
        }
        private void hideOtherWin()
        {
            foreach (Window window in App.Current.Windows)
            {
                if (this == window)
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.Show();
                }
                else window.Hide();
            }
        }

        private void buttonStudy_Click(object sender, RoutedEventArgs e)
        {
            studyLists _studyListsWin;
            var host = new Window();
            if (_cardsFile.getDictFromFile() == null)
                    MessageBox.Show("No lists to study added, please add lists first", "Error");
                     
            else
            {
                if (_lists == null)
                {
                    _lists = new AddLists();
                    _lists.CardLists = _cardsFile.getDictFromFile();
                }            
                _studyListsWin = new studyLists(_lists);
                host.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                host.Content = _studyListsWin;
                host.Width = 300;
                host.Height = 310;
                host.Show();
                this.Close();
            }            
        }
    }
}

