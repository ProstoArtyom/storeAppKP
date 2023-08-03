using System.ComponentModel.DataAnnotations;

namespace PAS.Storage.Models;

public class Seller
{
    [Key]
    public int ID { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Email { get; set; }

    public string Phone { get; set; }

    public string Number { get; set; }

    public string Shop { get; set; }
}