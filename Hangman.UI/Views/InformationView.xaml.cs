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
using System.Windows.Shapes;

namespace Hangman.UI.Views
{
    /// <summary>
    /// Interaction logic for InformationView.xaml
    /// </summary>
    public partial class InformationView : Window
    {

        public static readonly DependencyProperty InformationHeader =
            DependencyProperty.Register(
            nameof(InformationHeader),
            typeof(string),
            typeof(InformationView),
            new PropertyMetadata("Information")
        );

        public string InformationHeaderProperty
        {
            get { return (string)GetValue(InformationHeader); }
            set { SetValue(InformationHeader, value); }
        }

        public static readonly DependencyProperty InformationContent =
            DependencyProperty.Register(
            nameof(InformationContent),
            typeof(string),
            typeof(InformationView),
            new PropertyMetadata("Are you sure?")
        );

        public string InformationContentProperty
        {
            get { return (string)GetValue(InformationContent); }
            set { SetValue(InformationContent, value); }
        }

        public static readonly DependencyProperty InformationButton =
            DependencyProperty.Register(
            nameof(InformationButton),
            typeof(string),
            typeof(InformationView),
            new PropertyMetadata("Ok")
        );

        public string InformationButtonProperty
        {
            get { return (string)GetValue(InformationButton); }
            set { SetValue(InformationButton, value); }
        }

        public InformationView()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent InformationClick =
            EventManager.RegisterRoutedEvent(
            nameof(InformationClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(InformationView)
        );

        public event RoutedEventHandler InformationClickEvent
        {
            add { AddHandler(InformationClick, value); }
            remove { RemoveHandler(InformationClick, value); }
        }

        private void Information_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(InformationClick));
        }
    }
}
