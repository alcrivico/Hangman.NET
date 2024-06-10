using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.UI.VisualComponents;
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
        private PlayerDTO player;

        public MenuView(PlayerDTO player)
        {
            InitializeComponent();
            this.player = player;
            this.ProfileControl.UserName = $"{player.Name} {player.FirstLastName} {player.SecondLastName}";
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
            SearchGameView searchGameView = new SearchGameView(player);
            searchGameView.Show();
            this.Close();
        }

        private void Button_CreateGame_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_CreateGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            CreateGameView createGameView = new CreateGameView(player);
            createGameView.Show();
            this.Close();
        }

        private void ProfileControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DoorButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                LogInView logInView = new LogInView();
                logInView.Show();
                this.Close();
            }
        }

        private void ProfileControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ProfileView profileView = new ProfileView(player);
            profileView.Show();
            this.Close();
        }
    }
}
