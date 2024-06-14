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
    /// Interaction logic for ConfirmationView.xaml
    /// </summary>
    public partial class ConfirmationView : Window
    {

        public static DependencyProperty ConfirmationHeader = 
            DependencyProperty.Register(
            nameof(ConfirmationHeader),
            typeof(string),
            typeof(ConfirmationView),
            new PropertyMetadata("Confirmation")
        );

        public string ConfirmationHeaderProperty
        {
            get { return (string)GetValue(ConfirmationHeader); }
            set { SetValue(ConfirmationHeader, value); }
        }

        public static DependencyProperty ConfirmationContent = 
            DependencyProperty.Register(
            nameof(ConfirmationContent),
            typeof(string),
            typeof(ConfirmationView),
            new PropertyMetadata("Are you sure?")
        );

        public string ConfirmationContentProperty
        {
            get { return (string)GetValue(ConfirmationContent); }
            set { SetValue(ConfirmationContent, value); }
        }

        public static DependencyProperty ConfirmationButton = 
            DependencyProperty.Register(
            nameof(ConfirmationButton),
            typeof(string),
            typeof(ConfirmationView),
            new PropertyMetadata("Ok")
        );

        public string ConfirmationButtonProperty
        {
            get { return (string)GetValue(ConfirmationButton); }
            set { SetValue(ConfirmationButton, value); }
        }

        public static DependencyProperty CancelButton = 
            DependencyProperty.Register(
            nameof(CancelButton),
            typeof(string),
            typeof(ConfirmationView),
            new PropertyMetadata("Cancel")
        );

        public string CancelButtonProperty
        {
            get { return (string)GetValue(CancelButton); }
            set { SetValue(CancelButton, value); }
        }

        public ConfirmationView()
        {
            InitializeComponent();

        }

        public static readonly RoutedEvent ConfirmationClick = 
            EventManager.RegisterRoutedEvent(
            nameof(ConfirmationClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ConfirmationView)
        );

        public event RoutedEventHandler ConfirmationClickEvent
        {
            add { AddHandler(ConfirmationClick, value); }
            remove { RemoveHandler(ConfirmationClick, value); }
        }

        private void Confirmation_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ConfirmationClick));
        }

        public static readonly RoutedEvent CancelClick = 
            EventManager.RegisterRoutedEvent(
            nameof(CancelClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(ConfirmationView)
        );

        public event RoutedEventHandler CancelClickEvent
        {
            add { AddHandler(CancelClick, value); }
            remove { RemoveHandler(CancelClick, value); }
        }

        private void Cancel_Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CancelClick));
        }

    }
}
