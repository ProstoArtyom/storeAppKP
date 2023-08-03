using System.ComponentModel.DataAnnotations;

namespace PAS.Storage.Models;

public class Product
{
    [Key]
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Stars { get; set; }
    
    public int Count { get; set; }
    
    public string Category { get; set; }
    
    public string Shop { get; set; }
    
    public string Description { get; set; }

    public byte[] Image { get; set; }
}