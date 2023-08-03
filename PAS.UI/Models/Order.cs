using System;
using PAS.Storage.Models.Enums;

namespace PAS.UI.Models;

public class Order
{
    public int ID { get; set; }
    
    public string IDsProducts { get; set; }
    
    public DateTime DateTimeCreated { get; set; }
    
    public string Status { get; set; }
    
    public decimal Price { get; set; }
    
    public PaymentType Payment { get; set; }

    public int IDUser { get; set; }

    public Order(Storage.Models.Order order)
    {
        ID = order.ID;
        IDsProducts = order.IDsProducts;
        DateTimeCreated = order.DateTimeCreated;
        Status = order.Status;
        Price = order.Price;
        Payment = order.Payment;
        IDUser = order.IDUser;
    }
}