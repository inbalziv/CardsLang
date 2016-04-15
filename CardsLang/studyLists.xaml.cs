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
    /// Interaction logic for studyLists.xaml
    /// </summary>
    public partial class studyLists : Page
    {
        
        private AddLists _studyLists;
        private studyOptions _studyOptions;
        public studyLists(AddLists studyLists)
        {
            InitializeComponent();
            _studyLists = studyLists;
            
            buttonStartStudy.Visibility = Visibility.Hidden;
            if (_studyLists.CardLists.Count() <= 0)
            {
                labelStudy.Content = "No Lists added yet";
                listBoxSubjects.Visibility = Visibility.Hidden;
            }
            else
            {
                fillBoxList();
            }
            
            
        }

        private void listBoxSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonStartStudy.Visibility = Visibility.Visible;
           // _studyLists.CardLists.Keys.ToList();

        }

        private void buttonStartStudy_Click(object sender, RoutedEventArgs e)
        {
            List<Card> _cardsListStudy;
            if (_studyLists.CardLists.TryGetValue(listBoxSubjects.SelectedValue.ToString(), out _cardsListStudy))
            {
                _studyOptions = new studyOptions(_cardsListStudy);
                //Load window - study options
                var hostStudy = new Window();
                hostStudy.Content = _studyOptions;
                hostStudy.Show();
                hideThisWin();
                // this.Close();
            }
        }
        private void hideThisWin()
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window.Content == _studyOptions)
                {
                    window.Show();
                }
                else window.Hide();
            }
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
        private void fillBoxList()
        {             
             if (_studyLists != null)
             {
                 listBoxSubjects.ItemsSource = _studyLists.CardLists.Keys.ToList();
             }
        }
    }
}
