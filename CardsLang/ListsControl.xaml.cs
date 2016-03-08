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
        public ListsControl()
        {
            InitializeComponent();
        }

        private void buttonAddList_Click(object sender, RoutedEventArgs e)
        {
            NewSubject _newSubjectWin = new NewSubject();

            if (textBoxListName.ToString().Trim() != "")
            {
                 var host = new Window();
                 host.Content = _newSubjectWin;
                 host.Show();
                 _newSubjectWin.textBoxSubject.Text = textBoxListName.Text.ToString().Trim();
                
            }


        }

        private void textBoxListName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
