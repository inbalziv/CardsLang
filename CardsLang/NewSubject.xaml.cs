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
    /// Interaction logic for NewSubject.xaml
    /// </summary>
    public partial class NewSubject : Page
    {
        private int _cardsNum = 0;
        public NewSubject()
        {
            InitializeComponent();
            _cardsNum = 0;
            var textBoxFront_TextChanged = new TextBox();
            
           // textBoxFront_TextChanged.Visible = false;
        }

        public bool Visible { get; private set; }

        private void buttonAddCard_Click(object sender, RoutedEventArgs e)
        {
            _cardsNum++;
        }

        private void textBoxFront_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_cardsNum == 0)
                this.Visible = false;
            else
            {

            }
        }

        private void textBox_Back_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
