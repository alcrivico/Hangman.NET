using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.Services.Player;
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
        private ResourceManager resourceManager;
        private CultureInfo cultureInfo;
        private PlayerDTO player;

        public MenuView(PlayerDTO player)
        {

            InitializeComponent();

            this.player = player;
            resourceManager = new ResourceManager(
                "Hangman.UI.Resources.I18n.Strings", 
                typeof(MenuView).Assembly);

            SetLanguage("es");

            this.ProfileControl.UserName = 
                $"{player.Name} {player.FirstLastName} {player.SecondLastName}";

        }

        private void SetLanguage(string language)
        {

            cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            TextBlock_Title.Text = resourceManager.GetString("RN_Title", cultureInfo);
            Button_SearchGame.Text = resourceManager.GetString("RN_BtnSearchGame", cultureInfo);
            Button_CreateGame.Text = resourceManager.GetString("RN_BtnCreateGame", cultureInfo);
            Footer_Text.Text = resourceManager.GetString("RN_Copyright", cultureInfo);
            TitleBarControl.FieldName = resourceManager.GetString("RN_LanguageField", cultureInfo);

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

            SearchGameView searchGameView = new SearchGameView(player);

            searchGameView.Show();
            this.Close();

        }

        private void Button_CreateGame_Loaded(object sender, RoutedEventArgs e) { }

        private void Button_CreateGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            CreateGameView createGameView = new CreateGameView(player);

            createGameView.Show();
            this.Close();

        }

        private void ProfileControl_Loaded(object sender, RoutedEventArgs e) { }

        private void DoorButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show(
                resourceManager.GetString("RN_ConfirmLogout", cultureInfo),
                resourceManager.GetString("RN_Confirmation", cultureInfo),
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                LogInView logInView = new LogInView();
                logInView.Show();
                this.Close();
            }

        }

        private void ProfileControl_MouseUp(object sender, MouseButtonEventArgs e)
        {

            ProfileView profileView = new ProfileView(player);
            profileView.Show();
            this.Close();

        }

    }

}