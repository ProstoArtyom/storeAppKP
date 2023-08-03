using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PAS.Storage.Contexts;
using PAS.Storage.Models;

namespace PAS.Storage.Repositories;

public class CartRepository
{
    public CartItem[] GetCartItemsFromCart(int IDUser)
    {
        using var context = new PASAppContext();
        
        var inIDUser = new SqliteParameter("@IDUser", IDUser);
        
        var cartItems = context.Cart.FromSqlRaw("SELECT Cart.IDProduct, " +
                                               "Cart.Count, " +
                                               "Cart.DateTimeAdded, " +
                                               "Cart.IDUser, " +
                                               "Products.Name, " +
                                               "Products.Price, " +
                                               "Products.Category " +
                                               "FROM Cart INNER JOIN " +
                                               "Products ON Products.ID = Cart.IDProduct " +
                                               "WHERE Cart.IDUser = @IDUser",
            inIDUser).ToList();
        return cartItems.ToArray();
    }
    
    public void AddCartItemToCart(CartItem cartItem)
    {
        using var context = new PASAppContext();
        
        var inIDProduct = new SqliteParameter("@IDProduct", cartItem.IDProduct);
        var inIDUser = new SqliteParameter("@IDUser", cartItem.IDUser);
        var inCount = new SqliteParameter("@Count", cartItem.Count);
        var inDateTimeAdded = new SqliteParameter("@DateTimeAdded", cartItem.DateTimeAdded);

        context.Database.ExecuteSqlRaw("INSERT INTO Cart " + 
                                       "(IDProduct, Count, IDUser, DateTimeAdded) " + 
                                       "VALUES " + 
                                       "(@IDProduct, @Count, @IDUser, @DateTimeAdded) " +
                                       "ON CONFLICT(IDProduct, IDUser) DO UPDATE SET " + 
                                       "Count = Count + @Count, DateTimeAdded = @DateTimeAdded",
            inIDProduct, inIDUser, inCount, inDateTimeAdded);
    }
    
    public void DeleteCartItemFromCart(CartItem cartItem)
    {
        using var context = new PASAppContext();
        
        var inIdBook = new SqliteParameter("@IdBook", cartItem.IDProduct);

        context.Database.ExecuteSqlRaw("DELETE FROM Cart " +
                                       "WHERE Cart.IdBook = @IdBook", inIdBook);
    }
    
    public void DeleteCartItemsFromCart(CartItem[] cartItems)
    {
        foreach (var cartItem in cartItems)
            DeleteCartItemFromCart(cartItem);
    }
    
    public void DeleteCartItemsFromCart(int IdUser)
    {
        using var context = new PASAppContext();
        
        var inIdUser = new SqliteParameter("@IdUser", IdUser);

        
        context.Database.ExecuteSqlRaw("DELETE FROM Cart " +
                                       "WHERE Cart.IdUser = @IdUser", inIdUser);
    }
}