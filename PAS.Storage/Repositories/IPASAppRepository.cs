using PAS.Storage.Models;

namespace PAS.Storage.Repositories;

public interface IPASAppRepository
{
    UserRepository Users { get; }
    
    ProductsRepository Products { get; }
    
    CartRepository Cart { get; }
    
    ProfileRepository Profiles { get; }
    
    OrderRepository Orders { get; }
    
    SellerRepository Sellers { get; }
}