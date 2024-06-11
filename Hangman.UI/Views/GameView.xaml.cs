using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
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
using System.Windows.Shapes;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        GameAdapter _gameAdapter ;
        List<string> _categories;
        List<string> _tips;
        Adapters.ControllerAdapters.Services.Game.GameDTO _gameDTO;
        PlayerDTO _playerDTO;
        WordDTO _word;
        int _wrongLetters;

        public GameView()
        {
            InitializeComponent();
        }

        public GameView(Adapters.ControllerAdapters.Services.Game.GameDTO gameDTO, PlayerDTO playerDTO)
        {

            _gameAdapter = new GameAdapter();
            _gameDTO = gameDTO;
            _playerDTO = playerDTO;
            _categories = new List<string>();
            _tips = new List<string>();
            _word = new WordDTO();
            _wrongLetters = 0;


            InitializeComponent();

            if (_gameDTO.CreatorName != _playerDTO.Name)
            {

                try
                {

                    _gameAdapter.SetChallenger(_gameDTO.GameCode, _playerDTO.Email);
                    _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Playing");

                    _word = _gameAdapter.SearchWord(_gameDTO.WordEN);

                    _categories.Add(_word.CategoryES);
                    _categories.Add(_word.CategoryEN);
                    _tips.Add(_word.TipES);
                    _tips.Add(_word.TipEN);

                    if(_gameDTO.Language == "Spanish") 
                    {

                        Information_Category.GameInformation = "Categoría: " + _categories[0];
                        Information_Tip.GameInformation = "Tip: " + _tips[0];
                        InformationMessage.AlertMessageText = "Creador de la partida: " + _gameDTO.CreatorName  + "\nCódigo de Partida: " + _gameDTO.GameCode;
                        HangmanWord.Word = _word.WordES;

                    }
                    else
                    {

                        Information_Category.GameInformation = "Category: " + _categories[1];
                        Information_Tip.GameInformation = "Tip: " + _tips[1];
                        InformationMessage.AlertMessageText = "Game Creator: " + _gameDTO.CreatorName + "\nGame Code: " + _gameDTO.GameCode;
                        HangmanWord.Word = _word.WordEN;

                    }

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();

                }

            }
            else
            {
                Keyboard.Visibility = Visibility.Hidden;
            }

        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_ExitGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea salir del juego?", "Salir del juego", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if(result == MessageBoxResult.Yes)
            {

                _gameAdapter.LeftGame(_gameDTO.GameCode);
                this.Close();

            }
        }

        private void ReceiveLetter(String letter)
        {

            if (_gameDTO.CreatorName != _playerDTO.Name)
            {

                try
                {

                    if (_gameDTO.Language == "Spanish")
                    {

                        if (_word.WordES.ToUpper().Contains(letter))
                        {
                            AlertMessage.Visibility = Visibility.Hidden;

                            HangmanWord.DiscoverLetter(letter);

                            if (HangmanWord.IsWordDiscovered)
                            {

                                _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Won");

                                MessageBox.Show("¡Felicidades! Has ganado la partida", _word.WordES, MessageBoxButton.OK, MessageBoxImage.Information);
                                
                                MenuView menuView = new MenuView(_playerDTO);

                                menuView.Show();

                                this.Close();

                            }

                        }
                        else
                        {

                            AlertMessage.AlertMessageText = "La letra " + letter + " no forma parte de la palabra";
                            AlertMessage.Visibility = Visibility.Visible;

                            _wrongLetters++;

                            Hangman.IncorrectGuesses = _wrongLetters;

                            if (_wrongLetters == 6)
                            {

                                _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Lost");

                                MessageBox.Show("La palabra secreta era\n" + _word.WordES, "Derrota", MessageBoxButton.OK, MessageBoxImage.Error);

                                MenuView menuView = new MenuView(_playerDTO);

                                menuView.Show();

                                this.Close();

                            }

                        }

                    }
                    else if (_gameDTO.Language == "English")
                    {

                        if (_word.WordEN.ToUpper().Contains(letter))
                        {

                            AlertMessage.Visibility = Visibility.Hidden;

                            HangmanWord.DiscoverLetter(letter);

                            if (HangmanWord.IsWordDiscovered)
                            {

                                _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Won");

                                MessageBox.Show("Congratulations! You have won the game", _word.WordEN, MessageBoxButton.OK, MessageBoxImage.Information);

                                MenuView menuView = new MenuView(_playerDTO);

                                menuView.Show();

                                this.Close();

                            }

                        }
                        else
                        {

                            AlertMessage.AlertMessageText = "The letter " + letter + " is not part of the word";
                            AlertMessage.Visibility = Visibility.Visible;

                            _wrongLetters++;
                            Hangman.IncorrectGuesses = _wrongLetters;

                            if (_wrongLetters == 6)
                            {

                                _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Lost");

                                MessageBox.Show("The secret word was\n" + _word.WordEN, "Defeat", MessageBoxButton.OK, MessageBoxImage.Error);

                                MenuView menuView = new MenuView(_playerDTO);

                                menuView.Show();

                                this.Close();

                            }

                        }

                    }

                }
                catch (Exception e)
                {
                    _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Cancelled");
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    MenuView menuView = new MenuView(_playerDTO);

                    menuView.Show();

                    this.Close();

                }

            }

        }

        private void Keyboard_Btn0Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("0");
        }

        private void Keyboard_Btn1Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("1");
        }

        private void Keyboard_Btn2Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("2");
        }

        private void Keyboard_Btn3Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("3");
        }

        private void Keyboard_Btn4Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("4");
        }

        private void Keyboard_Btn5Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("5");
        }

        private void Keyboard_Btn6Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("6");
        }

        private void Keyboard_Btn7Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("7");
        }

        private void Keyboard_Btn8Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("8");
        }

        private void Keyboard_Btn9Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("9");
        }

        private void Keyboard_BtnAClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("A");
        }

        private void Keyboard_BtnBClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("B");
        }

        private void Keyboard_BtnCClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("C");
        }

        private void Keyboard_BtnDClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("D");
        }

        private void Keyboard_BtnEClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("E");
        }

        private void Keyboard_BtnFClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("F");
        }

        private void Keyboard_BtnGClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("G");
        }

        private void Keyboard_BtnHClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("H");
        }

        private void Keyboard_BtnIClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("I");
        }

        private void Keyboard_BtnJClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("J");
        }

        private void Keyboard_BtnKClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("K");
        }

        private void Keyboard_BtnLClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("L");
        }

        private void Keyboard_BtnMClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("M");
        }

        private void Keyboard_BtnNClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("N");
        }

        private void Keyboard_BtnÑClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Ñ");
        }

        private void Keyboard_BtnOClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("O");
        }

        private void Keyboard_BtnPClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("P");
        }

        private void Keyboard_BtnQClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Q");
        }

        private void Keyboard_BtnRClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("R");
        }

        private void Keyboard_BtnSClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("S");
        }

        private void Keyboard_BtnTClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("T");
        }

        private void Keyboard_BtnUClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("U");
        }

        private void Keyboard_BtnVClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("V");
        }

        private void Keyboard_BtnWClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("W");
        }

        private void Keyboard_BtnXClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("X");
        }

        private void Keyboard_BtnYClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Y");
        }

        private void Keyboard_BtnZClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Z");
        }

    }

}
