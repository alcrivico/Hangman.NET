using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using Hangman.UI.VisualComponents;
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


namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para SearchGameView.xaml
    /// </summary>
    public partial class SearchGameView : Window
    {
        SearchGameAdapter searchGameAdapter;
        private ObservableCollection<Object> _gameDTOs;
        private List<Adapters.ControllerAdapters.Services.Game.GameDTO> _games;
        private PlayerDTO _player;

        // Constructor de Prueba
        public SearchGameView()
        {

            searchGameAdapter = new SearchGameAdapter();
            _gameDTOs = new ObservableCollection<Object>();

            InitializeComponent();

            DefineGamesTable();

            try
            {
                _games = searchGameAdapter.GetWaitingGames();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            SetGames(_games);
            GamesTable.SetItemsSource(_gameDTOs);

        }

        //Constructor de Desarrollo
        public SearchGameView(PlayerDTO player)
        {

            _player = player;
            _gameDTOs = new ObservableCollection<Object>();

            SearchGameAdapter searchGameAdapter = new SearchGameAdapter();

            InitializeComponent();

            DefineGamesTable();

            try
            {
                _games = searchGameAdapter.GetWaitingGames();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            SetGames(_games);
            GamesTable.SetItemsSource(_gameDTOs);

        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_Back_ButtonControlClick(object sender, RoutedEventArgs e)
        {

            MenuView menuView = new MenuView(_player);

            menuView.Show();
            this.Close();

        }

        private void DefineGamesTable()         
        {

            Dictionary<string, string>[] columns =
            {

                new Dictionary<string, string> {

                    { "Name", "Código de Partida" },
                    { "Width", "150.0" },
                    { "BindingName", "GameCode" }

                },
                new Dictionary<string, string> {

                    { "Name", "Creada por:" },
                    { "Width", "*" },
                    { "BindingName", "CreatorName" },

                },
                new Dictionary<string, string> {

                    { "Name", "Tiempo esperando:" },
                    { "Width", "*" },
                    { "BindingName", "WaitingTime" },

                }

            };

            GamesTable.DefineColumns(columns);

        }

        private void SetGames(List<Adapters.ControllerAdapters.Services.Game.GameDTO> games)
        {
            _gameDTOs.Clear();

            foreach (Adapters.ControllerAdapters.Services.Game.GameDTO game in games)
            {
                _gameDTOs.Add(game);
            }

        }

        private void AddGame(Adapters.ControllerAdapters.Services.Game.GameDTO game)
        {
            _gameDTOs.Add(game);
        }

        private void TextBox_GameCode_TextBoxControlTextChanged(object sender, RoutedEventArgs e)
        {
            searchGameAdapter = new SearchGameAdapter();

            if (TextBox_GameCode.Text != "")
            {
                var filtered_gameDTOs = from game in _games
                                        where game.GameCode.Contains(TextBox_GameCode.Text.ToUpper())
                                        select game;

                SetGames(filtered_gameDTOs.ToList());
                GamesTable.SetItemsSource(_gameDTOs);
            } 
            else
            {

                try
                {
                    _games = searchGameAdapter.GetWaitingGames();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();

                }

                SetGames(_games);
                GamesTable.SetItemsSource(_gameDTOs);

            }

        }
    }
}
