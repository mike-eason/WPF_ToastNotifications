using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ToastNotifications
{
    internal class ToastNotification : Window
    {
        public ToastTypes ToastType
        {
            get { return (ToastTypes)GetValue(ToastTypeProperty); }
            set { SetValue(ToastTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToastType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToastTypeProperty =
            DependencyProperty.Register("ToastType", typeof(ToastTypes), typeof(ToastNotification), new PropertyMetadata(ToastTypes.Error));

        public DisplayLocations DisplayLocation
        {
            get { return (DisplayLocations)GetValue(DisplayLocationProperty); }
            set { SetValue(DisplayLocationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayLocationProperty =
            DependencyProperty.Register("DisplayLocation", typeof(DisplayLocations), typeof(ToastNotification), new PropertyMetadata(DisplayLocations.BottomRight));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ToastNotification), new PropertyMetadata(string.Empty));

        public Window DisplayOrigin
        {
            get { return (Window)GetValue(DisplayOriginProperty); }
            set { SetValue(DisplayOriginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayOrigin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayOriginProperty =
            DependencyProperty.Register("DisplayOrigin", typeof(Window), typeof(ToastNotification), new PropertyMetadata(null));

        static ToastNotification()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToastNotification), new FrameworkPropertyMetadata(typeof(ToastNotification)));
        }

        public ToastNotification()
        {
            this.Closing += ToastNotification_Closing;
            this.Loaded += ToastNotification_Loaded;
        }

        public ToastNotification(string title, string message, 
            ToastTypes toastType = ToastTypes.Error, 
            DisplayLocations location = DisplayLocations.BottomRight,
            Window displayOrigin = null)
        {
            this.Title = title;
            this.Message = message;
            this.ToastType = toastType;
            this.DisplayLocation = location;
            this.DisplayOrigin = displayOrigin;

            this.Closing += ToastNotification_Closing;
            this.Loaded += ToastNotification_Loaded;
        }

        void ToastNotification_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= ToastNotification_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.25));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        void ToastNotification_Loaded(object sender, RoutedEventArgs e)
        {
            Rect area;
            int offset = 12;

            if (DisplayOrigin != null)
                area = new Rect(new Point(DisplayOrigin.Left, DisplayOrigin.Top), DisplayOrigin.RenderSize);
            else
                area = System.Windows.SystemParameters.WorkArea;

            if (DisplayLocation == DisplayLocations.BottomRight)
            {
                this.Left = area.Right - this.Width - offset;
                this.Top = area.Bottom - this.Height - offset;
            }
            else if (DisplayLocation == DisplayLocations.BottomLeft)
            {
                this.Left = area.Left + offset;
                this.Top = area.Bottom - this.Height - offset;
            }
            else if (DisplayLocation == DisplayLocations.TopLeft)
            {
                this.Left = area.Left + offset;
                this.Top = area.Top + offset;
            }
            else if (DisplayLocation == DisplayLocations.TopRight)
            {
                this.Left = area.Right - this.Width - offset;
                this.Top = area.Top + offset;
            }
        }
    }
}