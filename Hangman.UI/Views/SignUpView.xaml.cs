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
        
        public partial class SignUpView : Window
        {
            public SignUpView()
            {
                InitializeComponent();
            }

            private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
            {
                WindowState = e;
            }

            private void Button_SignUp_ButtonControlClick(object sender, RoutedEventArgs e)
            {
                
            }

            private void TextBlock_LogIn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                LogInView logInView = new();
                logInView.Show();
                this.Close();
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
