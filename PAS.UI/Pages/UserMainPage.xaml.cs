using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PAS.UI.HelperClasses;
using PAS.UI.Pages.Products;
using PAS.UI.Pages.Profile;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages;

public partial class UserMainPage : PASAppPage
{
    public MainPageViewModel PageViewModel { get; private set; }
    
    public ProfilePage ProfilePage { get; private set; }
    
    public ProductsListPage ProductsListPage { get; private set; }
    
    public CartPage CartPage { get; private set; }
    
    public UserMainPage()
    {
        InitializeComponent();

        DataContext = PageViewModel = MainPageViewModel.Instance;
        PagesNavigation.ProductsListPage = ProductsListPage = new ProductsListPage(this);
        ProfilePage = new ProfilePage();
        CartPage = new CartPage();

        MainFrame.Navigate(ProductsListPage);
    }
    
    private void AccountBtn_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(ProfilePage);
    }
    
    private void MainBtn_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(ProductsListPage);
    }

    private void CartBtn_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(CartPage);
    }
}