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
    /// Interaction logic for KeyboardControl.xaml
    /// </summary>
    public partial class KeyboardControl : UserControl
    {

        public static RoutedEvent BtnMClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnMClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnMClick
        {
            add { AddHandler(BtnMClicEvent, value); }
            remove { RemoveHandler(BtnMClicEvent, value); }
        }

        public static RoutedEvent BtnNClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnNClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnNClick
        {
            add { AddHandler(BtnNClicEvent, value); }
            remove { RemoveHandler(BtnNClicEvent, value); }
        }

        public static RoutedEvent BtnBClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnBClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnBClick
        {
            add { AddHandler(BtnBClicEvent, value); }
            remove { RemoveHandler(BtnBClicEvent, value); }
        }

        public static RoutedEvent BtnVClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnVClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnVClick
        {
            add { AddHandler(BtnBClicEvent, value); }
            remove { RemoveHandler(BtnBClicEvent, value); }
        }

        public static RoutedEvent BtnCClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnCClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnCClick
        {
            add { AddHandler(BtnCClicEvent, value); }
            remove { RemoveHandler(BtnCClicEvent, value); }
        }

        public static RoutedEvent BtnXClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnXClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnXClick
        {
            add { AddHandler(BtnXClicEvent, value); }
            remove { RemoveHandler(BtnXClicEvent, value); }
        }

        public static RoutedEvent BtnZClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnZClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnZClick
        {
            add { AddHandler(BtnZClicEvent, value); }
            remove { RemoveHandler(BtnZClicEvent, value); }
        }

        public static RoutedEvent BtnÑClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnÑClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnÑClick
        {
            add { AddHandler(BtnÑClicEvent, value); }
            remove { RemoveHandler(BtnÑClicEvent, value); }
        }

        public static RoutedEvent BtnLClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnLClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnLClick
        {
            add { AddHandler(BtnLClicEvent, value); }
            remove { RemoveHandler(BtnLClicEvent, value); }
        }

        public static RoutedEvent BtnJClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnJClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnJClick
        {
            add { AddHandler(BtnJClicEvent, value); }
            remove { RemoveHandler(BtnJClicEvent, value); }
        }

        public static RoutedEvent BtnKClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnKClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnKClick
        {
            add { AddHandler(BtnKClicEvent, value); }
            remove { RemoveHandler(BtnKClicEvent, value); }
        }

        public static RoutedEvent BtnHClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnHClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnHClick
        {
            add { AddHandler(BtnHClicEvent, value); }
            remove { RemoveHandler(BtnHClicEvent, value); }
        }

        public static RoutedEvent BtnGClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnGClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnGClick
        {
            add { AddHandler(BtnGClicEvent, value); }
            remove { RemoveHandler(BtnGClicEvent, value); }
        }

        public static RoutedEvent BtnFClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnFClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnFClick
        {
            add { AddHandler(BtnFClicEvent, value); }
            remove { RemoveHandler(BtnFClicEvent, value); }
        }

        public static RoutedEvent BtnDClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnDClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnDClick
        {
            add { AddHandler(BtnDClicEvent, value); }
            remove { RemoveHandler(BtnDClicEvent, value); }
        }

        public static RoutedEvent BtnSClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnSClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnSClick
        {
            add { AddHandler(BtnSClicEvent, value); }
            remove { RemoveHandler(BtnSClicEvent, value); }
        }

        public static RoutedEvent BtnAClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnAClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnAClick
        {
            add { AddHandler(BtnAClicEvent, value); }
            remove { RemoveHandler(BtnAClicEvent, value); }
        }

        public static RoutedEvent BtnPClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnPClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnPClick
        {
            add { AddHandler(BtnPClicEvent, value); }
            remove { RemoveHandler(BtnPClicEvent, value); }
        }

        public static RoutedEvent BtnOClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnOClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnOClick
        {
            add { AddHandler(BtnOClicEvent, value); }
            remove { RemoveHandler(BtnOClicEvent, value); }
        }

        public static RoutedEvent BtnIClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnIClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnIClick
        {
            add { AddHandler(BtnIClicEvent, value); }
            remove { RemoveHandler(BtnIClicEvent, value); }
        }

        public static RoutedEvent BtnUClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnUClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnUClick
        {
            add { AddHandler(BtnUClicEvent, value); }
            remove { RemoveHandler(BtnUClicEvent, value); }
        }

        public static RoutedEvent BtnYClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnYClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnYClick
        {
            add { AddHandler(BtnYClicEvent, value); }
            remove { RemoveHandler(BtnYClicEvent, value); }
        }

        public static RoutedEvent BtnRClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnRClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnRClick
        {
            add { AddHandler(BtnRClicEvent, value); }
            remove { RemoveHandler(BtnRClicEvent, value); }
        }

        public static RoutedEvent BtnTClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnTClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnTClick
        {
            add { AddHandler(BtnTClicEvent, value); }
            remove { RemoveHandler(BtnTClicEvent, value); }
        }

        public static RoutedEvent BtnEClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnEClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnEClick
        {
            add { AddHandler(BtnEClicEvent, value); }
            remove { RemoveHandler(BtnEClicEvent, value); }
        }

        public static RoutedEvent BtnWClicEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnWClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnWClick
        {
            add { AddHandler(BtnWClicEvent, value); }
            remove { RemoveHandler(BtnWClicEvent, value); }
        }

        public static RoutedEvent BtnQClickEvent = EventManager.RegisterRoutedEvent(
            nameof(BtnQClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler BtnQClick
        {
            add { AddHandler(BtnQClickEvent, value); }
            remove { RemoveHandler(BtnQClickEvent, value); }
        }

        public static RoutedEvent Btn0ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn0Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn0Click
        {
            add { AddHandler(Btn0ClickEvent, value); }
            remove { RemoveHandler(Btn0ClickEvent, value); }
        }

        public static RoutedEvent Btn9ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn9Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn9Click
        {
            add { AddHandler(Btn9ClickEvent, value); }
            remove { RemoveHandler(Btn9ClickEvent, value); }
        }

        public static RoutedEvent Btn8ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn8Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn8Click
        {
            add { AddHandler(Btn8ClickEvent, value); }
            remove { RemoveHandler(Btn8ClickEvent, value); }
        }

        public static RoutedEvent Btn7ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn7Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn7Click
        {
            add { AddHandler(Btn7ClickEvent, value); }
            remove { RemoveHandler(Btn7ClickEvent, value); }
        }

        public static RoutedEvent Btn6ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn6Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn6Click
        {
            add { AddHandler(Btn6ClickEvent, value); }
            remove { RemoveHandler(Btn6ClickEvent, value); }
        }

        public static RoutedEvent Btn5ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn5Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn5Click
        {
            add { AddHandler(Btn5ClickEvent, value); }
            remove { RemoveHandler(Btn5ClickEvent, value); }
        }

        public static RoutedEvent Btn4ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn4Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn4Click
        {
            add { AddHandler(Btn4ClickEvent, value); }
            remove { RemoveHandler(Btn4ClickEvent, value); }
        }

        public static RoutedEvent Btn3ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn3Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn3Click
        {
            add { AddHandler(Btn3ClickEvent, value); }
            remove { RemoveHandler(Btn3ClickEvent, value); }
        }

        public static RoutedEvent Btn2ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn2Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn2Click
        {
            add { AddHandler(Btn2ClickEvent, value); }
            remove { RemoveHandler(Btn2ClickEvent, value); }
        }

        public static RoutedEvent Btn1ClickEvent = EventManager.RegisterRoutedEvent(
            nameof(Btn1Click),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(KeyboardControl));

        public event RoutedEventHandler Btn1Click
        {
            add { AddHandler(Btn1ClickEvent, value); }
            remove { RemoveHandler(Btn1ClickEvent, value); }
        }

        public KeyboardControl()
        {
            InitializeComponent();
        }

        private void BtnM_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnMClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnN_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnNClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnB_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnBClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnV_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnVClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnC_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnCClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnX_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnXClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnZ_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnZClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnÑ_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnÑClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnL_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnLClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnK_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnKClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnJ_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnJClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnH_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnHClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnG_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnGClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnF_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnFClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnD_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnDClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnS_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnSClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnA_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnAClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnP_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnPClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnO_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnOClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnI_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnIClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnU_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnUClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnY_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnYClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnT_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnTClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnR_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnRClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnE_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnEClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnW_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnWClicEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void BtnQ_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BtnQClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn0_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn0ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn9_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn9ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn8_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn8ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn7_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn7ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn6_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn6ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn5_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn5ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn4_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn4ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn3_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn3ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn2_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn2ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

        private void Btn1_ButtonControlClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Btn1ClickEvent));
            ButtonControl button = (ButtonControl)sender;
            button.IsButtonEnabled = false;
            button.Opacity = 0.5;
        }

    }

}