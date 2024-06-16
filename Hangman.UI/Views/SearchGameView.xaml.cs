using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using Hangman.UI.VisualComponents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
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
using System.Globalization;


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
        private LanguageDTO _language;
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;

        public SearchGameView(PlayerDTO player, LanguageDTO language)
        {

            _player = player;
            _language = language;
            _gameDTOs = new ObservableCollection<Object>();
            _resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(SearchGameView).Assembly);

            SearchGameAdapter searchGameAdapter = new SearchGameAdapter();

            InitializeComponent();

            if (_language.LanguageName.Equals("Spanish"))
            {
                SetLanguage("es");
            }
            else if (_language.LanguageName.Equals("English"))
            {
                SetLanguage("en");
            }

            DefineGamesTable();

            try
            {
                _games = searchGameAdapter.GetWaitingGames();
            }
            catch (Exception e)
            {

                InformationControl.Show(
                    _resourceManager.GetString("RN_Error", _cultureInfo), 
                    _resourceManager.GetString("RN_NoWaitingGamesFound", _cultureInfo), 
                    _resourceManager.GetString("RN_Accept", _cultureInfo));
                this.Close();

            }

            SetGames(_games);
            GamesTable.SetItemsSource(_gameDTOs);

        }

        private void SetLanguage(string language)
        {
            _cultureInfo = new CultureInfo(language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = _cultureInfo;

            Title.Text = _resourceManager.GetString("RN_TitleSearchGame", _cultureInfo);
            TextBox_GameCode.FieldName = _resourceManager.GetString("RN_GameCode", _cultureInfo);
            Button_Join.Text = _resourceManager.GetString("RN_BtnSearchGame", _cultureInfo);
            Button_Back.Text = _resourceManager.GetString("RN_Back", _cultureInfo);
            Footer_Text.Text = _resourceManager.GetString("RN_Copyright", _cultureInfo);
            TitleBarControl.FieldName = _resourceManager.GetString("RN_LanguageField", _cultureInfo);

            TitleBarControl.SelectComboBoxLanguageName(_language.LanguageName);
            DefineGamesTable();

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

                    { "Name", _resourceManager.GetString("RN_GameCode", _cultureInfo) },
                    { "Width", "150.0" },
                    { "BindingName", "GameCode" }

                },
                new Dictionary<string, string> {

                    { "Name", _resourceManager.GetString("RN_CreatedBy", _cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "CreatorName" },

                },
                new Dictionary<string, string> {

                    { "Name", _resourceManager.GetString("RN_TimeWaiting", _cultureInfo) },
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

                    InformationControl.Show(
                        _resourceManager.GetString("RN_Error", _cultureInfo), 
                        _resourceManager.GetString("RN_NoWaitingGamesFound", _cultureInfo), 
                        _resourceManager.GetString("RN_Accept", _cultureInfo));
                    this.Close();

                }

                SetGames(_games);
                GamesTable.SetItemsSource(_gameDTOs);

            }

        }

        private void Button_Join_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            GameView gameView = new GameView((Adapters.ControllerAdapters.Services.Game.GameDTO) GamesTable.GetSelectedItem(), _player);
            gameView.Show();
            this.Close();
        }

        private void GamesTable_SelectedItemChanged(object sender, RoutedEventArgs e)
        {

            Button_Join.IsEnabled = true;
            Button_Join.Opacity = 1;

        }

    }

}
