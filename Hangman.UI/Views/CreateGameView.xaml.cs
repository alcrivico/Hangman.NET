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
using System.Diagnostics;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Lógica de interacción para CreateGameView.xaml
    /// </summary>
    public partial class CreateGameView : Window
    {
        private CreateGameAdapter _createGameAdapter;
        private PlayerDTO _player;
        private List<WordDTO> _words;
        public List<CategoryDTO> _categories;
        private ObservableCollection<Object> _categoryDTOs;
        private ObservableCollection<Object> _wordDTOs;

        public CreateGameView()
        {
            _createGameAdapter = new CreateGameAdapter();
            _categories = null;

            _categoryDTOs = new ObservableCollection<Object>();

            InitializeComponent();

            try
            {
                _categories = _createGameAdapter.GetCategoriesList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MenuView menuView = new MenuView(_player);
                menuView.Show();
                this.Close();

            }

            InitializeTable();

            SetCategories(_categories);

            CategoryList.SetItemsSource(_categoryDTOs, "CategoryES");

        }

        public CreateGameView(PlayerDTO player)
        {
            _createGameAdapter = new CreateGameAdapter();
            _player = player;
            _words = null;
            _categories = null;
            _wordDTOs = new ObservableCollection<Object>();
            _categoryDTOs = new ObservableCollection<Object>();

            InitializeComponent();

            try
            {
                _categories = _createGameAdapter.GetCategoriesList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MenuView menuView = new MenuView(_player);
                menuView.Show();
                this.Close();

            }

            SetCategories(_categories);
            
            CategoryList.SetItemsSource(_categoryDTOs, "CategoryES");

            InitializeTable();

            try
            {
                _words = _createGameAdapter.GetWordsList();
                Debug.WriteLine("Word is: " + _words);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MenuView menuView = new MenuView(_player);
                menuView.Show();
                this.Close();

            }

            SetWords(_words);

            WordsTable.SetItemsSource(_wordDTOs);

        }

        private void SetCategories(List<CategoryDTO> categories)
        {

            _categoryDTOs.Clear();

            foreach (CategoryDTO category in categories)
            {
                _categoryDTOs.Add(category);
            }

        }

        private void SetWords(List<WordDTO> words)
        {

            foreach (WordDTO word in words)
            {
                _wordDTOs.Add(word);
            }

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

        private void Button_StartGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            //
        }

        private void Button_Cancel_ButtonControlClick(object sender, RoutedEventArgs e)
        {

            MenuView menuView = new MenuView(_player);
            menuView.Show();
            this.Close();

        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            WindowState = e;
        }

        private void CategoryList_SelectedItemChanged(object sender, RoutedEventArgs e)
        {

            SetWords(_words);
            WordsTable.SetItemsSource(_wordDTOs);

        }
    }

}
