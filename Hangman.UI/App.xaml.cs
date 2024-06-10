using System.Configuration;
using System.Data;
using System.Windows;
using Hangman.UI.Views;

namespace Hangman.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public void ApplicationStart(object sender, StartupEventArgs e)
        {

            SearchGameView  initialView = new();

            initialView.Show();

        }

    }

}
