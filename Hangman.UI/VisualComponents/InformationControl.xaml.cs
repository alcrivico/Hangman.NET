using Hangman.UI.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Interaction logic for InformationControl.xaml
    /// </summary>
    public partial class InformationControl : UserControl
    {

        Window _window;

        public static DependencyProperty InformationHeader =
            DependencyProperty.Register(
            nameof(InformationHeader),
            typeof(string),
            typeof(InformationControl),
            new PropertyMetadata("Information")
        );

        public string InformationHeaderProperty
        {
            get { return (string)GetValue(InformationHeader); }
            set { SetValue(InformationHeader, value); }
        }

        public static DependencyProperty InformationContent =
            DependencyProperty.Register(
            nameof(InformationContent),
            typeof(string),
            typeof(InformationControl),
            new PropertyMetadata("Are you sure?")
        );

        public string InformationContentProperty
        {
            get { return (string)GetValue(InformationContent); }
            set { SetValue(InformationContent, value); }
        }

        public static DependencyProperty InformationButton =
            DependencyProperty.Register(
            nameof(InformationButton),
            typeof(string),
            typeof(InformationControl),
            new PropertyMetadata("Ok")
        );

        public string InformationButtonProperty
        {
            get { return (string)GetValue(InformationButton); }
            set { SetValue(InformationButton, value); }
        }

        public InformationControl()
        {
            InitializeComponent();
        }

        public static void Show(string header, string content, string buttontext)
        {

            var messageBox = new InformationControl
            {

                InformationHeaderProperty = header,
                InformationContentProperty = content,
                InformationButtonProperty = buttontext

            };

            var window = new Window
            {
                Content = messageBox,
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.ToolWindow,
                Background = Brushes.Transparent,
                AllowsTransparency = true
            };

            messageBox._window = window;

            window.ShowDialog();

        }

        private void Information_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Information_Button.Background = FindResource("SolidColorBrush_PolynesianBlue") as SolidColorBrush;
        }

        private void Information_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Information_Button.Background = FindResource("SolidColorBrush_RoyalBlue") as SolidColorBrush;
        }

        private void Information_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (_window != null)
            {
                _window.DialogResult = true;
            }

        }

    }
}
