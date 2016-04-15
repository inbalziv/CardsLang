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
        private int _count;
        private int _succeedCount;
        private int _totalCards;
        public bool _isFrontFirst { get; private set; }
        private List<Card> _studyCards;
        private studyLists _studyListsWin;
        private AddLists _dictLists;        
        string _key;
        public Study(bool isRandom, bool isFrontFirst, AddLists dictLists, string key)
        {
            InitializeComponent();
            _dictLists = dictLists;
            this._isFrontFirst = isFrontFirst;
            _count = 0;
            _succeedCount = 0;
            _key = key;
            initialDisaply();
            prepareStudy(isRandom);
            study();
        }
        private void prepareStudy(bool isRandom)
        {
            List<Card> studyCards;
            if (_dictLists.CardLists.TryGetValue(_key, out studyCards))
            {
                _totalCards = studyCards.Count;
                if (isRandom)
                {
                    _studyCards = createRandom(studyCards);
                }
                else _studyCards = studyCards;
                
            }

        }
        private void initialDisaply()
        {
            labelCount.Content = _count.ToString() + " out of " + _totalCards.ToString();
            labelAvg.Content = "Avarage - 0%";
            buttonCorrect.Visibility = Visibility.Hidden;
            buttonNot.Visibility = Visibility.Hidden;
            buttonNext.Visibility = Visibility.Hidden;
            buttonShow.Visibility = Visibility.Visible;
            labelGrade.Visibility = Visibility.Hidden;

        }
        private void study()
        {
            string front;
            string back;
            if (_count < _studyCards.Count)
            {
                if (_isFrontFirst)
                {
                    front = _studyCards[_count]._front;
                    back = _studyCards[_count]._back;
                }
                else
                {
                    back = _studyCards[_count]._front;
                    front = _studyCards[_count]._back;
                }
                _count++;
                disaplyCard(front, back);
            }

        }
        private void disaplyCard(string front, string back)
        {
            labelFront.Content = front;
            labelFront.Visibility = Visibility.Visible;
            labelBack.Content = back;
            labelBack.Visibility = Visibility.Hidden;


        }
        private List<Card> createRandom(List<Card> list)
        {

            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        private void buttonShow_Click(object sender, RoutedEventArgs e)
        {
            labelBack.Visibility = Visibility.Visible;
            buttonNot.Visibility = Visibility.Visible;
            buttonCorrect.Visibility = Visibility.Visible;
            labelGrade.Visibility = Visibility.Visible;
            buttonShow.Visibility = Visibility.Hidden;
        }

        private void buttonCorrect_Click(object sender, RoutedEventArgs e)
        {
            _succeedCount++;
            disaplyGrade();
        }

        private void buttonNot_Click(object sender, RoutedEventArgs e)
        {
            disaplyGrade();
        }
        private void disaplyGrade()
        {
            buttonCorrect.Visibility = Visibility.Hidden;
            buttonNot.Visibility = Visibility.Hidden;
            buttonShow.Visibility = Visibility.Hidden;
            labelGrade.Visibility = Visibility.Hidden;
            labelAvg.Visibility = Visibility.Visible;
            labelCount.Visibility = Visibility.Visible;
            labelAvg.Content = _succeedCount.ToString();
            labelCount.Content = _count.ToString() + " out of " + _totalCards.ToString();
            if (_count < _totalCards)
                buttonNext.Visibility = Visibility.Visible;
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            initialDisaply();
            study();
        }

        private void buttonDone_Click(object sender, RoutedEventArgs e)
        {
            loadStudyListsWin();
        }
        private void loadStudyListsWin()
        {

            _studyListsWin = new studyLists(_dictLists);
            var hostStudy = new Window();
            hostStudy.Content = _studyListsWin;
            hostStudy.Show();
            hideThisWin();
        }
        private void hideThisWin()
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window.Content == _studyListsWin)
                {
                    window.Show();
                }
                else window.Close();
            }
        }
    }
}
