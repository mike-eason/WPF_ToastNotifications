using System;
using System.Windows.Threading;

namespace PeanutButter.Toast
{
    internal class Toast
    {
        public event EventHandler<ToastNotification> ToastClosing;

        private DispatcherTimer _Timer;
        private ToastNotification _Notification;

        public Toast(ToastNotification notification)
        {
            _Notification = notification;

            _Notification.Dismissed += Notification_Dismissed;
        }

        private void Notification_Dismissed(object sender, EventArgs e)
        {
            OnToastClosing();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Stop and close the window.
            _Timer.Stop();

            OnToastClosing();
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

        protected void OnToastClosing()
        {
            //Unsubscribe from the on dismiss event first (to avoid memory leaks)
            _Notification.Dismissed -= Notification_Dismissed;

            var eh = ToastClosing;

            if (eh != null)
                eh(this, _Notification);
        }
    }
}