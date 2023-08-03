using System.Windows;
using System.Windows.Controls;
using PAS.Storage.Repositories;
using PAS.UI.HelperClasses;

namespace PAS.UI.Pages.Authorization;

public partial class UserAuthPage : PASAppPage
{
    private readonly RegistrationUserPage registrationUserPage;
    
    public UserAuthPage()
    {
        InitializeComponent();

        this.registrationUserPage = new RegistrationUserPage(this);
    }

    private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
    {
        LoginTb.Text = string.Empty;
        PasswordTb.Password = string.Empty;
        
        NavigationService!.Navigate(registrationUserPage);
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
        
        var user = DataStore.Users.GetUserByLogin(LoginTb.Text);
        if (user == null)
        {
            MessageBox.Show("Пользователь с таким логином не найден!");
            return;
        }
        else if (user.Password != password)
        {
            MessageBox.Show("Неверный пароль");
            return;
        }
        
        LoginTb.Text = string.Empty;
        PasswordTb.Password = string.Empty;
        
        NavigationService!.GoBack();
        WindowsNavigation.AuthWindow.Hide();

        AppUser.SetInstance(user.Login, user.Password, user.ID);

        var userMainPage = PagesNavigation.UserMainPage;
        WindowsNavigation.MainWindow.mainFrame.Navigate(userMainPage);

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