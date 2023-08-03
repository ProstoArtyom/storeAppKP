using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PAS.Storage.Contexts;
using PAS.Storage.Models;
using PAS.Storage.Models.Enums;

namespace PAS.Storage.Repositories;

public class OrderRepository
{
    public Order[] GetOrders(int IDUser)
    {
        using var context = new PASAppContext();

        var inIDUser = new SqliteParameter("@IDUser", IDUser);

        var orders = context.Orders.FromSqlRaw("SELECT Orders.ID, " + 
                                                               "Orders.IDsProducts, " +
                                                               "Orders.DateTimeCreated, " +
                                                               "Orders.Status, " +
                                                               "Orders.Price, " +
                                                               "Orders.Payment, " +
                                                               "Orders.IDUser " +
                                                               "FROM Orders " +
                                                               "WHERE Orders.IDUser = @IDUser",
            inIDUser);
        return orders.ToArray();
    }

    public Order CreateOrder(CartItem[] cartItems, PaymentType payment, Profile profile)
    {
        var order = new Order
        {
            Price = cartItems.Select(x => x.Price * x.Count).Sum(),
            Status = "Создано",
            IDsProducts = string.Join(',', cartItems.Select(x => x.IDProduct)),
            DateTimeCreated = DateTime.Now,
            Payment = payment,
            IDUser = profile.IDUser
        };

        return order;
    }

    public void SetOrder(Order order)
    {
        using var context = new PASAppContext();
        
        var inIDsProducts = new SqliteParameter("@IDsProducts", order.IDsProducts);
        var inDateTimeCreated = new SqliteParameter("@DateTimeCreated", order.DateTimeCreated);
        var inStatus = new SqliteParameter("@Status", order.Status);
        var inPrice = new SqliteParameter("@Price", order.Price);
        var inPayment = new SqliteParameter("@Payment", order.Payment);
        var inIDUser = new SqliteParameter("@IDUser", order.IDUser);

        context.Database.ExecuteSqlRaw("INSERT INTO Orders " + 
                                       "(IDsProducts, DateTimeCreated, Status, Price, Payment, IDUser) " + 
                                       "VALUES " + 
                                       "(@IDsProducts, @DateTimeCreated, @Status, @Price, @Payment, @IDUser)",
            inIDsProducts, inDateTimeCreated, inStatus, inPrice, inPayment, inIDUser);
    }
}