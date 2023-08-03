using System.Windows;
using System.Windows.Controls;
using PAS.UI.Models;
using PAS.UI.ViewModels;

namespace PAS.UI.Controls;

public partial class SellerAccountInfoView : PASAppUserControl
{
    private readonly SellerAccountInfoViewModel accountInfoViewModel;
    
    private readonly Seller seller;
    
    public SellerAccountInfoView(SellerAccountInfoViewModel accountInfoViewModel, Seller seller)
    {
        InitializeComponent();
        
        this.seller = seller;
        DataContext = this.accountInfoViewModel = accountInfoViewModel;
    }
    
    private void EditBtn_Click(object sender, RoutedEventArgs e)
    {
        SetStatusForTextControls(Visibility.Visible, Visibility.Collapsed);

        EditBtn.Visibility = Visibility.Collapsed;
        CancelBtn.Visibility = Visibility.Visible;
        SaveBtn.Visibility = Visibility.Visible;
    }

    private void CancelBtn_Click(object sender, RoutedEventArgs e)
    {
        NameTb.Text = NameTbl.Text;
        SurnameTb.Text = SurnameTbl.Text;
        EmailTb.Text = EmailTbl.Text;
        PhoneTb.Text = PhoneTbl.Text;
        ShopTb.Text = ShopTbl.Text;
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        var newSeller = new Storage.Models.Seller
        {   
            ID = seller.ID,
            Name = NameTb.Text,
            Surname = SurnameTb.Text,
            Email = EmailTb.Text,
            Phone = PhoneTb.Text,
            Shop = ShopTb.Text
        };

        DataStore.Sellers.UpdateSeller(newSeller);
        accountInfoViewModel.UpdateProperties(newSeller);
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SetStatusForTextControls(Visibility visibilityTb, Visibility visibilityTbl)
    {
        TextBox[] textBoxes = { NameTb, SurnameTb, EmailTb, PhoneTb, ShopTb };
        foreach (var textBox in textBoxes)
            textBox.Visibility = visibilityTb;

        TextBlock[] textBlocks = { NameTbl, SurnameTbl, EmailTbl, PhoneTbl, ShopTbl };
        foreach (var textBlock in textBlocks)
            textBlock.Visibility = visibilityTbl;
    }
}