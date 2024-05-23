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
    /// Interaction logic for GameInformationControl.xaml
    /// </summary>
    public partial class GameInformationControl : UserControl
    {

        public string GameInformation
        {
            get { return (string)GetValue(GameInformationProperty); }
            set { SetValue(GameInformationProperty, value); }
        }

        public static readonly DependencyProperty GameInformationProperty =
            DependencyProperty.Register(
                               "GameInformation",
                               typeof(string),
                               typeof(GameInformationControl),
                               new PropertyMetadata(string.Empty));

        public GameInformationControl()
        {
            InitializeComponent();
        }
    }
}
