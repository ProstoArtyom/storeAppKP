
using PAS.UI.Models;

namespace PAS.UI.ViewModels;

public class ProductPageViewModel
{
    private readonly Product product;
    
    public string ProductName => product.Name;

    public string Category => product.Category;

    public string Stars => product.Stars;

    public decimal Price => product.Price;

    public string Shop => product.Shop;

    public int Count => product.Count;
    
    public string Description => product.Description;

    public byte[] Image => product.Image;

    public ProductPageViewModel(Product product)
    {
        this.product = product;
    }
}