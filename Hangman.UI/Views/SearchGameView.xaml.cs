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
        private ObservableCollection<GameDTO> _gameDTOs;

        public SearchGameView()
        {
            _gameDTOs = new ObservableCollection<GameDTO>();

            List<GameDTO> games = new List<GameDTO> //Esta lista es temporal se recuperará de un Adapter de Servicio
            {

                new GameDTO
                {

                    ID = "1",
                    CreatedBy = "alcrivico",
                    WaitingTime = 30

                },
                new GameDTO
                {

                    ID = "2",
                    CreatedBy = "raulh230600",
                    WaitingTime = 5

                },
                new GameDTO
                {

                    ID = "3",
                    CreatedBy = "XxJuanProGamerxX",
                    WaitingTime = 3

                },
                new GameDTO
                {

                    ID = "4",
                    CreatedBy = "miguelmorales2301",
                    WaitingTime = 1

                },
                new GameDTO
                {

                    ID = "5",
                    CreatedBy = "SoyUnPokemonYTuNo",
                    WaitingTime = 17

                }

            };

            InitializeComponent();
            DefineGamesTable();
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
                    { "BindingName", "ID" }

                },
                new Dictionary<string, string> {

                    { "Name", "Creada por:" },
                    { "Width", "*" },
                    { "BindingName", "CreatedBy" },

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
