using NanoCart.Carts.Requests;
using NanoCart.Carts.Responses;

namespace NanoCart.Carts.Interfaces;

public interface ICartService
{
   Task<ApiResponse> GetCart(long id);
   Task<ApiResponse> CreateCart();
}