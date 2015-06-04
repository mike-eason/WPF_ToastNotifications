using System;
using System.Windows.Threading;

namespace ToastNotifications
{
    internal class Toast
    {
        public DispatcherTimer Timer { get; private set; }
        public ToastNotification Notification { get; private set; }

        public Toast(ToastNotification notification)
        {
            Notification = notification;
            Notification.AllowsTransparency = true;
            Notification.WindowStyle = System.Windows.WindowStyle.None;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Stop and close the window.
            Timer.Stop();

            Notification.Close();
        }

        public void Show(TimeSpan displayTime)
        {
            //Set up the timer
            Timer = new DispatcherTimer();
            Timer.Interval = displayTime;
            Timer.Tick += Timer_Tick;

            //Display the window
            Notification.Show();

            //Focus back to the other window if there is one present.
            if (Notification.DisplayOrigin != null)
                Notification.DisplayOrigin.Focus();

            //Start the timer
            Timer.Start();
        }
    }
}