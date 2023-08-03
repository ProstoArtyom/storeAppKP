using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PAS.UI.Controls;
using PAS.UI.HelperClasses;
using PAS.UI.Models;
using PAS.UI.ViewModels;

namespace PAS.UI.Pages.Products;

public partial class ProductsListPage : PASAppPage
{
    private UserMainPage MainPage { get; set; }

    private string QuerySearch => MainPage.SearchTb.Text;
    
    public ProductsListPage(UserMainPage mainPage)
    {
        InitializeComponent();

        categoryCb.SelectionChanged += CategoryCb_OnSelectionChanged;
        filterCb.SelectionChanged += FilerCb_OnSelectionChanged;

        MainPage = mainPage;
        MainPage.SearchBtn.Click += (sender, args) =>
        {
            LoadProducts();
        };

        MainPage.SearchTb.KeyDown += (sender, e) =>
        {
            if (e.Key == Key.Enter)
                LoadProducts();
        };
        
        LoadProducts();
    }

    public void LoadProducts()
    {
        var selectedCategoryItem = categoryCb.SelectedItem as ComboBoxItem;
        var selectedCategory = selectedCategoryItem!.Content.ToString();

        if (selectedCategory != "Всё")
        {
            LoadProducts(selectedCategory!);
            return;
        }
        
        var products = DataStore.Products.GetProducts().Select(x => new Product(x));
        var searchedProducts = products.Where(x => x.Name.Contains(QuerySearch, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        var filteredProducts = FilterProducts(searchedProducts);
        
        SetProducts(filteredProducts);
    }

    private void LoadProducts(string category)
    {
        var products = DataStore.Products.GetProductsByCategory(category).Select(x => new Product(x));
        var searchedProducts = products.Where(x => x.Name.Contains(QuerySearch, StringComparison.OrdinalIgnoreCase))
            .ToArray();
        var filteredProducts = FilterProducts(searchedProducts);
        
        SetProducts(filteredProducts);
    }
    
    private Product[] FilterProducts(Product[] products)
    {
        IEnumerable<Product> filteredProducts;
        
        var selectedFilterItem = filterCb.SelectedItem as ComboBoxItem;
        var selectedFilter = selectedFilterItem!.Content.ToString();
        switch (selectedFilter)
        {
            case "Без сортировки":
                filteredProducts = products;
                break;
            case "Сначала дешёвые":
                filteredProducts = products.OrderBy(x => x.Price);
                break;
            case "Сначала дорогие":
                filteredProducts = products.OrderByDescending(x => x.Price);
                break;
            case "Больше звёзд":
                filteredProducts = products.OrderByDescending(x => x.Stars);
                break;
            case "Меньше звёзд":
                filteredProducts = products.OrderBy(x => x.Stars);
                break;
            default:
                throw new Exception("Не найден заданный фильтр");
        }

        return filteredProducts.ToArray();
    }

    private void SetProducts(Product[] products)
    {
        if (products.Length == 0)
        {
            StatusTbl.Text = "Товары с данными параметрами не найдены.";
            StatusTbl.Visibility = Visibility.Visible;
            productsView.ItemsSource = products;
            return;
        }

        productsView.ItemsSource = products;
        StatusTbl.Text = string.Empty;
        StatusTbl.Visibility = Visibility.Collapsed;
    }

    private void CategoryCb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LoadProducts();
    }

    private void FilerCb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LoadProducts();
    }

    private void AddToCartButton_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var product = (Product)button.DataContext;
        
        var cartItem = new PAS.Storage.Models.CartItem
        {
            IDProduct = product.ID,
            IDUser = MainPageViewModel.Instance.IDUser,
            Count = 1,
            DateTimeAdded = DateTime.Now
        };
        
        DataStore.Cart.AddCartItemToCart(cartItem);
        MessageBox.Show("Товар успешно добавлен в корзину");
    }

    private void ProductsView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var listViewItem = (ListViewItem)sender;
        var product = (Product)listViewItem.Content;

        var productPage = new ProductPage(product);
        NavigationService!.Navigate(productPage);
    }
}