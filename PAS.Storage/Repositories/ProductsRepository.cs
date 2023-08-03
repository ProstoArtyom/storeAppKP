using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PAS.Storage.Contexts;
using PAS.Storage.Models;

namespace PAS.Storage.Repositories;

public class ProductsRepository
{
    public Product[] GetProducts()
    {
        using (var context = new PASAppContext())
        {
            var products = context.Products.FromSqlRaw("SELECT Products.ID, " +
                                                       "Products.Name, " +
                                                       "Products.Price, " +
                                                       "Products.Stars, " +
                                                       "Products.Count, " +
                                                       "Products.Category, " +
                                                       "Products.Description, " +
                                                       "Products.Image, " +
                                                       "Shops.Shop " +
                                                       "FROM Products INNER JOIN " +
                                                       "Shops ON Products.ShopID = Shops.ID").ToList();
            return products.ToArray();
        }
    }

    public Product[] GetProductsByCategory(string category)
    {
        using (var context = new PASAppContext())
        {
            var inCategory = new SqliteParameter("@Category", category);

            var products = context.Products.FromSqlRaw("SELECT Products.ID, " +
                                                       "Products.Name, " +
                                                       "Products.Price, " +
                                                       "Products.Stars, " +
                                                       "Products.Count, " +
                                                       "Products.Category, " +
                                                       "Products.Description, " +
                                                       "Products.Image, " +
                                                       "Shops.Shop " +
                                                       "FROM Products INNER JOIN " +
                                                       "Shops ON Products.ShopID = Shops.ID " +
                                                       "WHERE Products.Category = @Category",
                inCategory).ToList();
            return products.ToArray();
        }
    }
    
    public Product GetProductsByID(int ID)
    {
        using var context = new PASAppContext();
        
        var inCategory = new SqliteParameter("@ID", ID);

        var products = context.Products.FromSqlRaw("SELECT Products.ID, " +
                                                   "Products.Name, " +
                                                   "Products.Price, " +
                                                   "Products.Stars, " +
                                                   "Products.Count, " +
                                                   "Products.Category, " +
                                                   "Products.Description, " +
                                                   "Products.Image, " +
                                                   "Shops.Shop " +
                                                   "FROM Products INNER JOIN " +
                                                   "Shops ON Products.ShopID = Shops.ID " +
                                                   "WHERE Products.ID = @ID",
            inCategory).ToList();
        return products.FirstOrDefault();
    }

    public Product[] GetSellerProductsByCategory(int IDSeller, string category)
    {
        using var context = new PASAppContext();
        
        var inCategory = new SqliteParameter("@Category", category);
        var inIDSeller = new SqliteParameter("@IDSeller", IDSeller);

        var products = context.Products.FromSqlRaw("SELECT Products.ID, " +
                                                   "Products.Name, " +
                                                   "Products.Price, " +
                                                   "Products.Stars, " +
                                                   "Products.Count, " +
                                                   "Products.Category, " +
                                                   "Products.Description, " +
                                                   "Products.Image, " +
                                                   "Shops.Shop " +
                                                   "FROM Products INNER JOIN " +
                                                   "Shops ON Products.ShopID = Shops.ID " +
                                                   "WHERE Products.Category = @Category AND Shops.IDSeller = @IDSeller",
            inCategory, inIDSeller).ToList();
        return products.ToArray();
    }

    public Product[] GetSellerProducts(int IDSeller)
    {
        using var context = new PASAppContext();
        
        var inIDSeller = new SqliteParameter("@IDSeller", IDSeller);

        var products = context.Products.FromSqlRaw("SELECT Products.ID, " +
                                                   "Products.Name, " +
                                                   "Products.Price, " +
                                                   "Products.Stars, " +
                                                   "Products.Count, " +
                                                   "Products.Category, " +
                                                   "Products.Description, " +
                                                   "Products.Image, " +
                                                   "Shops.Shop " +
                                                   "FROM Products INNER JOIN " +
                                                   "Shops ON Products.ShopID = Shops.ID " +
                                                   "WHERE Shops.IDSeller = @IDSeller",
            inIDSeller).ToList();
        return products.ToArray();
    }

    public void AddProduct(Product product, int IDSeller)
    {
        using var context = new PASAppContext();
        
        var inName = new SqliteParameter("@Name", product.Name);
        var inPrice = new SqliteParameter("@Price", product.Price);
        var inStars = new SqliteParameter("@Stars", product.Stars);
        var inCount = new SqliteParameter("@Count", product.Count);
        var inCategory = new SqliteParameter("@Category", product.Category);
        var inDescription = new SqliteParameter("@Description", product.Description);
        var inImage = new SqliteParameter("@Image", product.Image);
        var inShopName = new SqliteParameter("@ShopName", product.Shop);

        context.Database.ExecuteSqlRaw("INSERT INTO Products (Name, Price, Stars, Count, " +
                                       "Category, Description, Image, ShopID) " +
                                       "SELECT @Name, @Price, @Stars, @Count, " +
                                       "@Category, @Description, @Image, Shops.ID " +
                                       "FROM Shops WHERE Shops.Shop = @ShopName", 
            inName, inPrice, inStars, inCount, inCategory, inDescription, inImage, inShopName);
    }

    public void DeleteProductByID(int IDProduct)
    {
        using var context = new PASAppContext();
        
        var inIDProduct = new SqliteParameter("@IDProduct", IDProduct);

        context.Database.ExecuteSqlRaw("DELETE FROM Products " +
                                       "WHERE Products.ID = @IDProduct", inIDProduct);
    }
}