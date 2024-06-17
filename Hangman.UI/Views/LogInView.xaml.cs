using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Resources;
using System.Globalization;
using Hangman.Adapters.ControllerAdapters.Services.Game;
using Microsoft.VisualBasic;
using Hangman.UI.VisualComponents;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private LogInAdapter _logInAdapter;
        private LanguageDTO _language;

        public LogInView()
        {

            InitializeComponent();

            _resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(LogInView).Assembly);
            
            SetLanguage("es");

            TitleBarControl.SetSelectedLanguage(_language);

            if (_language.LanguageName.Equals("Spanish"))
            {
                SetLanguage("es");
            }

            _language = TitleBarControl.SelectedItem as LanguageDTO;

            _logInAdapter = new LogInAdapter();

        }

        public LogInView(LanguageDTO language)
        {

            InitializeComponent();

            _language = language;

            _resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(LogInView).Assembly);

            TitleBarControl.SetSelectedLanguage(_language);

            if (_language.LanguageName.Equals("Spanish"))
            {
                SetLanguage("es");
            }

            _logInAdapter = new LogInAdapter();

        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_LogIn_ButtonControlClick(object sender, RoutedEventArgs e)
        {

            string username = TextBoxControl_Email.Text;
            string password = PasswordBoxControl.PasswordText;

            try
            {

                PlayerDTO response = _logInAdapter.LogIn(username, password);

                if (response.ResponseCode == 0)
                {

                    MenuView menuView = new MenuView(response, _language);
                    menuView.Show();
                    this.Close();
                }
                else
                {

                    ShowAlert(
                        _resourceManager.GetString("RN_AlertLogIn", _cultureInfo), 
                        FindResource("SolidColorBrush_Gold") as SolidColorBrush, 
                        FindResource("SolidColorBrush_MarianBlue") as SolidColorBrush
                    );

                }

            }
            catch (Exception ex)
            {

                ShowAlert(
                        _resourceManager.GetString("RN_AlertDatabase", _cultureInfo),
                        FindResource("SolidColorBrush_RustyRed") as SolidColorBrush,
                        FindResource("SolidColorBrush_White") as SolidColorBrush
                    );

            }
        }

        private void ShowAlert(string message, SolidColorBrush borderColor, SolidColorBrush textColor)
        {

            AlertTextBlock.Text = message;
            AlertBorder.Background = borderColor;
            AlertTextBlock.Foreground = textColor;
            AlertBorder.Visibility = Visibility.Visible;

        }

        private void TextBlock_SingUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            SignUpView signUpView = new SignUpView(_language);

            signUpView.Show();
            this.Close();

        }

        private void TextBlock_SingUp_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock_SingUp.Foreground = FindResource("SolidColorBrush_MikadoYellow") as SolidColorBrush;
        }

        private void TextBlock_SingUp_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock_SingUp.Foreground = FindResource("SolidColorBrush_Gold") as SolidColorBrush;
        }

        private void SetLanguage(string language)
        {

            _cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;

            TextBlock_Title.Text = _resourceManager.GetString("RN_Title", _cultureInfo);
            TextBoxControl_Email.FieldName = _resourceManager.GetString("RN_Email", _cultureInfo);
            PasswordBoxControl.FieldName = _resourceManager.GetString("RN_Password", _cultureInfo);
            AlertTextBlock.Text = _resourceManager.GetString("RN_AlertLogIn", _cultureInfo);
            Button_LogIn.Text = _resourceManager.GetString("RN_BtnLogin", _cultureInfo);
            TextBlock_SingUp.Text = _resourceManager.GetString("RN_BtnRegister", _cultureInfo);
            Footer_Text.Text = _resourceManager.GetString("RN_Copyright", _cultureInfo);
            _language = TitleBarControl.SelectedItem as LanguageDTO;
            TitleBarControl.FieldName = _resourceManager.GetString("RN_LanguageField", _cultureInfo);

        }

        private void TitleBarControl_LanguageChanged(object sender, RoutedEventArgs e)
        {

            if (TitleBarControl.SelectedItem is LanguageDTO)
            {
                LanguageDTO languageDTO = (LanguageDTO) TitleBarControl.SelectedItem;

                if (languageDTO.LanguageName.Equals("Spanish"))
                {
                    SetLanguage("es");
                }
                if (languageDTO.LanguageName.Equals("English"))
                {
                    SetLanguage("en");
                }

            }  
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

    }

}