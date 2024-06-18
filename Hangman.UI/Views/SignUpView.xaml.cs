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
using System.Diagnostics;
using System.Windows.Controls;

namespace Hangman.UI.Views
{
    public partial class SignUpView : Window
    {
        private bool _isEdit;
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private LanguageDTO _language;
        private PlayerDTO _player;
        private Button Button_Back;

        public SignUpView(LanguageDTO language)
        {
            
            _isEdit = false;
            _language = language;

            InitializeComponent();

            _resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(SignUpView).Assembly);
            
            TitleBarControl.SetSelectedLanguage(_language);

            if (_language.LanguageName.Equals("Spanish"))
            {
                SetLanguage("es");
            }

        }

        public SignUpView(PlayerDTO player, LanguageDTO language)
        {
            
            _player = player;
            _isEdit = true;
            _language = language;

            InitializeComponent();

            _resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(SignUpView).Assembly);
            
            Title.Text = _resourceManager.GetString("RN_EditProfile", _cultureInfo);
            TextBox_Email.IsEnabled = false;
            TextBox_Email.Text = _player.Email;
            TextBox_Name.Text = _player.Name;
            TextBox_FirstLastName.Text = _player.FirstLastName;
            TextBox_SecondLastName.Text = _player.SecondLastName;
            DatePicker_BirthDate.SelectedDate = _player.BirthDate;
            Button_SignUp.Text = _resourceManager.GetString("RN_SaveChanges", _cultureInfo);
            Button_SignUp.FontSize = 20;
            TextBlock_LogIn.Visibility = Visibility.Collapsed;
        
            TitleBarControl.SetSelectedLanguage(_language);

            if (_language.LanguageName.Equals("Spanish"))
            {
                SetLanguage("es");
            }

            Button_Back = new Button
            {
                Content = _resourceManager.GetString("RN_Back", _cultureInfo),
                Width = 100,
                Height = 30,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            Button_Back.Click += BackButton_Click;

            Grid.SetRow(Button_Back, 2); 
            Grid.SetColumn(Button_Back, 0);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ProfileView profileView = new ProfileView(_player, _language);
            profileView.Show();
        }

        private void SetLanguage(string language)
        {
            
            _cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;
            Title.Text = _resourceManager.GetString("RN_TitleSignUp", _cultureInfo);
            TextBox_Name.FieldName = _resourceManager.GetString("RN_Name", _cultureInfo);
            TextBox_FirstLastName.FieldName = _resourceManager.GetString("RN_FirstLastName", _cultureInfo);
            TextBox_SecondLastName.FieldName = _resourceManager.GetString("RN_SecondLastName", _cultureInfo);
            DatePicker_BirthDate.FieldName = _resourceManager.GetString("RN_BirthDate", _cultureInfo);
            TextBox_Email.FieldName = _resourceManager.GetString("RN_Email", _cultureInfo);

            Debug.WriteLine("Antes de la asignación: " + _resourceManager.GetString("RN_LanguageField", _cultureInfo));
            TitleBarControl.FieldName = _resourceManager.GetString("RN_LanguageField", _cultureInfo);
            Debug.WriteLine("Despues de la asignación: " + _resourceManager.GetString("RN_LanguageField", _cultureInfo));
            
            
            PasswordBox_ConfirmPassword.FieldName = _resourceManager.GetString("RN_ConfirmPassword", _cultureInfo);
            PasswordBox_Password.FieldName = _resourceManager.GetString("RN_Password", _cultureInfo);
            Button_SignUp.Text = _resourceManager.GetString("RN_BtnSignUp", _cultureInfo);
            TextBlock_LogIn.Text = _resourceManager.GetString("RN_LogIn", _cultureInfo);
            Footer_Text.Text = _resourceManager.GetString("RN_Copyright", _cultureInfo);
            _language = TitleBarControl.SelectedItem as LanguageDTO;
        
        }

        private void TitleBarControl_LanguageChanged(object sender, RoutedEventArgs e)
        {

            if (TitleBarControl.SelectedItem is LanguageDTO languageDTO)
            {
                Debug.WriteLine("LanguageDTO: " + languageDTO.LanguageName);
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

                    if (!_isEdit)
                    {

                        var signUpAdapter = new SignUpAdapter();
                        PlayerDTO response = signUpAdapter.SignUp(playerDTO);

                        InformationControl.Show(_resourceManager.GetString("RN_Success", _cultureInfo), _resourceManager.GetString("RN_SignUpSuccess", _cultureInfo), _resourceManager.GetString("RN_Accept", _cultureInfo));
                        
                        LogInView logInView = new LogInView();

                        logInView.Show();
                        this.Close();

                    }
                    else
                    {

                        var updateProfileAdapter = new UpdateProfileAdapter();
                        PlayerDTO response = updateProfileAdapter.UpdatePlayer(playerDTO);

                        InformationControl.Show(_resourceManager.GetString("RN_Success", _cultureInfo), _resourceManager.GetString("RN_ProfileUpdateSuccess", _cultureInfo), _resourceManager.GetString("RN_Accept", _cultureInfo));
                        
                        ProfileView profileView = new ProfileView(playerDTO, _language);
                        
                        profileView.Show();
                        this.Close();

                    }

                }
                catch (Exception ex)
                {
                    InformationControl.Show(_resourceManager.GetString("RN_Error", _cultureInfo), _resourceManager.GetString("RN_RegisterError", _cultureInfo), _resourceManager.GetString("RN_Accept", _cultureInfo));
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
                
                InformationControl.Show(_resourceManager.GetString("RN_Error", _cultureInfo), _resourceManager.GetString("RN_MissingFields", _cultureInfo), _resourceManager.GetString("RN_Accept", _cultureInfo));
                
                return false;

            }

            if (playerDTO.Name.Length > 50 || playerDTO.FirstLastName.Length > 50 || playerDTO.SecondLastName.Length > 50 || playerDTO.Email.Length > 50 || playerDTO.Password.Length > 50)
            {
               
                InformationControl.Show(_resourceManager.GetString("RN_Error", _cultureInfo), _resourceManager.GetString("RN_FieldLengthError", _cultureInfo), _resourceManager.GetString("RN_Accept", _cultureInfo));
                
                return false;

            }

            if (!Regex.IsMatch(playerDTO.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {

                InformationControl.Show(_resourceManager.GetString("RN_Error", _cultureInfo), _resourceManager.GetString("RN_InvalidEmailFormat", _cultureInfo), _resourceManager.GetString("RN_Accept", _cultureInfo));
                
                return false;

            }

            if (!playerDTO.Password.Equals(confirmPassword))
            {

                InformationControl.Show(_resourceManager.GetString("RN_Error", _cultureInfo), _resourceManager.GetString("RN_PasswordMismatch", _cultureInfo), _resourceManager.GetString("RN_Accept", _cultureInfo));

                return false;
            }

            return true;

        }

        private void TextBlock_LogIn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            LogInView logInView = new LogInView(_language);

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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
    }

}