using NanoCart.Carts.Requests;
using NanoCart.Entities;

namespace NanoCart.Carts.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCart(CartViewRequest request);
    
    Task<Cart> AddItemsToCart();
    
    Task<Cart> RemoveItemFromCart();
    
    Task FlushCart();

    Task<Cart> CreateCart();
    
    Task DeleteCart();
}