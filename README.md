# WPF Toast Notifications
Display toast notifications from a WPF application.

#Sample Code

Simple toast with default settings.

`ToastNotifications.ToastManager.Show("An error has occurred", "Something really really really bad just happened.");`

Simple success toast

`ToastNotifications.ToastManager.Show("Success", "Whatever you just did, that was successful.", ToastNotifications.ToastTypes.Success);`

A warning toast with positioning

`ToastNotifications.ToastManager.Show("Warning", "Stop doing that.", ToastNotifications.ToastTypes.Success, ToastNotifications.DisplayLocations.TopRight);`
