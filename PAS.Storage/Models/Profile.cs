using System.ComponentModel.DataAnnotations;

namespace PAS.Storage.Models;

public class Profile
{
    [Key]
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public int IDUser { get; set; }
}