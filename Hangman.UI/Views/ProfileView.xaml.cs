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
    /// Lógica de interacción para ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Window
    {
        public ProfileView()
        {
            InitializeComponent();
        }

        private void TitleBarControl_WindowStateChangeRequested(object sender, WindowState e)
        {
            this.WindowState = e;
        }

        private void Button_Back_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Back_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Button_ModifyProfile_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_ModifyProfile_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBoxControl_GlobalScore(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBoxControl_Name(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBoxControl_LastName(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBoxControl_SecondLastName(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBoxControl_Email(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
