using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using Hangman.Adapters.ControllerAdapters.Services.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hangman.UI.VisualComponents;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Window
    {
        ProfileAdapter profileAdapter;
        private PlayerDTO _player;
        private ObservableCollection<Object> _gameDTOs;
        private List<Adapters.ControllerAdapters.Services.Player.GameDTO> _games;

        public ProfileView()
        {
            InitializeComponent();
            InitializeTable();
        }

        public ProfileView(PlayerDTO player)
        {
            
            _player = player;
            profileAdapter = new ProfileAdapter();
            _gameDTOs = new ObservableCollection<Object>();

            InitializeComponent();
            InitializeTable();

            birhtDate.IsEnabled = false;
            email.IsEnabled = false;
            name.IsEnabled = false;
            firstLastName.IsEnabled = false;
            secondLastName.IsEnabled = false;
            score.IsEnabled = false;

            try
            {
                _games = profileAdapter.GetPlayedGames(player.Email);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            SetGames(_games);
             
            GamesTable.SetItemsSource(_gameDTOs);
        }

        private void InitializeTable()
        {
            Dictionary<string, string>[] columns =
             {
                new Dictionary<string, string> {
                    { "Name", "Contrincante" },
                    { "Width", "150.0" },
                    { "BindingName", "CreatorName" }
                },
                new Dictionary<string, string> {
                    { "Name", "Fecha de Juego" },
                    { "Width", "*" },
                    { "BindingName", "CreationDate" }
                },
                new Dictionary<string, string> {
                    { "Name", "Palabra" },
                    { "Width", "*" },
                    { "BindingName", "WordEN" }
                },
                new Dictionary<string, string> {
                    { "Name", "Resultado" },
                    { "Width", "*" },
                    { "BindingName", "Status" }
                }
            };

            GamesTable.DefineColumns(columns);
        }

        private int CalculateGlobalScore(List<Adapters.ControllerAdapters.Services.Player.GameDTO> games)
        {
            int scorePerGame = 10;
            int totalScore = games.Count(game => game.Status == "Win") * scorePerGame;
            return totalScore;
        }

        private void SetGames(List<Adapters.ControllerAdapters.Services.Player.GameDTO> games)
        {
            _gameDTOs.Clear();

            foreach (Adapters.ControllerAdapters.Services.Player.GameDTO game in games)
            {
                _gameDTOs.Add(game);
            }

        }

        private void AddGame(Adapters.ControllerAdapters.Services.Game.GameDTO game)
        {
            _gameDTOs.Add(game);
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_Back_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Back_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            MenuView menuView = new MenuView(_player);

            menuView.Show();
            this.Close();
        }

        private void Button_ModifyProfile_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_ModifyProfile_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            SignUpView profileView = new SignUpView(_player);
            profileView.Show();
        }

        private void TextBoxControl_GlobalScore(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = CalculateGlobalScore(_games).ToString();
            }
        }

        private void TextBoxControl_Name(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = _player.Name;
            }
        }

        private void TextBoxControl_LastName(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = _player.FirstLastName;
            }
        }

        private void TextBoxControl_SecondLastName(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = _player.SecondLastName;
            }
        }

        private void TextBoxControl_Email(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = _player.Email;
            }
        }

        private void TextBoxControl_BirthDate(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = _player.BirthDate.Day.ToString() + "/" + _player.BirthDate.Month.ToString()+"/"+_player.BirthDate.Year.ToString();
            }
        }

    }
}
