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
    /// Interaction logic for ComboBoxControl.xaml
    /// </summary>
    public partial class ComboBoxControl : UserControl
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
                typeof(ComboBoxControl),
                new PropertyMetadata(string.Empty));

        public int ComboBoxWidth
        {
            get { return (int)GetValue(ComboBoxWidthProperty); }
            set { SetValue(ComboBoxWidthProperty, value); }
        }

        public static readonly DependencyProperty ComboBoxWidthProperty =
            DependencyProperty.Register(
                               "ComboBoxWidth",
                               typeof(int),
                               typeof(ComboBoxControl),
                               new PropertyMetadata(150));

        public int ComboBoxHeight
        {
            get { return (int)GetValue(ComboBoxHeightProperty); }
            set { SetValue(ComboBoxHeightProperty, value); }
        }

        public static readonly DependencyProperty ComboBoxHeightProperty =
            DependencyProperty.Register(
                               "ComboBoxHeight",
                               typeof(int),
                               typeof(ComboBoxControl),
                               new PropertyMetadata(55));

        public ComboBoxControl()
        {
            InitializeComponent();
        }

        private void ComboBox_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // TODO
        }

        private void ComboBox_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox_Highlight.Visibility = Visibility.Visible;
        }

        private void ComboBox_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ComboBox_Highlight.Visibility = Visibility.Hidden;
        }

    }

}
