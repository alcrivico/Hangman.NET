using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.UI.VisualComponents;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Hangman.UI.Views
{
    public partial class MenuView : Window
    {
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private PlayerDTO _player;

        public MenuView(PlayerDTO player)
        {

            InitializeComponent();

            this._player = player;
            _resourceManager = new ResourceManager(
                "Hangman.UI.Resources.I18n.Strings", 
                typeof(MenuView).Assembly);

            SetLanguage("es");

            this.ProfileControl.UserName = 
                $"{_player.Name} {_player.FirstLastName} {_player.SecondLastName}";

        }

        private void SetLanguage(string language)
        {

            _cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;

            TextBlock_Title.Text = _resourceManager.GetString("RN_Title", _cultureInfo);
            Button_SearchGame.Text = _resourceManager.GetString("RN_BtnSearchGame", _cultureInfo);
            Button_CreateGame.Text = _resourceManager.GetString("RN_BtnCreateGame", _cultureInfo);
            Footer_Text.Text = _resourceManager.GetString("RN_Copyright", _cultureInfo);
            TitleBarControl.FieldName = _resourceManager.GetString("RN_LanguageField", _cultureInfo);

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

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_SearchGame_Loaded(object sender, RoutedEventArgs e) { }

        private void Button_SearchGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {

            SearchGameView searchGameView = new SearchGameView(_player);

            searchGameView.Show();
            this.Close();

        }

        private void Button_CreateGame_Loaded(object sender, RoutedEventArgs e) { }

        private void Button_CreateGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            LanguageDTO selectedLanguage = TitleBarControl.SelectedItem as LanguageDTO;

            if (selectedLanguage != null)
            {

                CreateGameView createGameView = new CreateGameView(_player, selectedLanguage);

                createGameView.Show();
                this.Close();

            }

        }

        private void ProfileControl_Loaded(object sender, RoutedEventArgs e) { }

        private void DoorButton_Click(object sender, RoutedEventArgs e)
        {

            bool result = ConfirmationControl.Show(
                _resourceManager.GetString("RN_ConfirmLogout", _cultureInfo),
                _resourceManager.GetString("RN_Confirmation", _cultureInfo),
                _resourceManager.GetString("RN_Acccept", _cultureInfo),
                _resourceManager.GetString("RN_Cancel", _cultureInfo)
            );

            if (result)
            {

                LogInView logInView = new LogInView();

                logInView.Show();
                this.Close();

            }

        }

        private void ProfileControl_MouseUp(object sender, MouseButtonEventArgs e)
        {

            ProfileView profileView = new ProfileView(_player);

            profileView.Show();
            this.Close();

        }

    }

}