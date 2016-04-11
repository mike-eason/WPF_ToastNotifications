using System;
using System.Windows;

namespace PeanutButter.Toast
{
    public class Toaster : IToaster
    {
        private const string _DEFAULT_TITLE = "Operation Failed";

        private ToastNotificationHost _HOST;

        public void Show(
            Exception error,
            Rect? parentContainer = null,
            bool isPersistent = false)
        {
            Show(_DEFAULT_TITLE, error.Message, parentContainer, isPersistent);
        }

        public void Show(
            string title,
            Exception error,
            Rect? parentContainer = null,
            bool isPersistent = false)
        {
            Show(title, error.Message, parentContainer, isPersistent);
        }

        public void Show(
            string title,
            string message,
            Rect? parentContainer = null,
            bool isPersistent = false)
        {
            Show(title, message, ToastTypes.Error, parentContainer, isPersistent);
        }

        public void Show(
            string title,
            string message,
            ToastTypes toastType,
            Rect? parentContainer = null,
            bool isPersistent = false)
        {
            Show(title, message, toastType, new TimeSpan(0, 0, 5), parentContainer, isPersistent);
        }

        public void Show(
            string title,
            string message,
            ToastTypes toastType,
            TimeSpan displayTime,
            Rect? parentContainer = null,
            bool isPersistent = false)
        {
            //Show the host window
            ShowHost(parentContainer);

            //Create a new toast control
            ToastNotification notification = new ToastNotification()
            {
                Title = title,
                Message = message,
                ToastType = toastType,
                IsPersistent = isPersistent
            };

            //Create a toast and accompanying dispatcher timer.
            Toast toast = new Toast(notification);
            toast.ToastClosing += Toast_ToastClosing;

            //Add the toast to the host window
            _HOST.Toasts.Add(notification);

            //display it for X seconds
            toast.Show(displayTime);
        }

        private void ShowHost(Rect? container)
        {
            //If the current host window is null, create it.
            if (_HOST == null)
            {
                _HOST = new ToastNotificationHost()
                {
                    DisplayOrigin = container
                };

                _HOST.Show();
                _HOST.Closed += _HOST_Closed;
            }
            //Otherwise, set it's display location and origin.
            else
                _HOST.DisplayOrigin = container;

            _HOST.Reposition();

            //Display the window
            if (!_HOST.IsVisible)
                _HOST.Visibility = Visibility.Visible;
        }

        private void Toast_ToastClosing(object sender, ToastNotification e)
        {
            //Remove the toast from the host window
            _HOST.Toasts.Remove(e);

            //If there are no more toasts to show, then close the host window
            if (_HOST.Toasts.Count == 0)
                _HOST.Visibility = Visibility.Collapsed;
        }

        private void _HOST_Closed(object sender, EventArgs e)
        {
            //Reset the host.
            _HOST.Closed -= _HOST_Closed;
            _HOST = null;
        }
    }
}