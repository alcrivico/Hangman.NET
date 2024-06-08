using Hangman.UI.VisualComponents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para SearchGameView.xaml
    /// </summary>
    public partial class SearchGameView : Window
    {
        public SearchGameView()
        {
            InitializeComponent();

            Dictionary<string, string>[] columns =
             {
                new Dictionary<string, string> {
                    { "Name", "ID" },
                    { "Width", "150.0" }
                },
                new Dictionary<string, string> {
                    { "Name", "CreatedBy" },
                    { "Width", "*" }
                },
                new Dictionary<string, string> {
                    { "Name", "WaitingTime" },
                    { "Width", "*" }
                }
            };

            GamesTable.DefineColumns(columns);

            ObservableCollection<GameDTO> gameDTOs = new ObservableCollection<GameDTO>();

            gameDTOs.Add(new GameDTO { ID = "1", CreatedBy = "User1", WaitingTime = 15 });
            gameDTOs.Add(new GameDTO { ID = "2", CreatedBy = "User2", WaitingTime = 20 });
            gameDTOs.Add(new GameDTO { ID = "3", CreatedBy = "User3", WaitingTime = 25 });


            //GamesTable.SetItemsSource(gameDTOs);

        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

    }
}
