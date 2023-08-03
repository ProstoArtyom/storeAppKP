using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PAS.Storage.Contexts;
using PAS.Storage.Models;

namespace PAS.Storage.Repositories;

public class SellerRepository
{
    public Seller GetSellerByLogin(string login)
    {
        using var context = new PASAppContext();
        
        var inLogin = new SqliteParameter("@Login", login);
        List<Seller> sellers = context.Sellers.FromSqlRaw("SELECT Sellers.ID, " +
                                                          "Sellers.Login, " + 
                                                          "Sellers.Password, " +
                                                          "Sellers.Name, " + 
                                                          "Sellers.Surname, " + 
                                                          "Sellers.Email, " + 
                                                          "Sellers.Phone, " + 
                                                          "Sellers.Number, " + 
                                                          "Shops.Shop " +                                                          
                                                          "FROM Sellers INNER JOIN " + 
                                                          "Shops ON Sellers.IDShop = Shops.ID " + 
                                                          "WHERE Sellers.Login = @Login",
            inLogin).ToList();
        var seller = sellers.FirstOrDefault();
        return seller;
    }
    
    public Seller GetSellerByID(int ID)
    {
        using var context = new PASAppContext();
        
        var inLogin = new SqliteParameter("@ID", ID);
        List<Seller> sellers = context.Sellers.FromSqlRaw("SELECT Sellers.ID, " +
                                                          "Sellers.Login, " + 
                                                          "Sellers.Password, " +
                                                          "Sellers.Name, " + 
                                                          "Sellers.Surname, " + 
                                                          "Sellers.Email, " + 
                                                          "Sellers.Phone, " + 
                                                          "Sellers.Number, " + 
                                                          "Shops.Shop " +
                                                          "FROM Sellers INNER JOIN " + 
                                                          "Shops ON Sellers.IDShop = Shops.ID " +                                                           
                                                          "WHERE Sellers.ID = @ID",
            inLogin).ToList();
        var seller = sellers.FirstOrDefault();
        return seller;
    }
    
    public Seller GetSellerByEmail(string email)
    {
        using var context = new PASAppContext();
        
        var inEmail = new SqliteParameter("@Email", email);
        List<Seller> sellers = context.Sellers.FromSqlRaw("SELECT Sellers.ID, " +
                                                          "Sellers.Login, " + 
                                                          "Sellers.Password, " +
                                                          "Sellers.Name, " + 
                                                          "Sellers.Surname, " + 
                                                          "Sellers.Email, " + 
                                                          "Sellers.Phone, " + 
                                                          "Sellers.Number, " + 
                                                          "Shops.Shop " +
                                                          "FROM Sellers INNER JOIN " + 
                                                          "Shops ON Sellers.IDShop = Shops.ID " +                                                           
                                                          "WHERE Sellers.Email = @Email",
            inEmail).ToList();
        var seller = sellers.FirstOrDefault();
        return seller;
    }

    public Seller GetSellerByNumber(string number)
    {
        using var context = new PASAppContext();
        
        var inNumber = new SqliteParameter("@Number", number);
        List<Seller> sellers = context.Sellers.FromSqlRaw("SELECT Sellers.ID, " +
                                                          "Sellers.Login, " + 
                                                          "Sellers.Password, " +
                                                          "Sellers.Name, " + 
                                                          "Sellers.Surname, " + 
                                                          "Sellers.Email, " + 
                                                          "Sellers.Phone, " + 
                                                          "Sellers.Number, " + 
                                                          "Shops.Shop " +
                                                          "FROM Sellers INNER JOIN " + 
                                                          "Shops ON Sellers.IDShop = Shops.ID " +                                                           
                                                          "WHERE Sellers.Number = @Number",
            inNumber).ToList();
        var seller = sellers.FirstOrDefault();
        return seller;
    }
    
    public void SetSeller(Seller seller)
    {
        using var context = new PASAppContext();
        
        var inLogin = new SqliteParameter("@Login", seller.Login);
        var inPassword = new SqliteParameter("@Password", seller.Password);
        var inName = new SqliteParameter("@Name", seller.Name);
        var inSurname = new SqliteParameter("@Surname", seller.Surname);
        var inEmail = new SqliteParameter("@Email", seller.Email);
        var inPhone = new SqliteParameter("@Phone", seller.Phone);
        var inNumber = new SqliteParameter("@Number", seller.Number);

        context.Database.ExecuteSqlRaw("INSERT INTO Sellers (Login, Password, Name, Surname, " +
                                       "Email, Phone, Number, Shop) " +
                                       "VALUES (@Login, @Password, @Name, @Surname, " +
                                       "@Email, @Phone, @Number, @Shop)", 
            inLogin, inPassword, inName, inSurname, inEmail, inPhone, inNumber);
        
        var inIDSeller = new SqliteParameter("@IDSeller", seller.ID);
        var inShop = new SqliteParameter("@Shop", seller.Shop);

        context.Database.ExecuteSqlRaw("UPDATE Shops " +
                                       "SET Shop = @Shop " +
                                       "WHERE IDSeller = @IDSeller", 
            inIDSeller, inShop);
    }
    
    public void UpdateSeller(Seller seller)
    {
        using var context = new PASAppContext();
        
        var inID = new SqliteParameter("@ID", seller.ID);
        var inName = new SqliteParameter("@Name", seller.Name);
        var inSurname = new SqliteParameter("@Surname", seller.Surname);
        var inEmail = new SqliteParameter("@Email", seller.Email);
        var inPhone = new SqliteParameter("@Phone", seller.Phone);

        context.Database.ExecuteSqlRaw("UPDATE Sellers " +
                                       "SET Name = @Name, Surname = @Surname, Email = @Email, " +
                                       "Phone = @Phone " +
                                       "WHERE ID = @ID",
            inID, inName, inSurname, inEmail, inPhone);
        
        var inIDSeller = new SqliteParameter("@IDSeller", seller.ID);
        var inShop = new SqliteParameter("@Shop", seller.Shop);

        context.Database.ExecuteSqlRaw("UPDATE Shops " +
                                       "SET Shop = @Shop " +
                                       "WHERE IDSeller = @IDSeller", 
            inIDSeller, inShop);
    }
    
    public void CreateSeller(string login, string password, string email, string number)
    {
        using var context = new PASAppContext();

        var seller = new Seller
        {
            Login = login,
            Password = password,
            Email = email,
            Number = number,
            Phone = "",
            Name = "",
            Surname = "",
            Shop = ""
        };
        
        SetSeller(seller);

        var IDSeller = GetSellerByLogin(login).ID;

        var inID = new SqliteParameter("@IDSeller", IDSeller);
        var inShop = new SqliteParameter("@Shop", seller.Shop);

        context.Database.ExecuteSqlRaw("INSERT INTO Shops (IDSeller, Shop) " +
                                       "VALUES (@IDSeller, @Shop)", 
            inID, inShop);
    }

    public bool IsLoginExists(string login)
    {
        var seller = GetSellerByLogin(login);
        return seller != null;
    }

    public bool IsEmailUsed(string email)
    {
        var seller = GetSellerByEmail(email);
        return seller != null;    
    }

    public bool IsNumberUsed(string number)
    {
        var seller = GetSellerByNumber(number);
        return seller != null;
    }
}