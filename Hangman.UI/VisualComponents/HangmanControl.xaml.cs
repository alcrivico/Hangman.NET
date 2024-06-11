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
    /// Interaction logic for HangmanControl.xaml
    /// </summary>
    public partial class HangmanControl : UserControl
    {

        public int IncorrectGuesses
        {
            get { return (int)GetValue(IncorrectGuessesProperty); }
            set 
            { 
                SetValue(IncorrectGuessesProperty, value); 
                SetHangmanElements();
            }
        }

        public static readonly DependencyProperty IncorrectGuessesProperty =
            DependencyProperty.Register(
                               "IncorrectGuesses",
                               typeof(int),
                               typeof(HangmanControl),
                               new PropertyMetadata(0));

        public HangmanControl()
        {

            InitializeComponent();
            SetHangmanElements();

        }

        public void SetHangmanElements()
        {

            switch (IncorrectGuesses)
            {

                case 1:
                    Hangman_Head.Visibility = Visibility.Visible;
                    Hangman_Torso.Visibility = Visibility.Hidden;
                    Hangman_LeftArm.Visibility = Visibility.Hidden;
                    Hangman_RightArm.Visibility = Visibility.Hidden;
                    Hangman_LeftLeg.Visibility = Visibility.Hidden;
                    Hangman_RightLeg.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Hangman_Head.Visibility = Visibility.Visible;
                    Hangman_Torso.Visibility = Visibility.Visible;
                    Hangman_LeftArm.Visibility = Visibility.Hidden;
                    Hangman_RightArm.Visibility = Visibility.Hidden;
                    Hangman_LeftLeg.Visibility = Visibility.Hidden;
                    Hangman_RightLeg.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    Hangman_Head.Visibility = Visibility.Visible;
                    Hangman_Torso.Visibility = Visibility.Visible;
                    Hangman_LeftArm.Visibility = Visibility.Visible;
                    Hangman_RightArm.Visibility = Visibility.Hidden;
                    Hangman_LeftLeg.Visibility = Visibility.Hidden;
                    Hangman_RightLeg.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    Hangman_Head.Visibility = Visibility.Visible;
                    Hangman_Torso.Visibility = Visibility.Visible;
                    Hangman_LeftArm.Visibility = Visibility.Visible;
                    Hangman_RightArm.Visibility = Visibility.Visible;
                    Hangman_LeftLeg.Visibility = Visibility.Hidden;
                    Hangman_RightLeg.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    Hangman_Head.Visibility = Visibility.Visible;
                    Hangman_Torso.Visibility = Visibility.Visible;
                    Hangman_LeftArm.Visibility = Visibility.Visible;
                    Hangman_RightArm.Visibility = Visibility.Visible;
                    Hangman_LeftLeg.Visibility = Visibility.Visible;
                    Hangman_RightLeg.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    Hangman_Head.Visibility = Visibility.Visible;
                    Hangman_Torso.Visibility = Visibility.Visible;
                    Hangman_LeftArm.Visibility = Visibility.Visible;
                    Hangman_RightArm.Visibility = Visibility.Visible;
                    Hangman_LeftLeg.Visibility = Visibility.Visible;
                    Hangman_RightLeg.Visibility = Visibility.Visible;
                    break;
                default:
                    Hangman_Head.Visibility = Visibility.Hidden;
                    Hangman_Torso.Visibility = Visibility.Hidden;
                    Hangman_LeftArm.Visibility = Visibility.Hidden;
                    Hangman_RightArm.Visibility = Visibility.Hidden;
                    Hangman_LeftLeg.Visibility = Visibility.Hidden;
                    Hangman_RightLeg.Visibility = Visibility.Hidden;
                    break;

            }

        }

    }
}
