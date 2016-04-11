using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace PeanutButter.Toast
{
    /// <summary>
    /// Interaction logic for ToastNotificationHost.xaml
    /// </summary>
    public partial class ToastNotificationHost : Window
    {
        public ObservableCollection<ToastNotification> Toasts
        {
            get { return (ObservableCollection<ToastNotification>)GetValue(ToastsProperty); }
            set { SetValue(ToastsProperty, value); }
        }
        
        public static readonly DependencyProperty ToastsProperty =
            DependencyProperty.Register("Toasts", typeof(ObservableCollection<ToastNotification>), typeof(ToastNotificationHost), new PropertyMetadata(new ObservableCollection<ToastNotification>()));

        public Rect? DisplayOrigin
        {
            get { return (Rect?)GetValue(DisplayOriginProperty); }
            set { SetValue(DisplayOriginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayOrigin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayOriginProperty =
            DependencyProperty.Register("DisplayOrigin", typeof(Rect?), typeof(ToastNotificationHost), new PropertyMetadata(null, new PropertyChangedCallback(DisplayOriginChanged)));

        private static void DisplayOriginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ToastNotificationHost host = (ToastNotificationHost)d;

            host.Reposition();
        }

        public void Reposition()
        {
            Rect area;
            int offset = 12;

            if (DisplayOrigin != null)
                area = (Rect)DisplayOrigin;
            else
                area = System.Windows.SystemParameters.WorkArea;

            //Display the toast at the top right of the area.
            this.Left = area.Right - this.Width - offset;
            this.Top = area.Top + offset;
        }

        public ToastNotificationHost()
        {
            InitializeComponent();

            this.Closing += ToastNotificationHost_Closing;
            this.Loaded += ToastNotification_Loaded;
        }

        private void ToastNotificationHost_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= ToastNotificationHost_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.25));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void ToastNotification_Loaded(object sender, RoutedEventArgs e)
        {
            Reposition();
        }
    }
}