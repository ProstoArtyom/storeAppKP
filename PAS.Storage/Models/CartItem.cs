using System.ComponentModel.DataAnnotations;

namespace PAS.Storage.Models;

public class CartItem
{
    public int IDUser { get; set; }
    
    public int IDProduct { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Category { get; set; }
    
    public DateTime DateTimeAdded { get; set; }
    
    public int Count { get; set; }
}