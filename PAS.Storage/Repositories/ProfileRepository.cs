using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PAS.Storage.Contexts;
using PAS.Storage.Models;

namespace PAS.Storage.Repositories;

public class ProfileRepository
{
    public Profile GetProfileByID(int ID)
    {
        using var context = new PASAppContext();
        
        var inID = new SqliteParameter("@ID", ID);
        List<Profile> profiles = context.Profile.FromSqlRaw("SELECT Profiles.ID, " +
                                                            "Profiles.[Name], " +
                                                            "Profiles.Surname, " +
                                                            "Profiles.Email, " +
                                                            "Profiles.Phone, " +
                                                            "Profiles.Address, " +
                                                            "Profiles.IDUser " +
                                                            "FROM Profiles " +
                                                            "WHERE Profiles.IDUser = @ID",
            inID).ToList();
        var profile = profiles.FirstOrDefault();
        return profile;
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

    public Profile GetProfileByEmail(string email)
    {
        using var context = new PASAppContext();
        
        var inEmail = new SqliteParameter("@Email", email);
        List<Profile> profiles = context.Profile.FromSqlRaw("SELECT Profiles.ID, " +
                                                            "Profiles.[Name], " +
                                                            "Profiles.Surname, " +
                                                            "Profiles.Email, " +
                                                            "Profiles.Phone, " +
                                                            "Profiles.Address, " +
                                                            "Profiles.IDUser " +
                                                            "FROM Profiles " +
                                                            "WHERE Profiles.Email = @Email",
            inEmail).ToList();
        var profile = profiles.FirstOrDefault();
        return profile;
    }
    
    public bool IsEmailUsed(string email)
    {
        var profile = GetProfileByEmail(email);
        return profile != null;
    }
}