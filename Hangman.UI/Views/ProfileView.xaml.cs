using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.Services.Game;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using Hangman.UI.VisualComponents;
using System.Xml;

namespace Hangman.UI.Views
{
    public partial class ProfileView : Window
    {
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private ProfileAdapter _profileAdapter;
        private LanguageDTO _language;
        private PlayerDTO _player;
        private ObservableCollection<Object> _gameDTOs;
        private List<Adapters.ControllerAdapters.Services.Player.GameDTO> _games;

        public ProfileView(PlayerDTO player, LanguageDTO language)
        {
            InitializeComponent();

            _resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(ProfileView).Assembly);
            _player = player;
            _language = language;
            _profileAdapter = new ProfileAdapter();
            _gameDTOs = new ObservableCollection<Object>();

            InitializeTable();

            TitleBarControl.SetSelectedLanguage(_language);

            if (_language.LanguageName.Equals("Spanish"))
            {
                SetLanguage("es");
            }

            birhtDate.IsEnabled = false;
            email.IsEnabled = false;
            name.IsEnabled = false;
            firstLastName.IsEnabled = false;
            secondLastName.IsEnabled = false;
            score.IsEnabled = false;

            try
            {
                _games = _profileAdapter.GetPlayedGames(player.Email);
            }
            catch (Exception e)
            {

                InformationControl.Show(
                    _resourceManager.GetString("RN_Error", _cultureInfo),
                    e.Message,
                    _resourceManager.GetString("RN_Accept", _cultureInfo));

                MenuView menuView = new MenuView(_player, _language);

                menuView.Show();
                this.Close();

            }

            if (_games[0].GameCode != null)
            {
                SetGames(_games);
            }

            GamesTable.SetItemsSource(_gameDTOs);

        }

        private void SetLanguage(string language)
        {
            _cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;

            Title.Text = _resourceManager.GetString("RN_UserInfo", _cultureInfo);
            Button_Back.Text = _resourceManager.GetString("RN_Back", _cultureInfo);
            score.FieldName = _resourceManager.GetString("RN_GlobalScore", _cultureInfo);
            Button_ModifyProfile.Text = _resourceManager.GetString("RN_ModifyProfile", _cultureInfo);
            name.FieldName = _resourceManager.GetString("RN_Name", _cultureInfo);
            firstLastName.FieldName = _resourceManager.GetString("RN_FirstLastName", _cultureInfo);
            secondLastName.FieldName = _resourceManager.GetString("RN_SecondLastName", _cultureInfo);
            email.FieldName = _resourceManager.GetString("RN_Email", _cultureInfo);
            birhtDate.FieldName = _resourceManager.GetString("RN_BirthDate", _cultureInfo);
            birhtDate.Text = _player.BirthDate.ToString("d", _cultureInfo);
            Footer_Text.Text = _resourceManager.GetString("RN_Copyright", _cultureInfo);
            TitleBarControl.FieldName = _resourceManager.GetString("RN_LanguageField", _cultureInfo);
            _language = TitleBarControl.SelectedItem as LanguageDTO;

            InitializeTable();

        }

        private void TitleBarControl_LanguageChanged(object sender, RoutedEventArgs e)
        {
            if (TitleBarControl.SelectedItem is LanguageDTO languageDTO)
            {
                if (languageDTO.LanguageName.Equals("Spanish"))
                {
                    SetLanguage("es");
                }
                else if (languageDTO.LanguageName.Equals("English"))
                {
                    SetLanguage("en");
                }
            }
        }

        private void InitializeTable()
        {
            Dictionary<string, string>[] columns =
            {
                new Dictionary<string, string> {
                    { "Name", _resourceManager.GetString("RN_Opponent", _cultureInfo) },
                    { "Width", "150.0" },
                    { "BindingName", "CreatorName" }
                },
                new Dictionary<string, string> {
                    { "Name", _resourceManager.GetString("RN_GameDate", _cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "CreationDate" }
                },
                new Dictionary<string, string> {
                    { "Name", _resourceManager.GetString("RN_Word", _cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "Word" }
                },
                new Dictionary<string, string> {
                    { "Name", _resourceManager.GetString("RN_Result", _cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", _resourceManager.GetString("RN_ChooseStatus", _cultureInfo) }
                }
            };

            GamesTable.DefineColumns(columns);
        }

        private int CalculateGlobalScore(List<Adapters.ControllerAdapters.Services.Player.GameDTO> games)
        {
            int scorePerGame = 10;
            int totalScore = games.Count(game => game.StatusEn == "Won") * scorePerGame;
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
            MenuView menuView = new MenuView(_player, _language);
            menuView.Show();
            this.Close();
        }

        private void Button_ModifyProfile_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_ModifyProfile_ButtonControlClick(object sender, RoutedEventArgs e)
        {

            SignUpView profileView = new SignUpView(_player, _language);

            profileView.Show();
            this.Close();

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
                textBox.Text = _player.BirthDate.ToString("d", _cultureInfo);
            }
        }

    }

}