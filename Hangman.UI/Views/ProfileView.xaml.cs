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
        private ResourceManager resourceManager;
        private CultureInfo cultureInfo;
        private ProfileAdapter profileAdapter;
        private PlayerDTO _player;
        private ObservableCollection<Object> _gameDTOs;
        private List<Adapters.ControllerAdapters.Services.Player.GameDTO> _games;

        public ProfileView(PlayerDTO player)
        {
            InitializeComponent();

            resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(ProfileView).Assembly);

            _player = player;
            profileAdapter = new ProfileAdapter();
            _gameDTOs = new ObservableCollection<Object>();

            SetLanguage("es");
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
                MessageBox.Show(e.Message, resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Error);
                MenuView menuView = new MenuView(_player);
                menuView.Show();
                this.Close();
            }

            if (_games[0].GameCode != null)
            {
                SetGames(_games);
            }
            if (_games[0].ResponseCode == 1)
            {
                MessageBox.Show(resourceManager.GetString("RN_NoGamesFound", cultureInfo), resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Information);
            }

            GamesTable.SetItemsSource(_gameDTOs);
        }

        private void SetLanguage(string language)
        {
            cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Title.Text = resourceManager.GetString("RN_UserInfo", cultureInfo);
            Button_Back.Text = resourceManager.GetString("RN_Back", cultureInfo);
            score.FieldName = resourceManager.GetString("RN_GlobalScore", cultureInfo);
            Button_ModifyProfile.Text = resourceManager.GetString("RN_ModifyProfile", cultureInfo);
            name.FieldName = resourceManager.GetString("RN_Name", cultureInfo);
            firstLastName.FieldName = resourceManager.GetString("RN_FirstLastName", cultureInfo);
            secondLastName.FieldName = resourceManager.GetString("RN_SecondLastName", cultureInfo);
            email.FieldName = resourceManager.GetString("RN_Email", cultureInfo);
            birhtDate.FieldName = resourceManager.GetString("RN_BirthDate", cultureInfo);
            birhtDate.Text = _player.BirthDate.ToString("d", cultureInfo);
            Footer_Text.Text = resourceManager.GetString("RN_Copyright", cultureInfo);
            TitleBarControl.FieldName = resourceManager.GetString("RN_LanguageField", cultureInfo);

            // Actualiza los encabezados de la tabla
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
                    { "Name", resourceManager.GetString("RN_Opponent", cultureInfo) },
                    { "Width", "150.0" },
                    { "BindingName", "CreatorName" }
                },
                new Dictionary<string, string> {
                    { "Name", resourceManager.GetString("RN_GameDate", cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "CreationDate" }
                },
                new Dictionary<string, string> {
                    { "Name", resourceManager.GetString("RN_Word", cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "WordEN" }
                },
                new Dictionary<string, string> {
                    { "Name", resourceManager.GetString("RN_Result", cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "Status" }
                }
            };

            GamesTable.DefineColumns(columns);
        }

        private int CalculateGlobalScore(List<Adapters.ControllerAdapters.Services.Player.GameDTO> games)
        {
            int scorePerGame = 10;
            int totalScore = games.Count(game => game.Status == "Won") * scorePerGame;
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
                textBox.Text = _player.BirthDate.ToString("d", cultureInfo);
            }
        }
    }
}