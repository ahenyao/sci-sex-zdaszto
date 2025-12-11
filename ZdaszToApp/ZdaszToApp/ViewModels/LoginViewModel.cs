using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using Tmds.DBus.Protocol;
using System;

namespace ZdaszToApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty] private string? username;

    [ObservableProperty] private string? password;

    [ObservableProperty] private string? message;

    [ObservableProperty] private string? error_login = "Wpisz login";
    
    [ObservableProperty] private string? error_password = "Wpisz hasło";
    
    [ObservableProperty] private bool isLoggedIn;

    private static List<(string Username, string Password)> Users = new()
    {
        ("test", "1234"),
        ("admin", "admin")
    };

    [RelayCommand]
    private void Login()
    {
        
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            Message = "Nazwa użytkownika i hasło nie mogą być puste.";
            return;
        }

        var user = Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
        
        if (user == default)
        {
            Message = "Nieprawidłowa nazwa użytkownika lub hasło.";
            Password = string.Empty;
            Username = string.Empty;
        }
        else
        {
            Message = "Logowanie udane!";
            IsLoggedIn = true;
        }
        
        var userByLogin = Users.FirstOrDefault(u => u.Username == Username);
        if (userByLogin == default)
        {
            Error_login = "Wpisany login jest błędny";
        }
        else
        {
            if (userByLogin.Password != Password)
            {
                Error_password = "Wpisane hasło jest błędne";
            }
            
        }
    }
}
