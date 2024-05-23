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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Interaction logic for ButtonControl.xaml
    /// </summary>
    public partial class ButtonControl : UserControl
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
                typeof(ButtonControl), 
                new PropertyMetadata(string.Empty));

        public ButtonControl()
        {
            InitializeComponent();
        }

        public static RoutedEvent ButtonControlClickEvent = 
            EventManager.RegisterRoutedEvent(
                       nameof(ButtonControlClick),
                       RoutingStrategy.Bubble,
                       typeof(RoutedEventHandler),
                       typeof(ButtonControl));

        public event RoutedEventHandler ButtonControlClick
        {
            add { AddHandler(ButtonControlClickEvent, value); }
            remove { RemoveHandler(ButtonControlClickEvent, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button_Border.Effect = FindResource("ButtonDropShadow") as DropShadowEffect;
            Button.Height += 3;
            Button.Width += 3;

            RaiseEvent(new RoutedEventArgs(ButtonControlClickEvent));

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

            Button_Highlight.Opacity = 0.1;

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {

            Button_Highlight.Opacity = 0;

        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Button_Border.Effect = null;
            Button.Height -= 3;
            Button.Width -= 3;

        }
    }
}
