using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.CompilerServices;
using PAS.Storage.Models.Enums;
using PAS.Storage.Repositories;
using PAS.UI.Models;

namespace PAS.UI.ViewModels;

public class OrderPageViewModel
{
    private IPASAppRepository DataStore { get; } = new PASAppRepository();

    private readonly Order order;

    private readonly Product[] products;

    public Product[] Products => products;
    
    public int ID => order.ID;

    public string Status => order.Status;

    public PaymentType Payment => order.Payment;

    public DateTime DateTimeCreated => order.DateTimeCreated;
    
    public decimal Price => order.Price;

    public OrderPageViewModel(Order order)
    {
        this.order = order;

        products = order.IDsProducts
            .Split(',')
            .Select(x => int.Parse(x))
            .Select(x => DataStore.Products.GetProductsByID(x))
            .Select(x => new Product(x))
            .ToArray();
    }
}