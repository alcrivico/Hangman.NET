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
        private ResourceManager resourceManager;
        private CultureInfo cultureInfo;
        private LogInAdapter logInAdapter;

        public LogInView()
        {

            InitializeComponent();

            resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(LogInView).Assembly);
            
            SetLanguage("es");

            logInAdapter = new LogInAdapter();

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

                PlayerDTO response = logInAdapter.LogIn(username, password);

                if (response.ResponseCode == 0)
                {
                    MenuView menuView = new MenuView(response);
                    menuView.Show();
                    this.Close();
                }
                else
                {

                    ShowAlert(
                        "Correo y/o contraseña incorrectos. Por favor, verifíquelos", 
                        FindResource("SolidColorBrush_Gold") as SolidColorBrush, 
                        FindResource("SolidColorBrush_MarianBlue") as SolidColorBrush
                    );

                }

            }
            catch (Exception ex)
            {

                ShowAlert(
                        ex.Message,
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

            SignUpView signUpView = new SignUpView();

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

            cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            TextBlock_Title.Text = resourceManager.GetString("RN_Title", cultureInfo);
            TextBoxControl_Email.FieldName = resourceManager.GetString("RN_Email", cultureInfo);
            PasswordBoxControl.FieldName = resourceManager.GetString("RN_Password", cultureInfo);
            AlertTextBlock.Text = resourceManager.GetString("RN_AlertLogIn", cultureInfo);
            Button_LogIn.Text = resourceManager.GetString("RN_BtnLogin", cultureInfo);
            TextBlock_SingUp.Text = resourceManager.GetString("RN_BtnRegister", cultureInfo);
            Footer_Text.Text = resourceManager.GetString("RN_Copyright", cultureInfo);
            TitleBarControl.FieldName = resourceManager.GetString("RN_LanguageField", cultureInfo);

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

    }
}