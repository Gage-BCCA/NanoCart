using NanoCart.Carts.DTOs;
using NanoCart.Carts.Interfaces;
using NanoCart.Carts.Requests;
using NanoCart.Carts.Responses;
using NanoCart.Entities;

namespace NanoCart.Carts;

public class CartService : ICartService
{

    private readonly ICartRepository _repository;
    
    public CartService(ICartRepository repository)
    {
        this._repository = repository;
    }
    
    public async Task<CartViewResponse> GetCart(CartViewRequest request)
    {
        Cart cart = await _repository.GetCart(request);
        return new CartViewResponse(ConstrucutCartDTOFromCart(cart));
    }

    private CartDTO ConstrucutCartDTOFromCart(Cart cart)
    {
        return new CartDTO(cart);
    }
}