using Hangman.UI.Views;
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

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Interaction logic for WordControl.xaml
    /// </summary>
    /// 
    public partial class WordControl : UserControl
    {
        private string _word;
        private int _goodLetters;
        private bool _isWordDiscovered;

        public string Word
        {
            get { return _word; }
            set
            {
                _word = value;
                UpdateWord();
            }
        }

        private int GoodLetters
        {

            get { return _goodLetters; }

            set 
            { 

                _goodLetters = value; 

                if (_goodLetters == Word.Length)
                {

                    _isWordDiscovered = true;

                }

            }

        }

        public bool IsWordDiscovered 
        {

            get { return _isWordDiscovered; }

        }

        public WordControl()
        {
            InitializeComponent();
        }

        public void DiscoverLetter(string letter)
        {

            foreach (LetterControl letterControl in Content.Children)
            {

                if (letterControl.Text == letter)
                {

                    letterControl.LetterOpacity = 1;
                    GoodLetters++;

                }

            }

        }

        public void BuildLetterControls (string word)
        {

            LetterControl[] letterControls = new LetterControl[40];
            int numberOfLetters = word.Length;

            for (int i = 0; i < 40; i++)
            {

                letterControls[i] = new LetterControl();
                letterControls[i].Opacity = 0.5;

            }

            for (int i = 0; i < word.Length; i++)
            {
                letterControls[i].Opacity = 1;
                letterControls[i].LetterOpacity = 0;
                letterControls[i].Text = word[i].ToString();
            }

            Content.RowDefinitions.Add(new RowDefinition());
            Content.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 20; i++)
            {

                Grid.SetRow(letterControls[i], 0);
                Grid.SetColumn(letterControls[i], i);
                Content.Children.Add(letterControls[i]);

            }

            for (int i = 20; i < 40; i++)
            {

                Grid.SetRow(letterControls[i], 2);
                Grid.SetColumn(letterControls[i], i - 20);
                Content.Children.Add(letterControls[i]);

            }

        }

        private void UpdateWord()
        {
            BuildLetterControls(Word);
        }
        
    }

}
