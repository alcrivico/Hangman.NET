using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        private LogInAdapter logInAdapter;

        public LogInView()
        {
            InitializeComponent();
            Hangman.SetHangmanElements();
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
                    ShowAlert("Correo y/o contraseña incorrectos. Por favor, verifíquelos", Brushes.Yellow, Brushes.Black);
                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message, Brushes.Red, Brushes.White);
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
        }

        private void TextBlock_SingUp_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock_SingUp.Foreground = FindResource("SolidColorBrush_MikadoYellow") as SolidColorBrush;
        }

        private void TextBlock_SingUp_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock_SingUp.Foreground = FindResource("SolidColorBrush_Gold") as SolidColorBrush;
        }
    }
}