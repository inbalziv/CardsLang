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
    /// Interaction logic for Study.xaml
    /// </summary>
    public partial class Study : Page
    {
        public bool _isRandom { get; private set; }
        public bool _isFrontFirst { get; private set; }
        private List<Card> _studyCards;
        public Study(bool isRandom, bool isFrontFirst, List<Card> studyCards)
        {
            InitializeComponent();
            this._isRandom = isRandom;
            this._isFrontFirst = isFrontFirst;
            _studyCards = studyCards;
            startStudy();
        }
        private void startStudy()
        {
            if (_isRandom)
                studyRandom();
            else studyNotRandom();
        }
        private void studyRandom()
        {

        }
        private void studyNotRandom()
        {

        }
    }
}
