using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Hangman.UI.Views
{
    public partial class SignUpView : Window
    {
        private bool isEdit = false;
        public SignUpView()
        {
            InitializeComponent();
        }

        public SignUpView(PlayerDTO player)
        {
            isEdit = true;
            InitializeComponent();
            Title.Text = "Editar Perfil";
            TextBox_Email.IsEnabled = false;
            TextBox_Email.Text = player.Email;
            TextBox_Name.Text = player.Name;
            TextBox_FirstLastName.Text = player.FirstLastName;
            TextBox_SecondLastName.Text = player.SecondLastName;
            DatePicker_BirthDate.SelectedDate = player.BirthDate;
            Button_SignUp.Text = "Guardar Cambios";
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
                        MessageBox.Show("Registro exitoso. Puedes iniciar sesión ahora.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        LogInView logInView = new LogInView();
                        logInView.Show();
                        this.Close();
                    }
                    else
                    {
                        var updateProfileAdapter = new UpdateProfileAdapter();
                        PlayerDTO response = updateProfileAdapter.UpdatePlayer(playerDTO);
                        MessageBox.Show("Perfil actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        ProfileView profileView = new ProfileView(playerDTO);
                        profileView.Show();
                        this.Close();
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Faltan campos por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (playerDTO.Name.Length > 50 || playerDTO.FirstLastName.Length > 50 || playerDTO.SecondLastName.Length > 50 || playerDTO.Email.Length > 50 || playerDTO.Password.Length > 50)
            {
                MessageBox.Show("Los campos no deben exceder los 50 caracteres.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(playerDTO.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El formato del correo es incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!playerDTO.Password.Equals(confirmPassword))
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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