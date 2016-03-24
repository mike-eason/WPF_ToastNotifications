using System;
using System.Windows.Threading;

namespace Encore.UI.Toast
{
    internal class Toast
    {
        public event EventHandler<ToastNotification> OnToastClosing;

        private DispatcherTimer _Timer;
        private ToastNotification _Notification;

        public Toast(ToastNotification notification)
        {
            _Notification = notification;

            notification.OnDismissClicked += notification_OnDismissClicked;
        }

        private void notification_OnDismissClicked(object sender, EventArgs e)
        {
            NotifyOnToastClosing();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Stop and close the window.
            _Timer.Stop();

            NotifyOnToastClosing();
        }

        public void Show(TimeSpan displayTime)
        {
            //Only start the timer if the notification is not persistent.
            if (!_Notification.IsPersistent)
            {
                //Set up the timer
                _Timer = new DispatcherTimer();
                _Timer.Interval = displayTime;
                _Timer.Tick += Timer_Tick;

                //Start the timer
                _Timer.Start();
            }
        }

        private void NotifyOnToastClosing()
        {
            //Unsubscribe from the on dismiss event first (to avoid memory leaks)
            _Notification.OnDismissClicked -= notification_OnDismissClicked;

            if (OnToastClosing != null)
                OnToastClosing(this, _Notification);
        }
    }
}