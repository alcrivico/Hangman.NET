using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Media;
using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.UI.VisualComponents;

namespace Hangman.UI.Views
{
    public partial class SignUpView : Window
    {
        private bool isEdit = false;
        private ResourceManager resourceManager;
        private CultureInfo cultureInfo;

        public SignUpView()
        {
            InitializeComponent();
            resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(SignUpView).Assembly);
            SetLanguage("es");
        }

        public SignUpView(PlayerDTO player)
        {
            isEdit = true;
            InitializeComponent();
            resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(SignUpView).Assembly);
            SetLanguage("es");
            Title.Text = resourceManager.GetString("RN_EditProfile", cultureInfo);
            TextBox_Email.IsEnabled = false;
            TextBox_Email.Text = player.Email;
            TextBox_Name.Text = player.Name;
            TextBox_FirstLastName.Text = player.FirstLastName;
            TextBox_SecondLastName.Text = player.SecondLastName;
            DatePicker_BirthDate.SelectedDate = player.BirthDate;
            Button_SignUp.Text = resourceManager.GetString("RN_SaveChanges", cultureInfo);
            Button_SignUp.FontSize = 20;
            TextBlock_LogIn.Visibility = Visibility.Collapsed;
        }

        private void SetLanguage(string language)
        {
            cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Title.Text = resourceManager.GetString("RN_TitleSignUp", cultureInfo);
            TextBox_Name.FieldName = resourceManager.GetString("RN_Name", cultureInfo);
            TextBox_FirstLastName.FieldName = resourceManager.GetString("RN_FirstLastName", cultureInfo);
            TextBox_SecondLastName.FieldName = resourceManager.GetString("RN_SecondLastName", cultureInfo);
            DatePicker_BirthDate.FieldName = resourceManager.GetString("RN_BirthDate", cultureInfo);
            TextBox_Email.FieldName = resourceManager.GetString("RN_Email", cultureInfo);
            PasswordBox_Password.FieldName = resourceManager.GetString("RN_Password", cultureInfo);
            PasswordBox_ConfirmPassword.FieldName = resourceManager.GetString("RN_ConfirmPassword", cultureInfo);
            Button_SignUp.Text = resourceManager.GetString("RN_BtnSignUp", cultureInfo);
            TextBlock_LogIn.Text = resourceManager.GetString("RN_LogIn", cultureInfo);
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
            WindowState = e;
        }

        private void Button_SignUp_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            var playerDTO = new PlayerDTO
            {
                Name = TextBox_Name.Text,
                FirstLastName = TextBox_FirstLastName.Text,
                SecondLastName = TextBox_SecondLastName.Text,
                BirthDate = DatePicker_BirthDate.SelectedDate ?? DateTime.MinValue,
                Email = TextBox_Email.Text,
                Password = PasswordBox_Password.PasswordText
            };

            string confirmPassword = PasswordBox_ConfirmPassword.PasswordText;

            if (ValidatePlayerDTO(playerDTO, confirmPassword))
            {
                try
                {
                    if (!isEdit)
                    {
                        var signUpAdapter = new SignUpAdapter();
                        PlayerDTO response = signUpAdapter.SignUp(playerDTO);
                        InformationControl.Show(resourceManager.GetString("RN_Success", cultureInfo), resourceManager.GetString("RN_SignUpSuccess", cultureInfo), "Aceptar");
                        LogInView logInView = new LogInView();
                        logInView.Show();
                        this.Close();
                    }
                    else
                    {
                        var updateProfileAdapter = new UpdateProfileAdapter();
                        PlayerDTO response = updateProfileAdapter.UpdatePlayer(playerDTO);
                        InformationControl.Show(resourceManager.GetString("RN_Success", cultureInfo), resourceManager.GetString("RN_ProfileUpdateSuccess", cultureInfo), "Aceptar");
                        ProfileView profileView = new ProfileView(playerDTO);
                        profileView.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    InformationControl.Show(resourceManager.GetString("RN_Error", cultureInfo), ex.Message, "Aceptar");
                }
            }
        }

        private bool ValidatePlayerDTO(PlayerDTO playerDTO, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(playerDTO.Name) ||
                string.IsNullOrWhiteSpace(playerDTO.FirstLastName) ||
                string.IsNullOrWhiteSpace(playerDTO.SecondLastName) ||
                string.IsNullOrWhiteSpace(playerDTO.Email) ||
                string.IsNullOrWhiteSpace(playerDTO.Password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(resourceManager.GetString("RN_MissingFields", cultureInfo), resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (playerDTO.Name.Length > 50 || playerDTO.FirstLastName.Length > 50 || playerDTO.SecondLastName.Length > 50 || playerDTO.Email.Length > 50 || playerDTO.Password.Length > 50)
            {
                MessageBox.Show(resourceManager.GetString("RN_FieldLengthError", cultureInfo), resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(playerDTO.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(resourceManager.GetString("RN_InvalidEmailFormat", cultureInfo), resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!playerDTO.Password.Equals(confirmPassword))
            {
                MessageBox.Show(resourceManager.GetString("RN_PasswordMismatch", cultureInfo), resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void TextBlock_LogIn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LogInView logInView = new LogInView();
            logInView.Show();
            Close();
        }

        private void TextBlock_LogIn_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock_LogIn.Foreground = FindResource("SolidColorBrush_MikadoYellow") as SolidColorBrush;
        }

        private void TextBlock_LogIn_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock_LogIn.Foreground = FindResource("SolidColorBrush_Gold") as SolidColorBrush;
        }
    }
}