namespace PAS.UI.Models;

public class Seller
{
    public int ID { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }

    public string Phone { get; set; }

    public string Number { get; set; }
    
    public string Shop { get; set; }

    public Seller(Storage.Models.Seller seller)
    {
        ID = seller.ID;
        Login = seller.Login;
        Password = seller.Password;
        Name = seller.Name;
        Surname = seller.Surname;
        Email = seller.Email;
        Phone = seller.Phone;
        Number = seller.Number;
        Shop = seller.Shop;
    }
}