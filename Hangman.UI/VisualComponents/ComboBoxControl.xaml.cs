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
        public ComboBoxControl()
        {
            InitializeComponent();
        }

        private void ComboBox_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
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
