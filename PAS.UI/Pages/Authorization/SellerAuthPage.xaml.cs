using System.Windows;
using System.Windows.Controls;
using PAS.UI.HelperClasses;

namespace PAS.UI.Pages.Authorization;

public partial class SellerAuthPage : PASAppPage
{
    private readonly RegistrationSellerPage registrationAdminPage;
    
    public SellerAuthPage()
    {
        InitializeComponent();

        this.registrationAdminPage = new RegistrationSellerPage();
    }
    
    private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
    {
        LoginTb.Text = string.Empty;
        PasswordTb.Password = string.Empty;
        
        NavigationService!.Navigate(registrationAdminPage);
    }

    private void LogInBtn_Click(object sender, RoutedEventArgs e)
    {
        var login = LoginTb.Text;
        var password = PasswordTb.Password;

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Неккоректные данные!");
            return;
        }
        
        var seller = DataStore.Sellers.GetSellerByLogin(LoginTb.Text);
        if (seller == null)
        {
            MessageBox.Show("Продавец с таким логином не найден!");
            return;
        }
        
        if (seller.Password != password)
        {
            MessageBox.Show("Неверный пароль");
            return;
        }
        
        LoginTb.Text = string.Empty;
        PasswordTb.Password = string.Empty;
        
        NavigationService!.GoBack();
        WindowsNavigation.AuthWindow.Hide();

        AppUser.SetInstance(seller.Login, seller.Password, seller.ID);
        
        var sellerMainPage = PagesNavigation.SellerMainPage;
        WindowsNavigation.MainWindow.mainFrame.Navigate(sellerMainPage);
        
        WindowsNavigation.MainWindow.Show();
    }

    private void ReturnBtn_Click(object sender, RoutedEventArgs e)
    {
        LoginTb.Text = string.Empty;
        PasswordTb.Password = string.Empty;
        
        NavigationService!.GoBack();
    }
    
    private void AboutBtn_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Приложение PAS: учёт товаров в магазине\n" +
                        "Была разработана студентом УО \"МГК цифровых технологий\"\n" +
                        "Студент: Иванов Иван Иванович\n" +
                        "Группа: 54ТП");
    }
}