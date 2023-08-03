using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PAS.Storage.Models.Enums;
using PAS.UI.Models;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages.Products;

public partial class CartPage : PASAppPage
{
    private readonly CartPageViewModel pageViewModel;
    
    private List<CartItem> ProductsForDeleting { get; } = new();
    
    public CartPage()
    {
        InitializeComponent();
        this.Loaded += (sender, args) =>
        {
            LoadCartProducts();
        };

        DataContext = pageViewModel = new CartPageViewModel();
    }

    private CartItem[] CartItems { get; set; }

    private void LoadCartProducts(CartItem[] cartItems)
    {
        CartItemsListView.ItemsSource = pageViewModel.CartProducts = CartItems = cartItems;
        
        if (CartItems.Length == 0)
        {
            StatusCartTbl.Visibility = Visibility.Visible;
            GridManageCartList.Visibility = Visibility.Collapsed;
            PaymentMethodsPanel.Visibility = Visibility.Collapsed;
            PurchaseBtn.Visibility = Visibility.Collapsed;
        }
        else
        {
            StatusCartTbl.Visibility = Visibility.Collapsed;
            GridManageCartList.Visibility = Visibility.Visible;
            PaymentMethodsPanel.Visibility = Visibility.Visible;
            PurchaseBtn.Visibility = Visibility.Visible;
        }
    }
    
    private void LoadCartProducts()
    {
        var cartItems = DataStore.Cart.GetCartItemsFromCart(MainPageViewModel.Instance.IDUser)
            .Select(x => new CartItem(x))
            .ToArray();
        
        LoadCartProducts(cartItems);
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        SetCheckBoxVisibility(Visibility.Visible);
        EditButton.Visibility = Visibility.Collapsed;
        EditButtonsPanel.Visibility = Visibility.Visible;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        SetCheckBoxVisibility(Visibility.Hidden);
        EditButtonsPanel.Visibility = Visibility.Collapsed;
        EditButton.Visibility = Visibility.Visible;
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        var messageBoxResult = MessageBox.Show("Вы уверены, что хотите удалить выбранные товары с корзины?", 
            "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        if (messageBoxResult == MessageBoxResult.No)
            return;

        var cartProducts = CartItems.ToList();
        ProductsForDeleting.ForEach(x => cartProducts.Remove(x));
        
        DataStore.Cart.DeleteCartItemsFromCart(ProductsForDeleting.ToStorageCartItems());
        ProductsForDeleting.Clear();
        
        LoadCartProducts(cartProducts.ToArray());

        SetCheckBoxVisibility(Visibility.Hidden);
        EditButtonsPanel.Visibility = Visibility.Collapsed;
        EditButton.Visibility = Visibility.Visible;
    }
    
    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        var checkBox = (CheckBox)sender;
        var item = (CartItem)checkBox.DataContext;
        ProductsForDeleting.Add(item);
    }

    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        var checkBox = (CheckBox)sender;
        var item = (CartItem)checkBox.DataContext;
        ProductsForDeleting.Remove(item);
    }
    
    private void ProductsView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var listViewItem = (ListViewItem)sender;
        var cartItem = (CartItem)listViewItem.Content;

        var product = new Product(DataStore.Products.GetProductsByID(cartItem.IDProduct));
        var productPage = new ProductPage(product);
        NavigationService!.Navigate(productPage);
    }
    
    private void SetCheckBoxVisibility(Visibility visibility)
    {
        CartItemsListView.UpdateLayout();
        
        foreach (var item in CartItemsListView.Items)
        {
            var container = CartItemsListView.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
            var checkBox = FindVisualChild<CheckBox>(container);

            if (checkBox != null)
            {
                checkBox.Visibility = visibility;
            }
        }
    }

    private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);

            if (child is T desiredChild)
                return desiredChild;
            else
            {
                var result = FindVisualChild<T>(child);

                if (result != null)
                    return result;
            }
        }

        return null;
    }

    private void PurchaseBtn_Click(object sender, RoutedEventArgs e)
    {
        var profile = DataStore.Profiles.GetProfileByID(AppUser.Instance.AccountId);
        bool isAllPropertiesValid = new[]
        {
            profile.Name,
            profile.Surname,
            profile.Address,
            profile.Email,
            profile.Phone
        }.All(x => !string.IsNullOrWhiteSpace(x));

        if (!isAllPropertiesValid)
        {
            MessageBox.Show("Чтобы оформить заказ, необходимо заполнить информацию о вас в личном кабинете.");
            return;
        }

        var cartItems = DataStore.Cart.GetCartItemsFromCart(AppUser.Instance.AccountId);
        var paymentMethod = (PaymentType)GetIndexOfSelectedPaymentMethod();
        var order = DataStore.Orders.CreateOrder(cartItems, paymentMethod, profile);
        DataStore.Orders.SetOrder(order);
        
        DataStore.Cart.DeleteCartItemsFromCart();
        LoadCartProducts();
        
        MessageBox.Show("Вы успешно оформили заказ!");
    }

    private int GetIndexOfSelectedPaymentMethod()
    {
        var selectedIndex = -1;
        
        foreach (RadioButton radioButton in RadioButtonsPanel.Children)
        {
            if (radioButton.IsChecked.Value)
            {
                selectedIndex = RadioButtonsPanel.Children.IndexOf(radioButton);
                break;
            }
        }

        return selectedIndex;
    }
}