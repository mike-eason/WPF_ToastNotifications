# WPF Toast Notifications

This is a project which provides simple, beautiful toast notifications for WPF desktop applications.

#### Getting Started

Here's how to add this project to your solution:

1. Download the project as a ZIP.
2. Add the `.csproj` to your solution.
3. Rebuild the project.

## Code Examples

To create a simple toast, use the following code:

```
using Encore.UI.Toast;

...

string title = "Hello World!";
string message = "This is a test";
ToastTypes type = ToastTypes.Info;

Toaster toaster = new Toaster();
toaster.Show(title, message, type);
```

#### Toasting an Exception

You can display a toast notification to display the `Message` inside an `Exception`:

```
catch (Exception ex)
{
    toaster.Show(ex);
}
```

*Or*

```
catch (Exception ex)
{
    toaster.Show("Something Failed!", ex);
}
```

#### Toast Within Bounds

If you want to display a toast inside the bounds of the window, you can pass in the window location to the
`parentContainer` parameter:

```
Rect windowBounds = new Rect(
    this.Left,
    this.Top,
    this.Width,
    this.Height);

toaster.Show(title, message, type, windowBounds);
```

#### Persistent Toasts

Sometimes you might want your toast to stick around until the user manually closes it. You can pass in `true`
into the `isPersistent` paramter:

```
toaster.Show(title, message, type, isPersistent: true);
```

#### Display Toasts For Longer

Toasts will be displayed for 5 seconds by default, if you want to extend this period you can pass in a `TimeSpan`
into the `displayTime` paramter:

```
//10 seconds
TimeSpan displayTime = new TimeSpan(10000);

toaster.Show(title, message, type, displayTime);
```

#### Mocking and Unit Testing

For unit testing, I recommend that you first ensure that any `Toaster` objects are added to your classes using
`dependency injection`, this will prevent any real toasts from being displayed inside unit tests.

```
private IToaster _toaster;

public MyClass(IToaster toaster)
{
    _toaster = toaster;   
}
```

The method of `dependency injection` is up to you, however this will allow you to make use of the interface `IToaster` 
which can be mocked. For example using the `NSubstitute` framework.

```
IToaster toaster = Substitute.For<IToaster>();
```

## License

MIT License

Copyright (c) 2016 Mike Eason

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.