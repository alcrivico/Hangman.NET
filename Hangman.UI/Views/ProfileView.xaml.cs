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
        private PlayerDTO player;
        private ObservableCollection<Object> gameDTOs;
        private List<Adapters.ControllerAdapters.Services.Player.GameDTO> games;

        public ProfileView()
        {
            InitializeComponent();
            InitializeTable();
        }

        public ProfileView(PlayerDTO player)
        {
            InitializeComponent();
            InitializeTable();
            this.player = player;

            profileAdapter = new ProfileAdapter();
            gameDTOs = new ObservableCollection<Object>();
            games = new List<Adapters.ControllerAdapters.Services.Player.GameDTO>();

            try
            {
                games = profileAdapter.GetPlayedGames(player.Email);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            //Sabes por que me sale este error?
            SetGames(games);
            GamesTable.SetItemsSource(gameDTOs);
        }

        private void InitializeTable()
        {
            Dictionary<string, string>[] columns =
             [
                new Dictionary<string, string> {
                    { "Name", "Contrincante" },
                    { "Width", "150.0" },
                    { "BindingName", "Opponent" }
                },
                new Dictionary<string, string> {
                    { "Name", "Fecha de Juego" },
                    { "Width", "*" },
                    { "BindingName", "GameDate" }
                },
                new Dictionary<string, string> {
                    { "Name", "palabra" },
                    { "Width", "*" },
                    { "BindingName", "Word" }
                },

                new Dictionary<string, string> {
                    { "Name", "Resultado" },
                    { "Width", "*" },
                    { "BindingName", "Result" }
                }
            ];

            GamesTable.DefineColumns(columns);
        }

        private int CalculateGlobalScore(List<Adapters.ControllerAdapters.Services.Player.GameDTO> games)
        {
            int scorePerGame = 10;
            int totalScore = games.Count(game => game.Status == "Win") * scorePerGame;
            return totalScore;
        }

        private void SetGames(List<Adapters.ControllerAdapters.Services.Game.GameDTO> games)
        {
            gameDTOs.Clear();

            foreach (Adapters.ControllerAdapters.Services.Game.GameDTO game in games)
            {
                gameDTOs.Add(game);
            }

        }

        private void AddGame(Adapters.ControllerAdapters.Services.Game.GameDTO game)
        {
            gameDTOs.Add(game);
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
            
            this.Close();
        }

        private void Button_ModifyProfile_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_ModifyProfile_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            SignUpView profileView = new SignUpView();
            profileView.Show();
        }

        private void TextBoxControl_GlobalScore(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = CalculateGlobalScore(games).ToString();
            }
        }

        private void TextBoxControl_Name(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = player.Name;
            }
        }

        private void TextBoxControl_LastName(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = player.FirstLastName;
            }
        }

        private void TextBoxControl_SecondLastName(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = player.SecondLastName;
            }
        }

        private void TextBoxControl_Email(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBoxControl;
            if (textBox != null)
            {
                textBox.Text = player.Email;
            }
        }

    }
}
