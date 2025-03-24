using Microsoft.AspNetCore.Mvc;
using NanoCart.Carts.Interfaces;
using NanoCart.Carts.Requests;
using NanoCart.Carts.Responses;

namespace NanoCart.Carts;

[ApiController]
[Route("/cart")]
public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("/fetch")]
    public async Task<IActionResult> Fetch([FromQuery(Name = "id")] long id)
    {
        ApiResponse cart = await _cartService.GetCart(id);
        return Ok(cart);
    }

    [HttpGet("/create")]
    public async Task<IActionResult> Create()
    {
        return Ok(await _cartService.CreateCart());
    }

    [HttpPatch("/add")]
    public async Task<IActionResult> Push([FromBody] AddItemRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _cartService.AddItemToCart(request);
        return Ok();
    }

    [HttpPatch("/remove")]
    public async Task<IActionResult> Remove([FromBody] RemoveItemRequest request)
    {
        await _cartService.RemoveItemFromCart(request);
        return Ok();
    }

    [HttpDelete("/flush")]
    public async Task<IActionResult> Flush([FromBody] FlushCartRequest request)
    {
        await _cartService.FlushCart(request);
        return Ok();
    }

    [HttpGet("/refresh")]
    public async Task<IActionResult> RefreshExpiryDate([FromQuery(Name = "id")] long cartId)
    {
        await _cartService.RefreshCart(cartId);
        return Ok();
    }
    
}