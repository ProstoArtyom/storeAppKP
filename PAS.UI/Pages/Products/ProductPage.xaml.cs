using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PAS.UI.Controls;
using PAS.UI.Models;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages.Products;

public partial class ProductPage : PASAppPage
{
    private readonly Product product;

    public ProductPageViewModel PageViewModel { get; private set; }
    
    public ProductPage(Product product)
    {
        InitializeComponent();

        DataContext = PageViewModel = new ProductPageViewModel(product);

        this.product = product;
    }
    
    private void AddToCartButton_Click(object sender, RoutedEventArgs e)
    {
        var numericTextBox = numericTextBoxControl.numericTextBox;
        if (!int.TryParse(numericTextBox.Text, out int count))
        {
            MessageBox.Show("Введенное значение количества товара неккоректно!");
            return;
        }
        
        if (count > product.Count || count <= 0)
        {
            MessageBox.Show("Введённое количество товара недоступно!");
            return;
        }

        var cartItem = new PAS.Storage.Models.CartItem
        {
            IDProduct = product.ID,
            IDUser = MainPageViewModel.Instance.IDUser,
            Count = count,
            DateTimeAdded = DateTime.Now
        };
            
        DataStore.Cart.AddCartItemToCart(cartItem);
        MessageBox.Show("Товар успешно добавлен в корзину");
    }

    private void BackBtn_Click(object sender, RoutedEventArgs e)
    {
        NavigationService!.GoBack();
    }
}