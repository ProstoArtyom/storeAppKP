using System.ComponentModel.DataAnnotations;
using PAS.Storage.Models.Enums;

namespace PAS.Storage.Models;

public class Order
{
    [Key]
    public int ID { get; set; }
    
    public string IDsProducts { get; set; }
    
    public DateTime DateTimeCreated { get; set; }
    
    public string Status { get; set; }
    
    public decimal Price { get; set; }
    
    public PaymentType Payment { get; set; }

    public int IDUser { get; set; }
}