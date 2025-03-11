using Microsoft.AspNetCore.Mvc;
using NanoCart.Carts.Interfaces;
using NanoCart.Carts.Requests;
using NanoCart.Carts.Responses;

namespace NanoCart.Carts;

[ApiController]
[Route("[controller]")]
public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("/fetch")]
    public async Task<IActionResult> Get(CartViewRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        CartViewResponse cart = await _cartService.GetCart(request);
        return Ok(cart);
    }

    [HttpPost("/create")]
    public async Task<IActionResult> Create(CartViewRequest request)
    {
        return Ok();
    }

    [HttpPatch("/add")]
    public async Task<IActionResult> Push(CartViewRequest request)
    {
        return Ok();
    }

    [HttpPatch("/remove")]
    public async Task<IActionResult> Remove(CartViewRequest request)
    {
        return Ok();
    }

    [HttpDelete("/flush")]
    public async Task<IActionResult> Flush(CartViewRequest request)
    {
        return Ok();
    }

    [HttpPut("/replace")]
    public async Task<IActionResult> Replace(CartViewRequest request)
    {
        return Ok();
    }
    
}