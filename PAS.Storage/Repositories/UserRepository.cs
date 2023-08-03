using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PAS.Storage.Contexts;
using PAS.Storage.Models;

namespace PAS.Storage.Repositories;

public class UserRepository
{
    public static ProfileRepository ProfileRepository { get; } = new();
    
    public User GetUserByID(int ID)
    {
        using (var context = new PASAppContext())
        {
            var inID = new SqliteParameter("@ID", ID);
            List<User> users = context.Users.FromSqlRaw("SELECT Users.ID, " +
                                                        "Users.Login, " +
                                                        "Users.Password " +
                                                        "WHERE Users.ID = @ID",
                inID).ToList();
            var user = users.FirstOrDefault();
            return user;
        }
    }
    
    public User GetUserByLogin(string login)
    {
        using var context = new PASAppContext();
        
        var inLogin = new SqliteParameter("@Login", login);
        List<User> users = context.Users.FromSqlRaw("SELECT Users.ID, " +
                                                    "Users.Login, " +
                                                    "Users.Password " +
                                                    "FROM Users " +
                                                    "WHERE Users.Login = @Login",
            inLogin).ToList();
        var user = users.FirstOrDefault();
        return user;
    }
    
    public bool IsLoginExists(string login)
    {
        var user = GetUserByLogin(login);
        return user != null;
    }

    public void CreateUser(string login, string password, string email)
    {
        using var context = new PASAppContext();
        
        var inEmail = new SqliteParameter("@Email", email);

        context.Database.ExecuteSqlRaw("INSERT INTO Profiles (Name, Surname, Email, Phone, Address, IDUser) " +
                                       "VALUES ('', '', @Email, '', '', 0)", inEmail);

        var profile = ProfileRepository.GetProfileByEmail(email);
        var IDProfile = profile.ID;
        
        var inLogin = new SqliteParameter("@Login", login);
        var inPassword = new SqliteParameter("@Password", password);
        var inIDProfile = new SqliteParameter("@IDProfile", IDProfile);

        context.Database.ExecuteSqlRaw("INSERT INTO Users (Login, Password, IDProfile) " +
                                       "VALUES (@Login, @Password, @IDProfile)",
            inLogin, inPassword, inIDProfile);

        var User = GetUserByLogin(login);
        var inIDUser = new SqliteParameter("@IDUser", User.ID);

        context.Database.ExecuteSqlRaw("UPDATE Profiles " +
                                       "SET IDUser = @IDUser " +
                                       "WHERE ID = @IDProfile",
            inIDUser, inIDProfile);
    }
    
    public void SetProfile(Profile profile)
    {
        using var context = new PASAppContext();
        
        var inID = new SqliteParameter("@ID", profile.ID);
        var inName = new SqliteParameter("@Name", profile.Name);
        var inSurname = new SqliteParameter("@Surname", profile.Surname);
        var inAddress = new SqliteParameter("@Address", profile.Address);
        var inEmail = new SqliteParameter("@Email", profile.Email);
        var inPhone = new SqliteParameter("@Phone", profile.Phone);

        context.Database.ExecuteSqlRaw("UPDATE Profiles " +
                                       "SET Name = @Name, Surname = @Surname, Address = @Address, Email = @Email, Phone = @Phone " +
                                       "WHERE ID = @ID",
            inName, inSurname, inAddress, inEmail, inPhone, inID);
    }
}