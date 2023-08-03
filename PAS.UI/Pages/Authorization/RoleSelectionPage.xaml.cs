using System.Windows;
using System.Windows.Controls;

namespace PAS.UI.Pages.Authorization;

public partial class RoleSelectionPage : PASAppPage
{
    private readonly UserAuthPage userAuthPage;

    private readonly SellerAuthPage adminAuthPage;
    
    public RoleSelectionPage()
    {
        InitializeComponent();

        userAuthPage = new UserAuthPage();
        adminAuthPage = new SellerAuthPage();
    }

    private void SetUserAuth_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.Navigate(userAuthPage);
    }

    private void SetAdminAuth_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.Navigate(adminAuthPage);
    }
}