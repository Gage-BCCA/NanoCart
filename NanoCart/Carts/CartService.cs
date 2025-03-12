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
    
    public async Task<ApiResponse> GetCart(long id)
    {
        Cart cart = await _repository.GetCart(id);
        return new ApiResponse(new CartDTO(cart));
    }

    public async Task<ApiResponse> CreateCart()
    {
        Cart newCart = await _repository.CreateCart();
        return new ApiResponse(new CartDTO(newCart));
    }
    
}