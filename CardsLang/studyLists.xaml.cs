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
        public studyLists(AddLists studyLists)
        {
            InitializeComponent();
            _studyLists = studyLists;
            
            buttonStartStudy.Visibility = Visibility.Hidden;
            //TBD: if no subjects, change text + hide list box
            // else: fill box list
            fillBoxList();
        }

        private void listBoxSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonStartStudy.Visibility = Visibility.Visible;
            _studyLists.CardLists.Keys.ToList();

        }

        private void buttonStartStudy_Click(object sender, RoutedEventArgs e)
        {
            studyOptions _studyOptions = new studyOptions();
            //Load window - study options
            var hostStudy = new Window();
            hostStudy.Content = _studyOptions;
            hostStudy.Show();
           // this.Close();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            //TBD; close this window and show main
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
