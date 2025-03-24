using NanoCart.Carts.Requests;
using NanoCart.Carts.Responses;

namespace NanoCart.Carts.Interfaces;

public interface ICartService
{
   Task<ApiResponse> GetCart(long id);
   
   Task<ApiResponse> CreateCart();
   
   Task AddItemToCart(AddItemRequest request);
   
   Task RemoveItemFromCart(RemoveItemRequest request);

   Task FlushCart(FlushCartRequest request);

   Task RefreshCart(long cartId);
}