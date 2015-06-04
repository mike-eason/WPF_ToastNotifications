using System;
using System.Windows;

namespace ToastNotifications
{
    public enum ToastTypes
    {
        Success,
        Error,
        Warning,
        Info
    }

    public enum DisplayLocations
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public static class ToastManager
    {
        /// <summary>
        /// Displays a toast notification for 5 seconds.
        /// </summary>
        /// <param name="title">The toast title.</param>
        /// <param name="message">The toast message.</param>
        /// <param name="toastType">The type of toast to display.</param>
        /// <param name="location">The location to display the toast.</param>
        /// <param name="displayOrigin">The parent window to display the toast in.</param>
        public static void Show(string title, string message,
            ToastTypes toastType = ToastTypes.Error,
            DisplayLocations location = DisplayLocations.BottomRight,
            Window displayOrigin = null)
        {
            Show(title, message, new TimeSpan(0,0,5), toastType, location, displayOrigin);
        }

        /// <summary>
        /// Displays a toast notification for a given length of time.
        /// </summary>
        /// <param name="title">The toast title.</param>
        /// <param name="message">The toast message.</param>
        /// <param name="displayTime">The length of time to display the toast for.</param>
        /// <param name="toastType">The type of toast to display.</param>
        /// <param name="location">The location to display the toast.</param>
        /// <param name="displayOrigin">The parent window to display the toast in.</param>
        /// <remarks>If displayOrigin is set, then the location will be within the window, as opposed to the screen.</remarks>
        public static void Show(string title, string message, 
            TimeSpan displayTime,
            ToastTypes toastType = ToastTypes.Error,
            DisplayLocations location = DisplayLocations.BottomRight,
            Window displayOrigin = null)
        {
            //Create a new toast control
            ToastNotification notification = new ToastNotification(title, message, toastType, location, displayOrigin);

            //Create a toast and accompanying dispatcher timer.
            Toast toast = new Toast(notification);

            //display it for X seconds
            toast.Show(displayTime);
        }
    }
}