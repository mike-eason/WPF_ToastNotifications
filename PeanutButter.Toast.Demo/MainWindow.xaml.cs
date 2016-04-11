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

namespace PeanutButter.Toast.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Toaster _Toaster = new Toaster();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void toastRequested(object sender, RoutedEventArgs e)
        {
            ToastTypes type = GetChosenToastType((Button)sender);
            string title = txtTitle.Text;
            string message = txtMessage.Text;
            bool isPersistent = (bool)chkPersistent.IsChecked;
            bool showInWindow = (bool)chkShowInWindow.IsChecked;

            if (showInWindow)
            {
                Rect bounds = new Rect(
                    this.Left,
                    this.Top,
                    this.Width,
                    this.Height);

                _Toaster.Show(title, message, type, bounds, isPersistent);
            }
            else
                _Toaster.Show(title, message, type, isPersistent: isPersistent);
        }

        private ToastTypes GetChosenToastType(Button buttonClicked)
        {
            switch(buttonClicked.Name)
            {
                case "btnSuccess":
                    return ToastTypes.Success;
                case "btnError":
                    return ToastTypes.Error;
                case "btnWarning":
                    return ToastTypes.Warning;
                case "btnInfo":
                    return ToastTypes.Info;
            }

            throw new NotImplementedException("This button has not been implemented");
        }
    }
}