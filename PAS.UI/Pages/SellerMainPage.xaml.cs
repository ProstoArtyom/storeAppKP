using System.Windows;
using System.Windows.Controls;
using PAS.UI.HelperClasses;
using PAS.UI.Pages.Products;
using PAS.UI.Pages.Profile;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages;

public partial class SellerMainPage : PASAppPage
{
    public SellerProfilePage SellerProfilePage { get; }
    
    public MainPageViewModel PageViewModel { get; private set; }
    
    public SellersProductsListPage ProductsListPage { get; private set; }
    
    public AddProductPage AddProductPage { get; private set; }

    public SellerMainPage()
    {
        InitializeComponent();
        
        DataContext = PageViewModel = MainPageViewModel.Instance;
        PagesNavigation.SellersProductsListPage = ProductsListPage = new SellersProductsListPage(this);

        SellerProfilePage = new SellerProfilePage();
        AddProductPage = new AddProductPage();
        
        MainFrame.Navigate(ProductsListPage);
    }
    
    private void AccountBtn_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(SellerProfilePage);
    }
    
    private void MainBtn_Click(object sender, RoutedEventArgs e)
    {
        ProductsListPage.LoadProducts();
        MainFrame.Navigate(ProductsListPage);
    }

    private void AddProductBtn_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(AddProductPage);
    }
}