﻿using System;
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
using System.Drawing;



namespace CardsLang
{
    /// <summary>
    /// Interaction logic for NewSubject.xaml
    /// </summary>
     
    public partial class NewSubject : Page
    {
       // private Dictionary<string, List<Card>> _cardsList;
        private List<Card> _cards;
     //   AddLists _lists = new AddLists();
        //   public List<Card> _cards = new List<Card>();
        int _selectedIndex = -1;
        private AddLists _listsBuild = new AddLists();

        public NewSubject()
        {
            InitializeComponent();
            _cards = new List<Card>();

            hideListsControl();
            listBoxBack.SelectionMode = SelectionMode.Single;
          //  labelCount.Content = _cardsNum.ToString();
            buttonUpdateCard.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;

        }
           

        private void buttonAddCard_Click(object sender, RoutedEventArgs e)
        {
            
            addNewCard(textBoxFront.Text.ToString(), textBoxBack.Text.ToString());            
            
            listBoxBack.DataContext = _cards;

        }
        private void hideListsControl()
        {
            //ListsControl.VisibilityProperty = VisibilityProperty.hi
        }
        
    /*    private void addCard(string front, string back)
        {
            //add card to list in subject
            
            _cards.Add(new Card(front, back ));
        } */
        
        private void updateCard(string frontUpdate, string backUpdate)
        { /*
            int _indexUpdate;

            if (isCardValid(frontUpdate, backUpdate))
            {
                string _frontUpdate = frontUpdate.Trim();
                string _backUpdate = backUpdate.Trim();
                Card _card = new Card(_frontUpdate, _backUpdate);
                _indexUpdate = listBoxFront.SelectedIndex;

                if (_indexUpdate > -1)
                {
                    if ((_cards[_indexUpdate]._front != _frontUpdate) && (_cards[_indexUpdate]._back != _backUpdate))
                    {
                        _cards[_indexUpdate]._front = _frontUpdate;
                        _cards[_indexUpdate]._back = _backUpdate;
                        //update card value, 
                        // _cards.RemoveAt(_indexUpdate);
                        //maybe update values ??
                        //  _cards.Insert(_indexUpdate, _card);
                        updateBoxList(_frontUpdate, _backUpdate, _indexUpdate);
                        clearTextbox();
                    }
                }
            } */
        }
        private void deleteCard()
        { /*
            int _indexDelete = listBoxFront.SelectedIndex;
            if (_indexDelete > -1)
            {
                _cards.RemoveAt(_indexDelete);
                _cardsNum = _cardsNum--;
                listBoxFront.Items.RemoveAt(_indexDelete);
                listBoxBack.Items.RemoveAt(_indexDelete);
                clearTextbox();
                
            }*/
        }  
        private void clearTextbox()
        {
            textBoxFront.Text = "";
            textBoxBack.Text = "";
        }

       
        private void addNewCard(string front, string back)
        {
            string _front;
            string _back;
            if (isCardValid(front, back))
            {
                _front = front.Trim();
                _back = back.Trim();
                _listsBuild.addCard(_front, _back, textBoxSubject.Text);
                
                addCardToBoxList(_front, _back);                
                clearTextbox();
            }
        }
         
        private void addCardToBoxList(string front, string back)
        {
            
            this.listBoxFront.Items.Add(front);
            this.listBoxBack.Items.Add(back);

        }
        private void updateBoxList(string front, string back, int index)
        {
            if ((listBoxFront.Items.Count >= index) && (listBoxBack.Items.Count >= index) && (index > 0))                
            {
                _selectedIndex = index;
                listBoxFront.Items[_selectedIndex] = front;
                listBoxBack.Items[_selectedIndex] = back;
            }
        }
        private bool isCardValid(string front, string back)
        {
            if ((front.Trim() != "") && (back.Trim() != ""))
                return true;
            else return false;
        }
        private void textBoxFront_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Back_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBoxFront_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int _index;
            _index = this.listBoxFront.SelectedIndex;
            if (_index > -1)
            {                              
                this.textBoxFront.Text = listBoxFront.SelectedValue.ToString();
                this.textBoxBack.Text = listBoxBack.Items[_index].ToString();
                buttonAddCard.Visibility = Visibility.Hidden;
                buttonUpdateCard.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
            }

        }
        //listbox back
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int _index;
            
            _index = this.listBoxBack.SelectedIndex;
            if (_index > -1)
            {
                this.textBoxBack.Text = listBoxBack.SelectedValue.ToString();
                this.textBoxFront.Text = listBoxFront.Items[_index].ToString();
                listBoxFront.SelectedIndex = _index;
                buttonAddCard.Visibility = Visibility.Hidden;
                buttonUpdateCard.Visibility = Visibility.Visible;
                buttonDelete.Visibility = Visibility.Visible;
            }



        }
        
        private void buttonDone_Click(object sender, RoutedEventArgs e)
        {

            
        }
        
        private void buttonUpdateCard_Click(object sender, RoutedEventArgs e)
        {/*
            string _frontUpdate = textBoxFront.Text.ToString();
            string _backUpdate = textBoxBack.Text.ToString();
            
            if (isCardValid(_frontUpdate, textBoxBack.Text.ToString()))
            {
                int _indexUpdate = listBoxFront.SelectedIndex;
                if (_listsBuild.updateCard(_frontUpdate, _backUpdate, _indexUpdate))
                {
                    listBoxBack.DataContext = _cards;
                    buttonAddCard.Visibility = Visibility.Visible;
                    buttonUpdateCard.Visibility = Visibility.Hidden;
                    buttonDelete.Visibility = Visibility.Hidden;
                    updateBoxList(_frontUpdate, _backUpdate, _indexUpdate);
                    clearTextbox();
                }
            } */
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        { /*
            int _indexDelete = listBoxFront.SelectedIndex;
            if (_listsBuild.deleteCard(_indexDelete))
            {
                listBoxFront.Items.RemoveAt(_indexDelete);
                listBoxBack.Items.RemoveAt(_indexDelete);
                clearTextbox();
                buttonDelete.Visibility = Visibility.Hidden;
                buttonAddCard.Visibility = Visibility.Visible;
                buttonUpdateCard.Visibility = Visibility.Hidden;
            }*/
        } 
    }
    
}
