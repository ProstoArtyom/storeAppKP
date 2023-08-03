using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PAS.UI.HelperClasses.Commands;

namespace PAS.UI.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    public static MainPageViewModel Instance { get; set; }
    
    private string login;

    public string Login
    {
        get => login;
        set
        {
            login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    public int IDUser { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}