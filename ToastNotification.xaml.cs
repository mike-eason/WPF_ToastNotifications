using System;
using System.Windows;
using System.Windows.Controls;

namespace Encore.UI.Toast
{
    /// <summary>
    /// Interaction logic for ToastNotification.xaml
    /// </summary>
    public partial class ToastNotification : UserControl
    {
        public event EventHandler OnDismissClicked;

        public ToastTypes ToastType
        {
            get { return (ToastTypes)GetValue(ToastTypeProperty); }
            set { SetValue(ToastTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToastType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToastTypeProperty =
            DependencyProperty.Register("ToastType", typeof(ToastTypes), typeof(ToastNotification), new PropertyMetadata(ToastTypes.Error));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ToastNotification), new PropertyMetadata(null));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ToastNotification), new PropertyMetadata(string.Empty));

        public bool IsPersistent
        {
            get { return (bool)GetValue(IsPersistentProperty); }
            set { SetValue(IsPersistentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPersistant.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPersistentProperty =
            DependencyProperty.Register("IsPersistent", typeof(bool), typeof(ToastNotification), new PropertyMetadata(false));

        public ToastNotification()
        {
            InitializeComponent();
        }

        private void Dismiss_Clicked(object sender, RoutedEventArgs e)
        {
            if (OnDismissClicked != null)
                OnDismissClicked(this, EventArgs.Empty);
        }
    }
}