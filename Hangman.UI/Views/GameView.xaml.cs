using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
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
    /// Lógica de interacción para GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        GameAdapter gameAdapter = new GameAdapter();
        GameDTO gameDTO = new GameDTO();

        public GameView()
        {
            
            InitializeComponent();
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Hangman_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_ExitGame_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_ExitGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro que desea salir del juego?", "Salir del juego", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if(result == MessageBoxResult.Yes)
            {
                gameAdapter.LeftGame(gameDTO.GameCode);
                this.Close();
            }
        }

    }
}
