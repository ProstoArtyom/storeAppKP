namespace PAS.Storage.Repositories;

public class PASAppRepository : IPASAppRepository
{
    public UserRepository Users { get; }

    public ProductsRepository Products { get; }
    
    public CartRepository Cart { get; }
    
    public ProfileRepository Profiles { get; }
    
    public OrderRepository Orders { get; }

    public SellerRepository Sellers { get; }

    public PASAppRepository()
    {
        Users = new UserRepository();
        Products = new ProductsRepository();
        Cart = new CartRepository();
        Profiles = new ProfileRepository();
        Orders = new OrderRepository();
        Sellers = new SellerRepository();
    }
}