using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {

        public LogInView()
        {
            InitializeComponent();
            Hangman.SetHangmanElements();
            TextBoxControl.Disable();
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_LogIn_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            //Comportamiento de Prueba para el botón de LogIn - Resultado Esperado: Verificará el usuario y contraseña y llevará a la ventana MenuView
            //Temporal
            MessageBox.Show("Password: " + PasswordBoxControl.PasswordText);
            TextBoxControl.Enable();
        }

        private void TextBlock_SingUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Comportamiento de Prueba para el TextBlock de SingUp - Resultado Esperado: LLevará a la ventana SignUpView
            //Temporal
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

        private void TitleBarControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
