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
    /// 
    public class LanguageDTO
    {
        public required string LanguageName { get; set; }
    }

    public partial class TitleBarControl : UserControl
    {
        private ObservableCollection<Object> _languageDTOs;
        public event EventHandler<WindowState>? WindowStateChangeRequested;

        public TitleBarControl()
        {

            //SearchGameAdapter searchGameAdapter = new SearchGameAdapter();

            _languageDTOs = new ObservableCollection<Object>();

            List<LanguageDTO> languages = new List<LanguageDTO>();
            languages.Add(new LanguageDTO { LanguageName = "Español" });
            languages.Add(new LanguageDTO { LanguageName = "English" });

            InitializeComponent();

            /*try
            {
                languages = searchGameAdapter.GetLanguagesList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }*/

            SetLanguages(languages);

            ComboBoxControl_Language.SetItemsSource(_languageDTOs);

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

    }
}
