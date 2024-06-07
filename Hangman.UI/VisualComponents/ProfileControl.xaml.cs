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

namespace Hangman.UI.VisualComponents
{
    /// <summary>
    /// Lógica de interacción para ProfileControl.xaml
    /// </summary>
    public partial class ProfileControl : UserControl
    {
        public ProfileControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register(
                "UserName",
                typeof(string),
                typeof(ProfileControl),
                new PropertyMetadata(string.Empty));

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Manejar el evento MouseUp para actuar como botón
        private void ProfileControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // agregar la lógica para navegar al perfil del usuario
        }
    }
}
