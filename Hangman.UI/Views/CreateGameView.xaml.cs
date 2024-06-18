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
using System.Windows.Input;

namespace Hangman.UI.Views
{
    public partial class CreateGameView : Window
    {
        private ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;
        private CreateGameAdapter _createGameAdapter;
        private PlayerDTO _player;
        private LanguageDTO _language;
        private List<WordDTO> _words;
        public List<CategoryDTO> _categories;
        private ObservableCollection<Object> _categoryDTOs;
        private ObservableCollection<Object> _wordDTOs;

        public CreateGameView(PlayerDTO player, LanguageDTO language)
        {

            _createGameAdapter = new CreateGameAdapter();
            _player = player;
            _language = language;
            _words = new List<WordDTO>();
            _categories = null;
            _wordDTOs = new ObservableCollection<Object>();
            _categoryDTOs = new ObservableCollection<Object>();

            InitializeComponent();


            SetComponents();

            TitleBarControl.SetSelectedLanguage(_language);

            if (_language.LanguageName == "Spanish")
            {
                SetLanguage("es");
            }

            LoadData();
               
        }

        private void SetComponents()
        {
            _resourceManager = new ResourceManager("Hangman.UI.Resources.I18n.Strings", typeof(CreateGameView).Assembly);

            if (_language.LanguageName == "Spanish")
            {
                SetLanguage("es");
            }
            else if (_language.LanguageName == "English")
            {
                SetLanguage("en");
            }

            InitializeTable();

        }

        private void LoadData()
        {
            try
            {

                _categories = _createGameAdapter.GetCategoriesList();

                SetCategories(_categories);

                CategoryList.SetItemsSource(_categoryDTOs, _resourceManager.GetString("RN_ChooseCategory", _cultureInfo));

                _words = _createGameAdapter.GetWordsList();

                SetWords(_words);
                WordsTable.SetItemsSource(_wordDTOs);

            }
            catch (Exception ex)
            {

                InformationControl.Show(
                    _resourceManager.GetString("RN_Error", _cultureInfo),
                    _resourceManager.GetString("RN_NoCategoriesFound", _cultureInfo),
                    _resourceManager.GetString("RN_Accept", _cultureInfo));
                
                MenuView menuView = new MenuView(_player, _language);

                menuView.Show();
                this.Close();

            }
        }

        private void SetLanguage(string language)
        {

            _cultureInfo = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;

            Title.Text = _resourceManager.GetString("RN_CreateGame", _cultureInfo);
            CategoryList.FieldName = _resourceManager.GetString("RN_Categories", _cultureInfo);
            Button_StartGame.Text = _resourceManager.GetString("RN_StartGame", _cultureInfo);
            Button_Cancel.Text = _resourceManager.GetString("RN_Cancel", _cultureInfo);
            TitleBarControl.FieldName = _resourceManager.GetString("RN_LanguageField", _cultureInfo);

            InitializeTable();

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

                    { "Name", _resourceManager.GetString("RN_Word", _cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", _resourceManager.GetString("RN_ChooseWord", _cultureInfo) }

                },
                new Dictionary<string, string>
                {

                    { "Name", _resourceManager.GetString("RN_Hint", _cultureInfo) },
                    { "Width", "*" },
                    { "BindingName", _resourceManager.GetString("RN_ChooseTip", _cultureInfo) }

                }

            };

            WordsTable.DefineColumns(columns);

        }

        private void Button_StartGame_ButtonControlClick(object sender, RoutedEventArgs e)
        {

            Adapters.ControllerAdapters.Services.Game.GameDTO newGame = new Adapters.ControllerAdapters.Services.Game.GameDTO();
            WordDTO selectedWord = WordsTable.GetSelectedItem() as WordDTO;
            newGame.CreatorEmail = _player.Email;

            newGame.Word = selectedWord.WordEN;

            newGame.Language = _language.LanguageName;

            try
            {

                Adapters.ControllerAdapters.Services.Game.GameDTO response = _createGameAdapter.CreateGame(newGame);
                GameView gameView = new GameView(response, _player, _language);

                gameView.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                InformationControl.Show(
                    _resourceManager.GetString("RN_Error", _cultureInfo), 
                    _resourceManager.GetString("RN_RegisterError", _cultureInfo), 
                    _resourceManager.GetString("RN_Accept", _cultureInfo));
            }
        }

        private void Button_Cancel_ButtonControlClick(object sender, RoutedEventArgs e)
        {

            MenuView menuView = new MenuView(_player, _language);

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

                List<WordDTO> filteredWords = 
                    _words.Where(word => word.CategoryES == selectedCategory.CategoryES).ToList();
                
                _wordDTOs.Clear();

                foreach (var word in filteredWords)
                {
                    _wordDTOs.Add(word);
                }

                WordsTable.SetItemsSource(_wordDTOs);

            }

        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

    }

}