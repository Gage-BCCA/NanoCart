using NanoCart.Carts.Requests;
using NanoCart.Entities;

namespace NanoCart.Carts.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCart(long id);
    
    Task AddItemsToCart(long cartId, long productId);
    
    Task RemoveItemFromCart(long cartId, long productId);
    
    Task FlushCart(long cartId);

    Task<Cart> CreateCart();
    
    Task DeleteCart(long cartId);
}