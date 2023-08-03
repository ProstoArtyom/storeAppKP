using System;

namespace PAS.UI.Models;

public class CartItem
{
    public int IDUser { get; set; }

    public int IDProduct { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Category { get; set; }

    public DateTime DateTimeAdded { get; set; }
    
    public int Count { get; set; }
    
    public CartItem() {}

    public CartItem(Storage.Models.CartItem cartItem)
    {
        IDUser = cartItem.IDUser;
        IDProduct = cartItem.IDProduct;
        Name = cartItem.Name;
        Price = cartItem.Price;
        Category = cartItem.Category;
        DateTimeAdded = cartItem.DateTimeAdded;
        Count = cartItem.Count;
    }
}