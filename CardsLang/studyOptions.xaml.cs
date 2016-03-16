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
        public studyOptions()
        {
            InitializeComponent();
            radioButtonFront.IsChecked = true;
            radioButtonBack.IsChecked = false;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            
            Study _studyWin = new Study(checkBoxRandom.IsChecked.Value, radioButtonFront.IsChecked.Value);            
            var hostStudy = new Window();
            hostStudy.Content = _studyWin;
            hostStudy.Show();
            
        }
    }
}
