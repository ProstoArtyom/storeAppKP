
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using PAS.Storage.Models.Enums;
using PAS.UI.Models;

namespace PAS.UI.ViewModels;

public class AccountInfoViewModel : INotifyPropertyChanged
{
    private readonly Profile profile;

    private string name;
    
    private string surname;
    
    private string email;

    private string phone;

    private string address;
    
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Surname
    {
        get => surname;
        set
        {
            surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }    
    public string Email
    {
        get => email;
        set
        {
            email = value;
            OnPropertyChanged(nameof(Email));
        }
    }    
    public string Phone
    {
        get => phone;
        set
        {
            phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }    
    public string Address
    {
        get => address;
        set
        {
            address = value;
            OnPropertyChanged(nameof(Address));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public AccountInfoViewModel(Profile profile)
    {
        this.profile = profile;

        Name = profile.Name;
        Surname = profile.Surname;
        Email = profile.Email;
        Phone = profile.Phone;
        Address = profile.Address;
    }

    public void UpdateProperties(Storage.Models.Profile newProfile)
    {
        Name = newProfile.Name;
        Surname = newProfile.Surname;
        Email = newProfile.Email;
        Phone = newProfile.Phone;
        Address = newProfile.Address;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}