using System.Collections.Generic;
using System.Linq;
using PAS.Storage.Models;

namespace PAS.UI;

public static class CartItemExtensions
{
    public static CartItem ToStorageCartItem(this Models.CartItem cartItem) => new CartItem
    {
        Name = cartItem.Name,
        Category = cartItem.Category,
        Count = cartItem.Count,
        Price = cartItem.Price,
        DateTimeAdded = cartItem.DateTimeAdded,
        IDProduct = cartItem.IDProduct,
        IDUser = cartItem.IDUser
    };

    public static CartItem[] ToStorageCartItems(this Models.CartItem[] cartItems) => cartItems
        .Select(x => x.ToStorageCartItem())
        .ToArray();
    
    public static CartItem[] ToStorageCartItems(this List<Models.CartItem> cartItems) => cartItems
        .Select(x => x.ToStorageCartItem())
        .ToArray();
}