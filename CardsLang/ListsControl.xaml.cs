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

        public bool Visible { get; private set; }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void newList_Click(object sender, RoutedEventArgs e)
        {
            NewSubject _newSubjectWin = new NewSubject();
            var host = new Window();
            host.Content = _newSubjectWin;
            host.Show();
            this.Visible = false;
            // this.close();
        }
    }
}
