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

    public async Task AddItemToCart(AddItemRequest request)
    {
        await _repository.AddItemsToCart(request.CartId, request.ProductId);
    }
    
    public async Task RemoveItemFromCart(RemoveItemRequest request)
    {
        await _repository.AddItemsToCart(request.CartId, request.ProductId);
    }

    public async Task FlushCart(FlushCartRequest request)
    {
        await _repository.FlushCart(request.CartId);
    }

    public async Task RefreshCart(long cartId)
    {
        await _repository.RefreshCart(cartId);
    }
    
}