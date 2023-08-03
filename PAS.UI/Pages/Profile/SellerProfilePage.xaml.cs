using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PAS.UI.Controls;
using PAS.UI.HelperClasses;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages.Profile;

public partial class SellerProfilePage : PASAppPage
{
    private SellerAccountInfoView AccountInfoView { get; set; }
    
    private SellerAccountInfoViewModel AccountInfoViewModel { get; set; }
    
    public SellerProfilePage()
    {
        InitializeComponent();
        
        Loaded += (sender, args) =>
        {
            var seller = new Models.Seller(DataStore.Sellers.GetSellerByID(AppUser.Instance.AccountId));
            DataContext = AccountInfoViewModel = new SellerAccountInfoViewModel(seller);
            AccountInfoView = new SellerAccountInfoView(AccountInfoViewModel, seller);
            AccountInfoFrame.Navigate(AccountInfoView);
        };
    }

    private void ExitBtn_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите выйти из учётной записи?", 
            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;

        WindowsNavigation.MainWindow.Hide();
        WindowsNavigation.AuthWindow.Show();
    }
}