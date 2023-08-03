using PAS.UI.Pages;
using PAS.UI.Pages.Products;

namespace PAS.UI.HelperClasses;

public static class PagesNavigation
{
    public static SellersProductsListPage SellersProductsListPage { get; set; }

    public static ProductsListPage ProductsListPage { get; set; }

    public static UserMainPage UserMainPage => new UserMainPage();

    public static SellerMainPage SellerMainPage => new SellerMainPage();

}