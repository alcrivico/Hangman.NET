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
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using Hangman.Adapters.ControllerAdapters.Services.Game;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para SearchGameView.xaml
    /// </summary>
    public partial class SearchGameView : Window
    {
        private ObservableCollection<GameDTO> _gameDTOs;

        public SearchGameView()
        {
            _gameDTOs = new ObservableCollection<GameDTO>();

            SearchGameAdapter searchGameAdapter = new SearchGameAdapter();

            List<GameDTO> games;

            InitializeComponent();

            DefineGamesTable();

            try
            {
                games = searchGameAdapter.GetWaitingGames();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SetGames(games);
            GamesTable.SetItemsSource(_gameDTOs);

        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
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

        private void SetGames(List<GameDTO> games)
        {
            _gameDTOs.Clear();

            foreach (GameDTO game in games)
            {
                _gameDTOs.Add(game);
            }

        }

        private void AddGame(GameDTO game)
        {
            _gameDTOs.Add(game);
        }

    }
}
