using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace PAS.UI.Pages.Authorization;

public partial class RegistrationUserPage : PASAppPage
{
    public RegistrationUserPage(Page previousPage)
    {
        InitializeComponent();

        LoginTb.TextChanged += TextBox_TextChanged;
        PasswordTb.PasswordChanged += PasswordTbOnPasswordChanged;
        RepeatPasswordTb.PasswordChanged += PasswordTbOnPasswordChanged;
    }

    private void ReturnBtn_Click(object sender, RoutedEventArgs e)
    {
        LoginTb.Text = string.Empty;
        EmailTb.Text = string.Empty;
        PasswordTb.Password = string.Empty;
        RepeatPasswordTb.Password = string.Empty;

        NavigationService!.GoBack();
    }

    private void RegisterBtn_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckDataForValid())
            return;

        var login = LoginTb.Text;

        if (DataStore.Users.IsLoginExists(login))
        {
            MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var email = EmailTb.Text;
        
        if (DataStore.Profiles.IsEmailUsed(email))
        {
            MessageBox.Show("Данная почта уже используется другим пользователем!", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var password = PasswordTb.Password;
        
        DataStore.Users.CreateUser(login, password, email);
        
        MessageBox.Show("Вы успешно зарегистрировали учётную запись пользователя!", "Info", 
            MessageBoxButton.OK, MessageBoxImage.Information);
        
        LoginTb.Text = string.Empty;
        EmailTb.Text = string.Empty;
        PasswordTb.Password = string.Empty;
        RepeatPasswordTb.Password = string.Empty;
        
        NavigationService!.GoBack();
    }
    
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        int maxLength = 25;

        if (textBox.Text.Length > maxLength)
        {
            textBox.Text = textBox.Text.Substring(0, maxLength);
            textBox.CaretIndex = maxLength;
        }
    }
    
    private void PasswordTbOnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox passwordBox = (PasswordBox)sender;
        int maxLength = 25;

        if (passwordBox.Password.Length > maxLength)
            passwordBox.Password = passwordBox.Password.Substring(0, maxLength);
    }
    
    private bool CheckDataForValid()
    {
        if (!IsStringValid(LoginTb.Text))
        {
            MessageBox.Show("Введён некорректный логин! Повторите попытку.", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (!IsEmailValid(EmailTb.Text))
        {
            MessageBox.Show("Введена некорректная почта! Повторите попытку.", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (!IsStringValid(PasswordTb.Password))
        {
            MessageBox.Show("Введён некорректный пароль! Повторите попытку.", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (!(IsStringValid(RepeatPasswordTb.Password) && PasswordTb.Password == RepeatPasswordTb.Password))
        {
            MessageBox.Show("Пароли не совпадают! Повторите попытку.", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        return true;
    }
    
    private bool IsEmailValid(string input) => Regex.IsMatch(input, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
    
    private bool IsStringValid(string input) => Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
}