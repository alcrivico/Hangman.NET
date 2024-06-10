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
    /// Lógica de interacción para MenuView.xaml
    /// </summary>
    public partial class MenuView : Window
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_SearchGame_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_SearchGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            SearchGameView searchGameView = new SearchGameView();
            searchGameView.Show();
        }

        private void Button_CreateGame_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_CreateGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            CreateGameView createGameView = new CreateGameView();
            createGameView.Show();
        }

        private void ProfileControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DoorButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ProfileControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ProfileView profileView = new ProfileView();
            profileView.Show();
        }
    }
}
