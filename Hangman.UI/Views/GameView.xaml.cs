using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using Hangman.UI.VisualComponents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
        GameAdapter _gameAdapter;
        List<string> _categories;
        List<string> _tips;
        Adapters.ControllerAdapters.Services.Game.GameDTO _gameDTO;
        PlayerDTO _playerDTO;
        LanguageDTO _language;
        WordDTO _word;
        int _wrongLetters;
        TcpClient _challengerClient;
        NetworkStream _challengerStream;
        TcpClient _creatorClient;
        NetworkStream _creatorStream;
        private void StartChallengerClient()
        {

            _challengerClient = new TcpClient("127.0.0.1", 5000);
            _challengerStream = _challengerClient.GetStream();

            SendLetter(_gameDTO.GameCode);

        }
        private void StartCreatorClient()
        {

            _creatorClient = new TcpClient("127.0.0.1", 5000);
            _creatorStream = _creatorClient.GetStream();

            SendGameCode(_gameDTO.GameCode);
            ListenForLetters();

        }
        public void SendGameCode(string gameCode)
        {
            byte[] data = Encoding.UTF8.GetBytes(gameCode);
            _creatorStream.Write(data, 0, data.Length);
        }
        private void SendLetter(string letter)
        {

            if (_challengerClient.Connected && _challengerStream != null)
            {

                byte[] data = Encoding.UTF8.GetBytes(letter);

                _challengerStream.Write(data, 0, data.Length);

            }

        }

        private void ListenForLetters()
        {

            if (_creatorClient.Connected && _creatorStream != null)
            {

                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = _creatorStream.Read(buffer, 0, buffer.Length)) != 0)
                {

                    string letter = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (letter == _gameDTO.GameCode)
                    {
                        MessageBox.Show("Se ha conectado el Challenger", "Game Start", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    if (letter == "Game Over")
                    {

                        if (_gameDTO.Language == "Spanish")
                        {
                            MessageBox.Show("Fin del Juego", _word.WordES, MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (_gameDTO.Language == "English")
                        {
                            MessageBox.Show("Game Over", _word.WordEN, MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        _creatorStream.Close();
                        _creatorClient.Close();

                        Dispatcher.Invoke(() =>
                        {
                            MenuView menuView = new MenuView(_playerDTO, _language);

                            menuView.Show();
                            this.Close();
                            
                        });
                        return;

                    }
                    else
                    {

                        Dispatcher.Invoke(() =>
                        {
                            ReceiveLetter(letter);
                        });

                    }

                }

            }

        }

        public GameView(Adapters.ControllerAdapters.Services.Game.GameDTO gameDTO, PlayerDTO playerDTO, LanguageDTO language)
        {

            _gameAdapter = new GameAdapter();
            _gameDTO = gameDTO;
            _playerDTO = playerDTO;
            _categories = new List<string>();
            _tips = new List<string>();
            _word = new WordDTO();
            _wrongLetters = 0;


            InitializeComponent();

            TitleBarControl.SetSelectedLanguage(language);

            if (language.LanguageName.Equals("Spanish"))
            {
                TitleBarControl.FieldName = "Idioma";
            }
            else if (language.LanguageName.Equals("English"))
            {
                TitleBarControl.FieldName = "Language";
            }

            _language = TitleBarControl.SelectedItem as LanguageDTO;

            try
            {

                _word = _gameAdapter.SearchWord(_gameDTO.Word);

                if (_gameDTO.Language == "Spanish")
                {

                    Information_Category.GameInformation = "Categoría: " + _word.CategoryES;
                    Information_Tip.GameInformation = "Pista: " + _word.TipES;
                    InformationMessage.AlertMessageText = "Creador de la partida: " + _gameDTO.CreatorName + "\nCódigo de Partida: " + _gameDTO.GameCode;
                    HangmanWord.Word = _word.WordES;
                }
                else
                {

                    Information_Category.GameInformation = "Category: " + _word.CategoryEN;
                    Information_Tip.GameInformation = "Hint: " + _word.TipEN;
                    InformationMessage.AlertMessageText = "Game Creator: " + _gameDTO.CreatorName + "\nGame Code: " + _gameDTO.GameCode;
                    HangmanWord.Word = _word.WordEN;

                }

            }
            catch (Exception e)
            {

                InformationControl.Show("Error", e.Message, "Aceptar");
                this.Close();

            }

            if (_gameDTO.CreatorEmail != _playerDTO.Email)
            {

                try
                {

                    _gameAdapter.SetChallenger(_gameDTO.GameCode, _playerDTO.Email);
                    _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Playing");

                }
                catch (Exception e)
                {

                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();

                }

                Task.Run(() => StartChallengerClient());

            }
            else
            {

                Keyboard.Visibility = Visibility.Hidden;

                Task.Run(() => StartCreatorClient());

            }

        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_ExitGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea salir del juego?", "Salir del juego", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {

                if (_gameDTO.CreatorEmail != _playerDTO.Email)
                {

                    _gameAdapter.LeftGame(_gameDTO.GameCode);

                    _challengerStream.Close();
                    _challengerClient.Close();

                }
                else
                {

                    _creatorStream.Close();
                    _creatorClient.Close();

                }

                MenuView menuView = new MenuView(_playerDTO, _language);
                menuView.Show();
                this.Close();

            }
        }
        private void ReceiveLetter(String letter)
        {

            if (_gameDTO.CreatorEmail != _playerDTO.Email)
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

                                SendLetter("Game Over");

                                _challengerStream.Close();
                                _challengerClient.Close();

                                

                                this.Close();

                            }

                        }
                        else
                        {

                            AlertMessage.AlertMessageText = "La letra " + letter + " no forma parte de la palabra";
                            AlertMessage.Visibility = Visibility.Visible;

                            _wrongLetters++;

                            Hangman.IncorrectGuesses = _wrongLetters;


                            if (_wrongLetters == 5)
                            {
                                Information_Tip.Visibility = Visibility.Visible;
                            }

                            if (_wrongLetters == 6)
                            {

                                _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Lost");

                                MessageBox.Show("La palabra secreta era\n" + _word.WordES, "Derrota", MessageBoxButton.OK, MessageBoxImage.Error);

                                SendLetter("Game Over");

                                _challengerStream.Close();
                                _challengerClient.Close();

                                MenuView menuView = new MenuView(_playerDTO, _language);

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

                                SendLetter("Game Over");

                                _challengerStream.Close();
                                _challengerClient.Close();

                                MenuView menuView = new MenuView(_playerDTO, _language);

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

                                SendLetter("Game Over");

                                _challengerStream.Close();
                                _challengerClient.Close();

                                MenuView menuView = new MenuView(_playerDTO, _language);

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

                    MenuView menuView = new MenuView(_playerDTO, _language);

                    menuView.Show();

                    this.Close();

                }

            }
            else
            {

                try
                {

                    if (_gameDTO.Language == "Spanish")
                    {

                        if (_word.WordES.ToUpper().Contains(letter))
                        {
                            HangmanWord.DiscoverLetter(letter);
                        }
                        else
                        {

                            _wrongLetters++;
                            Hangman.IncorrectGuesses = _wrongLetters;

                        }

                    }
                    else if (_gameDTO.Language == "English")
                    {

                        if (_word.WordEN.ToUpper().Contains(letter))
                        {
                            HangmanWord.DiscoverLetter(letter);
                        }
                        else
                        {

                            _wrongLetters++;
                            Hangman.IncorrectGuesses = _wrongLetters;


                        }

                    }
                }
                catch (Exception ex)
                {

                    _gameAdapter.SetGameStatus(_gameDTO.GameCode, "Cancelled");

                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    MenuView menuView = new MenuView(_playerDTO, _language);

                    menuView.Show();

                    this.Close();

                }

            }

        }

        private void Keyboard_Btn0Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("0");
            SendLetter("0");

        }

        private void Keyboard_Btn1Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("1");
            SendLetter("1");
        }

        private void Keyboard_Btn2Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("2");
            SendLetter("2");
        }

        private void Keyboard_Btn3Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("3");
            SendLetter("3");
        }

        private void Keyboard_Btn4Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("4");
            SendLetter("4");
        }

        private void Keyboard_Btn5Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("5");
            SendLetter("5");
        }

        private void Keyboard_Btn6Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("6");
            SendLetter("6");
        }

        private void Keyboard_Btn7Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("7");
            SendLetter("7");
        }

        private void Keyboard_Btn8Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("8");
            SendLetter("8");
        }

        private void Keyboard_Btn9Click(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("9");
            SendLetter("9");
        }

        private void Keyboard_BtnAClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("A");
            SendLetter("A");
        }

        private void Keyboard_BtnBClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("B");
            SendLetter("B");
        }

        private void Keyboard_BtnCClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("C");
            SendLetter("C");
        }

        private void Keyboard_BtnDClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("D");
            SendLetter("D");
        }

        private void Keyboard_BtnEClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("E");
            SendLetter("E");
        }

        private void Keyboard_BtnFClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("F");
            SendLetter("F");
        }

        private void Keyboard_BtnGClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("G");
            SendLetter("G");
        }

        private void Keyboard_BtnHClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("H");
            SendLetter("H");
        }

        private void Keyboard_BtnIClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("I");
            SendLetter("I");
        }

        private void Keyboard_BtnJClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("J");
            SendLetter("J");
        }

        private void Keyboard_BtnKClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("K");
            SendLetter("K");
        }

        private void Keyboard_BtnLClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("L");
            SendLetter("L");
        }

        private void Keyboard_BtnMClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("M");
            SendLetter("M");
        }

        private void Keyboard_BtnNClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("N");
            SendLetter("N");
        }

        private void Keyboard_BtnÑClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Ñ");
            SendLetter("Ñ");
        }

        private void Keyboard_BtnOClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("O");
            SendLetter("O");
        }

        private void Keyboard_BtnPClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("P");
            SendLetter("P");
        }

        private void Keyboard_BtnQClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Q");
            SendLetter("Q");
        }

        private void Keyboard_BtnRClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("R");
            SendLetter("R");
        }

        private void Keyboard_BtnSClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("S");
            SendLetter("S");
        }

        private void Keyboard_BtnTClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("T");
            SendLetter("T");
        }

        private void Keyboard_BtnUClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("U");
            SendLetter("U");
        }

        private void Keyboard_BtnVClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("V");
            SendLetter("V");
        }

        private void Keyboard_BtnWClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("W");
            SendLetter("W");
        }

        private void Keyboard_BtnXClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("X");
            SendLetter("X");
        }

        private void Keyboard_BtnYClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Y");
            SendLetter("Y");
        }

        private void Keyboard_BtnZClick(object sender, RoutedEventArgs e)
        {
            ReceiveLetter("Z");
            SendLetter("Z");
        }

    }

}
