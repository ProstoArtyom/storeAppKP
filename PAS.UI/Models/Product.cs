using System;

namespace PAS.UI.Models;

public class Product
{
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string Stars { get; set; }
    
    public int Count { get; set; }
    
    public string Category { get; set; }
    
    public string Shop { get; set; }
    
    public string Description { get; set; }

    public byte[] Image { get; set; }
    
    public Product() {}

    public Product(Storage.Models.Product product)
    {
        ID = product.ID;
        Name = product.Name;
        Price = product.Price;
        Stars = product.Stars;
        Count = product.Count;
        Category = product.Category;
        Shop = product.Shop;
        Description = product.Description;
        Image = product.Image;
    }
}