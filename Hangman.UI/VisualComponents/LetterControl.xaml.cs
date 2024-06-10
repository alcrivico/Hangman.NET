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
    /// Interaction logic for LetterControl.xaml
    /// </summary>
    public partial class LetterControl : UserControl
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
                typeof(LetterControl), 
                new PropertyMetadata(string.Empty));

        public int Clarity
        {
            get { return (int)GetValue(ClarityProperty); }
            set { SetValue(ClarityProperty, value); }
        }

        public static readonly DependencyProperty ClarityProperty =
            DependencyProperty.Register(
                               "Clarity",
                               typeof(int),
                               typeof(LetterControl),
                               new PropertyMetadata(1));

        public LetterControl()
        {
            InitializeComponent();
        }
    }
}
