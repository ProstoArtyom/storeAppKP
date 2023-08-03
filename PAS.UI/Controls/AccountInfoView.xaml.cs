using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using PAS.UI.HelperClasses;
using PAS.UI.Models;
using PAS.UI.ViewModels;

namespace PAS.UI.Controls;

public partial class AccountInfoView : PASAppUserControl
{
    private readonly Profile profile;

    private readonly AccountInfoViewModel accountInfoViewModel;
    
    public AccountInfoView(AccountInfoViewModel accountInfoViewModel, Profile profile)
    {
        InitializeComponent();

        this.profile = profile;
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
        AddressTb.Text = AddressTbl.Text;
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        var newProfile = new Storage.Models.Profile
        {   
            ID = profile.ID,
            Name = NameTb.Text,
            Surname = SurnameTb.Text,
            Address = AddressTb.Text,
            Email = EmailTb.Text,
            Phone = PhoneTb.Text
        };

        DataStore.Profiles.SetProfile(newProfile);
        accountInfoViewModel.UpdateProperties(newProfile);
        
        SetStatusForTextControls(Visibility.Collapsed, Visibility.Visible);

        EditBtn.Visibility = Visibility.Visible;
        CancelBtn.Visibility = Visibility.Collapsed;
        SaveBtn.Visibility = Visibility.Collapsed;
    }

    private void SetStatusForTextControls(Visibility visibilityTb, Visibility visibilityTbl)
    {
        TextBox[] textBoxes = { NameTb, SurnameTb, EmailTb, PhoneTb, AddressTb };
        foreach (var textBox in textBoxes)
            textBox.Visibility = visibilityTb;

        TextBlock[] textBlocks = { NameTbl, SurnameTbl, EmailTbl, PhoneTbl, AddressTbl };
        foreach (var textBlock in textBlocks)
            textBlock.Visibility = visibilityTbl;
    }
}