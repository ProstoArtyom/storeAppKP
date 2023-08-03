using System.Windows;
using System.Windows.Controls;
using PAS.UI.HelperClasses;
using PAS.UI.Models;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages.Products;

public partial class SellerProductPage : PASAppPage
{
    private readonly Product product;

    public ProductPageViewModel PageViewModel { get; private set; }
    
    public SellerProductPage(Product product)
    {
        InitializeComponent();
        
        DataContext = PageViewModel = new ProductPageViewModel(product);

        this.product = product;
    }

    private void DeleteBtn_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить данный товар?", 
            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;

        DataStore.Products.DeleteProductByID(product.ID);
        
        MessageBox.Show("Вы успешно удалили товар из вашего списка.", 
            "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        
        PagesNavigation.SellersProductsListPage.LoadProducts();
        NavigationService.GoBack();
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }
}