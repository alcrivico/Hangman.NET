using Hangman.Adapters.ControllerAdapters.Services.Player;
using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.UI.VisualComponents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;

namespace Hangman.UI.Views
{
    public partial class CreateGameView : Window
    {
        private ResourceManager resourceManager;
        private CultureInfo cultureInfo;
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

            InitializeComponents();

            LoadData();
        }

        public CreateGameView(PlayerDTO player, LanguageDTO language)
        {
            _createGameAdapter = new CreateGameAdapter();
            _player = player;
            _words = new List<WordDTO>();
            _categories = null;
            _wordDTOs = new ObservableCollection<Object>();
            _categoryDTOs = new ObservableCollection<Object>();

            InitializeComponent();

            InitializeComponents();

            LoadData();
            TitleBarControl.SelectedItem = language;
               
        }

        private void InitializeComponents()
        {
            resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(CreateGameView).Assembly);
            SetLanguage("es"); 
            InitializeTable();

        }

        private void LoadData()
        {
            try
            {
                _categories = _createGameAdapter.GetCategoriesList();
                SetCategories(_categories);
                CategoryList.SetItemsSource(_categoryDTOs, "CategoryES");

                _words = _createGameAdapter.GetWordsList();
                SetWords(_words);
                WordsTable.SetItemsSource(_wordDTOs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Error);
                MenuView menuView = new MenuView(_player);
                menuView.Show();
                this.Close();
            }
        }

        private void SetLanguage(string language)
        {
            cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Title.Text = resourceManager.GetString("RN_CreateGame", cultureInfo);
            CategoryList.FieldName = resourceManager.GetString("RN_Categories", cultureInfo);
            Button_StartGame.Text = resourceManager.GetString("RN_StartGame", cultureInfo);
            Button_Cancel.Text = resourceManager.GetString("RN_Cancel", cultureInfo);
            TextBoxControl_GameCode.FieldName = resourceManager.GetString("RN_GameCode", cultureInfo);

            InitializeTable();
        }

        private void TitleBarControl_LanguageChanged(object sender, RoutedEventArgs e)
        {
            if (TitleBarControl.SelectedItem is LanguageDTO languageDTO)
            {
                if (languageDTO.LanguageName.Equals("Spanish"))
                {
                    SetLanguage("es");
                }
                else if (languageDTO.LanguageName.Equals("English"))
                {
                    SetLanguage("en");
                }
            }
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
            _wordDTOs.Clear();
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
                    { "Name", resourceManager.GetString("RN_Word", cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "WordES" }
                },
                new Dictionary<string, string>
                {
                    { "Name", resourceManager.GetString("RN_Hint", cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", "TipES" }
                },
            };

            WordsTable.DefineColumns(columns);
        }

        private void Button_StartGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            Adapters.ControllerAdapters.Services.Game.GameDTO newGame = new Adapters.ControllerAdapters.Services.Game.GameDTO();
            WordDTO selectedWord = WordsTable.GetSelectedItem() as WordDTO;

            newGame.CreatorEmail = _player.Email;
            newGame.WordES = selectedWord.WordES;
            newGame.WordEN = selectedWord.WordEN;
            newGame.Language = "Spanish";

            try
            {
                Adapters.ControllerAdapters.Services.Game.GameDTO response = _createGameAdapter.CreateGame(newGame);
                GameView gameView = new GameView();
                gameView.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, resourceManager.GetString("RN_Error", cultureInfo), MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            CategoryDTO selectedCategory = CategoryList.SelectedItem as CategoryDTO;

            if (selectedCategory != null)
            {
                List<WordDTO> filteredWords = _words.Where(word => word.CategoryES == selectedCategory.CategoryES).ToList();
                _wordDTOs.Clear();

                foreach (var word in filteredWords)
                {
                    _wordDTOs.Add(word);
                }

                WordsTable.SetItemsSource(_wordDTOs);
            }
        }
    }
}