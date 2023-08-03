namespace PAS.UI.Models;

public class Profile
{
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public Profile(Storage.Models.Profile profile)
    {
        ID = profile.ID;
        Name = profile.Name;
        Surname = profile.Surname;
        Email = profile.Email;
        Phone = profile.Phone;
        Address = profile.Address;
    }
}