using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PAS.Storage.Models.Enums;
using PAS.UI.Controls;
using PAS.UI.HelperClasses;
using PAS.UI.Models;
using PAS.UI.Pages.Order;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages.Profile;

public partial class ProfilePage : PASAppPage
{
    private AccountInfoView AccountInfoView { get; set; }
    
    private AccountInfoViewModel AccountInfoViewModel { get; set; }

    public ProfilePage()
    {
        InitializeComponent();
        
        Loaded += (sender, args) =>
        {
            var profile = new Models.Profile(DataStore.Profiles.GetProfileByID(AppUser.Instance.AccountId));
            DataContext = AccountInfoViewModel = new AccountInfoViewModel(profile);
            AccountInfoView = new AccountInfoView(AccountInfoViewModel, profile);
            AccountInfoFrame.Navigate(AccountInfoView);

            var orders = DataStore.Orders.GetOrders(AppUser.Instance.AccountId)
                .Select(x => new Models.Order(x))
                .ToArray();

            if (orders.Length == 0)
            {
                OrderDataGrid.Visibility = Visibility.Collapsed;
                OrdersStatusLbl.Visibility = Visibility.Visible;
            }
            else
            {
                OrderDataGrid.ItemsSource = orders;
                OrderDataGrid.Visibility = Visibility.Visible;
                OrdersStatusLbl.Visibility = Visibility.Collapsed;
            }
        };
    }

    private void OrderDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var selectedOrder = OrderDataGrid.SelectedItem as Models.Order;
        if (selectedOrder == null)
            return;

        var orderPage = new OrderPage(selectedOrder);
        NavigationService!.Navigate(orderPage);
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