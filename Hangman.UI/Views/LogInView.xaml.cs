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
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_LogIn_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            //Comportamiento de Prueba para el botón de LogIn
            //Temporal
            MessageBox.Show("Password: " + PasswordBoxControl.PasswordText);
        }

    }
}
