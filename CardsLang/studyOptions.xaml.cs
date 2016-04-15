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
    /// Interaction logic for studyOptions.xaml
    /// </summary>
    public partial class studyOptions : Page
    {
        private List<Card> _CardsStudy;
        Study _studyWin;
        public studyOptions(List<Card> cardsListStudy)
        {
            InitializeComponent();
            _CardsStudy = cardsListStudy;
            radioButtonFront.IsChecked = true;
            radioButtonBack.IsChecked = false;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            
            _studyWin = new Study(checkBoxRandom.IsChecked.Value, radioButtonFront.IsChecked.Value, _CardsStudy);            
            var hostStudy = new Window();
            hostStudy.Content = _studyWin;
            hostStudy.Show();
            hideThisWin();


        }
        private void hideThisWin()
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window.Content == _studyWin)
                {
                    window.Show();
                }
                else window.Close();
            }
        }
    }
}
