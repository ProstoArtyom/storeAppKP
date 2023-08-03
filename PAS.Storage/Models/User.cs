using System.ComponentModel.DataAnnotations;

namespace PAS.Storage.Models;

public class User
{
    [Key]
    public int ID { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
}