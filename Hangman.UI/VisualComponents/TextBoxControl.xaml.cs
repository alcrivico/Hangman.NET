using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for TextBoxControl.xaml
    /// </summary>
    public partial class TextBoxControl : UserControl
    {

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                               "Text",
                               typeof(string),
                               typeof(TextBoxControl),
                               new PropertyMetadata(string.Empty));

        public string FieldName
        {
            get { return (string)GetValue(FieldNameProperty); }
            set { SetValue(FieldNameProperty, value); }
        }

        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register(
                               "FieldName",
                               typeof(string),
                               typeof(TextBoxControl),
                               new PropertyMetadata(string.Empty));

        public int TextBoxWidth
        {
            get { return (int)GetValue(TextBoxWidthProperty); }
            set { SetValue(TextBoxWidthProperty, value); }
        }

        public static readonly DependencyProperty TextBoxWidthProperty =
            DependencyProperty.Register(
                               "TextBoxWidth",
                               typeof(int),
                               typeof(TextBoxControl),
                               new PropertyMetadata(150));

        public int TextBoxHeight
        {
            get { return (int)GetValue(TextBoxHeightProperty); }
            set { SetValue(TextBoxHeightProperty, value); }
        }

        public static readonly DependencyProperty TextBoxHeightProperty =
            DependencyProperty.Register(
                               "TextBoxHeight",
                               typeof(int),
                               typeof(TextBoxControl),
                               new PropertyMetadata(55));

        public TextBoxControl()
        {
            InitializeComponent();
        }

        public void Disable()
        {
            TextBox.IsEnabled = false;
            TextBox_Highlight.Visibility = Visibility.Visible;
        }

        public void Enable()
        {
            TextBox.IsEnabled = true;
            TextBox_Highlight.Visibility = Visibility.Hidden;
        }

    }
}
