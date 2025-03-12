using NanoCart.Carts.Requests;
using NanoCart.Entities;

namespace NanoCart.Carts.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCart(CartViewRequest request);
    
    Task AddItemsToCart(long cartId, long productId);
    
    Task RemoveItemFromCart(long cartId, long productId);
    
    Task FlushCart(long cartId);

    Task<long> CreateCart(Cart cart);
    
    Task DeleteCart(long cartId);
}