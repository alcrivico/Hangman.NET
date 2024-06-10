using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hangman.Adapters.ControllerAdapters.Services.Game;

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Interaction logic for ComboBoxControl.xaml
    /// </summary>
    public partial class ComboBoxControl : UserControl
    {

        public string FieldName
        {
            get { return (string)GetValue(FieldNameProperty); }
            set { SetValue(FieldNameProperty, value); }
        }

        public static readonly DependencyProperty FieldNameProperty =
            DependencyProperty.Register(
                               "FieldName",
                               typeof(string),
                               typeof(ComboBoxControl),
                               new PropertyMetadata(string.Empty));

        public string MemberPath
        {
            get { return (string)GetValue(MemberPathProperty); }
            set { SetValue(MemberPathProperty, value); }
        }

        public static readonly DependencyProperty MemberPathProperty =
            DependencyProperty.Register(
                "MemberPath",
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
                new PropertyMetadata(200));

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
                new PropertyMetadata(40));

        public ComboBoxControl()
        {
            InitializeComponent();
        }

        private void ComboBoxControl_Loaded(object sender, RoutedEventArgs e)
        {

            ComboBox comboBox = (ComboBox)sender;
            ToggleButton? toggleButton = comboBox.Template.FindName("toggleButton", comboBox) as ToggleButton;

            if (toggleButton != null)
            {

                Border? border = toggleButton.Template.FindName("templateRoot", toggleButton) as Border;

                if (border != null)
                {
                    border.Background = FindResource("SolidColorBrush_MarianBlue") as SolidColorBrush;
                    border.BorderBrush = FindResource("SolidColorBrush_Gold") as SolidColorBrush;
                    border.BorderThickness = new Thickness(3);
                    border.CornerRadius = new CornerRadius(10);
                }

            }

        }

        public void SetItemsSource(ObservableCollection<Object> itemsSource, String ItemPath)
        {
            ComboBoxControlType.ItemsSource = null;
            ComboBoxControlType.ItemsSource = itemsSource;

            ComboBoxControlType.DisplayMemberPath = ItemPath;

            ComboBoxControlType.SelectedIndex = 0;
        }

        public void SelectDefaultItem(int index)
        {
            ComboBoxControlType.SelectedIndex = index;
        }

    }

}
