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
using System.Windows.Input;
using GameDTO = Hangman.Adapters.ControllerAdapters.Services.Game.GameDTO;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;
using System.Windows.Controls;

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
            InitializeComponent();
            InitializeComponents();
        }

        public CreateGameView(PlayerDTO player)
        {
            InitializeComponent();
            InitializeComponents();

            _player = player;
            LoadCategoriesAndWords();
        }

        private void InitializeComponents()
        {
            resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(CreateGameView).Assembly);
            SetLanguage("es");

            _createGameAdapter = new CreateGameAdapter();
            _categories = null;
            _categoryDTOs = new ObservableCollection<Object>();
            _wordDTOs = new ObservableCollection<Object>();

            InitializeTable();
        }

        private void LoadCategoriesAndWords()
        {
            try
            {
                _categories = _createGameAdapter.GetCategoriesList();
                SetCategories(_categories);

                _words = _createGameAdapter.GetWordsList();
                SetWords(_words);

                CategoryList.SetItemsSource(_categoryDTOs, "CategoryES");
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
            Footer_Text.Text = resourceManager.GetString("RN_Copyright", cultureInfo);
            TitleBarControl.FieldName = resourceManager.GetString("RN_LanguageField", cultureInfo);

            // Actualiza los encabezados de la tabla
            InitializeTable();
        }

        private void TitleBarControl_LanguageChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as TitleBarControl)?.SelectedItem is LanguageDTO languageDTO)
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
            //TODO
            GameDTO newGame = new GameDTO();
            WordDTO selectedWord = WordsTable.GetSelectedItem() as WordDTO;

            newGame.CreatorEmail = _player.Email;            
            newGame.WordES = selectedWord.WordES;
            newGame.WordEN = selectedWord.WordEN;
            newGame.Language = "Spanish";
            try
            {
                GameDTO response = _createGameAdapter.CreateGame(newGame);

                //pasar palabradto?
                GameView gameView = new GameView(response, _player);
                gameView.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Cancel_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            MenuView menuView = new MenuView(_player);
            menuView.Show();
            this.Close();
        }

        private void CategoryList_SelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryList.SelectedItem is CategoryDTO selectedCategory)
            {
                // Handle category selection change
            }
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }
    }
}