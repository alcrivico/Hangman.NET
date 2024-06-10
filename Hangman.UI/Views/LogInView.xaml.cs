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
                var response = logInAdapter.LogIn(username, password);

                if (response.ResponseCode == 0)
                {
                    MenuView menuView = new MenuView();
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
            // Comportamiento de Prueba para el TextBlock de SingUp - Resultado Esperado: LLevará a la ventana SignUpView
            MessageBox.Show("SingUp");
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