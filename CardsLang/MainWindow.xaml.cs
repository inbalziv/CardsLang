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
    /// </summary>
    public partial class MainWindow : Window
    {
        private AddLists _lists;
        public MainWindow()
        {
            InitializeComponent();
            hideOtherWin();
        }
        public MainWindow(AddLists lists)
        {
            InitializeComponent();
            _lists = lists;
            hideOtherWin();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ListsControl _listControlWin;
            var host = new Window();
            if (_lists == null)
            {
                _listControlWin = new ListsControl();
            }
            else
            {
                _listControlWin = new ListsControl(_lists);
            }         

            host.Content = _listControlWin;
            host.Show();
            this.Close();
        }
        private void hideOtherWin()
        {
            foreach (Window window in App.Current.Windows)
            {
                if (this == window)
                {
                    window.Show();
                }
                else window.Hide();
            }
        }

        private void buttonStudy_Click(object sender, RoutedEventArgs e)
        {
            studyLists _studyListsWin;
            var host = new Window();
            if (_lists == null)
            {
                MessageBox.Show("No lists to study added, please add lists first","Error");
            }
            else
            {
                _studyListsWin = new studyLists(_lists);
                host.Content = _studyListsWin;
                host.Show();
                this.Close();
            }            
        }
    }
}

