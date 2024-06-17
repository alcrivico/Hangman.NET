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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hangman.Adapters.ControllerAdapters.Services.Game;
using Hangman.Adapters.ControllerAdapters.SingleAdapters;

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Interaction logic for TitleBarControl.xaml
    /// </summary>

    public partial class TitleBarControl : UserControl
    {
        private ObservableCollection<Object> _languageDTOs;
        public event EventHandler<WindowState>? WindowStateChangeRequested;

        public bool ChangeLanguage
        {
            get { return (bool)GetValue(ChangeLanguageProperty); }
            set { SetValue(ChangeLanguageProperty, value); }
        }

        public static readonly DependencyProperty ChangeLanguageProperty =
            DependencyProperty.Register(
                nameof(ChangeLanguage),
                typeof(bool),
                typeof(TitleBarControl),
                new PropertyMetadata(true));

        public double ChangeOpacity
        {

            get { return (double)GetValue(ChangeOpacityProperty); }

            set
            {
                SetValue(ChangeOpacityProperty, value);
            }

        }

        public static readonly DependencyProperty ChangeOpacityProperty =
            DependencyProperty.Register(
                nameof(ChangeOpacity),
                typeof(double),
                typeof(TitleBarControl),
                new PropertyMetadata(1.0));

        public string FieldName
        {

            get { return (string)GetValue(FieldNameProperty); }

            set
            {
                SetValue(FieldNameProperty, value);
            }

        }

        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register(
                nameof(FieldName),
                typeof(string),
                typeof(TitleBarControl),
                new PropertyMetadata(""));

        public object SelectedItem
        {
            get { return ComboBoxControl_Language.SelectedItem; }
            set { ComboBoxControl_Language.SelectedItem = value; }
        }

        public ComboBoxControl ComboBoxControlLanguage
        {
            get { return ComboBoxControl_Language; }
        }

        public void SelectComboBoxLanguageName(string languageName)
        {

            var customComboBox = this.ComboBoxControlLanguage;

            if (customComboBox != null)
            {

                var comboBox = customComboBox.ComboBoxControlType;

                if (comboBox != null)
                {

                    foreach (var item in comboBox.Items)
                    {

                        if (item is LanguageDTO language && language.LanguageName == languageName)
                        {

                            comboBox.SelectedItem = item;
                            break;

                        }

                    }

                }

            }

        }

        private void SelectComboBoxIndex(int index)
        {

            var customComboBox = this.ComboBoxControlLanguage;

            if (customComboBox != null)
            {

                var comboBox = customComboBox.ComboBoxControlType;

                if (comboBox != null)
                {

                    if (index >= 0 && index < comboBox.Items.Count)
                    {
                        comboBox.SelectedIndex = index;
                    }

                }

            }

        }

        public static readonly RoutedEvent LanguageChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(LanguageChanged),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(TitleBarControl));

        public event RoutedEventHandler LanguageChanged
        {
            add { AddHandler(LanguageChangedEvent, value); }
            remove { RemoveHandler(LanguageChangedEvent, value); }
        }

        public object SelectedLanguage
        {
            get { return ComboBoxControl_Language.SelectedItem; }
            set { ComboBoxControl_Language.SelectedItem = value; }
        }

        public static readonly DependencyProperty SelectedLanguageProperty =
            DependencyProperty.Register(
                nameof(SelectedLanguage),
                typeof(object),
                typeof(TitleBarControl),
                new PropertyMetadata(null));

        public TitleBarControl()
        {

            SearchGameAdapter searchGameAdapter = new SearchGameAdapter();

            _languageDTOs = new ObservableCollection<Object>();

            List<LanguageDTO> languages = null;

            InitializeComponent();

            try
            {
                languages = searchGameAdapter.GetLanguagesList();
            }
            catch (Exception e)
            {

                Window parentWindow = Window.GetWindow(this);
                
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();

            }

            SetLanguages(languages);

            ComboBoxControl_Language.SetItemsSource(_languageDTOs, "LanguageName");

            ComboBoxControl_Language.SetBinding(ComboBox.SelectedItemProperty, new Binding
            {
                Path = new PropertyPath(nameof(SelectedLanguage)),
                Mode = BindingMode.TwoWay,
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(TitleBarControl), 1)
            });

        }

        private void SetWindowState(WindowState newState)
        {
            WindowStateChangeRequested?.Invoke(this, newState);
        }

        private WindowState GetWindowState()
        {

            Window parentWindow = Window.GetWindow(this);

            return parentWindow.WindowState;

        }

        private void MinusLogo_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageBrush_MinusLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_RedMinusLogo"];
        }

        private void MinusLogo_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageBrush_MinusLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_MinusLogo"];
        }

        private void MaximizeLogo_MouseEnter(object sender, MouseEventArgs e)
        {
            if (GetWindowState() == WindowState.Maximized)
            {
                ImageBrush_MaximizeLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_RedMinimizeLogo"];
            }
            else
            {
                ImageBrush_MaximizeLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_RedMaximizeLogo"];
            }
        }

        private void MaximizeLogo_MouseLeave(object sender, MouseEventArgs e)
        {
            if (GetWindowState() == WindowState.Maximized)
            {
                ImageBrush_MaximizeLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_MinimizeLogo"];
            }
            else
            {
                ImageBrush_MaximizeLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_MaximizeLogo"];
            }
        }

        private void MaximizeLogo_Click(object sender, MouseButtonEventArgs e)
        {
            if (GetWindowState() == WindowState.Maximized)
            {
                SetWindowState(WindowState.Normal);
                ImageBrush_MaximizeLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_RedMaximizeLogo"];
            }
            else
            {
                SetWindowState(WindowState.Maximized);
                ImageBrush_MaximizeLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_RedMinimizeLogo"];
            }
        }

        private void ExitLogo_MouseEnter(object sender, MouseEventArgs e)
        {
            ImageBrush_ExitLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_RedExitLogo"];
        }

        private void ExitLogo_MouseLeave(object sender, MouseEventArgs e)
        {
            ImageBrush_ExitLogo.ImageSource = (ImageSource)Application.Current.Resources["Icon_ExitLogo"];
        }

        private void MinimizeLogo_Click(object sender, MouseButtonEventArgs e)
        {
            SetWindowState(WindowState.Minimized);
        }

        private void ExitLogo_Click(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
            Application.Current.Shutdown();
        }

        private void MinusLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetWindowState(WindowState.Minimized);
        }

        private void SetLanguages(List<LanguageDTO> languages)
        {
            _languageDTOs.Clear();

            foreach (LanguageDTO language in languages)
            {
                _languageDTOs.Add(language);
            }

        }

        public void SetSelectedLanguage(LanguageDTO languageDTO)
        {
            var language = _languageDTOs.OfType<LanguageDTO>().FirstOrDefault(l => l.LanguageName == languageDTO.LanguageName);
            if (language != null)
            {
                ComboBoxControl_Language.SelectedItem = language;
            }
        }

        private void ComboBoxControl_Language_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(LanguageChangedEvent));
        }

        public void SetSelectedItem(object item)
        {
            ComboBoxControl_Language.SelectedItem = item;
        }
    }
}
