using NanoCart.Carts.Requests;
using NanoCart.Entities;

namespace NanoCart.Carts.Interfaces;

public interface ICartRepository
{
    Task<Cart> GetCart(CartViewRequest request);
}