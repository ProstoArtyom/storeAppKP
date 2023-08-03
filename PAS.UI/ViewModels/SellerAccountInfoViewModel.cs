using System.ComponentModel;
using System.Runtime.CompilerServices;
using PAS.UI.Models;

namespace PAS.UI.ViewModels;

public class SellerAccountInfoViewModel : INotifyPropertyChanged
{
    private readonly Seller seller;

    private string name;
    
    private string surname;
    
    private string email;

    private string phone;

    private string number;
    
    private string shop;
    
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
    public string Number
    {
        get => number;
        set
        {
            number = value;
            OnPropertyChanged(nameof(Number));
        }
    }

    public string Shop
    {
        get => shop;
        set
        {
            shop = value;
            OnPropertyChanged(nameof(Shop));
        }
    }    
    public event PropertyChangedEventHandler? PropertyChanged;

    public SellerAccountInfoViewModel(Seller seller)
    {
        this.seller = seller;

        Name = seller.Name;
        Surname = seller.Surname;
        Email = seller.Email;
        Phone = seller.Phone;
        Number = seller.Number;
        Shop = seller.Shop;
    }

    public void UpdateProperties(Storage.Models.Seller newSeller)
    {
        Name = newSeller.Name;
        Surname = newSeller.Surname;
        Email = newSeller.Email;
        Phone = newSeller.Phone;
        Shop = newSeller.Shop;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}