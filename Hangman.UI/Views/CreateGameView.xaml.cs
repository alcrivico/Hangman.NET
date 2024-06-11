using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.Services.Game;
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
using System.Xml;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using System.Collections.ObjectModel;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para CreateGameView.xaml
    /// </summary>
    public partial class CreateGameView : Window
    {
        private PlayerDTO player;
        private List<WordDTO> wordsList;
        public ObservableCollection<CategoryDTO> Categories { get; set; }
        private ObservableCollection<object> categoriesCollection;

        public CreateGameView()
        {
            InitializeComponent();
            InitializeTable();
            Categories = new ObservableCollection<CategoryDTO>();
            LoadCategories();
        }

        public CreateGameView(PlayerDTO player)
        {
            InitializeComponent();
            InitializeTable();
            LoadCategories();
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
                    { "BindingName", "Tip" }
                },
            };

            WordsTable.DefineColumns(columns);
        }

        private void LoadCategories()
        {
            try
            {
                CreateGameAdapter adapter = new CreateGameAdapter();
                List<CategoryDTO> categories = adapter.GetCategoriesList();

                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
            }
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
