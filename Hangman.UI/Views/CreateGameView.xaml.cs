using Hangman.Adapters.ControllerAdapters.Services.Player;
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
using System.Xml;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para CreateGameView.xaml
    /// </summary>
    public partial class CreateGameView : Window
    {
        private PlayerDTO player;

        public CreateGameView()
        {
            InitializeComponent();
            InitializeTable();
        }

        public CreateGameView(PlayerDTO player)
        {
            InitializeComponent();
            InitializeTable();
            this.player = player;
        }

        private void InitializeTable()
        {
            Dictionary<string, string>[] columns =
            {
                new Dictionary<string, string>
                {
                    { "Name", "Palabra" },
                    { "Width", "*" },
                    { "BindingName", "Word" }
                },
                new Dictionary<string, string>
                {
                    { "Name", "Pista" },
                    { "Width", "*" },
                    { "BindingName", "Hint" }
                },
            };

            WordsTable.DefineColumns(columns);
        }

        private void Button_StartGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            //
        }

        private void Button_Cancel_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            //
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            WindowState = e;
        }

    }
}
