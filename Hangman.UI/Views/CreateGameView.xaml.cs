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
    /// Lógica de interacción para CreateGameView.xaml
    /// </summary>
    public partial class CreateGameView : Window
    {
        public CreateGameView()
        {
            InitializeComponent();
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_StartGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            //
        }

        private void Button_Cancel_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            //
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_StartGame_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_StartGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Cancel_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Cancel_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
