using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Lógica de interacción para AlertMessageControl.xaml
    /// </summary>
    public partial class AlertMessageControl : UserControl
    {
        public AlertMessageControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AlertMessageTextProperty =
            DependencyProperty.Register("AlertMessageText", typeof(string), typeof(AlertMessageControl), new PropertyMetadata());

        public string AlertMessageText
        {
            get { return (string)GetValue(AlertMessageTextProperty); }
            set { SetValue(AlertMessageTextProperty, value); }
        }

        public static readonly DependencyProperty BorderBrushColorProperty =
            DependencyProperty.Register("BorderBrushColor", typeof(Brush), typeof(AlertMessageControl), new PropertyMetadata(Brushes.Red));

        public Brush BorderBrushColor
        {
            get { return (Brush)GetValue(BorderBrushColorProperty); }
            set { SetValue(BorderBrushColorProperty, value); }
        }

        public static readonly DependencyProperty MessageFontSizeProperty =
            DependencyProperty.Register("MessageFontSize", typeof(double), typeof(AlertMessageControl), new PropertyMetadata(14.0));

        public double MessageFontSize
        {
            get { return (double)GetValue(MessageFontSizeProperty); }
            set { SetValue(MessageFontSizeProperty, value); }
        }

    }
}
