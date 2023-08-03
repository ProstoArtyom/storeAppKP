using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using PAS.Storage.Models;
using PAS.UI.HelperClasses;

namespace PAS.UI.Pages.Products;

public partial class AddProductPage : PASAppPage
{
    private string selectedImagePath;

    public AddProductPage()
    {
        InitializeComponent();
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        string name, description;
        int count;
        decimal price, stars;
        string category;
        byte[] image;
        
        try
        {
            name = NameTb.Text.Trim();
            description = DescriptionTb.Text.Trim();

            if (name == string.Empty || description == string.Empty)
                throw new Exception();
            
            count = int.Parse(CountTb.Text.Trim());
            stars = Convert.ToDecimal(StarsTb.Text.Trim(), CultureInfo.InvariantCulture);
            price = Convert.ToDecimal(PriceTb.Text.Trim(), CultureInfo.InvariantCulture);

            if (count < 1
                || stars < 0 || stars > 5
                || price < 0)
                throw new Exception();

            if (imgProduct.Source == null)
                throw new Exception();

            using (var stream = new MemoryStream())
            {
                var bmp = imgProduct.Source as BitmapImage;
                
                var jpegEncoder = new JpegBitmapEncoder();
                jpegEncoder.Frames.Add(BitmapFrame.Create(bmp));
                jpegEncoder.Save(stream);

                image = stream.ToArray();
            }
            
            var selectedCategoryItem = CategoryTb.SelectedItem as ComboBoxItem;
            category = selectedCategoryItem!.Content.ToString();
        }
        catch
        {
            MessageBox.Show("Неккоректные данные! Попробуйте ещё раз.", "Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var seller = DataStore.Sellers.GetSellerByID(AppUser.Instance.AccountId);
        
        var product = new Product
        {
            Name = name,
            Category = category,
            Count = count,
            Stars = stars.ToString(),
            Description = description,
            Price = price,
            Image = image,
            Shop = seller.Shop
        };

        DataStore.Products.AddProduct(product, AppUser.Instance.AccountId);
        
        MessageBox.Show("Вы успешно добавили товар в ваш список.", "Info", 
            MessageBoxButton.OK, MessageBoxImage.Information);
        
        PagesNavigation.SellersProductsListPage.LoadProducts();
        NavigationService.GoBack();
    }

    private void SelectPhotoBtn_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            selectedImagePath = openFileDialog.FileName;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(selectedImagePath);
            bitmap.EndInit();

            imgProduct.Source = bitmap;
        }
    }
}