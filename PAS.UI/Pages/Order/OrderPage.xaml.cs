using System;
using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PAS.UI.Models;
using PAS.UI.Pages.Products;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages.Order;

public partial class OrderPage : PASAppPage
{
    private readonly Models.Order order;

    public OrderPageViewModel PageViewModel { get; private set; }
    
    public OrderPage(Models.Order order)
    {
        InitializeComponent();
        DataContext = PageViewModel = new OrderPageViewModel(order);

        this.order = order;
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }

    private void ProductsDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var selectedProduct = ProductsDataGrid.SelectedItem as Product;
        if (selectedProduct == null)
            return;

        var product = new Product(DataStore.Products.GetProductsByID(selectedProduct.ID));
        var productPage = new ProductPage(product);
        NavigationService!.Navigate(productPage);
    }

    private void PrintBtn_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            this.IsEnabled = false;
            var printDialog = new PrintDialog();
            printDialog.ShowDialog();
            printDialog.PrintTicket.PageScalingFactor = 100;
            printDialog.PrintVisual(this, "Order");
        }
        finally
        {
            this.IsEnabled = true;
        }
    }
}