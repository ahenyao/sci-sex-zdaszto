using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ZdaszToApp.ViewModels;
using System;
using Avalonia.Controls.ApplicationLifetimes;

namespace ZdaszToApp.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        if (DataContext is LoginViewModel vm)
        {
            vm.PropertyChanged += (s, e) =>
            {
                if (vm.IsLoggedIn)
                {
                    var mainWindow = new ZdaszToApp.MainWindow
                    {
                        Title = "ZdaszToApp",
                    };
                    if (Application.Current?.ApplicationLifetime is ClassicDesktopStyleApplicationLifetime lifetime)
                    {
                        lifetime.MainWindow = mainWindow;
                    }

                    mainWindow.Show();
                    Close();
                }
            };
        }
    }
}
