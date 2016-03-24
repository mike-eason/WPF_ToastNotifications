using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PeanutButter.Toast
{
    public enum ToastTypes
    {
        Error,
        Success,
        Warning,
        Info
    }

    public interface IToaster
    {
        /// <summary>
        /// Show an error toast notification for 5 seconds.
        /// </summary>
        /// <param name="error">The error to display. The content will be the Message property on the exception.</param>
        /// <param name="parentContainer">The container to display the toast within. Leave this as null to use the primary monitor.</param>
        /// <param name="isPersistent">If true, the toast will remain visible until the user closes it.</param>
        void Show(
            Exception error,
            Rect? parentContainer = null,
            bool isPersistent = false);

        /// <summary>
        /// Show an error toast notification for 5 seconds.
        /// </summary>
        /// <param name="title">The title of the toast.</param>
        /// <param name="error">The error to display. The content will be the Message property on the exception.</param>
        /// <param name="parentContainer">The container to display the toast within. Leave this as null to use the primary monitor.</param>
        /// <param name="isPersistent">If true, the toast will remain visible until the user closes it.</param>
        void Show(
            string title,
            Exception error,
            Rect? parentContainer = null,
            bool isPersistent = false);

        /// <summary>
        /// Show an error toast notification for 5 seconds.
        /// </summary>
        /// <param name="title">The title of the toast.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="parentContainer">The container to display the toast within. Leave this as null to use the primary monitor.</param>
        /// <param name="isPersistent">If true, the toast will remain visible until the user closes it.</param>
        void Show(
            string title,
            string message,
            Rect? parentContainer = null,
            bool isPersistent = false);

        /// <summary>
        /// Show a toast notification for 5 seconds.
        /// </summary>
        /// <param name="title">The title of the toast.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="toastType">The toast type to be displayed.</param>
        /// <param name="parentContainer">The container to display the toast within. Leave this as null to use the primary monitor.</param>
        /// <param name="isPersistent">If true, the toast will remain visible until the user closes it.</param>
        void Show(
            string title,
            string message,
            ToastTypes toastType,
            Rect? parentContainer = null,
            bool isPersistent = false);

        /// <summary>
        /// Show a toast notification for a given time frame.
        /// </summary>
        /// <param name="title">The title of the toast.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="toastType">The toast type to be displayed.</param>
        /// <param name="displayTime">The duration to show the toast for.</param>
        /// <param name="parentContainer">The container to display the toast within. Leave this as null to use the primary monitor.</param>
        /// <param name="isPersistent">If true, the toast will remain visible until the user closes it.</param>
        void Show(
            string title,
            string message,
            ToastTypes toastType,
            TimeSpan displayTime,
            Rect? parentContainer = null,
            bool isPersistent = false);
    }
}
