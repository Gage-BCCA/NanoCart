using NanoCart.Carts.Requests;
using NanoCart.Carts.Responses;

namespace NanoCart.Carts.Interfaces;

public interface ICartService
{
   Task<CartViewResponse> GetCart(CartViewRequest request); 
}